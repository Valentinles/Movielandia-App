using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movielandia.Common.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseSeedAdminMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SeedAdminMiddleware>();
        }
    }
}
