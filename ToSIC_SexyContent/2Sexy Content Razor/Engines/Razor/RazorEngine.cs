﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Compilation;
using System.Web.WebPages;
using DotNetNuke.Entities.Modules;
using ToSic.Eav.Documentation;
using ToSic.Eav.Environment;
using ToSic.SexyContent.Engines;
using ToSic.SexyContent.Environment.Dnn7;
using ToSic.SexyContent.Razor;
using ToSic.SexyContent.Search;
using ToSic.Sxc.Search;

namespace ToSic.Sxc.Engines.Razor
{
    /// <summary>
    /// The razor engine, which compiles / runs engine templates
    /// </summary>
    [PublicApi]
    [EngineDefinition(Name = "Razor")]
    public class RazorEngine : EngineBase
    {
        [PrivateApi]
        protected SexyContentWebPage Webpage { get; set; }

        /// <inheritdoc />
        [PrivateApi]
        protected override void Init()
        {
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
        protected HttpContextBase HttpContext 
            => System.Web.HttpContext.Current == null ? null : new HttpContextWrapper(System.Web.HttpContext.Current);

        [PrivateApi("not sure if this is actually sued anywhere?")]
        public Type RequestedModelType()
        {
            if (Webpage != null)
            {
                var webpageType = Webpage.GetType();
                if (webpageType.BaseType.IsGenericType)
                    return webpageType.BaseType.GetGenericArguments()[0];
            }
            return null;
        }

        [PrivateApi]
        public void Render(TextWriter writer)
        {
            Log.Add("will render into textwriter");
            try
            {
                Webpage.ExecutePageHierarchy(new WebPageContext(HttpContext, Webpage, null), writer, Webpage);
            }
            catch (Exception maybeIEntityCast)
            {
                ProvideSpecialErrorOnIEntityIssues(maybeIEntityCast);
                throw;
            }
        }

        private const string IEntityErrDetection = "error CS0234: The type or namespace name 'IEntity' does not exist in the namespace 'ToSic.Eav'";
        private const string IEntityErrorMessage =
            "Error in your razor template. " +
            "You are seeing this because 2sxc 9.3 has a breaking change on ToSic.Eav.IEntity. " +
            "It's easy to fix - please read " +
            "https://2sxc.org/en/blog/post/fixing-the-breaking-change-on-tosic-eav-ientity-in-2sxc-9-3 " +
            ". What follows is the internal error: ";

        private static void ProvideSpecialErrorOnIEntityIssues(Exception maybeIEntityCast)
        {
            if (maybeIEntityCast is HttpCompileException || maybeIEntityCast is InvalidCastException)
                if (maybeIEntityCast.Message.IndexOf(IEntityErrDetection, StringComparison.Ordinal) > 0)
                    throw new Exception(IEntityErrorMessage, maybeIEntityCast);
        }

        /// <inheritdoc/>
        protected override string RenderTemplate()
        {
            Log.Add("will render razor template");
            var writer = new StringWriter();
            Render(writer);
            return writer.ToString();
        }

        private object CreateWebPageInstance()
        {
            try
            {
                var compiledType = BuildManager.GetCompiledType(TemplatePath);
                object objectValue = null;
                if (compiledType != null)
                    objectValue = RuntimeHelpers.GetObjectValue(Activator.CreateInstance(compiledType));
                return objectValue;
            }
            catch (Exception ex)
            {
                ProvideSpecialErrorOnIEntityIssues(ex);
                throw;
            }
        }

        private void InitHelpers(SexyContentWebPage webPage)
        {
            webPage.Html = new HtmlHelper();
            // Deprecated 2019-05-27 2dm - I'm very sure this isn't used anywhere or by anyone.
            // reactivate if it turns out to be used, otherwise delete ca. EOY 2019
            //webPage.Url = new UrlHelper(InstInfo);
            webPage.Sexy = CmsBlock;
            webPage.DnnAppAndDataHelpers = new DnnAppAndDataHelpers(CmsBlock);

        }

        private void InitWebpage()
        {
            if (string.IsNullOrEmpty(TemplatePath)) return;

            var objectValue = RuntimeHelpers.GetObjectValue(CreateWebPageInstance());
            // ReSharper disable once JoinNullCheckWithUsage
            if (objectValue == null)
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "The webpage found at '{0}' was not created.", TemplatePath));

            Webpage = objectValue as SexyContentWebPage;

            if ((Webpage == null))
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "The webpage at '{0}' must derive from SexyContentWebPage.", TemplatePath));

            Webpage.Context = HttpContext;
            Webpage.VirtualPath = TemplatePath;
            Webpage.Purpose = Purpose;
#pragma warning disable 618
            Webpage.InstancePurpose = (InstancePurposes) Purpose;
#pragma warning restore 618
            InitHelpers(Webpage);
        }

        /// <inheritdoc />
        public override void CustomizeData() 
            => Webpage?.CustomizeData();

        /// <inheritdoc />
        public override void CustomizeSearch(Dictionary<string, List<ISearchItem>> searchInfos, IContainer moduleInfo, DateTime beginDate)
        {
            if (Webpage == null || searchInfos == null || searchInfos.Count <= 0) return;

            // call new signature
            Webpage.CustomizeSearch(searchInfos, moduleInfo, beginDate);

            // also call old signature
            var oldSignature = searchInfos.ToDictionary(si => si.Key, si => si.Value.Cast<ISearchInfo>().ToList());
            Webpage.CustomizeSearch(oldSignature, ((Container<ModuleInfo>) moduleInfo).Original, beginDate);
        }
    }
}