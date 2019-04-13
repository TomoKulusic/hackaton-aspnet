using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SmartHousing.API.Database.Context
{
  public class SmartHousingContext : DbContext
  {
    // public DbSet<Application> Applications { get; set; }

    public SmartHousingContext(DbContextOptions<SmartHousingContext> options) : base(options) { }

  }
}