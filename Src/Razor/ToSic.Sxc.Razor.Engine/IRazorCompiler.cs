﻿using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace ToSic.Sxc.Razor.Engine
{
    public interface IRazorCompiler
    {
        (IView view, ActionContext context) CompileView(string partialName, Action<RazorView> configure = null);
    }
}
