﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Security.Permissions;
using ToSic.Eav;
using ToSic.Eav.Apps.Interfaces;
using ToSic.Eav.DataSources;
using ToSic.Eav.Interfaces;
using ToSic.Eav.Security.Permissions;
using ToSic.Eav.ValueProvider;
using ToSic.SexyContent.Adam;
using ToSic.SexyContent.DataSources;
using ToSic.SexyContent.Environment.Dnn7;
using ToSic.SexyContent.Internal;
using ToSic.SexyContent.Razor.Helpers;
using ToSic.SexyContent.WebApi.Dnn;
using Factory = ToSic.Eav.Factory;

namespace ToSic.SexyContent.WebApi
{
	// this is accessible from many non-2sxc modules so no [SupportedModules("2sxc,2sxc-app")]
    [SxcWebApiExceptionHandling]
    public abstract class SxcApiController : DnnApiControllerWithFixes, IAppAndDataHelpers
    {
        #region constructor

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            Log.Rename("2sApiC");
            SxcInstance = Helpers.GetSxcOfApiRequest(Request, true, Log);
            DnnAppAndDataHelpers = new DnnAppAndDataHelpers(SxcInstance, SxcInstance?.InstanceInfo, SxcInstance?.Log ?? Log);
            controllerContext.Request.Properties.Add(Constants.DnnContextKey, Dnn); // must run after creating AppAndDataHelpers
        }
        #endregion

        private DnnAppAndDataHelpers DnnAppAndDataHelpers { get; set; }

	    // Sexy object should not be accessible for other assemblies - just internal use
        internal SxcInstance SxcInstance { get; private set; }

        #region AppAndDataHelpers implementation

        public DnnHelper Dnn => DnnAppAndDataHelpers.Dnn;

	    public SxcHelper Sxc => DnnAppAndDataHelpers.Sxc;

        /// <inheritdoc />
        public App App
        {
            get
            {
                // try already-retrieved
                if (_app != null)
                    return _app;

                // try "normal" case with instance context
                if (SxcInstance != null)
                    return _app = DnnAppAndDataHelpers.App;

                var routeAppPath = Request.GetRouteData().Values["apppath"]?.ToString();
                var appId = GetCurrentAppIdFromPath(routeAppPath);
                // Look up if page publishing is enabled - if module context is not availabe, always false
                var publish = Factory.Resolve<IEnvironmentFactory>().PagePublisher(Log);
                var publishingEnabled = Dnn.Module != null && publish.IsEnabled(Dnn.Module.ModuleID);
                return _app = (App) Environment.Dnn7.Factory.App(appId, publishingEnabled);
            }
        }
        private App _app;

        /// <inheritdoc />
        public ViewDataSource Data => DnnAppAndDataHelpers.Data;

	    /// <inheritdoc />
        public dynamic AsDynamic(IEntity entity) => DnnAppAndDataHelpers.AsDynamic(entity);


        /// <inheritdoc />
        public dynamic AsDynamic(dynamic dynamicEntity) =>  DnnAppAndDataHelpers.AsDynamic(dynamicEntity);

        /// <inheritdoc />
        public dynamic AsDynamic(KeyValuePair<int, IEntity> entityKeyValuePair) =>  DnnAppAndDataHelpers.AsDynamic(entityKeyValuePair.Value);

        /// <inheritdoc />
        public IEnumerable<dynamic> AsDynamic(IDataStream stream) =>  DnnAppAndDataHelpers.AsDynamic(stream.List);

        /// <inheritdoc />
        public IEntity AsEntity(dynamic dynamicEntity) =>  DnnAppAndDataHelpers.AsEntity(dynamicEntity);

        /// <inheritdoc />
        public IEnumerable<dynamic> AsDynamic(IEnumerable<IEntity> entities) =>  DnnAppAndDataHelpers.AsDynamic(entities);

	    public IDataSource CreateSource(string typeName = "", IDataSource inSource = null,
	        IValueCollectionProvider configurationProvider = null)
	        => DnnAppAndDataHelpers.CreateSource(typeName, inSource, configurationProvider);

        public T CreateSource<T>(IDataSource inSource = null, IValueCollectionProvider configurationProvider = null)
            =>  DnnAppAndDataHelpers.CreateSource<T>(inSource, configurationProvider);

	    /// <inheritdoc />
	    public T CreateSource<T>(IDataStream inStream) => DnnAppAndDataHelpers.CreateSource<T>(inStream);

        /// <summary>
        /// content item of the current view
        /// </summary>
        public dynamic Content => DnnAppAndDataHelpers.Content;

        /// <summary>
        /// presentation item of the content-item. 
        /// </summary>
        [Obsolete("please use Content.Presentation instead")]
        public dynamic Presentation => DnnAppAndDataHelpers.Content?.Presentation;

	    public dynamic ListContent => DnnAppAndDataHelpers.ListContent;

