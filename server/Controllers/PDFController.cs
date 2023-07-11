using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PDFController : ControllerBase
    {
      
        [HttpPost]
        public IActionResult GenerateInvoicePdf([FromBody] DetailInvoceDTO invoiceDetails)
        {
            // Cargar la plantilla HTML desde un archivo o base de datos
            string templateHtml = LoadInvoiceTemplate();

            // Reemplazar los marcadores con los valores de la factura
            string html = ReplacePlaceholders(templateHtml, invoiceDetails);

            // Generar el archivo PDF a partir del HTML
            byte[] pdfBytes = GeneratePdfFromHtml(html);

            // Devolver el PDF como respuesta
            return File(pdfBytes, "application/pdf", "invoice.pdf");
        }

        private string LoadInvoiceTemplate()
        {
            // Cargar la plantilla HTML desde un archivo, base de datos u otra fuente
            string templateHtml = System.IO.File.ReadAllText("invoice_template.html");
            return templateHtml;
        }

        private string ReplacePlaceholders(string templateHtml, DetailInvoceDTO invoiceDetails)
        {
            // Reemplazar los marcadores con los valores de la factura
            string html = templateHtml
                .Replace("{{CustomerName}}", invoiceDetails.FirstName + " " + invoiceDetails.LastName)
                .Replace("{{InvoceDate}}", invoiceDetails.Date.ToString())
                .Replace("{{ProductRows}}", GenerateProductRowsHtml(invoiceDetails.Products!))
                .Replace("{{SubTotal}}", invoiceDetails.SubTotal.ToString())
                .Replace("{{Discounts}}", invoiceDetails.Discount.ToString())
                
                .Replace("{{Total}}", invoiceDetails.Total.ToString())
                .Replace("{{Itbis}}", invoiceDetails.ITBIS.ToString())
                .Replace("{{InvoceId}}", invoiceDetails.InvoceId.ToString());
                

            return html;
        }

        private string GenerateProductRowsHtml(List<ProductDTO> products)
        {
            // Generar las filas de productos dinámicamente en formato HTML
            StringBuilder rowsHtml = new StringBuilder();
            foreach (var product in products)
            {
                string rowHtml = $@"
              <tr>
                <td>{product.ProductName}</td>
                <td>{product.Quantity}</td>
                <td>{product.Price}</td>
              </tr>";
                rowsHtml.Append(rowHtml);
            }
            return rowsHtml.ToString();
        }

        private byte[] GeneratePdfFromHtml(string html)
        {

            var htmlToPdf = new HtmlToPDFCore.HtmlToPDF();
            var pdf = htmlToPdf.ReturnPDF(html);

          
            return pdf;
        }
    }
}