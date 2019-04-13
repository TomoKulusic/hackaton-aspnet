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
    //   new UserRole { Id = 1, UserId = 1, RoleId = (int)RoleEnum.Ministarstvo },
    //   new UserRole { Id = 2, UserId = 2, RoleId = (int)RoleEnum.Ministarstvo },
    //   new UserRole { Id = 3, UserId = 3, RoleId = (int)RoleEnum.Admin },
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
      new ElectricityTariff { Id = 1,Name = "Plavi", OneTarrif = 0.22, SupplyFee = 10.00 }
    };
  }
}