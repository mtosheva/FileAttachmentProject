using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebApplication1.Repositories;
using WebApplication1.Services;

namespace WebApplication1
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
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc($"v1", new OpenApiInfo { Title = " line of business API", Version = "1" });
                    //c.EnableAnnotations();
                    // Set the comments path for the Swagger JSON and UI.
                   // var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                  //  var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                  //  c.IncludeXmlComments(xmlPath);
                });

                services.AddCors(options =>
                {
                    options.AddPolicy("default", policy =>
                    {
                        policy.WithOrigins("http://localhost:4200")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
                });

                services.AddHttpContextAccessor();
                services.AddControllers();
            //.AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))
            //.AddNewtonsoftJson(o =>
            //{
            //    o.SerializerSettings.Converters.Add(new StringEnumConverter());
            //    o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //});
            // services.AddSwaggerGenNewtonsoftSupport();
            services.AddScoped<IFileService, FileService>();

            services.AddScoped<IFileRepository, FileRepository>();

              //  services.AddTransient<IAppHelper, AppHelper>();
                //services.AddAutoMapper(c =>
                //{
                //    c.AddProfile<LineOfBusinessProfile>();
                //});
            }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                app.UseSwagger();

                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
                // specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint($"/swagger/v1/swagger.json", "LoB");
                    c.RoutePrefix = string.Empty;
                    c.ShowCommonExtensions();
                });

                app.UseCors("default");



                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }

                app.UseHttpsRedirection();

                app.UseRouting();


                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            }
        }
    }
