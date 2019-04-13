using System;
using System.Linq;
using AutoMapper;

namespace SmartHousing.API.Mappings
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      this.AllowNullCollections = true;
    }
  }
}