﻿using System;
using System.IO;
using ToSic.Eav.Security.Permissions;
using ToSic.Eav.WebApi.Errors;
using ToSic.Sxc.Adam;
using ToSic.Sxc.Context;

namespace ToSic.Sxc.WebApi.Adam
{
    public partial class AdamTransUpload<TFolderId, TFileId>: AdamTransactionBase<AdamTransUpload<TFolderId, TFileId>, TFolderId, TFileId>
    {
        public AdamTransUpload(Lazy<AdamContext<TFolderId, TFileId>> adamState, IContextResolver ctxResolver) : base(adamState, ctxResolver, "Adm.TrnUpl") { }

        public UploadResultDto UploadOne(Stream stream, string subFolder, string fileName)
        {
            var file = UploadOne(stream, fileName, subFolder, false);

            return new UploadResultDto
            {
                Success = true,
                Error = "",
                Name = file.Name,
                Id = file.Id,
                Path = file.Url,
                Type = Classification.TypeName(file.Extension)
            };
        }

        public IFile UploadOne(Stream stream, string originalFileName, string subFolder, bool skipFieldAndContentTypePermissionCheck)
        {
            Log.Add($"upload one subfold:{subFolder}, file: {originalFileName}");

            // make sure the file name we'll use doesn't contain injected path-traversal
            originalFileName = Path.GetFileName(originalFileName);

            HttpExceptionAbstraction exp;
            if (!skipFieldAndContentTypePermissionCheck)
            {
                if (!AdamContext.Security.UserIsPermittedOnField(GrantSets.WriteSomething, out exp))
                    throw exp;

                // check that if the user should only see drafts, he doesn't see items of published data
                if (!AdamContext.Security.UserIsNotRestrictedOrItemIsDraft(AdamContext.ItemGuid, out var permissionException))
                    throw permissionException;
            }

            var folder = AdamContext.AdamRoot.Folder();

            if (!string.IsNullOrEmpty(subFolder))
                folder = AdamContext.AdamRoot.Folder(subFolder, false);

            // start with a security check...
            var fs = AdamContext.AdamManager.AdamFs;
            var parentFolder = fs.GetFolder(folder.SysId);

            // validate that dnn user have write permissions for folder in case dnn file system is used (usePortalRoot)
            if (AdamContext.UseSiteRoot && !AdamContext.Security.CanEditFolder(parentFolder))
                throw HttpException.PermissionDenied("can't upload - permission denied");

            // we only upload into valid adam if that's the scenario
            if (!AdamContext.Security.SuperUserOrAccessingItemFolder(parentFolder.Path, out exp))
                throw exp;

            #region check content-type extensions...

            // Check file size and extension
            var fileName = string.Copy(originalFileName);
            if (!AdamContext.Security.ExtensionIsOk(fileName, out var exceptionAbstraction))
                throw exceptionAbstraction;

            // check metadata of the FieldDef to see if still allowed extension
            // note 2018-04-20 2dm: can't do this for wysiwyg, as it doesn't have a setting for allowed file-uploads
            var additionalFilter = AdamContext.Attribute.Metadata.GetBestValue<string>("FileFilter");
            if (!string.IsNullOrWhiteSpace(additionalFilter)
                && !CustomFileFilterOk(additionalFilter, fileName))
                throw HttpException.NotAllowedFileType(fileName, "field has custom file-filter, which doesn't match");

            #endregion

            var maxSizeKb = fs.MaxUploadKb();
            if (stream.Length > 1024 * maxSizeKb)
                throw new Exception($"file too large - more than {maxSizeKb}Kb");

            // remove forbidden / troubling file name characters
            fileName = fileName
                .Replace("+", "plus")
                .Replace("%", "per")
                .Replace("#", "hash");

            if (fileName != originalFileName)
                Log.Add($"cleaned file name from'{originalFileName}' to '{fileName}'");

            var eavFile = fs.Add(parentFolder, stream, fileName, true);

            return eavFile;
        }
    }
}
