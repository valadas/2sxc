﻿using System.Web.Http;
using DotNetNuke.Security;
using DotNetNuke.Web.Api;
using ToSic.SexyContent.WebApi;
using ToSic.Sxc.WebApi.InPage;

namespace ToSic.Sxc.Dnn.WebApi.Cms
{
    [ValidateAntiForgeryToken]
    // cannot use this, as most requests now come from a lone page [SupportedModules("2sxc,2sxc-app")]
    public class ItemController : SxcApiController
    {
        protected override string HistoryLogName => "Api.Item";

        /// <summary>
        /// Used to be GET Module/Publish
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [DnnModuleAuthorize(AccessLevel = SecurityAccessLevel.View)]
        public bool Publish(int id)
            => new AppViewPickerBackend().Init(GetContext(), GetBlock(), Log)
                .Publish(id);
    }
}