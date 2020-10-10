using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Linq;
using System.Reflection;
using ha.data;
using ha.services;
using ha.services.contracts;
using ha.data.contracts;
using System;
using ha.sdk;
using System.Collections.Generic;

namespace test
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
            services.AddHttpClient();
            services.AddDbContext<DatabaseContext>();
            services.AddScoped<ISceneRepo, SceneRepo>();
            services.AddScoped<IDeviceRepo, DeviceRepo>();
            services.AddDeviceControllerFactory();
            services.AddScoped<ISceneController, SceneController>();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Home Automation", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "test v1"));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }


    public static class IServiceCollectionExtensions
    {

        public static void AddDeviceControllerFactory(this IServiceCollection services)
        {
            var deviceContollersRepositoryPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "devicecontrollers");


            Console.WriteLine($"Looking for controllers in {deviceContollersRepositoryPath}");

            foreach(var assembly in System.IO.Directory.GetFiles(deviceContollersRepositoryPath))
            {            
                if(System.IO.Path.GetExtension(assembly) == ".dll"){
                    Assembly.LoadFrom(assembly);
                }
            }

            var deviceControllers = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.DefinedTypes)
                .Where(type => type.IsClass && typeof(IDeviceController).IsAssignableFrom(type));

            var deviceControllerDictionary = new Dictionary<string, Type>();

            foreach (var deviceController in deviceControllers)
            {
                if (deviceController.GetCustomAttributes(typeof(DeviceTypeAttribute), true).Length > 0)
                {
                    var deviceTypeAttribute = deviceController.GetCustomAttributes<DeviceTypeAttribute>().First();
                    var deviceControllerType = deviceController.AsType();
                    services.AddSingleton(deviceControllerType);
                    deviceControllerDictionary.Add(deviceTypeAttribute.Name, deviceControllerType);
                    Console.WriteLine($" - Added {deviceTypeAttribute.Name}");

                }
            }

            services.AddSingleton<IDeviceControllerFactory>(ctx => new DeviceControllerFactory(ctx, deviceControllerDictionary));
        }


    }
}
