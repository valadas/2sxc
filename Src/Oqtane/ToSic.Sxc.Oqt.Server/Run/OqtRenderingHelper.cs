﻿using System;
using ToSic.Sxc.Oqt.Shared;
using ToSic.Sxc.Run;
using ToSic.Sxc.Web;

// TODO: #Oqtane - doesn't really do anything yet

namespace ToSic.Sxc.Oqt.Server.Run
{
    public class OqtRenderingHelper: RenderingHelper
    {
        public OqtRenderingHelper(ILinkPaths linkPaths) : base(linkPaths, $"{OqtConstants.OqtLogPrefix}.RndHlp") { }

        protected override void LogToEnvironmentExceptions(Exception ex)
        {
            // Don't do anything
        }
    }
}
