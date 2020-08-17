﻿using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Web.Api;
using ToSic.Eav;
using ToSic.Eav.Apps.ImportExport;
using ToSic.Eav.Persistence.Interfaces;
using ToSic.Sxc.Dnn.Run;
using ToSic.Sxc.Dnn.WebApi;

namespace ToSic.Sxc.WebApi.Cms
{
    [SupportedModules("2sxc,2sxc-app")]
    [SxcWebApiExceptionHandling]
    [ValidateAntiForgeryToken]
    public class InstallerController : DnnApiControllerWithFixes
    {
        protected override string HistoryLogName => "Api.2sInst";

        [HttpGet]
        [DnnModuleAuthorize(AccessLevel = SecurityAccessLevel.Admin)]
        //[ValidateAntiForgeryToken] - never activate this, because this is a GET and can't include the RVT
        public HttpResponseMessage InstallPackage(string packageUrl)
        {
            Log.Add("install package:" + packageUrl);
            var container = new DnnContainer(ActiveModule, Log);
            var block = container.BlockIdentifier;
            bool success;

            var helper = Factory.Resolve<IImportExportEnvironment>().Init(Log);
            try
            {
                // Increase script timeout to prevent timeouts
                HttpContext.Current.Server.ScriptTimeout = 300;

                success = new ZipFromUrlImport(helper, block.ZoneId, block.AppId, PortalSettings.UserInfo.IsSuperUser, Log)
                    .ImportUrl(packageUrl, ActiveModule.DesktopModule.ModuleName == "2sxc-app");
            }
            catch (Exception ex)
            {
                Exceptions.LogException(ex);
                throw new Exception("An error occurred while installing the app: " + ex.Message, ex);
            }
            
            Log.Add("install completed with success:" + success);
            return Request.CreateResponse(success ? HttpStatusCode.OK : HttpStatusCode.InternalServerError, new { success, helper.Messages });
        }

    }
}