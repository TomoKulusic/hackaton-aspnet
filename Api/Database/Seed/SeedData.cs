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
      new User { Id = 1, UserName = "tomokulusic", Name = "Tomislav", LastName = "Kulusic", Email = "tomokulusic@gmail.com", PasswordHash = hasher.HashPassword(null, "Svakacast1!"), SecurityStamp = randomGuid },
      new User { Id = 2, UserName = "petar.kleskovic", Name = "Petar", LastName = "Kleskovic", Email = "petar.kleskovic@enum.hr", PasswordHash = hasher.HashPassword(null, "Svakacast1!"), SecurityStamp = randomGuid },
      new User { Id = 3, UserName = "kxl9597", Name = "Klara", LastName = "Lucijanovic", Email = "kxl9597@g.rit.edu", PasswordHash = hasher.HashPassword(null, "Svakacast1!"),  SecurityStamp = randomGuid },
      new User { Id = 4, UserName = "stipe.brzi", Name = "Stjepan", LastName = "Brzica", Email = "stipe.brzi@gmail.com", PasswordHash = hasher.HashPassword(null, "Svakacast1!"),  SecurityStamp = randomGuid },
      new User { Id = 5, UserName = "frano.nola", Name = "Frano", LastName = "Nola", Email = "frano.nola@gmail.com", PasswordHash = hasher.HashPassword(null, "Svakacast1!"),  SecurityStamp = randomGuid },
      new User { Id = 6, UserName = "user", Name = "User", LastName = "User", Email = "user@gmail.com", PasswordHash = hasher.HashPassword(null, "Svakacast1!"),  SecurityStamp = randomGuid }

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
      new Water { Id = 1, Amount = 0.21, TarriffId = 1 },
      new Water { Id = 2, Amount = 0.22, TarriffId = 1 },
      new Water { Id = 3, Amount = 0.36, TarriffId = 1 },
      new Water { Id = 4, Amount = 0.31, TarriffId = 1 },
      new Water { Id = 5, Amount = 0.23, TarriffId = 1 },
      new Water { Id = 6, Amount = 0.26, TarriffId = 1 },
      new Water { Id = 7, Amount = 0.16, TarriffId = 1 },
      new Water { Id = 8, Amount = 0.21, TarriffId = 1 },
      new Water { Id = 9, Amount = 0.31, TarriffId = 1 },
      new Water { Id = 10, Amount = 0.16, TarriffId = 1 },
      new Water { Id = 11, Amount = 0.11, TarriffId = 1 },
      new Water { Id = 12, Amount = 0.91, TarriffId = 1 },
      new Water { Id = 13, Amount = 0.13, TarriffId = 1 },
      new Water { Id = 14, Amount = 0.31, TarriffId = 1 },
      new Water { Id = 15, Amount = 0.26, TarriffId = 2 },
      new Water { Id = 16, Amount = 0.21, TarriffId = 2 },
      new Water { Id = 17, Amount = 0.19, TarriffId = 2 },
      new Water { Id = 18, Amount = 0.20, TarriffId = 2 },
      new Water { Id = 19, Amount = 0.17, TarriffId = 2 },
      new Water { Id = 20, Amount = 0.27, TarriffId = 2 },
      new Water { Id = 21, Amount = 0.23, TarriffId = 2 },
      new Water { Id = 22, Amount = 0.26, TarriffId = 2 },
      new Water { Id = 23, Amount = 0.21, TarriffId = 2 },
      new Water { Id = 24, Amount = 0.27, TarriffId = 2 },
      new Water { Id = 25, Amount = 0.16, TarriffId = 2 },
      new Water { Id = 26, Amount = 0.14, TarriffId = 2 },
      new Water { Id = 27, Amount = 0.36, TarriffId = 2 },
      new Water { Id = 28, Amount = 0.21, TarriffId = 2 },
      new Water { Id = 29, Amount = 0.31, TarriffId = 2 },
      new Water { Id = 30, Amount = 0.18, TarriffId = 2 },
      new Water { Id = 31, Amount = 0.28, TarriffId = 1 },
      new Water { Id = 32, Amount = 0.31, TarriffId = 2 },
      new Water { Id = 33, Amount = 0.21, TarriffId = 1 },
      new Water { Id = 34, Amount = 0.12, TarriffId = 2 },
      new Water { Id = 35, Amount = 0.17, TarriffId = 1 },
      new Water { Id = 36, Amount = 0.22, TarriffId = 2 },
      new Water { Id = 37, Amount = 0.15, TarriffId = 1 },
      new Water { Id = 38, Amount = 0.12, TarriffId = 2 },
      new Water { Id = 39, Amount = 0.29, TarriffId = 1 },
      new Water { Id = 40, Amount = 0.21, TarriffId = 2 },
      new Water { Id = 41, Amount = 0.22, TarriffId = 1 },
      new Water { Id = 42, Amount = 0.23, TarriffId = 2 },
      new Water { Id = 43, Amount = 0.21, TarriffId = 1 },
      new Water { Id = 44, Amount = 0.32, TarriffId = 2 },
      new Water { Id = 45, Amount = 0.32, TarriffId = 1 },
      new Water { Id = 46, Amount = 0.25, TarriffId = 2 },
      new Water { Id = 47, Amount = 0.15, TarriffId = 1 },
      new Water { Id = 48, Amount = 0.28, TarriffId = 2 },
      new Water { Id = 49, Amount = 0.23, TarriffId = 1 },
      new Water { Id = 50, Amount = 0.17, TarriffId = 2 }
    };

    public static List<Electricity> Electricity = new List<Electricity>
    {
      new Electricity { Id = 1, Amount = 8.21, TarriffId = 1 },
      new Electricity { Id = 2, Amount = 8.91, TarriffId = 1 },
      new Electricity { Id = 3, Amount = 10.36, TarriffId = 1 },
      new Electricity { Id = 4, Amount = 9.51, TarriffId = 1 },
      new Electricity { Id = 5, Amount = 9.91, TarriffId = 1 },
      new Electricity { Id = 6, Amount = 7.21, TarriffId = 1 },
      new Electricity { Id = 7, Amount = 7.56, TarriffId = 1 },
      new Electricity { Id = 8, Amount = 7.91, TarriffId = 1 },
      new Electricity { Id = 9, Amount = 8.51, TarriffId = 1 },
      new Electricity { Id = 10, Amount = 9.56, TarriffId = 1 },
      new Electricity { Id = 11, Amount = 8.91, TarriffId = 2 },
      new Electricity { Id = 12, Amount = 6.91, TarriffId = 2 },
      new Electricity { Id = 13, Amount = 8.51, TarriffId = 2 },
      new Electricity { Id = 14, Amount = 8.91, TarriffId = 2 },
      new Electricity { Id = 15, Amount = 7.56, TarriffId = 2 },
      new Electricity { Id = 16, Amount = 7.21, TarriffId = 2 },
      new Electricity { Id = 17, Amount = 8.51, TarriffId = 2 },
      new Electricity { Id = 18, Amount = 3.56, TarriffId = 2 },
      new Electricity { Id = 19, Amount = 6.21, TarriffId = 2 },
      new Electricity { Id = 20, Amount = 6.91, TarriffId = 3 },
      new Electricity { Id = 21, Amount = 6.51, TarriffId = 3 },
      new Electricity { Id = 22, Amount = 8.56, TarriffId = 3 },
      new Electricity { Id = 23, Amount = 7.21, TarriffId = 3 },
      new Electricity { Id = 24, Amount = 6.21, TarriffId = 3 },
      new Electricity { Id = 25, Amount = 8.56, TarriffId = 3 },
      new Electricity { Id = 26, Amount = 9.51, TarriffId = 3 },
      new Electricity { Id = 27, Amount = 11.56, TarriffId = 3 },
      new Electricity { Id = 28, Amount = 8.69, TarriffId = 3 },
      new Electricity { Id = 29, Amount = 7.27, TarriffId = 3 },
      new Electricity { Id = 30, Amount = 8.31, TarriffId = 1 },
      new Electricity { Id = 31, Amount = 7.69, TarriffId = 2 },
      new Electricity { Id = 32, Amount = 9.11, TarriffId = 3 },
      new Electricity { Id = 33, Amount = 10.87, TarriffId = 1 },
      new Electricity { Id = 34, Amount = 7.91, TarriffId = 2 },
      new Electricity { Id = 35, Amount = 9.01, TarriffId = 3 },
      new Electricity { Id = 36, Amount = 9.12, TarriffId = 1 },
      new Electricity { Id = 37, Amount = 10.06, TarriffId = 2 },
      new Electricity { Id = 38, Amount = 6.98, TarriffId = 3 },
      new Electricity { Id = 39, Amount = 7.32, TarriffId = 1 },
      new Electricity { Id = 40, Amount = 7.31, TarriffId = 2 },
      new Electricity { Id = 41, Amount = 8.89, TarriffId = 3 },
      new Electricity { Id = 42, Amount = 9.34, TarriffId = 1 },
      new Electricity { Id = 43, Amount = 7.96, TarriffId = 2 },
      new Electricity { Id = 44, Amount = 7.61, TarriffId = 3 },
      new Electricity { Id = 45, Amount = 8.61, TarriffId = 1 },
      new Electricity { Id = 46, Amount = 7.90, TarriffId = 2 },
      new Electricity { Id = 47, Amount = 8.31, TarriffId = 3 },
      new Electricity { Id = 48, Amount = 9.37, TarriffId = 1 },
      new Electricity { Id = 49, Amount = 10.28, TarriffId = 2 },
      new Electricity { Id = 50, Amount = 9.49, TarriffId = 3 }
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
      new Utility { Id = 59, WaterId = 29,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Sipcine,  Date = new DateTime(2019, 3, 16), Amount = 71.21, UtilityType = UtilityType.Water },
      new Utility { Id = 60, WaterId = 30,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Sipcine,  Date = new DateTime(2019, 3, 15), Amount = 81.98, UtilityType = UtilityType.Water },
      new Utility { Id = 61, WaterId = null,  ElectricityId = 31, SmartHouseCityRegion = SmartHouseCityRegion.Centar ,  Date = new DateTime(2019, 3, 14), Amount = 91.72, UtilityType = UtilityType.Electricity },
      new Utility { Id = 62, WaterId = 31,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Batala,  Date = new DateTime(2019, 3, 14), Amount = 90.71, UtilityType = UtilityType.Water },
      new Utility { Id = 63, WaterId = null,  ElectricityId = 32, SmartHouseCityRegion = SmartHouseCityRegion.Gorica,  Date = new DateTime(2019, 3, 13), Amount = 61.72, UtilityType = UtilityType.Electricity },
      new Utility { Id = 64, WaterId = 32,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Gruz,  Date = new DateTime(2019, 3, 13), Amount = 71.89, UtilityType = UtilityType.Water },
      new Utility { Id = 65, WaterId = null,  ElectricityId = 33, SmartHouseCityRegion = SmartHouseCityRegion.Montovijerna,  Date = new DateTime(2019, 3, 12), Amount = 92.61, UtilityType = UtilityType.Electricity },
      new Utility { Id = 66, WaterId = 33,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Sipcine,  Date = new DateTime(2019, 3, 12), Amount = 89.01, UtilityType = UtilityType.Water },
      new Utility { Id = 67, WaterId = null,  ElectricityId = 34, SmartHouseCityRegion = SmartHouseCityRegion.Ploce,  Date = new DateTime(2019, 3, 11), Amount = 71.51, UtilityType = UtilityType.Electricity },
      new Utility { Id = 68, WaterId = 34,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Lapad,  Date = new DateTime(2019, 3, 11), Amount = 81.21, UtilityType = UtilityType.Water },
      new Utility { Id = 69, WaterId = null,  ElectricityId = 35, SmartHouseCityRegion = SmartHouseCityRegion.Centar,  Date = new DateTime(2019, 3, 10), Amount = 71.85, UtilityType = UtilityType.Electricity },
      new Utility { Id = 70, WaterId = 35,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Batala,  Date = new DateTime(2019, 3, 10), Amount = 49.21, UtilityType = UtilityType.Water },
      new Utility { Id = 71, WaterId = null,  ElectricityId = 36, SmartHouseCityRegion = SmartHouseCityRegion.Gorica,  Date = new DateTime(2019, 3, 9), Amount = 59.61, UtilityType = UtilityType.Electricity },
      new Utility { Id = 72, WaterId = 36,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Gruz,  Date = new DateTime(2019, 3, 9), Amount = 95.21, UtilityType = UtilityType.Water },
      new Utility { Id = 73, WaterId = null,  ElectricityId = 37, SmartHouseCityRegion = SmartHouseCityRegion.Montovijerna,  Date = new DateTime(2019, 3, 8), Amount = 72.31, UtilityType = UtilityType.Electricity },
      new Utility { Id = 74, WaterId = 37,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Sipcine,  Date = new DateTime(2019, 3, 8), Amount = 86.57, UtilityType = UtilityType.Water },
      new Utility { Id = 75, WaterId = null,  ElectricityId = 38, SmartHouseCityRegion = SmartHouseCityRegion.Ploce,  Date = new DateTime(2019, 3, 7), Amount = 71.93, UtilityType = UtilityType.Electricity },
      new Utility { Id = 76, WaterId = 38,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Lapad,  Date = new DateTime(2019, 3, 7), Amount = 96.21, UtilityType = UtilityType.Water },
      new Utility { Id = 77, WaterId = null,  ElectricityId = 39, SmartHouseCityRegion = SmartHouseCityRegion.Centar,  Date = new DateTime(2019, 3, 6), Amount = 61.82, UtilityType = UtilityType.Electricity },
      new Utility { Id = 78, WaterId = 39,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Batala,  Date = new DateTime(2019, 3, 6), Amount = 85.92, UtilityType = UtilityType.Water },
      new Utility { Id = 79, WaterId = null,  ElectricityId = 40, SmartHouseCityRegion = SmartHouseCityRegion.Gorica,  Date = new DateTime(2019, 3, 5), Amount = 81.93, UtilityType = UtilityType.Electricity },
      new Utility { Id = 80, WaterId = 40,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Gruz,  Date = new DateTime(2019, 3, 5), Amount = 85.71, UtilityType = UtilityType.Water },
      new Utility { Id = 81, WaterId = null,  ElectricityId = 41, SmartHouseCityRegion = SmartHouseCityRegion.Montovijerna,  Date = new DateTime(2019, 3, 4), Amount = 78.69, UtilityType = UtilityType.Electricity },
      new Utility { Id = 82, WaterId = 41,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Sipcine,  Date = new DateTime(2019, 3, 4), Amount = 81.27, UtilityType = UtilityType.Water },
      new Utility { Id = 83, WaterId = null,  ElectricityId = 42, SmartHouseCityRegion = SmartHouseCityRegion.Ploce,  Date = new DateTime(2019, 3, 3), Amount = 85.79, UtilityType = UtilityType.Electricity },
      new Utility { Id = 84, WaterId = 42,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Lapad,  Date = new DateTime(2019, 3, 3), Amount = 68.92, UtilityType = UtilityType.Water },
      new Utility { Id = 85, WaterId = null,  ElectricityId = 43, SmartHouseCityRegion = SmartHouseCityRegion.Centar,  Date = new DateTime(2019, 3, 2), Amount = 96.65, UtilityType = UtilityType.Electricity },
      new Utility { Id = 86, WaterId = 43,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Batala,  Date = new DateTime(2019, 3, 2), Amount = 69.82, UtilityType = UtilityType.Water },
      new Utility { Id = 87, WaterId = null,  ElectricityId = 44, SmartHouseCityRegion = SmartHouseCityRegion.Gorica,  Date = new DateTime(2019, 3, 1), Amount = 71.80, UtilityType = UtilityType.Electricity },
      new Utility { Id = 88, WaterId = 44,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Gruz,  Date = new DateTime(2019, 3, 1), Amount = 61.72, UtilityType = UtilityType.Water },
      new Utility { Id = 89, WaterId = null,  ElectricityId = 45, SmartHouseCityRegion = SmartHouseCityRegion.Montovijerna,  Date = new DateTime(2019, 2, 28), Amount = 72.89, UtilityType = UtilityType.Electricity },
      new Utility { Id = 90, WaterId = 45,  ElectricityId = null, SmartHouseCityRegion = SmartHouseCityRegion.Ploce,  Date = new DateTime(2019, 2, 28), Amount = 86.32, UtilityType = UtilityType.Water }
    };
  }
}