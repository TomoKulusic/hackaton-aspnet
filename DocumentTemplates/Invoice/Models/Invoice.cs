using System.Collections.Generic;

namespace SmartHousing.DocumentTemplates.Invoice.Models
{
  public class Invoice
  {

    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Currency { get; set; }
    public string InvoicePlaceDate { get; set; }
    public string TaxAmount { get; set; }
    public string TotalPlusTax { get; set; }

    public List<Item> Items { get; set; }
  }

  public class Item
  {
    public string Description { get; set; }
    public string UnitType { get; set; }
    public string PricePerUnit { get; set; }
    public string TotalPrice { get; set; }
  }
}