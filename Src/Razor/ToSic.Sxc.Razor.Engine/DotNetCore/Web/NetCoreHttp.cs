﻿using System.Collections.Specialized;
using System.Linq;
using Microsoft.AspNetCore.Http;
using ToSic.Sxc.Web;

// ReSharper disable once CheckNamespace
namespace ToSic.Sxc.DotNetCore.Web
{

    public class NetCoreHttp : HttpAbstractionBase, IHttp
    {
        public NetCoreHttp(IHttpContextAccessor contextAccessor) => Current = contextAccessor.HttpContext;

        public override NameValueCollection QueryStringParams
        {
            get
            {
                if (_queryStringValues != null) return _queryStringValues;
                // ReSharper disable once ConvertIfStatementToReturnStatement
                if (Request == null) 
                    return _queryStringValues = new NameValueCollection();

                var paramList = new NameValueCollection();
                Request.Query.ToList().ForEach(i => paramList.Add(i.Key, i.Value));
                return _queryStringValues = paramList;
            }
        }

        private NameValueCollection _queryStringValues;


    }
}
