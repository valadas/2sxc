﻿using System;
using ToSic.Eav.Logging;
using ToSic.Sxc.Blocks;

namespace ToSic.Sxc.Web
{
    public interface IRenderingHelpers
    {
        IRenderingHelpers Init(IBlockBuilder blockBuilder, ILog parentLog);

        string WrapInContext(string content,
            string dontRelyOnParameterOrder = Eav.Constants.RandomProtectionParameter,
            int instanceId = 0, 
            int contentBlockId = 0, 
            bool editContext = false, 
            string tag = "div",
            bool autoToolbar = false,
            bool addLineBreaks = true);

        string ContextAttributes(int instanceId, 
            int contentBlockId, 
            bool includeEditInfos,
            bool autoToolbar);

        string DesignErrorMessage(Exception ex, bool addToEventLog, string visitorAlternateError, bool addMinimalWrapper, bool encodeMessage);

        // 2020-08-11 disabled, doesn't seem to be needed outside of code
        //string UiContextInfos(bool autoToolbars);
    }
}