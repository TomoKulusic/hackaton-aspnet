using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SmartHousing.API.Shared
{
  public static class AppHelpers
  {
    public static T RegisterOptions<T>(IServiceCollection services, IConfiguration configuration) where T : class
    {
      var sectionName = typeof(T).Name;
      var section = configuration.GetSection(sectionName);
      var options = section.Get<T>();
      services.Configure<T>(section);
      return options;
    }

    public static string GenerateRegistrationRecord(string countyCode, string humanitarianAidType, int orderNumber)

    {
      DateTime today = DateTime.UtcNow;
      string year = today.Year.ToString();
      string yearCode = year.Substring(year.Length - 2);
      var registrationRecord = $"{countyCode}-HA/{humanitarianAidType}-{yearCode}-{orderNumber}";
      return registrationRecord;
    }

    public static string GuidWithoutHypens()
    {
      return Guid
        .NewGuid()
        .ToString()
        .Replace("-", string.Empty);
    }

    public static string BaseUrl(HttpContext context)
    {
      var request = context.Request;
      var baseUrl = $"{request.Scheme}://{request.Host}{request.PathBase}";
      return baseUrl;
    }

    public static string UrlCombine(string url1, string url2)
    {
      if (url1.Length == 0) { return url2; }
      if (url2.Length == 0) { return url1; }
      url1 = url1.TrimEnd('/', '\\');
      url2 = url2.TrimStart('/', '\\');
      return string.Format("{0}/{1}", url1, url2);
    }

    public static string BaseUrl(IHttpContextAccessor httpContext)
    {
      var request = httpContext.HttpContext.Request;
      var baseUrl = $"{request.Scheme}://{request.Host}";
      return baseUrl;
    }
  }
}