        /// <summary>
        /// presentation item of the content-item. 
        /// </summary>
        [Obsolete("please use ListContent.Presentation instead")]
	    public dynamic ListPresentation => DnnAppAndDataHelpers.ListContent?.Presentation;

        [Obsolete("This is an old way used to loop things - shouldn't be used any more - will be removed in 2sxc v10")]
        public List<Element> List => DnnAppAndDataHelpers.List;

	    #endregion


        #region Adam

	    /// <summary>
	    /// Provides an Adam instance for this item and field
	    /// </summary>
	    /// <param name="entity">The entity, often Content or similar</param>
	    /// <param name="fieldName">The field name, like "Gallery" or "Pics"</param>
	    /// <returns>An Adam object for navigating the assets</returns>
	    public AdamNavigator AsAdam(DynamicEntity entity, string fieldName)
	        => DnnAppAndDataHelpers.AsAdam(AsEntity(entity), fieldName);

        /// <summary>
        /// Provides an Adam instance for this item and field
        /// </summary>
        /// <param name="entity">The entity, often Content or similar</param>
        /// <param name="fieldName">The field name, like "Gallery" or "Pics"</param>
        /// <returns>An Adam object for navigating the assets</returns>
        public AdamNavigator AsAdam(IEntity entity, string fieldName) => DnnAppAndDataHelpers.AsAdam(entity, fieldName);
        #endregion

        #region App-Helpers for anonyous access APIs

        internal int GetCurrentAppIdFromPath(string appPath)
        {
            // check zone
            var zid = Env.ZoneMapper.GetZoneId(PortalSettings.PortalId);

            // get app from appname
            var aid = AppHelpers.GetAppIdFromGuidName(zid, appPath, true);
            Log.Add($"find app by path:{appPath}, found a:{aid}");
            return aid;
        }
        #endregion

        #region Security Checks 

        /// <summary>
        /// Check if a user may do something - and throw an error if the permission is not given
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="contentType"></param>
        /// <param name="grant"></param>
        /// <param name="specificItem"></param>
        /// <param name="useContext"></param>
        internal void PerformSecurityCheck(int appId, string contentType, PermissionGrant grant,
            ModuleInfo module, IEntity specificItem = null)
        {
            PerformSecurityCheck(appId, contentType, new List<PermissionGrant> { grant },
                specificItem, module);
        }

        /// <summary>
        /// Check if a user may do something - and throw an error if the permission is not given
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="contentType"></param>
        /// <param name="grant"></param>
        /// <param name="specificItem"></param>
        /// <param name="useContext"></param>
        internal void PerformSecurityCheck(int appId, string contentType, List<PermissionGrant> grant, IEntity specificItem, ModuleInfo module)
        {
            Log.Add($"security check for type:{contentType}, grant:{grant}, useContext:{module != null}, app:{appId}, item:{specificItem?.EntityId}");
            // make sure we have the right appId, zoneId and module-context
            var contextMod = ResolveModuleAndIDsOrThrow(module, App, appId, out var zoneId, out appId);

            // Ensure that we can find this content-type 
            var cache = DataSource.GetCache(zoneId, appId);
            var ct = cache.GetContentType(contentType);
            if (ct == null)
                throw Errors.Http.WithLink(HttpStatusCode.NotFound, "Could not find Content Type '" + contentType + "'.",
                    "content-types");

            // give ok for all host-users
            if (UserInfo.IsSuperUser)
                return;

            // Check if the content-type has a GUID as name - only these can have permission assignments
            // only check permissions on type if the type has a GUID as static-id
            var staticNameIsGuid = Guid.TryParse(ct.StaticName, out var _);
            // Check permissions in 2sxc - or check if the user has admin-right (in which case he's always granted access for these types of content)
            if (staticNameIsGuid 
                && new DnnPermissionController(ct, specificItem, Log, new DnnInstanceInfo(contextMod))
                    .UserMay(grant))
                return;

            // if initial test couldn't be done (non-guid) or failed, test for admin-specifically
            // note that auto-check not possible when not using context
            if (contextMod != null && ModulePermissionController.CanAdminModule(contextMod))
                return;

            throw Errors.Http.InformativeErrorForTypeAccessDenied(contentType, grant, staticNameIsGuid);
        }



        private static ModuleInfo ResolveModuleAndIDsOrThrow(/*bool useContext,*/ ModuleInfo module, App app, int? appIdOpt, out int? zoneId, out int appId)
        {
            var useContext = module != null;
            var contextMod = useContext ? module : null;
            zoneId = useContext ? app?.ZoneId : null;
            if (useContext) appIdOpt = app?.AppId ?? appIdOpt;

            if (!appIdOpt.HasValue)
                throw new Exception("app id doesn't have value, and apparently didn't get it from context either");

            appId = appIdOpt.Value;
            return contextMod;
        }



        #endregion

    }
}
