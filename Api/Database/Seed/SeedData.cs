using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using SmartHousing.API.Bal.Models;


namespace SmartHousing.API.Database.Seed
{
  public static class SeedData
  {
    private static string randomGuid = Guid.NewGuid().ToString();
    private static PasswordHasher<User> hasher = new PasswordHasher<User>();

    public static List<Role> Roles = new List<Role>()
    {
      new Role { Id=(int)SmartHouseRoles.User, Name="User", NormalizedName="user", ConcurrencyStamp=randomGuid },
      new Role { Id=(int)SmartHouseRoles.Admin, Name="Admin", NormalizedName="admin", ConcurrencyStamp=randomGuid },

    };


    public static List<User> User = new List<User>()
    {
      new User { Id = 1, UserName = "tomokulusic", Email = "tomokulusic@gmail.com", PasswordHash = hasher.HashPassword(null, "Svakacast1!"), SecurityStamp = randomGuid },
      new User { Id = 2, UserName = "petar.kleskovic", Email = "petar.kleskovic@enum.hr", PasswordHash = hasher.HashPassword(null, "Svakacast1!"), SecurityStamp = randomGuid },
      new User { Id = 3, UserName = "kxl9597", Email = "kxl9597@g.rit.edu", PasswordHash = hasher.HashPassword(null, "Svakacast1!"),  SecurityStamp = randomGuid },
      new User { Id = 4, UserName = "stipe.brzi", Email = "stipe.brzi@gmail.com", PasswordHash = hasher.HashPassword(null, "Svakacast1!"),  SecurityStamp = randomGuid },
      new User { Id = 5, UserName = "frano.nola", Email = "frano.nola@gmail.com", PasswordHash = hasher.HashPassword(null, "Svakacast1!"),  SecurityStamp = randomGuid },
      new User { Id = 6, UserName = "user", Email = "user@gmail.com", PasswordHash = hasher.HashPassword(null, "Svakacast1!"),  SecurityStamp = randomGuid }

    };

    public static List<UserRole> UserRole = new List<UserRole>()
    {
      new UserRole { Id = 1, UserId = 1, RoleId = (int)SmartHouseRoles.Admin },
      new UserRole { Id = 2, UserId = 2, RoleId = (int)SmartHouseRoles.Admin },
      new UserRole { Id = 3, UserId = 3, RoleId = (int)SmartHouseRoles.Admin },
      new UserRole { Id = 4, UserId = 4, RoleId = (int)SmartHouseRoles.Admin },
      new UserRole { Id = 5, UserId = 5, RoleId = (int)SmartHouseRoles.Admin },
      new UserRole { Id = 6, UserId = 6, RoleId = (int)SmartHouseRoles.User },

    };

    public static List<ElectricityTariff> ElectricityTariff = new List<ElectricityTariff>()
    {
      new ElectricityTariff { Id = 1,ElectricityTariffEnum = ElectricityTariffEnum.Blue, OneTarrif = 0.22, LowTarrif = null, HighTarrif = null, SupplyFee = 10.00 },
      new ElectricityTariff { Id = 2,ElectricityTariffEnum = ElectricityTariffEnum.White, OneTarrif = null, LowTarrif = 0.24, HighTarrif = 0.12, SupplyFee = 10.00 },
      new ElectricityTariff { Id = 3,ElectricityTariffEnum = ElectricityTariffEnum.Red, OneTarrif = null, LowTarrif = 0.16, HighTarrif = 0.08, SupplyFee = 41.30 },
      new ElectricityTariff { Id = 4,ElectricityTariffEnum = ElectricityTariffEnum.Crni, OneTarrif = 0.13, LowTarrif = null, HighTarrif = null, SupplyFee = 5.80 }
    };

    public static List<WaterTariff> WaterTariff = new List<WaterTariff>()
    {
      new WaterTariff { Id = 1, WaterTariffEnum = WaterTariffEnum.Stambeni, Tariff = 11.95 },
      new WaterTariff { Id = 2, WaterTariffEnum = WaterTariffEnum.Poslovni, Tariff = 20.93 }
    };

