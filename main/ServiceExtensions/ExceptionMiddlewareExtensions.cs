using Entities.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Main.ServiceExtensions
{
   public static class ExceptionMiddlewareExtensions
   {
      public static void ConfigureExceptionsHandler(this IApplicationBuilder app, IWebHostEnvironment env)
      {
         app.UseExceptionHandler(appError =>
         {
            appError.Run(async context =>
            {
               context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
               context.Response.ContentType = "application/json";

               var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

               if (contextFeature != null)
               {
                  if (env.IsDevelopment())
                  {
                     Console.WriteLine(contextFeature.Error.StackTrace);
                  }

                  await context.Response.WriteAsync(new ErrorDetails
                  {
                     statusCode = context.Response.StatusCode,
                     Message = "Internal Server error."
                  }.ToString());
               }
            });
         });
      }
   }
}
