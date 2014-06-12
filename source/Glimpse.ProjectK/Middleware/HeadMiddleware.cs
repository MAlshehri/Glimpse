﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Abstractions;

namespace Glimpse.ProjectK.Middleware
{
    public class HeadMiddleware
    {
        private readonly RequestDelegate next;
        private readonly MiddlewareManager manager;
        private readonly Type middlewareType;
        private readonly Guid builderId;

        public HeadMiddleware(RequestDelegate next, Type middlewareType, Guid builderId)
        {
            this.next = next;
            this.manager = MiddlewareManager.Instance;
            this.middlewareType = middlewareType;
            this.builderId = builderId;
        }

        public async Task Invoke(HttpContext context)
        {
            manager.Start(context, middlewareType, builderId);
            await next(context);
            manager.End(context, middlewareType, builderId);
        }
    }
}
