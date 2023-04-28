using SelectPdf;
using System.Drawing;
using System.Text;
using System;
namespace HELPERS
{
    //public class PDF : IDisposable
    //{
    //    public void Dispose()
    //    {
    //        if (document != null)
    //        {
    //            document.Close();
    //            document = null;
    //        }
    //    }
    //    string baseUrl = null;
    //    string wwwPath = "wwwroot";

    //    string directory = Server.MapPath(@"~\Content\Lib\bootstrap\dist\css/bootstrap.css");
    //    List<string> cssPaths = new List<string>() {
    //    "~/Content/Lib/bootstrap/dist/css/bootstrap.css",
    //    "~/Content/site.fonts.css",
    //    "~/Content/site.fonts.css",
    //    "css/site.reportes.css"
    //    };
    //    List<string> cssPersonalized = new List<string>();
    //    int headerSize { get; set; } = 25;
    //    int footerSize { get; set; } = 25;
    //    int delayProcess { get; set; } = 3;
    //    bool pageHorizontal { get; set; } = false;
    //    bool pageNumber { get; set; } = true;
    //    HtmlToPdfOptions optionsSetup { get; set; }
    //    HtmlToPdf converter { get; set; }
    //    PdfDocument document { get; set; }
    //    Font fontOriflame
    //    {
    //        get
    //        {
    //            /*
    //            if (OperatingSystem.IsWindows())
    //                return new Font("Oriflame Sans Print", 8);
    //            else
    //            */
    //                return null;
    //        }
    //    }
    //    public PDF(int? headerSize = null, int? footerSize = null, bool pageHorizontal = false, int? delayProcess = null, HtmlToPdfOptions optionsSetup = null, HtmlToPdf converter = null, PdfDocument document = null, bool? pageNumber = true)
    //    {
    //        //GlobalProperties.LicenseKey = "8drA0cPEwNHAwcHRw8HfwdHCwN/Aw9/IyMjI";

    //        this.pageHorizontal = pageHorizontal;

    //        if (delayProcess != null)
    //            this.delayProcess = delayProcess.Value;
    //        if (headerSize != null)
    //            this.headerSize = headerSize.Value;
    //        if (footerSize != null)
    //            this.footerSize = footerSize.Value;
    //        if (pageNumber != null)
    //            this.pageNumber = pageNumber.Value;
    //        if (optionsSetup != null)
    //            this.optionsSetup = optionsSetup;
    //        else
    //            this.optionsSetup = new HtmlToPdfOptions
    //            {
    //                MarginBottom = 15,
    //                MarginLeft = 15,
    //                MarginRight = 15,
    //                MarginTop = 15,
    //                PdfPageSize = PdfPageSize.A4
    //            };

    //        this.converter = new HtmlToPdf();
    //        this.converter.Options.PdfPageSize = this.optionsSetup.PdfPageSize;
    //        this.converter.Options.MarginBottom = this.optionsSetup.MarginBottom;
    //        this.converter.Options.MarginLeft = this.optionsSetup.MarginLeft;
    //        this.converter.Options.MarginRight = this.optionsSetup.MarginRight;
    //        this.converter.Options.MarginTop = this.optionsSetup.MarginTop;
    //        this.converter.Options.MinPageLoadTime = (int)this.delayProcess;
    //        this.converter.Options.MaxPageLoadTime = 600;

    //        if (pageHorizontal)
    //            this.converter.Options.PdfPageOrientation = PdfPageOrientation.Landscape;
    //    }
    //    public void AddCSS(List<string> ListCSS)
    //    {
    //        if (this.cssPersonalized == null)
    //            cssPersonalized = new List<string>();

    //        cssPersonalized = ListCSS;
    //    }
    //    public void AddCSS(string css)
    //    {
    //        if (this.cssPersonalized == null)
    //            cssPersonalized = new List<string>();

    //        cssPersonalized.Add(css);
    //    }
    //    private string createHTML(string bodyInject)
    //    {
    //        StringBuilder html = new StringBuilder();
    //        html.AppendLine("<html lang='en'>");
    //        html.AppendLine("<head>");
    //        html.AppendLine("<meta charset='utf-8' />");
    //        html.AppendLine("<meta name='viewport' content='width=device-width, initial-scale=1.0' />");


    //        var pathRoot = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

    //        //Elimina la seccion bin\debug para las versiones locales
    //        if (pathRoot != null)
    //            if (pathRoot.Contains("\\bin"))
    //            {
    //                int toRemove = pathRoot.IndexOf("\\bin");
    //                pathRoot = pathRoot.Substring(0, toRemove);
    //            }

    //        if (Directory.Exists($"{pathRoot}\\{wwwPath}"))
    //        {
    //            html.AppendLine("<style>");
    //            foreach (var css in cssPaths)
    //                if (File.Exists($"{pathRoot}\\{wwwPath}\\{css}"))
    //                    html.Append(File.ReadAllText($"{pathRoot}\\{wwwPath}\\{css}"));
    //            foreach (var css in cssPersonalized)
    //                if (File.Exists($"{pathRoot}\\{wwwPath}\\{css}"))
    //                    html.Append(File.ReadAllText($"{pathRoot}\\{wwwPath}\\{css}"));
    //            html.AppendLine("</style>");
    //        }
    //        else
    //        {
    //            foreach (var css in cssPaths)
    //                html.AppendLine($"<link rel='stylesheet' href='{css}' />");
    //            foreach (var css in cssPersonalized)
    //                html.AppendLine($"<link rel='stylesheet' href='{css}' />");
    //        }


