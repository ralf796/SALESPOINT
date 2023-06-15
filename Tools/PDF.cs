using SelectPdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class PDF
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (document != null)
                document = null;
        }
        readonly string? baseUrl = null;
        readonly string wwwPath = "wwwroot";
        readonly List<string> cssRefs = new List<string>() {
        "https://d1aabelff4cltc.cloudfront.net/bootstrap/dist/css/bootstrap.min.css",
        "https://d1aabelff4cltc.cloudfront.net/fontawesome/css/all.min.css"
        };
        readonly List<string> cssPaths = new List<string>() {
        "css/site.fonts.css",
        "css/site.reportes.css"
        };
        List<string> cssPersonalized;
        string cssCode;
        List<string> cssFullList
        {
            get
            {
                List<string> result = new List<string>();
                result.AddRange(cssPaths);
                result.AddRange(cssPersonalized);
                return result;
            }
        }
        List<string> scriptList;
        string scriptCode;

        int headerSize { get; set; } = 25;
        int footerSize { get; set; } = 25;
        int delayProcess { get; set; } = 3;
        bool pageNumber { get; set; } = true;
        HtmlToPdfOptions optionsSetup { get; set; }
        HtmlToPdf converter { get; set; }
        PdfDocument? document { get; set; }
        Font? fontOriflame
        {
            get
            {
                if (OperatingSystem.IsWindows())
                    return new Font("Oriflame Sans Print", 8);
                else
                    return null;
            }
        }
        public PDF(int? headerSize = null, int? footerSize = null, bool? pageNumber = true)
        {
            //GlobalProperties.LicenseKey = "8drA0cPEwNHAwcHRw8HfwdHCwN/Aw9/IyMjI";

            cssPersonalized = new List<string>();
            cssCode = string.Empty;
            scriptList = new List<string>();
            scriptCode = string.Empty;

            if (headerSize != null)
                this.headerSize = headerSize.Value;
            if (footerSize != null)
                this.footerSize = footerSize.Value;
            if (pageNumber != null)
                this.pageNumber = pageNumber.Value;
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
            this.converter.Options.MinPageLoadTime = this.delayProcess;
            this.converter.Options.MaxPageLoadTime = 600;
        }
        /// <summary>
        /// Metodo para establecer el alto del encabezado de pagina del documento
        /// </summary>
        /// <param name="size">Valor de entero</param>
        public void HeaderSize(int size)
        {
            this.headerSize = size;
        }
        /// <summary>
        /// Metodo para establecer el alto del pie de pagina del documento
        /// </summary>
        /// <param name="size">Valor de entero</param>
        public void FooterSize(int size)
        {
            this.footerSize = size;
        }
        /// <summary>
        /// Metodo para habilitar la sección de número de pagina 
        /// </summary>
        /// <param name="display">Valor true o false</param>
        public void PageNumber(bool display)
        {
            this.pageNumber = display;
        }
        /// <summary>
        /// Metodo para asignar el tiempo de espera para generar el documento
        /// </summary>
        /// <param name="delay">Cantidad de tiempo en segundos (default:3)</param>
        public void DelayProcess(int delay)
        {
            this.delayProcess = delay;
            this.converter.Options.MinPageLoadTime = this.delayProcess;
        }
        public void PageOrientation(PdfPageOrientation orientation)
        {
            this.converter.Options.PdfPageOrientation = orientation;
        }
        /// <summary>
        /// Metodo para agregar una lista de referencias CSS
        /// </summary>
        /// <param name="ListCSS">Lista de links de acceso a los recursos (https://)</param>
        public void AddCSS(List<string> ListCSS)
        {
            cssPersonalized = ListCSS;
        }
        /// <summary>
        /// Metodo para agregar una referencia a CSS
        /// </summary>
        /// <param name="css">Link web de acceso al recurso</param>
        public void AddCSS(string css)
        {
            cssPersonalized.Add(css);
        }
        public void AddCssCode(string cssCode)
        {
            this.cssCode = cssCode;
        }
        /// <summary>
        /// Metodo para agregar las referencias de scripts web
        /// </summary>
        /// <param name="ListScript">Lista de Scripts cada item debe ser web (https://)</param>
        public void AddScripts(List<string> ListScript)
        {
            this.scriptList = ListScript;
        }
        /// <summary>
        /// Metodo para agregar las referencias de forma individual de scripts web, debe iniciar con https
        /// </summary>
        /// <param name="script">Link de referencia a la libreria debe ser web (https://)</param>
        public void AddScripts(string script)
        {
            scriptList.Add(script);
        }
        /// <summary>
        /// Metodo para insertar scripts, requiere los tags <script></script>
        /// </summary>
        /// <param name="scriptCode">Código a insertar en el pie de documento, no debe contener los tag <script></script></param>
        public void AddScriptCode(string scriptCode)
        {
            this.scriptCode = scriptCode;
        }
        private void generateHeadStyles(ref StringBuilder html)
        {
            foreach (var css in cssRefs)
                html.AppendLine($"<link rel='stylesheet' href='{css}' />");

            var pathRoot = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (pathRoot != null && pathRoot.Contains("\\bin"))
                pathRoot = pathRoot.Substring(0, pathRoot.IndexOf("\\bin"));

            if (Directory.Exists($"{pathRoot}\\{wwwPath}"))
            {
                html.AppendLine("<style>");
                foreach (string css in cssFullList)
                    if (System.IO.File.Exists($"{pathRoot}\\{wwwPath}\\{css}"))
                        html.Append(System.IO.File.ReadAllText($"{pathRoot}\\{wwwPath}\\{css}"));
                html.AppendLine("</style>");
            }
            else
            {
                foreach (var css in cssFullList)
                    html.AppendLine($"<link rel='stylesheet' href='{css}' />");
            }

            if (!string.IsNullOrEmpty(cssCode))
                html.AppendLine(cssCode);
        }
        /// <summary>
        /// Metodo para generar PDF
        /// </summary>
        /// <param name="html">Contenido del Body del PDF</param>
        /// <param name="htmlHeader">Contenido del Header del PDF</param>
        /// <param name="htmlFooter">Contenido del Footer del PDF</param>
        /// <returns>Retorna el PDF en bytes para su exportación</returns>
        public byte[] CreateFile(string html, string? htmlHeader = null, string? htmlFooter = null)
        {
            byte[] result;
            if (!string.IsNullOrEmpty(htmlHeader))
            {
                PdfHtmlSection headerAdd = new PdfHtmlSection(createHTML(htmlHeader), baseUrl);
                headerAdd.AutoFitHeight = HtmlToPdfPageFitMode.AutoFit;
                converter.Options.DisplayHeader = true;
                converter.Header.DisplayOnFirstPage = true;
                converter.Header.DisplayOnEvenPages = true;
                converter.Header.DisplayOnOddPages = true;
                converter.Header.Height = headerSize;
                converter.Header.Add(headerAdd);
            }
            if (!string.IsNullOrEmpty(htmlFooter))
            {
                PdfHtmlSection footerAdd = new PdfHtmlSection(createHTML(htmlFooter), baseUrl);
                footerAdd.AutoFitHeight = HtmlToPdfPageFitMode.AutoFit;
                converter.Options.DisplayFooter = true;
                converter.Footer.DisplayOnFirstPage = true;
                converter.Footer.DisplayOnEvenPages = true;
                converter.Footer.DisplayOnOddPages = true;
                converter.Footer.Height = footerSize;
                converter.Footer.Add(footerAdd);
            }
            if (pageNumber)
            {
                PdfTextSection text = new PdfTextSection(0, 0, "{page_number} / {total_pages}", fontOriflame);
                text.HorizontalAlign = PdfTextHorizontalAlign.Right;
                converter.Options.DisplayHeader = true;
                converter.Header.Add(text);
            }

            if (html.Length > 750000)
            {
                this.delayProcess = 10;
                this.converter.Options.MinPageLoadTime = this.delayProcess;
            }
            document = converter.ConvertHtmlString(createHTML(html, true), baseUrl);
            result = document.Save();
            document.Close();
            return result;
        }
        /// <summary>
        /// Metodo para generar PDF
        /// </summary>
        /// <param name="html">Contenido del Body del PDF</param>
        /// <param name="htmlHeader">Contenido del Header del PDF</param>
        /// <param name="htmlFooter">Contenido del Footer del PDF</param>
        /// <returns>Retorna el PDF en bytes para su exportación</returns>
        public byte[] CreateFile(StringBuilder html, StringBuilder? htmlHeader = null, StringBuilder? htmlFooter = null) => CreateFile(html.ToString(), htmlHeader?.ToString(), htmlFooter?.ToString());
        /// <summary>
        /// Metodo para generar PDF
        /// </summary>
        /// <param name="html">Contenido del Body del PDF</param>
        /// <param name="htmlHeader">Contenido del Header del PDF</param>
        /// <param name="htmlFooter">Contenido del Footer del PDF</param>
        /// <returns>Retorna el PDF en base64 para su exportación</returns>
        public string CreateBase64(string html, string? htmlHeader = null, string? htmlFooter = null)
        {
            byte[] data = CreateFile(html, htmlHeader, htmlFooter);

            return Convert.ToBase64String(data);
        }
        /// <summary>
        /// Metodo para generar PDF
        /// </summary>
        /// <param name="html">Contenido del Body del PDF</param>
        /// <param name="htmlHeader">Contenido del Header del PDF</param>
        /// <param name="htmlFooter">Contenido del Footer del PDF</param>
        /// <returns>Retorna el PDF en base64 para su exportación</returns>
        public string CreateBase64(StringBuilder html, StringBuilder? htmlHeader = null, StringBuilder? htmlFooter = null) => CreateBase64(html.ToString(), htmlHeader?.ToString(), htmlFooter?.ToString());
        /// <summary>
        /// Metodo para obtener el html generado en el render
        /// </summary>
        /// <param name="html">Contenido del PDF a generar</param>
        /// <param name="isBody">Indica si se deben insertar los scripts del usuario</param>
        /// <returns></returns>
        public string DebugHTML(string html, bool isBody = false)
        {
            return createHTML(html, isBody);
        }
        private string createHTML(string bodyInject, bool isBody = false)
        {
            StringBuilder html = new StringBuilder();
            html.AppendLine("<html lang='en'>");
            html.AppendLine("<head>");
            html.AppendLine("<meta charset='utf-8' />");
            html.AppendLine("<meta name='viewport' content='width=device-width, initial-scale=1.0' />");
            generateHeadStyles(ref html);
            html.AppendLine("</head>");
            html.AppendLine("<body>");
            html.AppendLine($"<div class='container-fluid'>{bodyInject}</div>");

            if (isBody && scriptList != null && scriptList.Count > 0)
            {
                foreach (var script in scriptList)
                    html.AppendLine($"<script src='{script}'></script>");
            }
            if (isBody && !string.IsNullOrEmpty(scriptCode))
                html.AppendLine(scriptCode);

            html.AppendLine("</body>");
            html.AppendLine("</html>");
            return html.ToString();
        }
    }
}
