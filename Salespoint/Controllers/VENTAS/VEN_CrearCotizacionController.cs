using System;
using System.IO;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;
using System.Text;
using Salespoint.Class;
using SelectPdf;
using Ventas.Class;

using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using BE;
using GenesysOracleSV.Clases;

namespace Salespoint.Controllers.VENTAS
{
    public class VEN_CrearCotizacionController : Controller
    {
        // GET: VEN_CrearCotizacion
        public ActionResult Index()
        {
            return View();
        }

        public void SendMail()
        {
            string fromMail = "alejandrolopez445@gmail.com";
            string fromPassword = "xqauughsgosppmrm";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = "Test Subject";
            message.To.Add(new MailAddress("alejandrolopez445@gmail.com"));
            message.Body = "<html><body> Test Body </body></html>";
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
            };

            smtpClient.Send(message);
        }

        public static string UrlFile(string fileRoute)
        {

            string key = string.Empty;
            if (System.Configuration.ConfigurationManager.AppSettings["Index"] != null)
                key = System.Configuration.ConfigurationManager.AppSettings["Index"];

            return $"{key}{fileRoute}";
        }
        public ActionResult PDF2(string fechai = "", string fechaf = "")
        {
            try
            {

                fechai = "2023-02-01";
                fechaf = "2023-02-28";

                DateTime beginDate = Convert.ToDateTime(fechai);
                DateTime endDate = Convert.ToDateTime(fechaf);
                DateTime now = DateTime.Now;
                string urlStyle = UrlFile("Content/lib/bootstrap/dist/css/bootstrap.css");
                string urlFont = UrlFile("Content/lib/css/site.fonts.css");
                string urlStyleReport = UrlFile("Content/lib/css/site.reportes.css");
                StringBuilder html = new StringBuilder();
                StringBuilder header = new StringBuilder();
                StringBuilder footer = new StringBuilder();


                footer.AppendLine("<div class='row'>");
                footer.AppendLine("<div class='col-12 d-flex justify-content-between'>");
                footer.AppendLine($"<h6> <b> Usuario: </b> raul </h6>");
                footer.AppendLine($"<h6>  <b> Fecha: </b> {now.ToString("dd/MM/yyyy HH:mm:ss")} </h6>");
                footer.AppendLine("</div>");
                footer.AppendLine("</div>");

                header.AppendLine("<div class='row'>");
                header.AppendLine("<div class='col-12'>");
                header.AppendLine($"<table class='table table-sm table-borderless'>");
                header.AppendLine(" <tbody>");
                header.AppendLine("<tr>");
                header.AppendLine("<td colspan='6'>");
                header.AppendLine("<div class='row'>");
                header.AppendLine("<div class=' d-flex justify-content-center'><img src='' height='100' class='img-responsive' /></div>");
                header.AppendLine("<div class='col-12 mb-3'>");
                header.AppendLine($"<h1 class='m-0 p-0 d-flex justify-content-center'></h1>");
                header.AppendLine($"<h4 class='m-0 p-0 d-flex justify-content-center'></h3>");
                header.AppendLine($"<h4 class='m-0 p-0 d-flex d-flex justify-content-center'></h4>");
                header.AppendLine("</div>");
                header.AppendLine("</div>");

                header.AppendLine("</td>");
                header.AppendLine("</tr>");
                header.AppendLine("</tbody>");
                header.AppendLine("</table>");
                header.AppendLine("</div>");
                header.AppendLine("</div>");

                html.AppendLine($@"
                     <div class='row text-center justify-content-center' style='margin-top:-33px'>
                        <div class='col-12 col-sm-12 col-md-12'>
                            <table class='table table-sm' style='width:100%'>
                                <tbody>
                                    <tr>
                                        <td class='text-end border-0 pe-1'>{Utils.Fecha_Larga_Letras(DateTime.Now)}</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class='col-12 col-sm-12 col-md-12' style='margin-top:50px'>
                            <table class='table table-sm' style='width:100%; border:none'>
                                <tbody>
                                    <tr>
                                        <td class='border-0'>Señor(a)</td>
                                    </tr>
                                    <tr>
                                        <td class='ps-5 border-0'>Perla Blanco</td>
                                    </tr>
                                    <tr>
                                        <td class='border-0'>Oriflame</td>
                                    </tr>
                                    <tr>
                                        <td class='border-0'>Presente.-</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class='col-12 col-sm-11 col-md-11'>
                            <table class='table' style='width:100%'>
                                <tbody>
                                    <tr>
                                        <td style='text-align:justify' class='border-0'>
                                            Espero que al momento de recibir la presente cotización sus actividades se estén desarrollando
                                            con éxito, a continuación les detallo el trabajo solicitado esperando que nuestros costos se
                                            ajusten a su presupuesto. Cualquier duda o comentario estoy a sus órdenes.
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                    ");
                

                var doc = new PDFMaker(headerSize: 130).CreateBase64(html, header, footer);
                var file = new FileResult { File = doc, MimeType = "application/pdf", FileName = "Cortes Caja.pdf" };
                return Json(file);
            }
            catch
            {
                throw;
            }
        }
        public class FileResult
        {
            public string File { get; set; }
            public string FileName { get; set; }
            public string MimeType { get; set; }
        }


        public ActionResult PDF(int id_venta = 0)
        {
            //Get html
            System.Text.StringBuilder html = new System.Text.StringBuilder();
            html.AppendLine("<!DOCTYPE html>");
            html.AppendLine("<html>");
            html.AppendLine("<head>");
            html.AppendLine("<meta charset='utf-8' />");
            html.AppendLine(@"<link rel='stylesheet' href='https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css' integrity='sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm' crossorigin='anonymous'>");
            html.AppendLine("<script src='http://code.jquery.com/jquery-latest.min.js'></script>");
            html.AppendLine("</head>");
            html.AppendLine("<body class='pt-4' >");
            html.AppendLine($@"
            <div class='row' style='font-size:45px'>                
                <div class='form-group col-md-7 text-center' style='margin-top:30px'>
                    <div class='row'>
                        <div class='form-group col-md-12'>
                            <h6 style='font-size:25px'>DISTRIBUIDORA DE REPUESTOS EL EDEN</h6>
                        </div>
                        <div class='form-group col-md-12'>
                            <h6 style='font-size:22px; margin-top:-20px'>CALZADA EL MOSQUITO 2-05 ZONA 3 SAN PEDRO SACATEPEQUEZ, SAN MARCOS</h6>
                        </div>
                        <div class='form-group col-md-12'>
                            <h6 style='font-size:22px; margin-top:-20px'>NIT: 74974324</h6>
                        </div>
                        <div class='form-group col-md-12'>
                            <h6 style='font-size: 22px; margin-top:-20px'>7760-8499</h6>
                        </div>
                    </div>
                </div>
            </div>
            <div class='row' style='font-size:20px'>
                <div class='col-md-12 pl-5' style='margin-top:5px'>
                    <b>ÓRDEN DE COMPRA:</b> {id_venta}<br>
                    <b>SERIE:</b> {54874}<br>
                </div>
            </div>
            <div class='col-12 pt-4' style='font-size:18px'>
                <table class='table table-sm' id='tdDatos'>
                    <thead>
                        <tr style=''>
                            <th class='pl-2 pr-2 border text-center' style='vertical-align:middle; border: 1px solid'>CANTIDAD</th>
                            <th class='pl-2 pr-2 border text-center' style='vertical-align:middle; border: 1px solid'>DESCRIPCIÓN</th>
                            <th class='pl-2 pr-2 border text-center' style='vertical-align:middle; border: 1px solid'>PRECIO UNITARIO</th>
                            <th class='pl-2 pr-2 border text-center' style='vertical-align:middle; border: 1px solid'>DESCUENTO</th>
                            <th class='pl-2 pr-2 border text-center' style='vertical-align:middle; border: 1px solid'>TOTAL SIN DESCUENTO</th>
                            <th class='pl-2 pr-2 border text-center' style='vertical-align:middle; border: 1px solid'>TOTAL CON DESCUENTO</th>
                        </tr>
                    </thead>
                    <tbody id='tbodyListado'>");


            html.AppendLine("<tr>");
            html.AppendLine($"<td class='text-center' style='border-bottom: 1px solid'>{32}</td>");
            html.AppendLine($"<td class='text-left' style='border-bottom: 1px solid'>lkasjd</td>");
            html.AppendLine($"<td class='text-right' style='border-bottom: 1px solid'>{654.1}</td>");
            html.AppendLine($"<td class='text-right' style='border-bottom: 1px solid'>{0}</td>");
            html.AppendLine($"<td class='text-right' style='border-bottom: 1px solid'>{324965}</td>");
            html.AppendLine($"<td class='text-right' style='border-bottom: 1px solid'>{54}</td>");
            html.AppendLine("</tr>");

            html.AppendLine($@"</tbody>
                </table>
            </div>
            <div class='row' style='font-size:20px'>
                <div class='col-md-12 pl-5 text-center'>
                    <b>TOTAL SIN DESCUENTO :</b> <span class='font-weight-bold pl-2' style='font-size:22px'> Q{654}</span><br>
                    <b>DESCUENTO:</b> <span class='font-weight-bold pl-2' style='font-size:22px'> Q{654}</span><br>
                    <b>TOTAL A PAGAR:</b><span class='font-weight-bold pl-2'  style='font-size:22px'> Q{654}</span><br>
                    <b>TOTAL EN LETRAS: </b> {new NumeroLetra().Convertir("2164", true)}<br>
                </div>
            </div>
            <div class='row pt-5'>
                <div class='col-md-12 text-center border-dark border-top'>
                   
                </div>
            </div>");
            html.AppendLine("</body>");
            html.AppendLine("</html>");
            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();
            converter.Options.PdfPageSize = PdfPageSize.Letter;
            converter.Options.PdfPageOrientation = PdfPageOrientation.Portrait;
            converter.Options.WebPageWidth = 1400;
            converter.Options.WebPageHeight = 600;

            converter.Options.MarginBottom = 30;
            converter.Options.MarginTop = 30;
            converter.Options.MarginLeft = 7;
            converter.Options.MarginRight = 7;

            // create a new pdf document converting an html
            PdfDocument doc = converter.ConvertHtmlString(html.ToString());

            //Save memory
            MemoryStream fileStream = new MemoryStream();
            doc.Save(fileStream);
            doc.Close();

            string file64 = Convert.ToBase64String(fileStream.ToArray());
            var file = new { File = file64, MimeType = "application/pdf", FileName = $"Comprobante.pdf" };
            return Json(file);
        }

        public JsonResult GetCliente(int tipo = 0, string nit = "")
        {
            try
            {
                nit = nit.Replace("-", "");
                nit = nit.Replace("/", "");

                var item = new Ventas_BE();
                var itemCliente = new Clientes_BE();
                List<Clientes_BE> listaCliente = new List<Clientes_BE>();

                item.MTIPO = tipo;
                item.NIT = nit.Trim();
                item = Connect.Connect_Ventas(item).FirstOrDefault();

                if (item == null && tipo == 2 && nit != "")
                {
                    var datos_contribuyente = Certificador_FEL.Get_Datos_Contribuyente(nit);
                    if (datos_contribuyente.nombre != "")
                    {
                        itemCliente.NOMBRE = datos_contribuyente.nombre.Replace(",,", ", ");
                        itemCliente.DIRECCION = "CIUDAD";
                        itemCliente.TELEFONO = "";
                        itemCliente.EMAIL = "";
                        itemCliente.NIT = datos_contribuyente.nit;
                        itemCliente.CREADO_POR = Session["usuario"].ToString();
                        itemCliente.MTIPO = 1;
                        listaCliente = Connect.Connect_Clientes(itemCliente);
                    }

                    if (listaCliente != null)
                    {
                        item = new Ventas_BE();
                        item.MTIPO = tipo;
                        item.NIT = nit.Trim();
                        item = Connect.Connect_Ventas(item).FirstOrDefault();
                    }
                }
                return Json(new { State = 1, data = item }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { State = -1, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetClienteID(int tipo = 0, int id = 0)
        {
            try
            {
                var item = new Ventas_BE();
                item.MTIPO = tipo;
                item.ID_CLIENTE = id;
                item = Connect.Connect_Ventas(item).FirstOrDefault();
                return Json(new { State = 1, data = item }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { State = -1, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetCatalogo()
        {
            try
            {
                var item = new Catalogo_BE();
                List<Catalogo_BE> lista = new List<Catalogo_BE>();
                item.MTIPO = 1;
                lista= Connect.Connect_Catalogo(item);

                return Json(new { State = 1, data = lista }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { State = -1, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        private bool SaveHeader(int idVenta = 0, string serie = "", decimal correlativo = 0, int idCliente = 0, decimal total = 0, decimal descuento = 0, decimal subtotal = 0, string usuario = "", int fel = 0, int esCredito = 0)
        {
            bool respuesta = false;
            var item = new Ventas_BE();
            item.MTIPO = 4;
            item.ID_VENTA = idVenta;
            item.SERIE = serie;
            item.CORRELATIVO = correlativo;
            item.ID_CLIENTE = idCliente;
            item.TOTAL = total;
            item.SUBTOTAL = subtotal;
            item.TOTAL_DESCUENTO = descuento;
            item.CREADO_POR = usuario;
            item.FEL = fel;
            item.ID_PRODUCTO = esCredito;
            var resultHeader = Connect.Connect_Ventas(item);

            if (resultHeader != null)
            {
                if (resultHeader.FirstOrDefault().CODIGO_RESPUESTA == "01")
                    respuesta = true;
            }
            else
                respuesta = false;

            return respuesta;
        }
        private bool SaveDetail(int idVenta = 0, int idProducto = 0, int cantidad = 0, decimal precio = 0, decimal total = 0, decimal descuento = 0, decimal subtotal = 0)
        {
            bool respuesta = false;
            var item = new Ventas_BE();
            item.MTIPO = 5;
            item.ID_VENTA = idVenta;
            item.ID_PRODUCTO = idProducto;
            item.CANTIDAD = cantidad;
            item.PRECIO_VENTA = precio;
            item.TOTAL = total;
            item.TOTAL_DESCUENTO = descuento;
            item.SUBTOTAL = subtotal;
            var resultDetail = Connect.Connect_Ventas(item);

            if (resultDetail != null)
            {
                if (resultDetail.FirstOrDefault().CODIGO_RESPUESTA == "01")
                    respuesta = true;
            }
            else
                respuesta = false;

            return respuesta;
        }
        private bool DeleteOrder(int idVenta = 0)
        {
            bool respuesta = false;
            var item = new Ventas_BE();
            item.MTIPO = 6;
            item.ID_VENTA = idVenta;
            var resultDetail = Connect.Connect_Ventas(item);

            if (resultDetail != null)
            {
                if (resultDetail.FirstOrDefault().CODIGO_RESPUESTA == "01")
                    respuesta = true;
            }
            else
                respuesta = false;

            return respuesta;
        }
        public void SaveOrder(string encabezado = "", string detalles = "", int fel = 0, int esCredito = 0)
        {
                var item = JsonConvert.DeserializeObject<Ventas_BE>(encabezado);
                List<Ventas_BE> listaDetalles = JsonConvert.DeserializeObject<List<Ventas_BE>>(detalles);
                string usuario = Session["usuario"].ToString();
                item.CREADO_POR = usuario;                
                bool banderaDetail = false;

                var itemID = new Ventas_BE();
                itemID.MTIPO = 6;
                item.ID_VENTA = Connect.Connect_Ventas(item).FirstOrDefault().ID_VENTA;

                if (SaveHeader(Convert.ToInt32(item.ID_VENTA), "", 1, item.ID_CLIENTE, item.TOTAL, item.TOTAL_DESCUENTO, item.SUBTOTAL, usuario, fel, esCredito) == true)
                {
                    foreach (var row in listaDetalles)
                    {
                        if (banderaDetail == false)
                        {
                            if (SaveDetail(Convert.ToInt32(item.ID_VENTA), row.ID_PRODUCTO, row.CANTIDAD, row.PRECIO_VENTA, row.TOTAL, row.TOTAL_DESCUENTO, row.SUBTOTAL) == false)
                            {
                                DeleteOrder(Convert.ToInt32(item.ID_VENTA));
                                banderaDetail = true;
                            }
                        }
                    }
                }
        }
    
     public PartialViewResult Catalogo()
        {
            var item = new Catalogo_BE();
            List<Catalogo_BE> lista = new List<Catalogo_BE>();
            item.MTIPO = 1;
            lista = Connect.Connect_Catalogo(item);

            ViewBag.data = lista;
            ViewBag.item = lista.FirstOrDefault();
            return PartialView();
        }
    }
}