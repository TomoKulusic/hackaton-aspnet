using System;
using System.Linq;
using AutoMapper;
using API = SmartHousing.API.Database.Models;
using DAL = SmartHousing.API.Bal.Models;

namespace SmartHousing.API.Mappings
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      this.AllowNullCollections = true;

      CreateMap<DAL.Utility, API.Database.Models.Utility>();

    }
  }
}