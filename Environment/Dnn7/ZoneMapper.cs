﻿using System;
using System.Collections.Generic;
using System.Linq;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Services.Localization;
using ToSic.Eav.Apps;
using ToSic.SexyContent.Environment.Base;
using ToSic.SexyContent.Environment.Interfaces;

namespace ToSic.SexyContent.Environment.Dnn7
{
    public class ZoneMapper : IZoneMapper
    {
        /// <summary>
        /// Will get the EAV ZoneId for the current tennant
        /// Always returns a valid value, as it will otherwise create one if it was missing
        /// </summary>
        /// <param name="tennantId"></param>
        /// <returns></returns>
        public int GetZoneId(int tennantId)
        {
            // additional protection agains invalid portalid which may come from bad dnn configs and execute in search-index mode
            // see https://github.com/2sic/2sxc/issues/1054
            if (tennantId < 0)
                throw new Exception("Can't get zone for invalid portal ID: " + tennantId);

            var zoneSettingKey = Settings.PortalSettingsPrefix + "ZoneID";
            var c = PortalController.GetPortalSettingsDictionary(tennantId);
            var portalSettings = new PortalSettings(tennantId);

            int zoneId;

            // Create new zone automatically
            if (!c.ContainsKey(zoneSettingKey))
            {
                zoneId = ZoneManager.CreateZone(portalSettings.PortalName + " (Portal " + tennantId + ")");
                PortalController.UpdatePortalSetting(tennantId, Settings.PortalSettingZoneId, zoneId.ToString());
            }
            else zoneId = Int32.Parse(c[zoneSettingKey]);

            return zoneId;
        }


        /// <summary>
        /// Returns all DNN Cultures with active / inactive state
        /// </summary>
        public List<Culture> CulturesWithState(int tennantId, int zoneId)
        {
            // note: 
            var availableEavLanguages = new ZoneManager(zoneId).Languages; 
            var defaultLanguageCode = new PortalSettings(tennantId).DefaultLanguage;
            var defaultLanguage = availableEavLanguages
                .FirstOrDefault(p => p.TennantKey  == defaultLanguageCode);
            var defaultLanguageIsActive = defaultLanguage?.Active == true;

            return (from c in LocaleController.Instance.GetLocales(tennantId)
                    select new Culture(
                        c.Value.Code,
                        c.Value.Text,
                        availableEavLanguages.Any(a => a.Active && a.TennantKey == c.Value.Code),
                        c.Value.Code == defaultLanguageCode && !defaultLanguageIsActive ||
                        (defaultLanguageIsActive && c.Value.Code != defaultLanguageCode))
                )
                .OrderByDescending(c => c.Code == defaultLanguageCode)
                .ThenBy(c => c.Code).ToList();

        }
    }
}