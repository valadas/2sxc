﻿//using System.IO;
//using Microsoft.AspNetCore.Http;
//using ToSic.Eav;
//using ToSic.Eav.Documentation;
//using ToSic.Eav.Run;
//using ToSic.Sxc.Oqt.Shared;
//using ToSic.Sxc.Oqt.Shared.Dev;

//// #todo: not really multi-tenant, incl. url 

//namespace ToSic.Sxc.Oqt.Server.Wip
//{
//    /// <summary>
//    /// This is a Mvc implementation of a Tenant-object. 
//    /// </summary>
//    [InternalApi_DoNotUse_MayChangeWithoutNotice("this is just fyi")]
//    public class WipTenant : Tenant<int>
//    {
//        private readonly IServerPaths _serverPaths;

//        /// <summary>
//        /// Constructor for DI
//        /// </summary>
//        /// <param name="httpContextAccessor"></param>
//        public WipTenant(IHttpContextAccessor httpContextAccessor, IServerPaths serverPaths) : base(0)
//        {
//            _serverPaths = serverPaths;
//            HttpContext = httpContextAccessor.HttpContext;
//        }

//        /// <summary>
//        /// Constructor for normal initialization
//        /// </summary>
//        /// <param name="httpContext"></param>
//        public WipTenant(HttpContext httpContext) : base(0)
//        {
//            HttpContext = httpContext;
//            _serverPaths = Factory.Resolve<IServerPaths>();

//        }

//        //public WipTenant(HttpContext httpContext, MvcPortalSettings settings) : base(
//        //    settings ?? new MvcPortalSettings())
//        //{
//        //    HttpContext = httpContext;
//        //}

//        protected HttpContext HttpContext { get; }

//        public override ITenant Init(int tenantId)
//        {
//            UnwrappedContents = tenantId;
//            return this;
//        }

//        /// <inheritdoc />
//        public override string DefaultLanguage => WipConstants.DefaultLanguage;

//        /// <inheritdoc />
//        public override int Id => UnwrappedContents;

//        // https://localhost:44361
//        public override string Url => HttpContext?.Request.Host.ToString();

//        /// <inheritdoc />
//        public override string Name => "dummy";

//        [PrivateApi]
//        public override string AppsRootPhysical => AppsRootPartial();

//        private static string AppsRootPartial()
//        {
//            return Path.Combine(OqtConstants.ContentSubfolder, WipConstants.AppRootPublicBase, Settings.AppsRootFolder);
//        }

//        [PrivateApi]
//        public override string AppsRootLink => Path.Combine(string.Format(OqtConstants.AppAssetsLinkRoot, Id.ToString()));

//        public override string AppsRootPhysicalFull => Eav.Factory.Resolve<IServerPaths>().FullAppPath(AppsRootPartial());

//        [PrivateApi]
//        public override bool RefactorUserIsAdmin => false;

//        /// <inheritdoc />
//        public override string ContentPath => WipConstants.ContentRoot;

//        public override int ZoneId => UnwrappedContents;

//    }
//}
