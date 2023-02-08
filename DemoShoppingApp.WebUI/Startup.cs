using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoShoppingApp.WebUI.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DemoShoppingApp.WebUI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDefaultServices(Configuration);
            services.AddCustomServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.AddDefaultConfiguration(env);
        }
    }
}