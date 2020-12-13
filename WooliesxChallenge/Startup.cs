using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WooliesxChallenge.Application;
using WooliesxChallenge.Domain;
using WooliesxChallenge.Domain.Interfaces;
using WooliesxChallenge.Proxy;
using WooliesxChallenge.Proxy.Resource;

namespace WooliesxChallenge.Api
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
            var devChallegeResourceUrl = Configuration.GetValue<string>("DevChallegeResourceUrl");
           
            services.AddSingleton<IDevChallengeResourceClient>(x =>
                new DevChallengeResourceClient(new Uri(devChallegeResourceUrl)));

            services.AddSingleton<IDevChallengeResourceProxy, DevChallengeResourceProxy>();
            services.AddSingleton<IDevChallengeResourceProxy, DevChallengeResourceProxy>();
            services.Configure<UserSetting>(Configuration.GetSection(UserSetting.Setting));
            
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IProductService, ProductService>();

            services.AddSingleton<ITrolleyCalculatorService, TrolleyCalculatorService>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "WooliesX Challenge API",
                    Description = "WooliesX Challenge API",
                    
                });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseErrorHandlingMiddleware();


            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WooliesX Challenge V1");
            });

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
