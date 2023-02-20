using SelectPdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;

namespace Salespoint.Class
{
    public class PDFMaker
    {
        int? headerSize { get; set; } = 25;
        int? footerSize { get; set; } = 25;
        int? delayProcess { get; set; } = 5;
        bool pageHorizontal { get; set; } = false;
        HtmlToPdfOptions optionsSetup { get; set; }
        HtmlToPdf converter { get; set; }
        PdfDocument document { get; set; }
        Font fontOriflame => new Font("Oriflame Sans Print", 8);
        public PDFMaker(int? headerSize = null, int? footerSize = null, bool pageHorizontal = false, int? delayProcess = null, HtmlToPdfOptions optionsSetup = null, HtmlToPdf converter = null, PdfDocument document = null)
        {
            if (delayProcess != null)
                this.delayProcess = delayProcess;
            if (headerSize != null)
                this.headerSize = headerSize;
            if (footerSize != null)
                this.footerSize = footerSize;
            if (optionsSetup != null)
                this.optionsSetup = optionsSetup;
            else
                this.optionsSetup = new HtmlToPdfOptions
                {
                    MarginBottom = 15,
                    MarginLeft = 15,
                    MarginRight = 15,
                    MarginTop = 15,
                    PdfPageSize = PdfPageSize.A4
                };



            this.converter = new HtmlToPdf();
            this.converter.Options.PdfPageSize = this.optionsSetup.PdfPageSize;
            this.converter.Options.MarginBottom = this.optionsSetup.MarginBottom;
            this.converter.Options.MarginLeft = this.optionsSetup.MarginLeft;
            this.converter.Options.MarginRight = this.optionsSetup.MarginRight;
            this.converter.Options.MarginTop = this.optionsSetup.MarginTop;
            this.converter.Options.MinPageLoadTime = (int)this.delayProcess;
            this.converter.Options.MaxPageLoadTime = 300;
            if (pageHorizontal)
                this.converter.Options.PdfPageOrientation = PdfPageOrientation.Landscape;
        }
        private string createHTML(string bodyInject)
        {
            //string urlStyle = UITools.UrlFile("lib/bootstrap/dist/css/bootstrap.css");
            //string urlFont = UITools.UrlFile("css/site.fonts.css");
            //string urlStyleReport = UITools.UrlFile("css/site.reportes.css");

            StringBuilder html = new StringBuilder();
            html.AppendLine("<html lang='en'>");
            html.AppendLine("<head>");
            html.AppendLine("<meta charset='utf-8' />");
            html.AppendLine("<meta name='viewport' content='width=device-width, initial-scale=1.0' />");
            html.AppendLine($"<link rel='stylesheet' href='lib/bootstrap/dist/css/bootstrap.css' />");
            html.AppendLine($"<link rel='stylesheet' href='css/site.fonts.css' />");
            html.AppendLine($"<link rel='stylesheet' href='css/site.reportes.css' />");
            html.AppendLine("</head>");
            html.AppendLine("<body>");
            html.AppendLine($"<div class='container-fluid'>{bodyInject}</div>");
            html.AppendLine("</body>");
            html.AppendLine("</html>");
            return html.ToString();
        }
        public byte[] CreateFile(string html, string htmlHeader = null, string htmlFooter = null)
        {
            //Log
            //#region LogPDF
            //if (!Directory.Exists("PDF"))
            //    Directory.CreateDirectory("PDF");

            //using (var outTxt = new StreamWriter($"PDF/{Guid.NewGuid().ToString()}.html", true))
            //{
            //    outTxt.WriteLine(createHTML(html));
            //    outTxt.Close();
            //}

            //#endregion

            string urlBase = UrlFile("");
            byte[] result;
            //Header
            if (!string.IsNullOrEmpty(htmlHeader))
            {
                PdfHtmlSection headerAdd = new PdfHtmlSection(createHTML(htmlHeader), urlBase);
                headerAdd.AutoFitHeight = HtmlToPdfPageFitMode.AutoFit;
                converter.Options.DisplayHeader = true;
                converter.Header.DisplayOnFirstPage = true;
                converter.Header.DisplayOnEvenPages = true;
                converter.Header.DisplayOnOddPages = true;
                converter.Header.Height = headerSize.Value;
                converter.Header.Add(headerAdd);
            }
            if (!string.IsNullOrEmpty(htmlFooter))
            {
                PdfHtmlSection footerAdd = new PdfHtmlSection(createHTML(htmlFooter), urlBase);
                footerAdd.AutoFitHeight = HtmlToPdfPageFitMode.AutoFit;
                converter.Options.DisplayFooter = true;
                converter.Footer.DisplayOnFirstPage = true;
                converter.Footer.DisplayOnEvenPages = true;
                converter.Footer.DisplayOnOddPages = true;
                converter.Footer.Height = footerSize.Value;
                converter.Footer.Add(footerAdd);
            }

            //Page Number
            PdfTextSection text = new PdfTextSection(0, 0, "{page_number} / {total_pages}", fontOriflame);
            text.HorizontalAlign = PdfTextHorizontalAlign.Right;
            converter.Options.DisplayHeader = true;
            converter.Header.Add(text);

            document = converter.ConvertHtmlString(createHTML(html), urlBase);
            result = document.Save();
            document.Close();
            return result;
        }
        public byte[] CreateFile(StringBuilder html, StringBuilder htmlHeader = null, StringBuilder htmlFooter = null) => CreateFile(html.ToString(), htmlHeader?.ToString() ?? null, htmlFooter?.ToString() ?? null);
        public string CreateBase64(string html, string htmlHeader = null, string htmlFooter = null)
        {
            byte[] data = CreateFile(html, htmlHeader, htmlFooter);

            return Convert.ToBase64String(data);
        }
        public string CreateBase64(StringBuilder html, StringBuilder htmlHeader = null, StringBuilder htmlFooter = null) => CreateBase64(html.ToString(), htmlHeader?.ToString() ?? null, htmlFooter?.ToString() ?? null);

        public static string UrlFile(string fileRoute)
        {

            string key = string.Empty;
            if (System.Configuration.ConfigurationManager.AppSettings["Index"] != null)
                key = System.Configuration.ConfigurationManager.AppSettings["Index"];

            return $"{key}{fileRoute}";
        }
    }
}