﻿using System;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using ToSic.Eav.Documentation;
using ToSic.Eav.Run;
using ToSic.Sxc.Engines;
using ToSic.Sxc.Razor.Code;
using ToSic.Sxc.Razor.Components;
using ToSic.Sxc.Run;

namespace ToSic.Sxc.Razor.Engines
{
    /// <summary>
    /// The razor engine, which compiles / runs engine templates
    /// </summary>
    [InternalApi_DoNotUse_MayChangeWithoutNotice("this is just fyi")]
    [EngineDefinition(Name = "Razor")]

    public partial class RazorEngine3 : EngineBase
    {
        #region Constructor / DI

        public RazorEngine3(IServerPaths serverPaths, ILinkPaths linkPaths, TemplateHelpers templateHelpers) : base(serverPaths, linkPaths, templateHelpers) { }

        #endregion


        /// <inheritdoc />
        [PrivateApi]
        protected override void Init()
        {
            // in MVC we're always using V10 compatibility
            CompatibilityAutoLoadJQueryAndRVT = false;

            try
            {
                InitWebpage();
            }
            // Catch web.config Error on DNNs upgraded to 7
            catch (ConfigurationErrorsException exc)
            {
                var e = new Exception("Configuration Error: Please follow this checklist to solve the problem: http://swisschecklist.com/en/i4k4hhqo/2Sexy-Content-Solve-configuration-error-after-upgrading-to-DotNetNuke-7", exc);
                throw e;
            }
        }

        [PrivateApi]
        public async Task<TextWriter> RenderTask()
        {
            Log.Add("will render into TextWriter");
            try
            {
                if (string.IsNullOrEmpty(TemplatePath)) return null;
                var dynCode = new Razor3DynamicCode().Init(Block, 10, Log);

                var compiler = Eav.Factory.Resolve<IRenderRazor>();
                var result = await compiler.RenderToStringAsync(TemplatePath, new Object(),
                    rzv =>
                    {
                        if (rzv.RazorPage is ISxcRazorComponent asSxc)
                        {
                            asSxc.DynCode = dynCode;
                            asSxc.VirtualPath = TemplatePath;
                            asSxc.Purpose = Purpose;

                        }
                    });
                var writer = new StringWriter();
                writer.Write(result);
                // todo: continue here 2020-08-19
                return writer;
            }
            catch (Exception maybeIEntityCast)
            {
                Sxc.Code.ErrorHelp.AddHelpIfKnownError(maybeIEntityCast);
                throw;
            }
        }



        /// <inheritdoc/>
        protected override string RenderTemplate()
        {
            Log.Call();
            var task = RenderTask();
            task.Wait();
            return task.Result.ToString();
        }

        private string InitWebpage()
        {
            if (string.IsNullOrEmpty(TemplatePath)) return null;
            var dynCode = new Razor3DynamicCode().Init(Block, 10, Log);

            var compiler = Eav.Factory.Resolve<IRenderRazor>();
            var result = compiler.RenderToStringAsync(TemplatePath, new Object(), 
                rzv =>
                {
                    if (rzv.RazorPage is ISxcRazorComponent asSxc)
                    {
                        asSxc.DynCode = dynCode;
                        asSxc.VirtualPath = TemplatePath;
                        asSxc.Purpose = Purpose;

                    }

                });
            // todo: de-async!
            return result.Result;

            // WIP https://github.com/dotnet/aspnetcore/blob/master/src/Mvc/Mvc.Razor.RuntimeCompilation/src/RuntimeViewCompiler.cs#L397-L404
            // maybe also https://stackoverflow.com/questions/48206993/how-to-load-asp-net-core-razor-view-dynamically-at-runtime
            // later also check loading more DLLs on https://stackoverflow.com/questions/58685966/adding-assemblies-types-to-be-made-available-to-razor-page-at-runtime

        }
    }
}