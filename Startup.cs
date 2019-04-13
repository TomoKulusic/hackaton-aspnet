using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SmartHousing.API.Shared;
using SmartHousing.Options;
using SmartHousing.API.v1.Services;

namespace smart_housing_aspnet
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    private ConnectionStrings _connectionStrings;


    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      this.AddOptions(services);

      services.AddScoped<IWaterService, WaterService>();
      services.AddScoped<IElectricityService, ElectricityService>();


      services.AddAutoMapper();



      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
      }

      app.UseDefaultFiles();
      app.UseStaticFiles();

      app.UseMvc();
      app.UseSpa(m => m.Options.DefaultPage = "/index.html");
    }

    public void AddOptions(IServiceCollection services)
    {
      _connectionStrings = AppHelpers.RegisterOptions<ConnectionStrings>(services, Configuration);

    }
  }
}
