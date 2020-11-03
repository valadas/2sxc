﻿using System;
using System.Collections.Generic;
using System.Linq;
using ToSic.Eav.Apps;
using ToSic.Eav.Data;
using ToSic.Eav.Security;
using ToSic.Eav.Security.Permissions;
using ToSic.Eav.WebApi.Formats;

namespace ToSic.Sxc.WebApi.Save
{
    public class SxcPagePublishing: SaveHelperBase<SxcPagePublishing>
    {
        #region Constructor / DI
        private readonly ContentGroupList _contentGroupList;
        public SxcPagePublishing(ContentGroupList contentGroupList) : base("Sxc.PgPubl")
        {
            _contentGroupList = contentGroupList;
        }

        #endregion

        internal Dictionary<Guid, int> SaveInPagePublishing(
            int appId,
            List<BundleWithHeader<IEntity>> items,
            bool partOfPage,
            Func<bool, Dictionary<Guid, int>> internalSaveMethod,
            IMultiPermissionCheck permCheck
        )
        {
            var allowWriteLive = permCheck.UserMayOnAll(GrantSets.WritePublished);
            var forceDraft = !allowWriteLive;
            Log.Add($"allowWrite: {allowWriteLive} forceDraft: {forceDraft}");

            // list of saved IDs
            Dictionary<Guid, int> postSaveIds = null;

            // The internal call which will be used further down
            var groupList = _contentGroupList.Init(Block, Log, new AppIdentity(Eav.Apps.App.AutoLookupZone, appId));
            Dictionary<Guid, int> SaveAndSaveGroupsInnerCall(Func<bool, Dictionary<Guid, int>> call,
                bool forceSaveAsDraft)
            {
                var ids = call.Invoke(forceSaveAsDraft);
                // now assign all content-groups as needed
                groupList.IfChangesAffectListUpdateIt(items, ids);
                return ids;
            }


            // use dnn versioning if partOfPage
            if (partOfPage)
            {
                Log.Add("partOfPage - save with publishing");
                var versioning = Eav.Factory.Resolve<IPagePublishing>().Init(Log);
                //var dnnContext = new DnnDynamicCode().Init(Block, Log);
                //var instanceId = Block.Context.Container.Id;
                //var userId = Block.Context.User.Guid;
                versioning.DoInsidePublishing(Block.Context,
                    args => postSaveIds = SaveAndSaveGroupsInnerCall(internalSaveMethod, forceDraft));
            }
            else
            {
                Log.Add("partOfPage false, save without publishing");
                postSaveIds = SaveAndSaveGroupsInnerCall(internalSaveMethod, forceDraft);
            }

            Log.Add(() => $"post save IDs: {string.Join(",", postSaveIds.Select(psi => psi.Key + "(" + psi.Value + ")"))}");
            return postSaveIds;
        }

    }
}