    public static List<Water> Water = new List<Water>
    {
      new Water { Id = 1, Amount = 100.21, TarriffId = 1 },
      new Water { Id = 2, Amount = 150.21, TarriffId = 1 },
      new Water { Id = 3, Amount = 111.56, TarriffId = 1 },
      new Water { Id = 4, Amount = 131.51, TarriffId = 1 },
      new Water { Id = 5, Amount = 95.91, TarriffId = 1 },
      new Water { Id = 6, Amount = 71.21, TarriffId = 1 },
      new Water { Id = 7, Amount = 78.56, TarriffId = 1 },
      new Water { Id = 8, Amount = 222.91, TarriffId = 1 },
      new Water { Id = 9, Amount = 87.51, TarriffId = 1 },
      new Water { Id = 10, Amount = 90.56, TarriffId = 1 },
      new Water { Id = 11, Amount = 111.91, TarriffId = 1 },
      new Water { Id = 12, Amount = 135.91, TarriffId = 1 },
      new Water { Id = 13, Amount = 190.51, TarriffId = 1 },
      new Water { Id = 14, Amount = 221.91, TarriffId = 1 },
      new Water { Id = 15, Amount = 115.56, TarriffId = 2 },
      new Water { Id = 16, Amount = 78.21, TarriffId = 2 },
      new Water { Id = 17, Amount = 89.51, TarriffId = 2 },
      new Water { Id = 18, Amount = 34.56, TarriffId = 2 },
      new Water { Id = 19, Amount = 120.21, TarriffId = 2 },
      new Water { Id = 20, Amount = 123.91, TarriffId = 2 },
      new Water { Id = 21, Amount = 167.51, TarriffId = 2 },
      new Water { Id = 22, Amount = 241.56, TarriffId = 2 },
      new Water { Id = 23, Amount = 231.21, TarriffId = 2 },
      new Water { Id = 24, Amount = 56.21, TarriffId = 2 },
      new Water { Id = 25, Amount = 89.56, TarriffId = 2 },
      new Water { Id = 26, Amount = 69.51, TarriffId = 2 },
      new Water { Id = 27, Amount = 141.56, TarriffId = 2 },
      new Water { Id = 28, Amount = 113.21, TarriffId = 2 },
      new Water { Id = 29, Amount = 178.21, TarriffId = 2 },
      new Water { Id = 30, Amount = 172.91, TarriffId = 2 }
    };

    public static List<Electricity> Electricity = new List<Electricity>
    {
      new Electricity { Id = 1, Amount = 100.21, TarriffId = 1 },
      new Electricity { Id = 2, Amount = 150.21, TarriffId = 1 },
      new Electricity { Id = 3, Amount = 111.56, TarriffId = 1 },
      new Electricity { Id = 4, Amount = 131.51, TarriffId = 1 },
      new Electricity { Id = 5, Amount = 95.91, TarriffId = 1 },
      new Electricity { Id = 6, Amount = 71.21, TarriffId = 1 },
      new Electricity { Id = 7, Amount = 78.56, TarriffId = 1 },
      new Electricity { Id = 8, Amount = 222.91, TarriffId = 1 },
      new Electricity { Id = 9, Amount = 87.51, TarriffId = 1 },
      new Electricity { Id = 10, Amount = 90.56, TarriffId = 1 },
      new Electricity { Id = 11, Amount = 111.91, TarriffId = 2 },
      new Electricity { Id = 12, Amount = 135.91, TarriffId = 2 },
      new Electricity { Id = 13, Amount = 190.51, TarriffId = 2 },
      new Electricity { Id = 14, Amount = 221.91, TarriffId = 2 },
      new Electricity { Id = 15, Amount = 115.56, TarriffId = 2 },
      new Electricity { Id = 16, Amount = 78.21, TarriffId = 2 },
      new Electricity { Id = 17, Amount = 89.51, TarriffId = 2 },
      new Electricity { Id = 18, Amount = 34.56, TarriffId = 2 },
      new Electricity { Id = 19, Amount = 120.21, TarriffId = 2 },
      new Electricity { Id = 20, Amount = 123.91, TarriffId = 3 },
      new Electricity { Id = 21, Amount = 167.51, TarriffId = 3 },
      new Electricity { Id = 22, Amount = 241.56, TarriffId = 3 },
      new Electricity { Id = 23, Amount = 231.21, TarriffId = 3 },
      new Electricity { Id = 24, Amount = 56.21, TarriffId = 3 },
      new Electricity { Id = 25, Amount = 89.56, TarriffId = 3 },
      new Electricity { Id = 26, Amount = 69.51, TarriffId = 3 },
      new Electricity { Id = 27, Amount = 141.56, TarriffId = 3 },
      new Electricity { Id = 28, Amount = 113.21, TarriffId = 3 },
      new Electricity { Id = 29, Amount = 178.21, TarriffId = 3 },
      new Electricity { Id = 30, Amount = 172.91, TarriffId = 3 }
    };

