using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalcCodingChallenge.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CalcCodingChallenge
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //services.AddDbContext<CalcHistoryContext>(options =>
            //        options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
            services.AddDbContext<CalcHistoryContext>(options => options.UseInMemoryDatabase("Inmemorydb", null));
            services.AddScoped<CalcHistoryContext>();
            services.AddCors(options =>
               {
                   options.AddPolicy(name: MyAllowSpecificOrigins,
                     builder =>
                     {
                         builder.WithOrigins("http://127.0.0.1:8080", "http://127.0.0.1" )
                         .AllowAnyHeader()
                         .AllowAnyMethod();
                     }
                     );
               });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
