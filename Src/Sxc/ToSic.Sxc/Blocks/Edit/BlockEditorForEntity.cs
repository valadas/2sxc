﻿using System;
using System.Collections.Generic;
using ToSic.Eav.Apps;
using ToSic.Eav.Data;
using ToSic.Sxc.Apps;
using IApp = ToSic.Eav.Apps.IApp;

namespace ToSic.Sxc.Blocks.Edit
{
    internal class BlockEditorForEntity : BlockEditorBase
    {
        public BlockEditorForEntity(IServiceProvider serviceProvider, Lazy<CmsRuntime> lazyCmsRuntime, Lazy<CmsManager> cmsManagerLazy) : base(serviceProvider, lazyCmsRuntime, cmsManagerLazy)
        {
        }

        #region methods which the entity-implementation must customize 

        protected override void SavePreviewTemplateId(Guid templateGuid)
            => Update(new Dictionary<string, object>
            {
                {ViewParts.TemplateContentType, templateGuid.ToString()}
            });


        internal override void SetAppId(int? appId)
        {
            // 2rm 2016-04-05 added resolver for app guid here (discuss w/ 2dm, I'm not sure why the id was saved before)
            var appName = "";
            if (appId.HasValue)
            {
                var cache = State.Cache;
                var zoneAppId = cache.GetIdentity(null, appId);
                appName = cache.Zones[zoneAppId.ZoneId].Apps[appId.Value];
            }
            UpdateValue(BlockFromEntity.CbPropertyApp, appName);
        }

        internal override void EnsureLinkToContentGroup(Guid cgGuid)
            => UpdateValue(BlockFromEntity.CbPropertyContentGroup, cgGuid.ToString()); // must pre-convert to string, as it's not a reference to an entity in the same app


        internal override void UpdateTitle(IEntity titleItem)
        {
            if (titleItem?.GetBestTitle() == null) return;
            UpdateValue(BlockFromEntity.CbPropertyTitle, titleItem.GetBestTitle());
        }

        #endregion

        #region private helpers

        private void UpdateValue(string key, object value) 
            => Update(new Dictionary<string, object> { { key, value } });

        private void Update(Dictionary<string, object> newValues)
        {
            var app = ((BlockBase)Block).Parent.App;
            GetAppManagerOrReuse(app)
                .Entities.UpdateParts(Math.Abs(Block.ContentBlockId), newValues);
        }


        #endregion

    }

}
