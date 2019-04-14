using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Hosting.Internal;

using SmartHousing.EmailTemplates;
using SmartHousing.API.Shared;
using SmartHousing.DocumentTemplates;
using SmartHousing.API.Database.Context;
using SmartHousing.API.Database.Models;

using API = SmartHousing.API.Bal.Models;
using DAL = SmartHousing.API.Database.Models;
using VM = SmartHousing.DocumentTemplates.Invoice.Models;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using IronPdf;

namespace SmartHousing.Api.v1.Services
{
  public interface IPdfService
  {
    MemoryStream GetPdfStream(int invoiceId);

    IActionResult GetInvoicePdf(int invoiceId);
  }

  public class PdfService : IPdfService
  {
    const string PdfApplicationType = "application/pdf";
    private readonly SmartHousingContext _context;
    private readonly IMapper _mapper;
    public readonly IHttpContextAccessor _httpContextAccessor;
    private IHtmlRenderService _htmlRenderService;

    public PdfService(
      SmartHousingContext context,
      IMapper mapper,
      IHttpContextAccessor httpContextAccessor,
      IHtmlRenderService htmlRenderService)
    {
      _context = context;
      _mapper = mapper;
      _httpContextAccessor = httpContextAccessor;
      _htmlRenderService = htmlRenderService;
    }

    public MemoryStream GetPdfStream(int invoiceId)
    {

      var dalInvoice = _context.Invoice
            .Include(m => m.Order)
            .ThenInclude(m => m.OrderProducts)
            .FirstOrDefault(m => m.Id == invoiceId);

      var invoice = _mapper.Map<VM.Invoice>(dalInvoice);
      var doc = GetPdf(invoice);
      return doc.Stream;
    }

    public IActionResult GetInvoicePdf(int invoiceId)
    {
      var dalInvoice;
      var dalInvoice = _context.Invoice
        .Include(m => m.Order)
        .ThenInclude(m => m.OrderProducts)
        .FirstOrDefault(m => m.Id == invoiceId);

      var invoice = _mapper.Map<VM.Invoice>(dalInvoice);

      var doc = GetPdf(invoice);
      return new FileContentResult(doc.BinaryData, PdfApplicationType);
    }

    public PdfDocument GetPdf(VM.Invoice invoice)
    {
      var baseUrl = AppHelpers.BaseUrl(_httpContextAccessor);
      var invoiceHtmlFilePath = "DocumentTemplates/Invoice/Templates/invoice.html";
      var footerHtmlFilePath = "DocumentTemplates/Invoice/Templates/Assets/footer.html";

      var footerPath = $"{baseUrl}/invoice-assets/footer.html";

      HtmlToPdf Renderer = new HtmlToPdf();
      var html = _htmlRenderService.Render<VM.Invoice>(invoiceHtmlFilePath, invoice);
      var footerHtml = _htmlRenderService.Render<VM.Invoice>(footerHtmlFilePath, invoice);
      var doc = Renderer.RenderHtmlAsPdf(html);
      doc.AddHTMLFooters(new HtmlHeaderFooter()
      {
        HtmlFragment = footerHtml,
        Height = 30
      });
      return doc;
    }
  }
}