using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

using Proteron.HumanitarianAid.DAL;

using AutoMapper;
using SmartHousing.API.Database.Context;
using SmartHousing.API.Database.Models;
using SmartHousing.API.Bal.Models;

namespace SmartHousing.API.v1.Services
{

  public class AmountCalculator
  {
    private readonly SmartHousingContext _context;
    private readonly IMapper _mapper;


    public AmountCalculator(SmartHousingContext context, IMapper mapper)
    {
      this._context = context;
      this._mapper = mapper;
    }

    public double getElectricityTariff(int tariffId, double amount)
    {

      var tariff = this._context.ElectricityTariff.Where(m => m.Id == tariffId).FirstOrDefault();
      return calculateAmount(amount, tariff);
    }



    public double getWaterTariff(int tariffId, double amount)
    {

      var tariff = this._context.WaterTariff.Where(m => m.Id == tariffId).FirstOrDefault();


      return calculateWaterAmount(amount, tariff);

    }


    public double calculateWaterAmount(double amount, WaterTariff tariff)
    {
      double newAmount = 0.0;

      switch (tariff.WaterTariffEnum)
      {
        case WaterTariffEnum.Poslovni:
          newAmount = amount + tariff.Tariff;
          break;
        case WaterTariffEnum.Stambeni:
          newAmount = amount + tariff.Tariff;
          break;
      }

      return newAmount;
    }

    public double calculateAmount(double amount, ElectricityTariff tariff)
    {
      double newAmount = 0.0;
      var currentTime = DateTime.Now;


      switch (tariff.ElectricityTariffEnum)
      {
        case ElectricityTariffEnum.Blue:

          newAmount = (amount * tariff.OneTarrif ?? 0) + tariff.SupplyFee + amount;
          break;
        case ElectricityTariffEnum.White:

          if (currentTime.Hour >= 7 && currentTime.Hour <= 21)
          {
            newAmount = (amount * tariff.LowTarrif ?? 0) + tariff.SupplyFee + amount;
          }
          else
          {
            newAmount = (amount * tariff.HighTarrif ?? 0) + tariff.SupplyFee + amount;

          }
          break;
        case ElectricityTariffEnum.Red:

          if (currentTime.Hour >= 7 && currentTime.Hour <= 21)
          {
            newAmount = (amount * tariff.LowTarrif ?? 0) + tariff.SupplyFee + amount;
          }
          else
          {
            newAmount = (amount * tariff.HighTarrif ?? 0) + tariff.SupplyFee + amount;

          }

          break;

        case ElectricityTariffEnum.Crni:
          newAmount = (amount * tariff.OneTarrif ?? 0) + tariff.SupplyFee + amount;
          break;
      }

      return newAmount;
    }
  }
}
