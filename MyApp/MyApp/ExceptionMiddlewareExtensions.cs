﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MyApp
{
    // <copyright file="ExceptionMiddlewareExtensions.cs" company="Fuse Forward">
    // Copyright (c) 2018 All Rights Reserved
    // </copyright>
    // <author>Somya Raj</author>
    // <date>29/10/2018 10:30:00 AM </date>
    // <summary>Class representing methods to handle exceptions</summary>

    public static class ExceptionMiddlewareExtensions
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        static ExceptionMiddlewareExtensions()
        {
            //logger = NLog.LogManager.GetCurrentClassLogger();
        }

        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
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
                        logger.Error("\n" + contextFeature.Error + "\n", "MyApp");

                        await context.Response.WriteAsync(new
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error."
                        }.ToString());
                    }
                });
            });
        }
    }
}
