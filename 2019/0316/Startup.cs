﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ShortUrl
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IUrlMappingStore, UrlMappingStore>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Put the basic add-new page here.
            app.UseFileServer();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Use this middleware for URL mappings.
            app.Use(async (context, next) => {
                var path = context.Request.Path;
                if (path.HasValue) 
                {
                    var store = context.RequestServices.GetService(typeof(IUrlMappingStore)) as IUrlMappingStore;
                    var mapping = store.GetUrlMapping(path.Value.Replace("/", ""));

                    if (mapping is UrlMapping)
                    {
                        context.Response.Redirect(mapping.LongUrl);
                        return;
                    }
                }

                await next.Invoke();
            });

            app.UseMvc();
        }
    }
}