    public static List<Utility> Utilities = new List<Utility>
    {
      new Utility { Id = 1, WaterId = null,  ElectricityId = 1, SmartHouseCityRegion = SmartHouseCityRegion.Centar, Date = new DateTime(2019, 4, 13), Amount = 53.21, UtilityType = UtilityType.Electricity },
      new Utility { Id = 2, WaterId = null,  ElectricityId = 2, SmartHouseCityRegion = SmartHouseCityRegion.Centar, Date = new DateTime(2019, 4, 12), Amount = 43.21, UtilityType = UtilityType.Electricity },
      new Utility { Id = 3, WaterId = null,  ElectricityId = 3, SmartHouseCityRegion = SmartHouseCityRegion.Centar, Date = new DateTime(2019, 4, 11), Amount = 65.11, UtilityType = UtilityType.Electricity },
      new Utility { Id = 4, WaterId = null,  ElectricityId = 4, SmartHouseCityRegion = SmartHouseCityRegion.Batala, Date = new DateTime(2019, 4, 10), Amount = 112.21, UtilityType = UtilityType.Electricity },
      new Utility { Id = 5, WaterId = null,  ElectricityId = 5, SmartHouseCityRegion = SmartHouseCityRegion.Batala, Date = new DateTime(2019, 4, 8), Amount = 156.91, UtilityType = UtilityType.Electricity },
      new Utility { Id = 6, WaterId = null,  ElectricityId = 6, SmartHouseCityRegion = SmartHouseCityRegion.Batala, Date = new DateTime(2019, 4, 7), Amount = 157.11, UtilityType = UtilityType.Electricity },
      new Utility { Id = 7, WaterId = null,  ElectricityId = 7, SmartHouseCityRegion = SmartHouseCityRegion.Gorica, Date = new DateTime(2019, 4, 6), Amount = 87.91, UtilityType = UtilityType.Electricity },
      new Utility { Id = 8, WaterId = null,  ElectricityId = 8, SmartHouseCityRegion = SmartHouseCityRegion.Gorica, Date = new DateTime(2019, 4, 5), Amount = 56.51, UtilityType = UtilityType.Electricity },
      new Utility { Id = 9, WaterId = null,  ElectricityId = 9, SmartHouseCityRegion = SmartHouseCityRegion.Gorica, Date = new DateTime(2019, 4, 4), Amount = 51.21, UtilityType = UtilityType.Electricity },
      new Utility { Id = 10, WaterId = null,  ElectricityId = 10,SmartHouseCityRegion = SmartHouseCityRegion.Gruz,  Date = new DateTime(2019, 4, 3), Amount = 78.90, UtilityType = UtilityType.Electricity },
      new Utility { Id = 11, WaterId = null,  ElectricityId = 11,SmartHouseCityRegion = SmartHouseCityRegion.Gruz,  Date = new DateTime(2019, 4, 2), Amount = 11.21, UtilityType = UtilityType.Electricity },
      new Utility { Id = 12, WaterId = null,  ElectricityId = 12,SmartHouseCityRegion = SmartHouseCityRegion.Gruz,  Date = new DateTime(2019, 4, 1), Amount = 56.88, UtilityType = UtilityType.Electricity },
      new Utility { Id = 13, WaterId = null,  ElectricityId = 13,SmartHouseCityRegion = SmartHouseCityRegion.Lapad,  Date = new DateTime(2019, 3, 31), Amount = 51.56, UtilityType = UtilityType.Electricity },
      new Utility { Id = 14, WaterId = null,  ElectricityId = 14,SmartHouseCityRegion = SmartHouseCityRegion.Lapad,  Date = new DateTime(2019, 3, 30), Amount = 78.91, UtilityType = UtilityType.Electricity },
      new Utility { Id = 15, WaterId = null,  ElectricityId = 15,SmartHouseCityRegion = SmartHouseCityRegion.Lapad,  Date = new DateTime(2019, 3, 29), Amount = 111.21, UtilityType = UtilityType.Electricity },
      new Utility { Id = 16, WaterId = null,  ElectricityId = 16,SmartHouseCityRegion = SmartHouseCityRegion.Montovijerna,  Date = new DateTime(2019, 3, 28), Amount = 56.78, UtilityType = UtilityType.Electricity },
      new Utility { Id = 17, WaterId = null,  ElectricityId = 17,SmartHouseCityRegion = SmartHouseCityRegion.Montovijerna,  Date = new DateTime(2019, 3, 27), Amount = 67.91, UtilityType = UtilityType.Electricity },
      new Utility { Id = 18, WaterId = null,  ElectricityId = 18,SmartHouseCityRegion = SmartHouseCityRegion.Montovijerna,  Date = new DateTime(2019, 3, 26), Amount = 41.89, UtilityType = UtilityType.Electricity },
      new Utility { Id = 19, WaterId = null,  ElectricityId = 19,SmartHouseCityRegion = SmartHouseCityRegion.Ploce,  Date = new DateTime(2019, 3, 25), Amount = 60.81, UtilityType = UtilityType.Electricity },
      new Utility { Id = 20, WaterId = null,  ElectricityId = 20,SmartHouseCityRegion = SmartHouseCityRegion.Ploce,  Date = new DateTime(2019, 3, 24), Amount = 111.21, UtilityType = UtilityType.Electricity },
      new Utility { Id = 21, WaterId = null,  ElectricityId = 21,SmartHouseCityRegion = SmartHouseCityRegion.Ploce,  Date = new DateTime(2019, 3, 23), Amount = 41.90, UtilityType = UtilityType.Electricity },
      new Utility { Id = 22, WaterId = null,  ElectricityId = 22,SmartHouseCityRegion = SmartHouseCityRegion.Ploce,  Date = new DateTime(2019, 3, 22), Amount = 78.91, UtilityType = UtilityType.Electricity },
      new Utility { Id = 23, WaterId = null,  ElectricityId = 23,SmartHouseCityRegion = SmartHouseCityRegion.Ploce,  Date = new DateTime(2019, 3, 21), Amount = 56.78, UtilityType = UtilityType.Electricity },
      new Utility { Id = 24, WaterId = null,  ElectricityId = 24,SmartHouseCityRegion = SmartHouseCityRegion.Ploce,  Date = new DateTime(2019, 3, 20), Amount = 67.91, UtilityType = UtilityType.Electricity },
      new Utility { Id = 25, WaterId = null,  ElectricityId = 25,SmartHouseCityRegion = SmartHouseCityRegion.Sipcine,  Date = new DateTime(2019, 3, 19), Amount = 151.99, UtilityType = UtilityType.Electricity },
      new Utility { Id = 26, WaterId = null,  ElectricityId = 26,SmartHouseCityRegion = SmartHouseCityRegion.Sipcine,  Date = new DateTime(2019, 3, 18), Amount = 111.21, UtilityType = UtilityType.Electricity },
      new Utility { Id = 27, WaterId = null,  ElectricityId = 27,SmartHouseCityRegion = SmartHouseCityRegion.Sipcine,  Date = new DateTime(2019, 3, 17), Amount = 56.78, UtilityType = UtilityType.Electricity },
      new Utility { Id = 28, WaterId = null,  ElectricityId = 28,SmartHouseCityRegion = SmartHouseCityRegion.Sipcine,  Date = new DateTime(2019, 3, 16), Amount = 51.21, UtilityType = UtilityType.Electricity },
      new Utility { Id = 29, WaterId = null,  ElectricityId = 29,SmartHouseCityRegion = SmartHouseCityRegion.Sipcine,  Date = new DateTime(2019, 3, 15), Amount = 67.91, UtilityType = UtilityType.Electricity },
      new Utility { Id = 30, WaterId = null,  ElectricityId = 30,SmartHouseCityRegion = SmartHouseCityRegion.Sipcine,  Date = new DateTime(2019, 3, 14), Amount = 41.89, UtilityType = UtilityType.Electricity },
      new Utility { Id = 31, WaterId = 1,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Batala,  Date = new DateTime(2019, 4, 13), Amount = 78.91, UtilityType = UtilityType.Water },
      new Utility { Id = 32, WaterId = 2,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Batala,  Date = new DateTime(2019, 4, 12), Amount = 121.91, UtilityType = UtilityType.Water },
      new Utility { Id = 33, WaterId = 3,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Batala,  Date = new DateTime(2019, 4, 11), Amount = 111.21, UtilityType = UtilityType.Water },
      new Utility { Id = 34, WaterId = 4,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Centar,  Date = new DateTime(2019, 4, 10), Amount = 51.21, UtilityType = UtilityType.Water },
      new Utility { Id = 35, WaterId = 5,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Centar,  Date = new DateTime(2019, 4, 9), Amount = 151.99, UtilityType = UtilityType.Water },
      new Utility { Id = 36, WaterId = 6,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Centar,  Date = new DateTime(2019, 4, 8), Amount = 56.78, UtilityType = UtilityType.Water },
      new Utility { Id = 37, WaterId = 7,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Centar,  Date = new DateTime(2019, 4, 7), Amount = 41.90, UtilityType = UtilityType.Water },
      new Utility { Id = 38, WaterId = 8,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Gorica,  Date = new DateTime(2019, 4, 6), Amount = 78.91, UtilityType = UtilityType.Water },
      new Utility { Id = 39, WaterId = 9,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Gorica,  Date = new DateTime(2019, 4, 5), Amount = 67.91, UtilityType = UtilityType.Water },
      new Utility { Id = 40, WaterId = 10,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Gruz,  Date = new DateTime(2019, 4, 4), Amount = 60.81, UtilityType = UtilityType.Water },
      new Utility { Id = 41, WaterId = 11,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Gruz,  Date = new DateTime(2019, 4, 3), Amount = 111.21, UtilityType = UtilityType.Water },
      new Utility { Id = 42, WaterId = 12,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Gruz,  Date = new DateTime(2019, 4, 2), Amount = 87.22, UtilityType = UtilityType.Water },
      new Utility { Id = 43, WaterId = 13,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Lapad,  Date = new DateTime(2019, 4, 1), Amount = 78.91, UtilityType = UtilityType.Water },
      new Utility { Id = 44, WaterId = 14,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Lapad,  Date = new DateTime(2019, 3, 31), Amount = 41.89, UtilityType = UtilityType.Water },
      new Utility { Id = 45, WaterId = 15,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Lapad,  Date = new DateTime(2019, 3, 30), Amount = 67.91, UtilityType = UtilityType.Water },
      new Utility { Id = 46, WaterId = 16,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Lapad,  Date = new DateTime(2019, 3, 29), Amount = 111.21, UtilityType = UtilityType.Water },
      new Utility { Id = 47, WaterId = 17,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Montovijerna,  Date = new DateTime(2019, 3, 28), Amount = 56.78, UtilityType = UtilityType.Water },
      new Utility { Id = 48, WaterId = 18,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Montovijerna,  Date = new DateTime(2019, 3, 27), Amount = 41.90, UtilityType = UtilityType.Water },
      new Utility { Id = 49, WaterId = 19,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Montovijerna,  Date = new DateTime(2019, 3, 26), Amount = 78.91, UtilityType = UtilityType.Water },
      new Utility { Id = 50, WaterId = 20,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Montovijerna,  Date = new DateTime(2019, 3, 25), Amount = 67.91, UtilityType = UtilityType.Water },
      new Utility { Id = 51, WaterId = 21,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Montovijerna,  Date = new DateTime(2019, 3, 24), Amount = 41.89, UtilityType = UtilityType.Water },
      new Utility { Id = 52, WaterId = 22,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Ploce,  Date = new DateTime(2019, 3, 23), Amount = 56.78, UtilityType = UtilityType.Water },
      new Utility { Id = 53, WaterId = 23,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Ploce,  Date = new DateTime(2019, 3, 22), Amount = 60.81, UtilityType = UtilityType.Water },
      new Utility { Id = 54, WaterId = 24,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Ploce,  Date = new DateTime(2019, 3, 21), Amount = 78.91, UtilityType = UtilityType.Water },
      new Utility { Id = 55, WaterId = 25,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Ploce,  Date = new DateTime(2019, 3, 20), Amount = 67.91, UtilityType = UtilityType.Water },
      new Utility { Id = 56, WaterId = 26,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Ploce,  Date = new DateTime(2019, 3, 19), Amount = 111.21, UtilityType = UtilityType.Water },
      new Utility { Id = 57, WaterId = 27,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Sipcine,  Date = new DateTime(2019, 3, 18), Amount = 56.78, UtilityType = UtilityType.Water },
      new Utility { Id = 58, WaterId = 28,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Sipcine,  Date = new DateTime(2019, 3, 17), Amount = 67.91, UtilityType = UtilityType.Water },
      new Utility { Id = 59, WaterId = 29,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Sipcine,  Date = new DateTime(2019, 3, 16), Amount = 111.21, UtilityType = UtilityType.Water },
      new Utility { Id = 60, WaterId = 30,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Sipcine,  Date = new DateTime(2019, 3, 15), Amount = 111.21, UtilityType = UtilityType.Water }

    };
  }
}