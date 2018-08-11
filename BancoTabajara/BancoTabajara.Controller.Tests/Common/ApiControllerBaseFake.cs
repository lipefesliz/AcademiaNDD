﻿using BancoTabajara.Controllers;
using BancoTabajara.Controllers.Common;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BancoTabajara.Controller.Tests.Common
{
    public class ApiControllerBaseFake : ApiControllerBase
    {
        public IHttpActionResult HandleCallback<TSuccess>(Func<TSuccess> func)
        {
            return base.HandleCallback(func);
        }

        public IHttpActionResult HandleQuery<TResult>(IQueryable<TResult> query)
        {
            return base.HandleQuery(query);
        }

        public IHttpActionResult HandleQueryable<TSource>(IQueryable<TSource> query)
        {
            return base.HandleQueryable<TSource>(query);
        }

        public IHttpActionResult HandleValidationFailure<T>(IList<T> validationFailure) where T : ValidationFailure
        {
            return base.HandleValidationFailure<T>(validationFailure);
        }
    }

    public class ApiControllerBaseDummy
    {
    }

    public class ApiControllerBaseDummyQuery
    {
    }
}
