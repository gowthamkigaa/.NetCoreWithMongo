using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB_POC.Models;
using MongoDB_POC.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDB_POC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {           
            // requires using Microsoft.Extensions.Options
            services.Configure<DBSettings>(
                Configuration.GetSection(nameof(DBSettings)));

            services.AddSingleton<IDBSettings>(sp =>
                sp.GetRequiredService<IOptions<DBSettings>>().Value);

            // IDBSettings dBSettings = getDBDetails;

            services.AddSingleton<BookService>();
            //services.AddSingleton<BaseService<Author>>();
            services.AddSingleton<IBaseService<Author>>(x => new BaseService<Author>(x.GetService<IDBSettings>(), "author"));
            services.AddSingleton<AuthorService>();
            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
