using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartHousing.API.Bal.Models;

namespace SmartHousing.API.Database.Context
{
  public class SmartHousingContext : DbContext
  {
    public DbSet<Utilities> Utilities { get; set; }
    public SmartHousingContext(DbContextOptions<SmartHousingContext> options) : base(options) { }

  }
}