    //        html.AppendLine("</head>");
    //        html.AppendLine("<body>");
    //        html.AppendLine($"<div class='container-fluid'>{bodyInject}</div>");
    //        html.AppendLine("</body>");
    //        html.AppendLine("</html>");
    //        return html.ToString();
    //    }
    //    public byte[] CreateFile(string html, string htmlHeader = null, string htmlFooter = null)
    //    {
    //        byte[] result;
    //        if (!string.IsNullOrEmpty(htmlHeader))
    //        {
    //            PdfHtmlSection headerAdd = new PdfHtmlSection(createHTML(htmlHeader), baseUrl);
    //            headerAdd.AutoFitHeight = HtmlToPdfPageFitMode.AutoFit;
    //            converter.Options.DisplayHeader = true;
    //            converter.Header.DisplayOnFirstPage = true;
    //            converter.Header.DisplayOnEvenPages = true;
    //            converter.Header.DisplayOnOddPages = true;
    //            converter.Header.Height = headerSize;
    //            converter.Header.Add(headerAdd);
    //        }
    //        if (!string.IsNullOrEmpty(htmlFooter))
    //        {
    //            PdfHtmlSection footerAdd = new PdfHtmlSection(createHTML(htmlFooter), baseUrl);
    //            footerAdd.AutoFitHeight = HtmlToPdfPageFitMode.AutoFit;
    //            converter.Options.DisplayFooter = true;
    //            converter.Footer.DisplayOnFirstPage = true;
    //            converter.Footer.DisplayOnEvenPages = true;
    //            converter.Footer.DisplayOnOddPages = true;
    //            converter.Footer.Height = footerSize;
    //            converter.Footer.Add(footerAdd);
    //        }
    //        if (pageNumber)
    //        {
    //            PdfTextSection text = new PdfTextSection(0, 0, "{page_number} / {total_pages}", fontOriflame);
    //            text.HorizontalAlign = PdfTextHorizontalAlign.Right;
    //            converter.Options.DisplayHeader = true;
    //            converter.Header.Add(text);
    //        }
    //        document = converter.ConvertHtmlString(createHTML(html), baseUrl);
    //        result = document.Save();
    //        document.Close();
    //        return result;
    //    }
    //    public byte[] CreateFile(StringBuilder html, StringBuilder htmlHeader = null, StringBuilder htmlFooter = null) => CreateFile(html.ToString(), htmlHeader?.ToString() ?? null, htmlFooter?.ToString() ?? null);
    //    public string CreateBase64(string html, string htmlHeader = null, string htmlFooter = null)
    //    {
    //        byte[] data = CreateFile(html, htmlHeader, htmlFooter);

    //        return Convert.ToBase64String(data);
    //    }
    //    public string CreateBase64(StringBuilder html, StringBuilder htmlHeader = null, StringBuilder htmlFooter = null) => CreateBase64(html.ToString(), htmlHeader?.ToString() ?? null, htmlFooter?.ToString() ?? null);

    //}

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
        private string createHTML(string bodyInject, string styleBootstrap, string styleFonts, string styleReport)
        {
            StringBuilder html = new StringBuilder();
            html.AppendLine("<html lang='en'>");
            html.AppendLine("<head>");
            html.AppendLine("<meta charset='utf-8' />");
            html.AppendLine("<meta name='viewport' content='width=device-width, initial-scale=1.0' />");
            html.AppendLine($"<link rel='stylesheet' href='{styleBootstrap}'/>");
            html.AppendLine($"<link rel='stylesheet' href='{styleFonts}'/>");
            html.AppendLine($"<link rel='stylesheet' href='{styleReport}'/>");
            html.AppendLine("<style>");
            html.AppendLine("</style>");
            html.AppendLine("</head>");
            html.AppendLine("<body>");
            html.AppendLine($"<div class='container-fluid'>{bodyInject}</div>");
            html.AppendLine("</body>");
            html.AppendLine("</html>");
            return html.ToString();
        }
        public byte[] CreateFile(string html, string htmlHeader = null, string htmlFooter = null, string styleBootstrap = "", string styleFonts = "", string styleReport = "")
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
                PdfHtmlSection headerAdd = new PdfHtmlSection(createHTML(htmlHeader, styleBootstrap, styleFonts, styleReport), urlBase);
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
                PdfHtmlSection footerAdd = new PdfHtmlSection(createHTML(htmlFooter, styleBootstrap, styleFonts, styleReport), urlBase);
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

            document = converter.ConvertHtmlString(createHTML(html, styleBootstrap, styleFonts, styleReport), urlBase);
            result = document.Save();
            document.Close();
            return result;
        }
        public byte[] CreateFile(StringBuilder html, StringBuilder htmlHeader = null, StringBuilder htmlFooter = null, string styleBootstrap = "", string styleFonts = "", string styleReport = "") => CreateFile(html.ToString(), htmlHeader?.ToString() ?? null, htmlFooter?.ToString() ?? null, styleBootstrap, styleFonts, styleReport);
        public string CreateBase64(string html, string htmlHeader = null, string htmlFooter = null, string styleBootstrap = "", string styleFonts = "", string styleReport = "")
        {
            byte[] data = CreateFile(html, htmlHeader, htmlFooter, styleBootstrap, styleFonts, styleReport);

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