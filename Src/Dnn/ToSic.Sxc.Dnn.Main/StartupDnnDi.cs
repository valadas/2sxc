﻿using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ToSic.Eav.Apps.Environment;
using ToSic.Eav.Apps.ImportExport;
using ToSic.Eav.Apps.Run;
using ToSic.Eav.Apps.Security;
using ToSic.Eav.Caching;
using ToSic.Eav.Context;
using ToSic.Eav.Data;
using ToSic.Eav.LookUp;
using ToSic.Eav.Persistence.Interfaces;
using ToSic.Eav.Repositories;
using ToSic.Eav.Run;
using ToSic.Sxc.Adam;
using ToSic.Sxc.Cms.Publishing;
using ToSic.Sxc.Code;
using ToSic.Sxc.Context;
using ToSic.Sxc.Dnn;
using ToSic.Sxc.Dnn.Adam;
using ToSic.Sxc.Dnn.Code;
using ToSic.Sxc.Dnn.ImportExport;
using ToSic.Sxc.Dnn.Install;
using ToSic.Sxc.Dnn.LookUp;
using ToSic.Sxc.Dnn.Run;
using ToSic.Sxc.Dnn.Web;
using ToSic.Sxc.Dnn.WebApi;
using ToSic.Sxc.Dnn.WebApi.Context;
using ToSic.Sxc.Engines;
using ToSic.Sxc.Run;
using ToSic.Sxc.Web;
using ToSic.Sxc.WebApi.Adam;
using ToSic.Sxc.WebApi.Context;


namespace ToSic.SexyContent
{

    internal static class StartupDnnDi
    {
        public static IServiceCollection AddDnn(this IServiceCollection services, string appsCacheOverride)
        {
            // Core Runtime Context Objects
            services.TryAddScoped<IUser, DnnUser>();
            services.TryAddScoped<ISite, DnnSite>();
            services.TryAddScoped<IZoneCultureResolver, DnnSite>();
            services.TryAddTransient<IModule, DnnModule>();
            services.TryAddTransient<DnnModule>();

            // 
            services.TryAddTransient<IValueConverter, DnnValueConverter>();

            services.TryAddTransient<XmlExporter, DnnXmlExporter>();
            services.TryAddTransient<IImportExportEnvironment, DnnImportExportEnvironment>();

            // new for .net standard
            services.TryAddTransient<IAppFileSystemLoader, DnnAppFileSystemLoader>();
            services.TryAddTransient<IAppRepositoryLoader, DnnAppFileSystemLoader>();
            services.TryAddTransient<IZoneMapper, DnnZoneMapper>();

            services.TryAddTransient<IClientDependencyOptimizer, DnnClientDependencyOptimizer>();
            services.TryAddTransient<AppPermissionCheck, DnnPermissionCheck>();
            services.TryAddTransient<DnnPermissionCheck>();

            services.TryAddTransient<DynamicCodeRoot, DnnDynamicCodeRoot>();
            services.TryAddTransient<DnnDynamicCodeRoot>();
            services.TryAddTransient<IPlatformModuleUpdater, DnnModuleUpdater>();
            services.TryAddTransient<IEnvironmentInstaller, DnnInstallationController>();

            // ADAM 
            services.TryAddTransient<IAdamFileSystem<int, int>, DnnAdamFileSystem>();
            services.TryAddTransient<AdamManager, AdamManager<int, int>>();

            // Settings
            services.TryAddTransient<IUiContextBuilder, DnnUiContextBuilder>();

            // new #2160
            services.TryAddTransient<AdamSecurityChecksBase, DnnAdamSecurityChecks>();

            services.TryAddTransient<ILookUpEngineResolver, DnnLookUpEngineResolver>();
            services.TryAddTransient<DnnLookUpEngineResolver>();
            services.TryAddTransient<IFingerprint, DnnFingerprint>();

            // new in 11.07 - exception logger
            services.TryAddTransient<IEnvironmentLogger, DnnEnvironmentLogger>();

            // new in 11.08 - provide Razor Engine and platform
            services.TryAddTransient<IEngineFinder, DnnEngineFinder>();
            services.TryAddSingleton<IPlatform, DnnPlatformContext>();

            // add page publishing
            services.TryAddTransient<IPagePublishing, Sxc.Dnn.Cms.DnnPagePublishing>();
            services.TryAddTransient<IPagePublishingResolver, Sxc.Dnn.Cms.DnnPagePublishingResolver>();

            if (appsCacheOverride != null)
            {
                try
                {
                    var appsCacheType = Type.GetType(appsCacheOverride);
                    services.TryAddSingleton(typeof(IAppsCache), appsCacheType);
                }
                catch
                {
                    /* ignore */
                }
            }

            return services;
        }
    }
}