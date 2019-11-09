﻿using System;
using System.Threading;
using System.Web;
using ToSic.Eav.Apps;
using ToSic.Eav.Logging;
using ToSic.Sxc.Apps;
using IApp = ToSic.Sxc.IApp;

namespace ToSic.SexyContent
{
    /// <summary>
    /// The app class gives access to the App-object - for the data and things like the App:Path placeholder in a template
    /// </summary>
    public class App : Eav.Apps.App, IApp
    {
        #region Dynamic Properties: Configuration, Settings, Resources
        public dynamic Configuration
        {
            get
            {
                if(!_configLoaded && AppMetadata != null)
                    _config = new DynamicEntity(AppMetadata, new[] {Thread.CurrentThread.CurrentCulture.Name}, null);
                _configLoaded = true;
                return _config;
            }
        }
        private bool _configLoaded;
        private dynamic _config;

        public dynamic Settings
        {
            get
            {
                if(!_settingsLoaded && AppSettings != null)
                    _settings = new DynamicEntity(AppSettings, new[] {Thread.CurrentThread.CurrentCulture.Name}, null);
                _settingsLoaded = true;
                return _settings;
            }
        }
        private bool _settingsLoaded;
        private dynamic _settings;

        public dynamic Resources
        {
            get
            {
                if(!_resLoaded && AppResources!= null)
                    _res = new DynamicEntity(AppResources, new[] {Thread.CurrentThread.CurrentCulture.Name}, null);
                _resLoaded = true;
                return _res;
            }
        }
        private bool _resLoaded;
        private dynamic _res;

        #endregion

        #region App-Level TemplateManager, ContentGroupManager, EavContext --> must move to EAV some time
        private TemplatesRuntime _templateManager;
        public TemplatesRuntime TemplateManager => _templateManager 
            ?? (_templateManager = new TemplatesRuntime(ZoneId, AppId, Log));

        private ContentGroupManager _contentGroupManager;
        public ContentGroupManager ContentGroupManager => _contentGroupManager 
            ?? (_contentGroupManager = new ContentGroupManager(ZoneId, AppId, ShowDraftsInData, VersioningEnabled, Log));

        #endregion

        /// <summary>
        /// Special constructor to clarify it's a reduced app without data
        /// Background: data operations need to know more like showDraft etc.
        /// which often isn't needed for simpler operations
        /// </summary>
        public static App LightWithoutData(ITenant tenant, int appId, ILog parentLog)
            => new App(tenant, AutoLookupZone, appId, null, true, parentLog);

        public static App LightWithoutData(ITenant tenant, int zoneId, int appId, ILog parentLog)
            => new App(tenant, zoneId, appId, null, true, parentLog);

        public static App LightWithoutData(ITenant tenant, int zoneId, int appId, bool allowSideEffects, ILog parentLog)
            => new App(tenant, zoneId, appId, null, allowSideEffects, parentLog);

        /// <summary>
        /// New constructor which auto-configures the app-data
        /// </summary>
        public App(ITenant tenant, 
            int zoneId, 
            int appId, 
            Func<Eav.Apps.App, IAppDataConfiguration> buildConfig, 
            bool allowSideEffects, 
            ILog parentLog = null)
            : base(tenant, zoneId, appId, allowSideEffects, buildConfig, parentLog) { }

        #region Paths
        public string Path => VirtualPathUtility.ToAbsolute(GetRootPath());
        public string Thumbnail => System.IO.File.Exists(PhysicalPath + IconFile) ? Path + IconFile : null;

        #endregion

        
    }
}