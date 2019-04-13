using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartHousing.API.Bal.Models;
using SmartHousing.API.Database.Seed;

namespace SmartHousing.API.Database.Context
{
  public class SmartHousingContext : IdentityDbContext<User, IdentityRole<int>, int>
  {
    public DbSet<Utility> Utilities { get; set; }
    public DbSet<Water> Water { get; set; }

    public DbSet<Electricity> Electricity { get; set; }
    public DbSet<ElectricityTariff> ElectricityTariff { get; set; }
    public DbSet<WaterTariff> WaterTariff { get; set; }
    public SmartHousingContext(DbContextOptions<SmartHousingContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      builder.Entity<User>().ToTable(nameof(User));
      builder.Entity<IdentityRole<int>>().ToTable(nameof(Role));
      builder.Entity<IdentityUserClaim<int>>().ToTable(nameof(UserClaim));
      builder.Entity<IdentityUserLogin<int>>().ToTable(nameof(UserLogin));
      builder.Entity<IdentityUserRole<int>>().ToTable(nameof(UserRole));
      builder.Entity<IdentityUserToken<int>>().ToTable(nameof(UserToken));
      builder.Entity<IdentityRoleClaim<int>>().ToTable(nameof(RoleClaim));


      //builder.Entity<Role>().HasData(SeedData.Roles);       reference blyat
      builder.Entity<ElectricityTariff>().HasData(SeedData.ElectricityTariff);
      builder.Entity<WaterTariff>().HasData(SeedData.WaterTariff);
      builder.Entity<Electricity>().HasData(SeedData.Electricity);
      builder.Entity<Water>().HasData(SeedData.Water);
      builder.Entity<Utility>().HasData(SeedData.Utilities);


      builder.Entity<Role>().HasData(SeedData.Roles);
      builder.Entity<UserRole>().HasData(SeedData.UserRole);
      builder.Entity<User>().HasData(SeedData.User);

    }

  }
}