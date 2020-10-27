﻿using System;
using ToSic.Eav.Data;
using ToSic.Eav.Documentation;
using ToSic.Eav.Logging;
using ToSic.Eav.Run;
using ToSic.Sxc.Blocks;

namespace ToSic.Sxc.Run
{
    [PrivateApi]
    public interface IPlatformModuleUpdater: IHasLog<IPlatformModuleUpdater>
    {
        /// <summary>
        /// Set the App of a Container / Module
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="appId"></param>
        /// <param name="parentLog"></param>
        void SetAppId(IContainer instance, int? appId, ILog parentLog);

        /// <summary>
        /// Set the preview view of the Container / Module
        /// </summary>
        /// <param name="instanceId"></param>
        /// <param name="previewView"></param>
        void SetPreview(int instanceId, Guid previewView);

        /// <summary>
        /// Persist the Content-Group once created. 
        /// </summary>
        /// <param name="instanceId"></param>
        /// <param name="blockExists"></param>
        /// <param name="guid"></param>
        void SetContentGroup(int instanceId, bool blockExists, Guid guid);

        /// <summary>
        /// Update the title in the platform
        /// </summary>
        /// <param name="block"></param>
        /// <param name="titleItem"></param>
        void UpdateTitle(IBlock block, IEntity titleItem);
    }
}