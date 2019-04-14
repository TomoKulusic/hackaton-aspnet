// using System.Collections.Generic;

// namespace CroatianUmbrella.DocumentTemplates.Invoice.Models
// {
//   public class TestData
//   {
//     public Invoice invoice = new Invoice()
//     {
//       CustomerName = "Customer Name",
//       CustomerAddress = "Customer Address",
//       CustomerCityZip = "20000 Dubrovnik",
//       InvoiceNumber = "36/1/10",
//       CustomerOib = "12345678901",
//       InvoicePlaceDate = "Dubrovnik, 14.03.2019.",
//       DeliveryDate = "14.03.2019.",
//       Currency = "HRK",
//       OrderNumber = "Test Order Number",
//       DocumentId = "Test Document ID",
//       TotalAmountNumber = "296.00",
//       TotalAmountText = "Tristosedamdeset",
//       TaxAmount = "74.00",
//       TotalPlusTax = "370.00",
//       Jir = "Test JIR",
//       Zki = "Test ZKI",
//       InvoiceRemark = "Test Bill Remark",
//       ClerkName = "Test Clerk Name",
//       PaymentType = "Transakcijski Racun",
//       InvoiceTime = "14:31",
//       Items = GetAllItems(),
//       RootUrl = AppHelpers.BaseUrl(_httpContextAccessor)
//     };

//     public List<Item> GetAllItems()
//     {
//       return new List<Item>
//       {
//         new Item
//         {
//           ItemNumber = "1",
//           Name = "HRVATSKI KISOBRAN BY ELLA DVORNIK PUZZLELLA",
//           Code = "PuzzlElla",
//           Unit = "kom",
//           Price = "280.00",
//           Amount = "1",
//           Tax = "25",
//           Total = "280.00"
//         },
//         new Item
//         {
//           ItemNumber = "2",
//           Name = "TRANSPORT",
//           Code = "TRANSPORT",
//           Unit = "KOM",
//           Price = "16.00",
//           Amount = "1",
//           Tax = "25",
//           Total = "16.00"
//         }
//       };
//     }
//   }
// }