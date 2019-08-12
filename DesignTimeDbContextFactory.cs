using System;
using System.Diagnostics;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SmartHousing.API.Database.Context;
using SmartHousing.Options;

namespace Proteron.HumanitarianAid.DAL
{
  public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SmartHousingContext>
  {

    public SmartHousingContext CreateDbContext(string[] args)
    {
      var directory = Directory.GetCurrentDirectory();
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(directory)
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<SmartHousingContext>();
      var connectionString = configuration.GetConnectionString(nameof(ConnectionStrings.DatabaseConnection));

      builder.UseSqlServer(connectionString);
      return new SmartHousingContext(builder.Options);
    }
  }
}