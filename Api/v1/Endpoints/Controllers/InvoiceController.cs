using System.IO;
using System.Text;

using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SmartHousing.API.Bal.Models;
using SmartHousing.API.v1.Services;
using SmartHousing.Api.v1.Services;

namespace SmartHousing.Api.Endpoints.Controllers
{
  [Route("api/v1/[controller]")]        // Pitat Toma
  public class InvoiceController : Controller
  {
    private readonly IPdfService pdfService;
    public InvoiceController(IPdfService pdfService)
    {
      this.pdfService = pdfService;
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
      return pdfService.GetInvoicePdf(id);
    }

  }
}