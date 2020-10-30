﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToSic.Sxc.Apps.Assets;
using ToSic.Sxc.Oqt.Shared;
using ToSic.Sxc.WebApi.Assets;

namespace ToSic.Sxc.Oqt.Server.Controllers.Admin
{
    /// <summary>
    /// This one supplies portal-wide (or cross-portal) settings / configuration
    /// </summary>
    [ValidateAntiForgeryToken]
    [Authorize(Roles = Oqtane.Shared.Constants.AdminRole)]
    [Route(WebApiConstants.WebApiStateRoot + "/admin/appfiles/[action]")]
    public class AppFilesController : SxcStatefulControllerBase
    {
        protected override string HistoryLogName => "Api.Assets";

        private AppAssetsBackend Backend() => Eav.Factory.Resolve<AppAssetsBackend>().Init(GetBlock().App, GetContext().User, Log);

        public AppFilesController(StatefulControllerDependencies dependencies) : base(dependencies)
        { }

        [HttpGet]
        public List<string> All(int appId, bool global = false, string path = null, string mask = "*.*", bool withSubfolders = false, bool returnFolders = false)
            => Backend().List(appId, global, path, mask, withSubfolders, returnFolders);

        /// <summary>
        /// Get details and source code
        /// </summary>
        /// <param name="templateId"></param>
        /// <param name="global">this determines, if the app-file store is the global in _default or the local in the current app</param>
        /// <param name="path"></param>
        /// <param name="appId"></param>
        /// <returns></returns>
        [HttpGet]
        public AssetEditInfo Asset(int appId,
            int templateId = 0, string path = null, // identifier is always one of these two
            bool global = false)
            => Backend().Get(templateId, path, global, appId);


        /// <summary>
        /// Create a new file (if it doesn't exist yet) and optionally prefill it with content
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="path"></param>
        /// <param name="content"></param>
        /// <param name="global">this determines, if the app-file store is the global in _default or the local in the current app</param>
        /// <returns></returns>
        [HttpPost]
        public bool Create([FromRoute] int appId, [FromRoute] string path,
            [FromBody] FileContentsDto content, // note: as of 2020-09 the content is never submitted
            bool global = false)
            => Backend().Create(appId, path, content, global);




        /// <summary>
        /// Update an asset with POST
        /// </summary>
        /// <param name="template"></param>
        /// <param name="templateId"></param>
        /// <param name="global">this determines, if the app-file store is the global in _default or the local in the current app</param>
        /// <param name="path"></param>
        /// <param name="appId"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Asset([FromRoute] int appId, [FromBody] AssetEditInfo template,
            [FromRoute] int templateId = 0, [FromRoute] string path = null, // identifier is either template Id or path
                                                                        // todo w/SPM - global never seems to be used - must check why and if we remove or add to UI
            [FromRoute] bool global = false)
            => Backend().Save(template, templateId, global, path, appId);
    }
}