﻿using System;
using System.Linq;
using ToSic.Eav.Apps;
using ToSic.Eav.Logging;
using ToSic.Eav.Run;
using ToSic.Sxc.Blocks;
using ToSic.Sxc.Web;

namespace ToSic.Sxc.WebApi
{
    /// <summary>
    /// This helps API calls to get the app which is currently needed
    /// It does not perform security checks ATM and maybe never will
    /// </summary>
    internal class AppFinder: HasLog
    {
        private IZoneMapper _zoneMapper;
        private int _tenantId;

        private readonly IHttp _http;

        public AppFinder(IHttp http): base("Api.FindAp")
        {
            _http = http;
        }

        public AppFinder Init(int tenantId, IZoneMapper zoneMapper, ILog parentLog) 
        {
            Log.LinkTo(parentLog);
            _tenantId = tenantId;
            _zoneMapper = zoneMapper;
            return this;
        }

        /// <summary>
        /// find the AppIdentity of an app which is referenced by a path
        /// </summary>
        /// <param name="appPath"></param>
        /// <returns></returns>
        internal IAppIdentity GetCurrentAppIdFromPath(string appPath)
        {
            var wrapLog = Log.Call(appPath);
            var zid = _zoneMapper.GetZoneId(_tenantId);

            // get app from AppName
            var aid = new ZoneRuntime(zid, Log).FindAppId(appPath, true);
            wrapLog($"found app:{aid}");
            return new AppIdentity(zid, aid);
        }


        /// <summary>
        /// Retrieve the appId - either based on the parameter, or if missing, use context
        /// Note that this will fail, if both appPath and context are missing
        /// </summary>
        /// <returns></returns>
        internal IAppIdentity GetAppIdFromPathOrContext(string appPath, IBlockBuilder blockBuilder)
        {
            var wrapLog = Log.Call($"{appPath}, ...", message: "detect app from query string parameters");

            // try to override detection based on additional zone/app-id in urls
            var appId = GetAppIdentityFromUrlQueryAppZone();

            if (appId == null)
            {
                Log.Add($"auto detect app and init eav - path:{appPath}, context null: {blockBuilder == null}");
                appId = appPath == null || appPath == "auto"
                    ? new AppIdentity(
                        blockBuilder?.Block?.ZoneId ??
                        throw new ArgumentException("try to get app-id from context, but none found"),
                        blockBuilder.Block.AppId)
                    : GetCurrentAppIdFromPath(appPath);
            }

            wrapLog(appId.LogState());

            return appId;
        }

        /// <summary>
        /// This will detect the app based on appid/zoneid params in the URL
        /// It's a temporary solution, because normally we want the control flow to be more obvious
        /// </summary>
        /// <returns></returns>
        private IAppIdentity GetAppIdentityFromUrlQueryAppZone()
        {
            var allUrlKeyValues = _http.QueryStringKeyValuePairs();
            var ok1 = int.TryParse(allUrlKeyValues.FirstOrDefault(x => x.Key == Route.ZoneIdKey).Value, out var zoneIdFromQueryString);
            var ok2 = int.TryParse(allUrlKeyValues.FirstOrDefault(x => x.Key == Route.AppIdKey).Value, out var appIdFromQueryString);
            if (ok1 && ok2)
            {
                Log.Add($"Params in URL detected - will use appId:{appIdFromQueryString}, zoneId:{zoneIdFromQueryString}");
                return new AppIdentity(zoneIdFromQueryString, appIdFromQueryString);
            }
            return null;
        }

    }
}
