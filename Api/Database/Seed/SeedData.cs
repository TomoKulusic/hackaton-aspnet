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

    //private static PasswordHasher<T> hasher = new PasswordHasher<T>();

    // public static List<Role> Roles = new List<Role>()
    // {
    //   new Role { Id=(int)RoleEnum.User, Name="User", NormalizedName="user", ConcurrencyStamp=randomGuid },
    //   new Role { Id=(int)RoleEnum.Admin, Name="Admin", NormalizedName="admin", ConcurrencyStamp=randomGuid },
    //   new Role { Id=(int)RoleEnum.Ured, Name="Nadlezni Ured", NormalizedName="nadlezniUred", ConcurrencyStamp=randomGuid },
    //   new Role { Id=(int)RoleEnum.Ministarstvo, Name="Ministarstvo", NormalizedName="ministarstvo", ConcurrencyStamp=randomGuid },
    // };

    // public static List<CollectionAim> CollectonAim = new List<CollectionAim>()
    // {
    //   new CollectionAim { Id=(int)EnumCollectionAim.ProtectionOfLife, Name=EnumCollectionAim.ProtectionOfLife},
    //   new CollectionAim { Id=(int)EnumCollectionAim.ProtectionOfPhysicalAndMentalHealth, Name=EnumCollectionAim.ProtectionOfPhysicalAndMentalHealth},
    //   new CollectionAim { Id=(int)EnumCollectionAim.FoodAndClothing, Name=EnumCollectionAim.FoodAndClothing},
    //   new CollectionAim { Id=(int)EnumCollectionAim.Dwelling, Name=EnumCollectionAim.Dwelling},
    //   new CollectionAim { Id=(int)EnumCollectionAim.SchoolingCondition, Name=EnumCollectionAim.SchoolingCondition},
    //   new CollectionAim { Id=(int)EnumCollectionAim.HelpInFacilitiesReconstruction, Name=EnumCollectionAim.HelpInFacilitiesReconstruction},
    //   new CollectionAim { Id=(int)EnumCollectionAim.TransportHelpAndAvailability, Name=EnumCollectionAim.TransportHelpAndAvailability},
    //   new CollectionAim { Id=(int)EnumCollectionAim.AccidentAndCatastropheHelp, Name=EnumCollectionAim.AccidentAndCatastropheHelp},
    //   new CollectionAim { Id=(int)EnumCollectionAim.SocialExclusionPrevention, Name=EnumCollectionAim.SocialExclusionPrevention},
    // };

    // public static List<LegalEntityCondition> LegalEntityCondition = new List<LegalEntityCondition>()
    // {
    //   new LegalEntityCondition { Id=(int)EnumLegalEntityCondition.TwoYears180DaysDuration, Name=EnumLegalEntityCondition.TwoYears180DaysDuration},
    //   new LegalEntityCondition { Id=(int)EnumLegalEntityCondition.TwoYearsFiveHumanitaranActions, Name=EnumLegalEntityCondition.TwoYearsFiveHumanitaranActions},
    // };

    // public static List<User> User = new List<User>()
    // {
    //   new User { Id = 1, Email = "tomislav.kulusic@proteron.hr", PasswordHash = hasher.HashPassword(null, "Svakacast1!"), EmailConfirmed = true, LockoutEnabled = true, SecurityStamp = randomGuid },
    //   new User { Id = 2, Email = "frano.nola@proteron.hr", PasswordHash = hasher.HashPassword(null, "Svakacast1!"), EmailConfirmed = true, LockoutEnabled = true, SecurityStamp = randomGuid },
    //   new User { Id = 3, Email = "administrator@live.com", PasswordHash = hasher.HashPassword(null, "Svakacast1!"), EmailConfirmed = true, LockoutEnabled = true, SecurityStamp = randomGuid }
    // };


    // public static List<UserRole> UserRole = new List<UserRole>()
    // {
    //   new UserRole { Id = 1, UserId = 1, RoleId =RoleEnum.Ministarstvo },
    //   new UserRole { Id = 2, UserId = 2, RoleId =RoleEnum.Ministarstvo },
    //   new UserRole { Id = 3, UserId = 3, RoleId =RoleEnum.Admin },
    // };

    // public static List<DocumentType> DocumentType = new List<DocumentType>()
    // {
    //   new DocumentType { Id =(int)DocumentTypeEnum.AuthorizationToUsePhoneNumber, Name=nameof(DocumentTypeEnum.AuthorizationToUsePhoneNumber), Area="Area", IsMandatory=true }
    // };

    // public static List<Applicant> Applicant = new List<Applicant>()
    // {
    //   new Applicant { Id = 1, UserId = 3 },
    // };

    // public static List<Application> Application = new List<Application>()
    // {
    //   new Application { Id = 1, ApplicantId = 1, Type=CollectionType.ConstantCollection, StartDate=DateTime.UtcNow, EndDate=DateTime.UtcNow  },
    // };

    // public static List<ConstantCollectionPlans> ConstantCollectionPlans = new List<ConstantCollectionPlans>()
    // {
    //   new ConstantCollectionPlans { Id = 1, ApplicationId=1 },
    // };

    public static List<ElectricityTariff> ElectricityTariff = new List<ElectricityTariff>()
    {
      new ElectricityTariff { Id = 1,Name = "Plavi", OneTarrif = 0.22, LowTarrif = null, HighTarrif = null, SupplyFee = 10.00 },
      new ElectricityTariff { Id = 2,Name = "Bijeli", OneTarrif = null, LowTarrif = 0.24, HighTarrif = 0.12, SupplyFee = 10.00 },
      new ElectricityTariff { Id = 3,Name = "Crveni", OneTarrif = null, LowTarrif = 0.16, HighTarrif = 0.08, SupplyFee = 41.30 },
      new ElectricityTariff { Id = 4,Name = "Crni", OneTarrif = 0.13, LowTarrif = null, HighTarrif = null, SupplyFee = 5.80 }
    };

    public static List<WaterTariff> WaterTariff = new List<WaterTariff>()
    {
      new WaterTariff { Id = 1, Name = "Stambeni", Tariff = 11.95 },
      new WaterTariff { Id = 2, Name = "Poslovni", Tariff = 20.93 }
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
      new Utility { Id = 1, WaterId = null,  ElectricityId = 1,  Date = new DateTime(2019, 4, 13), Amount = 53.21, UtilityType = UtilityType.Electricity },
      new Utility { Id = 2, WaterId = null,  ElectricityId = 2,  Date = new DateTime(2019, 4, 12), Amount = 43.21, UtilityType = UtilityType.Electricity },
      new Utility { Id = 3, WaterId = null,  ElectricityId = 3,  Date = new DateTime(2019, 4, 11), Amount = 65.11, UtilityType = UtilityType.Electricity },
      new Utility { Id = 4, WaterId = null,  ElectricityId = 4,  Date = new DateTime(2019, 4, 10), Amount = 112.21, UtilityType = UtilityType.Electricity },
      new Utility { Id = 5, WaterId = null,  ElectricityId = 5,  Date = new DateTime(2019, 4, 8), Amount = 156.91, UtilityType = UtilityType.Electricity },
      new Utility { Id = 6, WaterId = null,  ElectricityId = 6,  Date = new DateTime(2019, 4, 7), Amount = 157.11, UtilityType = UtilityType.Electricity },
      new Utility { Id = 7, WaterId = null,  ElectricityId = 7,  Date = new DateTime(2019, 4, 6), Amount = 87.91, UtilityType = UtilityType.Electricity },
      new Utility { Id = 8, WaterId = null,  ElectricityId = 8,  Date = new DateTime(2019, 4, 5), Amount = 56.51, UtilityType = UtilityType.Electricity },
      new Utility { Id = 9, WaterId = null,  ElectricityId = 9,  Date = new DateTime(2019, 4, 4), Amount = 51.21, UtilityType = UtilityType.Electricity },
      new Utility { Id = 10, WaterId = null,  ElectricityId = 10,  Date = new DateTime(2019, 4, 3), Amount = 78.90, UtilityType = UtilityType.Electricity },
      new Utility { Id = 11, WaterId = null,  ElectricityId = 11,  Date = new DateTime(2019, 4, 2), Amount = 11.21, UtilityType = UtilityType.Electricity },
      new Utility { Id = 12, WaterId = null,  ElectricityId = 12,  Date = new DateTime(2019, 4, 1), Amount = 56.88, UtilityType = UtilityType.Electricity },
      new Utility { Id = 13, WaterId = null,  ElectricityId = 13,  Date = new DateTime(2019, 3, 31), Amount = 51.56, UtilityType = UtilityType.Electricity },
      new Utility { Id = 14, WaterId = null,  ElectricityId = 14,  Date = new DateTime(2019, 3, 30), Amount = 78.91, UtilityType = UtilityType.Electricity },
      new Utility { Id = 15, WaterId = null,  ElectricityId = 15,  Date = new DateTime(2019, 3, 29), Amount = 111.21, UtilityType = UtilityType.Electricity },
      new Utility { Id = 16, WaterId = null,  ElectricityId = 16,  Date = new DateTime(2019, 3, 28), Amount = 56.78, UtilityType = UtilityType.Electricity },
      new Utility { Id = 17, WaterId = null,  ElectricityId = 17,  Date = new DateTime(2019, 3, 27), Amount = 67.91, UtilityType = UtilityType.Electricity },
      new Utility { Id = 18, WaterId = null,  ElectricityId = 18,  Date = new DateTime(2019, 3, 26), Amount = 41.89, UtilityType = UtilityType.Electricity },
      new Utility { Id = 19, WaterId = null,  ElectricityId = 19,  Date = new DateTime(2019, 3, 25), Amount = 60.81, UtilityType = UtilityType.Electricity },
      new Utility { Id = 20, WaterId = null,  ElectricityId = 20,  Date = new DateTime(2019, 3, 24), Amount = 111.21, UtilityType = UtilityType.Electricity },
      new Utility { Id = 21, WaterId = null,  ElectricityId = 21,  Date = new DateTime(2019, 3, 23), Amount = 41.90, UtilityType = UtilityType.Electricity },
      new Utility { Id = 22, WaterId = null,  ElectricityId = 22,  Date = new DateTime(2019, 3, 22), Amount = 78.91, UtilityType = UtilityType.Electricity },
      new Utility { Id = 23, WaterId = null,  ElectricityId = 23,  Date = new DateTime(2019, 3, 21), Amount = 56.78, UtilityType = UtilityType.Electricity },
      new Utility { Id = 24, WaterId = null,  ElectricityId = 24,  Date = new DateTime(2019, 3, 20), Amount = 67.91, UtilityType = UtilityType.Electricity },
      new Utility { Id = 25, WaterId = null,  ElectricityId = 25,  Date = new DateTime(2019, 3, 19), Amount = 151.99, UtilityType = UtilityType.Electricity },
      new Utility { Id = 26, WaterId = null,  ElectricityId = 26,  Date = new DateTime(2019, 3, 18), Amount = 111.21, UtilityType = UtilityType.Electricity },
      new Utility { Id = 27, WaterId = null,  ElectricityId = 27,  Date = new DateTime(2019, 3, 17), Amount = 56.78, UtilityType = UtilityType.Electricity },
      new Utility { Id = 28, WaterId = null,  ElectricityId = 28,  Date = new DateTime(2019, 3, 16), Amount = 51.21, UtilityType = UtilityType.Electricity },
      new Utility { Id = 29, WaterId = null,  ElectricityId = 29,  Date = new DateTime(2019, 3, 15), Amount = 67.91, UtilityType = UtilityType.Electricity },
      new Utility { Id = 30, WaterId = null,  ElectricityId = 30,  Date = new DateTime(2019, 3, 14), Amount = 41.89, UtilityType = UtilityType.Electricity },
      new Utility { Id = 31, WaterId = 1,  ElectricityId = null,  Date = new DateTime(2019, 4, 13), Amount = 78.91, UtilityType = UtilityType.Water },
      new Utility { Id = 32, WaterId = 2,  ElectricityId = null,  Date = new DateTime(2019, 4, 12), Amount = 121.91, UtilityType = UtilityType.Water },
      new Utility { Id = 33, WaterId = 3,  ElectricityId = null,  Date = new DateTime(2019, 4, 11), Amount = 111.21, UtilityType = UtilityType.Water },
      new Utility { Id = 34, WaterId = 4,  ElectricityId = null,  Date = new DateTime(2019, 4, 10), Amount = 51.21, UtilityType = UtilityType.Water },
      new Utility { Id = 35, WaterId = 5,  ElectricityId = null,  Date = new DateTime(2019, 4, 9), Amount = 151.99, UtilityType = UtilityType.Water },
      new Utility { Id = 36, WaterId = 6,  ElectricityId = null,  Date = new DateTime(2019, 4, 8), Amount = 56.78, UtilityType = UtilityType.Water },
      new Utility { Id = 37, WaterId = 7,  ElectricityId = null,  Date = new DateTime(2019, 4, 7), Amount = 41.90, UtilityType = UtilityType.Water },
      new Utility { Id = 38, WaterId = 8,  ElectricityId = null,  Date = new DateTime(2019, 4, 6), Amount = 78.91, UtilityType = UtilityType.Water },
      new Utility { Id = 39, WaterId = 9,  ElectricityId = null,  Date = new DateTime(2019, 4, 5), Amount = 67.91, UtilityType = UtilityType.Water },
      new Utility { Id = 40, WaterId = 10,  ElectricityId = null,  Date = new DateTime(2019, 4, 4), Amount = 60.81, UtilityType = UtilityType.Water },
      new Utility { Id = 41, WaterId = 11,  ElectricityId = null,  Date = new DateTime(2019, 4, 3), Amount = 111.21, UtilityType = UtilityType.Water },
      new Utility { Id = 42, WaterId = 12,  ElectricityId = null,  Date = new DateTime(2019, 4, 2), Amount = 87.22, UtilityType = UtilityType.Water },
      new Utility { Id = 43, WaterId = 13,  ElectricityId = null,  Date = new DateTime(2019, 4, 1), Amount = 78.91, UtilityType = UtilityType.Water },
      new Utility { Id = 44, WaterId = 14,  ElectricityId = null,  Date = new DateTime(2019, 3, 31), Amount = 41.89, UtilityType = UtilityType.Water },
      new Utility { Id = 45, WaterId = 15,  ElectricityId = null,  Date = new DateTime(2019, 3, 30), Amount = 67.91, UtilityType = UtilityType.Water },
      new Utility { Id = 46, WaterId = 16,  ElectricityId = null,  Date = new DateTime(2019, 3, 29), Amount = 111.21, UtilityType = UtilityType.Water },
      new Utility { Id = 47, WaterId = 17,  ElectricityId = null,  Date = new DateTime(2019, 3, 28), Amount = 56.78, UtilityType = UtilityType.Water },
      new Utility { Id = 48, WaterId = 18,  ElectricityId = null,  Date = new DateTime(2019, 3, 27), Amount = 41.90, UtilityType = UtilityType.Water },
      new Utility { Id = 49, WaterId = 19,  ElectricityId = null,  Date = new DateTime(2019, 3, 26), Amount = 78.91, UtilityType = UtilityType.Water },
      new Utility { Id = 50, WaterId = 20,  ElectricityId = null,  Date = new DateTime(2019, 3, 25), Amount = 67.91, UtilityType = UtilityType.Water },
      new Utility { Id = 51, WaterId = 21,  ElectricityId = null,  Date = new DateTime(2019, 3, 24), Amount = 41.89, UtilityType = UtilityType.Water },
      new Utility { Id = 52, WaterId = 22,  ElectricityId = null,  Date = new DateTime(2019, 3, 23), Amount = 56.78, UtilityType = UtilityType.Water },
      new Utility { Id = 53, WaterId = 23,  ElectricityId = null,  Date = new DateTime(2019, 3, 22), Amount = 60.81, UtilityType = UtilityType.Water },
      new Utility { Id = 54, WaterId = 24,  ElectricityId = null,  Date = new DateTime(2019, 3, 21), Amount = 78.91, UtilityType = UtilityType.Water },
      new Utility { Id = 55, WaterId = 25,  ElectricityId = null,  Date = new DateTime(2019, 3, 20), Amount = 67.91, UtilityType = UtilityType.Water },
      new Utility { Id = 56, WaterId = 26,  ElectricityId = null,  Date = new DateTime(2019, 3, 19), Amount = 111.21, UtilityType = UtilityType.Water },
      new Utility { Id = 57, WaterId = 27,  ElectricityId = null,  Date = new DateTime(2019, 3, 18), Amount = 56.78, UtilityType = UtilityType.Water },
      new Utility { Id = 58, WaterId = 28,  ElectricityId = null,  Date = new DateTime(2019, 3, 17), Amount = 67.91, UtilityType = UtilityType.Water },
      new Utility { Id = 59, WaterId = 29,  ElectricityId = null,  Date = new DateTime(2019, 3, 16), Amount = 111.21, UtilityType = UtilityType.Water },
      new Utility { Id = 60, WaterId = 30,  ElectricityId = null,  Date = new DateTime(2019, 3, 15), Amount = 111.21, UtilityType = UtilityType.Water }

    };
  }
}