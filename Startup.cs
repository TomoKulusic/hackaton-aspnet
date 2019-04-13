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
using SmartHousing.API.Database.Context;
using Microsoft.EntityFrameworkCore;
using SmartHousing.API.Bal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace SmartHousing
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    private ConnectionStrings _connectionStrings;
    private JwtIssuerOptions _jwtIssuerOptions;



    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      this.AddOptions(services);

      services.AddDbContext<SmartHousingContext>(options =>
      {
        options.UseSqlServer(this._connectionStrings.DatabaseConnection);
      });

      services.AddDefaultIdentity<User>(config =>
      {
        config.SignIn.RequireConfirmedEmail = true;
      })
      .AddRoles<Role>()
      .AddEntityFrameworkStores<SmartHousingContext>();

      this.ConfigureIdentity(services);
      this.ConfigureAuthentication(services);

      services.AddScoped<IWaterService, WaterService>();
      services.AddScoped<IElectricityService, ElectricityService>();
      services.AddScoped<IUtilitesService, UtilitesService>();
      services.AddTransient<AmountCalculator>();



      services.AddAutoMapper();

      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      // if (env.IsDevelopment())
      // {
      //   app.UseDeveloperExceptionPage();
      // }
      // else
      // {
      // }
      app.UseAuthentication();
      app.UseMvc();

      // app.UseDefaultFiles();
      // app.UseStaticFiles();
      // app.UseSpa(m => m.Options.DefaultPage = "/index.html");

    }

    public void AddOptions(IServiceCollection services)
    {
      _connectionStrings = AppHelpers.RegisterOptions<ConnectionStrings>(services, Configuration);
      _jwtIssuerOptions = AppHelpers.RegisterOptions<JwtIssuerOptions>(services, Configuration);


    }

    public void ConfigureIdentity(IServiceCollection services)
    {
      services.Configure<IdentityOptions>(options =>
      {
        // Password settings.
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireUppercase = true;
        options.Password.RequiredLength = 8;
        options.Password.RequiredUniqueChars = 1;

        // Lockout settings.
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
        options.Lockout.MaxFailedAccessAttempts = 5;
        options.Lockout.AllowedForNewUsers = true;

        // User settings.
        options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
        options.User.RequireUniqueEmail = false;
      });
    }

    public void ConfigureAuthentication(IServiceCollection services)
    {
      services.AddAuthentication(options =>
      {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
      .AddJwtBearer(x =>
      {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = _jwtIssuerOptions.Key,
          ValidateIssuer = false,
          ValidateAudience = false
        };
      });
    }

  }
}
