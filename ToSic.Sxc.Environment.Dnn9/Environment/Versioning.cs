﻿using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Tabs;
using System;
using ToSic.Eav.Apps.Enums;
using ToSic.Eav.Apps.Environment;
using ToSic.Eav.Apps.Interfaces;

namespace ToSic.Sxc.Environment.Dnn9.Environment
{
    public class Versioning : IEnvironmentVersioning
    {
        public bool Supported => true;

        public VersioningRequirements Requirements(int moduleId)
        {
            var moduleInfo = ModuleController.Instance.GetModule(moduleId, Null.NullInteger, true);
            var versioningEnabled = TabChangeSettings.Instance.IsChangeControlEnabled(moduleInfo.PortalID, moduleInfo.TabID);
            if (!versioningEnabled)
                return VersioningRequirements.DraftOptional;

            var portalSettings = new PortalSettings(moduleInfo.PortalID);
            if (!portalSettings.UserInfo.IsSuperUser)
                return VersioningRequirements.DraftRequired;

            // Else versioningEnabled && IsSuperUser
            return VersioningRequirements.DraftRecommended;
        }

        public bool IsVersioningEnabled(int moduleId)
        {
            return Requirements(moduleId) != VersioningRequirements.DraftOptional;
        }


        public void DoInsideVersioning(int moduleId, int userId, Action<VersioningActionInfo> action)
        {
            if (IsVersioningEnabled(moduleId))
            {
                var moduleVersionSettings = new ModuleVersionSettingsController(moduleId);
                if (moduleVersionSettings.IsLatestVersionPublished())
                {
                    // If the latest version is published, get an new version number and submit it to DNN
                    TabChangeTracker.Instance.TrackModuleModification
                    (
                        moduleVersionSettings.ModuleInfo, moduleVersionSettings.IncreaseLatestVersion(), userId
                    );
                }
            }

            var versioningActionInfo = new VersioningActionInfo() { };
            action.Invoke(versioningActionInfo);
        }


        public void PublishLatestVersion(int moduleId)
        {
            // TODO2tk: Set all items in content-block from draft to published
            var moduleVersionSettings = new ModuleVersionSettingsController(moduleId);
            moduleVersionSettings.PublishLatestVersion();
        }

        public void DeleteLatestVersion(int moduleId)
        {
            // NOTE2tk: If we want to support that, rollback any item in draft state of the module-content-block
            var moduleVersionSettings = new ModuleVersionSettingsController(moduleId);
            moduleVersionSettings.DeleteLatestVersion();
        }

        public int GetLatestVersion(int moduleId)
        {
            var moduleVersionSettings = new ModuleVersionSettingsController(moduleId);
            return moduleVersionSettings.GetLatestVersion();
        }

        public int GetPublishedVersion(int moduleId)
        {
            var moduleVersionSettings = new ModuleVersionSettingsController(moduleId);
            return moduleVersionSettings.GetPublishedVersion();
        }
    }
}
