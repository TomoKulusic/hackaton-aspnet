using HandlebarsDotNet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace SmartHousing.DocumentTemplates
{
  public interface IHtmlRenderService
  {
    string Render<T>(string viewPath, T model);
  }

  // Used to create clear html from handlebars 
  public class HtmlRenderService : IHtmlRenderService
  {
    IHttpContextAccessor _httpContextAccessor;

    public HtmlRenderService(IHttpContextAccessor httpContextAccessor)
    {
      _httpContextAccessor = httpContextAccessor;
    }

    public string Render<T>(string viewPath, T model)
    {
      var source = File.ReadAllText(viewPath);
      var template = Handlebars.Compile(source);
      var result = template(model);
      return result;
    }
  }
}