using HELPERS;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using System.Linq;

namespace RESTAURANTE
{
    public class PED_MeseroCreaController : Controller
    {
        [SessionExpireFilter]
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Get_Mesas()
        {
            var item = new Pedido_BE();
            item.MTIPO = 5;
            List<Pedido_BE> lista;
            lista = Connect.Connect_Pedido(item);
            ViewBag.data = lista;
            return PartialView();
        }

        public PartialViewResult Get_Categorias()
        {
            var item = new Pedido_BE();
            item.MTIPO = 6;
            List<Pedido_BE> lista;
            lista = Connect.Connect_Pedido(item);
            ViewBag.data = lista;
            return PartialView();
        }

        public PartialViewResult Get_Productos(int id_categoria = 0)
        {
            var item = new Pedido_BE();
            item.MTIPO = 7;
            item.ID_CATEGORIA = id_categoria;
            List<Pedido_BE> lista;
            lista = Connect.Connect_Pedido(item);
            ViewBag.data = lista;
            return PartialView();
        }

        public PartialViewResult Get_DetallesMesa(int id_mesa = 0)
        {
            var item = new Pedido_BE();
            item.MTIPO = 4;
            item.ID_MESA = id_mesa;
            item.CREADO_POR = Session["usuario"].ToString();

            List<Pedido_BE> lista;
            lista = Connect.Connect_Pedido(item);
            ViewBag.data = lista;
            return PartialView();
        }

        public JsonResult DeshabilitarMesa(int id_mesa = 0)
        {
            var respuesta = new Respuesta();
            try
            {
                List<Pedido_BE> RESULT_SP;
                var item = new Pedido_BE();
                item.MTIPO = 8;
                item.ID_MESA = id_mesa;
                RESULT_SP = Connect.Connect_Pedido(item);

                if (RESULT_SP.Count == 0)
                {
                    respuesta.Codigo = 2;
                    respuesta.Descripcion = "No se ha podido deshabilitar la mesa.";
                }
                else
                {
                    respuesta.Codigo = 1;
                    respuesta.Descripcion = "Mesa deshabilitada correctamente";
                }
            }
            catch (Exception ex)
            {
                respuesta.Codigo = -1;
                respuesta.Descripcion = $"Mensaje: {ex.Message}";
            }
            return Json(respuesta);
        }

        public JsonResult HabilitarMesa(int id_mesa = 0)
        {
            var respuesta = new Respuesta();
            try
            {
                List<Pedido_BE> RESULT_SP;
                var item = new Pedido_BE();
                item.MTIPO = 9;
                item.ID_MESA = id_mesa;
                RESULT_SP = Connect.Connect_Pedido(item);

                if (RESULT_SP.Count == 0)
                {
                    respuesta.Codigo = 2;
                    respuesta.Descripcion = "No se ha podido habilitar la mesa.";
                }
                else
                {
                    respuesta.Codigo = 1;
                    respuesta.Descripcion = "Mesa habilitada correctamente";
                }
            }
            catch (Exception ex)
            {
                respuesta.Codigo = -1;
                respuesta.Descripcion = $"Mensaje: {ex.Message}";
            }
            return Json(respuesta);
        }

        [SessionExpireFilter]
        public JsonResult Create_DetalleMesa(int id_mesa = 0, int id_producto = 0, int cantidad = 0, string observaciones = "")
        {
            var respuesta = new Respuesta();
            try
            {
                List<Pedido_BE> RESULT_SP;
                var item = new Pedido_BE();
                item.MTIPO = 1;
                item.ID_MESA = id_mesa;
                item.ID_PRODUCTO = id_producto;
                item.CANTIDAD = cantidad;
                item.OBSERVACIONES = observaciones;
                item.CREADO_POR = Session["usuario"].ToString();
                RESULT_SP = Connect.Connect_Pedido(item);

                if (RESULT_SP.Count == 0)
                {
                    respuesta.Codigo = 2;
                    respuesta.Descripcion = "No se ha podido agregar el detalle.";
                }
                else
                {
                    respuesta.Codigo = 1;
                    respuesta.Descripcion = "Se agregó correctamente";
                }
            }
            catch (Exception ex)
            {
                respuesta.Codigo = -1;
                respuesta.Descripcion = $"Mensaje: {ex.Message}";
            }
            return Json(respuesta);
        }

        [SessionExpireFilter]
        public JsonResult Update_DetalleMesa_Observaciones(int id_mesa_menu = 0, string observaciones = "")
        {
            var respuesta = new Respuesta();
            try
            {
                List<Pedido_BE> RESULT_SP;
                var item = new Pedido_BE();
                item.MTIPO = 2;
                item.ID_MESA_MENU = id_mesa_menu;
                item.OBSERVACIONES = observaciones;
                item.CREADO_POR = Session["usuario"].ToString();
                RESULT_SP = Connect.Connect_Pedido(item);

                if (RESULT_SP.Count == 0)
                {
                    respuesta.Codigo = 2;
                    respuesta.Descripcion = "No se ha podido actualizar la observación.";
                }
                else
                {
                    respuesta.Codigo = 1;
                    respuesta.Descripcion = "Observación actualizada correctamente";
                }
            }
            catch (Exception ex)
            {
                respuesta.Codigo = -1;
                respuesta.Descripcion = $"Mensaje: {ex.Message}";
            }
            return Json(respuesta);
        }

        [SessionExpireFilter]
        public JsonResult Delete_DetalleMesa(int id_mesa_menu = 0)
        {
            var respuesta = new Respuesta();
            try
            {
                List<Pedido_BE> RESULT_SP;
                var item = new Pedido_BE();
                item.MTIPO = 3;
                item.ID_MESA_MENU = id_mesa_menu;
                item.CREADO_POR = Session["usuario"].ToString();
                RESULT_SP = Connect.Connect_Pedido(item);

                if (RESULT_SP.Count == 0)
                {
                    respuesta.Codigo = 2;
                    respuesta.Descripcion = "No se ha podido eliminar el menu.";
                }
                else
                {
                    respuesta.Codigo = 1;
                    respuesta.Descripcion = "Menu eliminado correctamente";
                }
            }
            catch (Exception ex)
            {
                respuesta.Codigo = -1;
                respuesta.Descripcion = $"Mensaje: {ex.Message}";
            }
            return Json(respuesta);
        }

        [SessionExpireFilter]
        public JsonResult Create_Pedido(int id_mesa = 0)
        {
            var respuesta = new Respuesta();
            try
            {
                List<Pedido_BE> RESULT_SP;
                string usuario = Session["usuario"].ToString();
                var item_Encabezado = new Pedido_BE();
                item_Encabezado.MTIPO = 12;
                item_Encabezado.ID_MESA = id_mesa;
                item_Encabezado.CREADO_POR = usuario;
                item_Encabezado.ID_TIPO_PEDIDO = 1;
                RESULT_SP = Connect.Connect_Pedido(item_Encabezado);

                if (RESULT_SP.Count == 0)
                {
                    respuesta.Resultado = false;
                    respuesta.Codigo = 0;
                    respuesta.Descripcion = "No se ha podido crear el encabezado del pedido.";
                }
                else
                {
                    //item_Encabezado.MTIPO = 13;
                    //RESULT_SP = Connect.Connect_Pedido(item_Encabezado);

                    respuesta.Codigo = RESULT_SP.FirstOrDefault().ID_PEDIDO_ENCABEZADO;
                    respuesta.Descripcion = "Pedido creado correctamente.";
                    respuesta.Resultado = true;
                }
            }
            catch (Exception ex)
            {
                respuesta.Codigo = -1;
                respuesta.Descripcion = $"Mensaje: {ex.Message}";
                respuesta.Resultado = false;
            }
            return Json(respuesta);
        }

        [SessionExpireFilter]
        public JsonResult Update_Pedido(int id_mesa = 0)
        {
            var respuesta = new Respuesta();
            try
            {
                List<Pedido_BE> RESULT_SP;
                string usuario = Session["usuario"].ToString();
                var item_Encabezado = new Pedido_BE();
                item_Encabezado.MTIPO = 14;
                item_Encabezado.ID_MESA = id_mesa;
                item_Encabezado.CREADO_POR = usuario;
                RESULT_SP = Connect.Connect_Pedido(item_Encabezado);

                if (RESULT_SP.Count == 0)
                {
                    respuesta.Codigo = 2;
                    respuesta.Descripcion = "No se ha podido actualizar el pedido.";
                }
                else
                {
                    item_Encabezado.MTIPO = 13;
                    RESULT_SP = Connect.Connect_Pedido(item_Encabezado);

                    respuesta.Codigo = 1;
                    respuesta.Descripcion = "Pedido actualizado correctamente.";
                }
            }
            catch (Exception ex)
            {
                respuesta.Codigo = -1;
                respuesta.Descripcion = $"Mensaje: {ex.Message}";
            }
            return Json(respuesta);
        }

        public ActionResult Ticket(int idPedido)
        {
            var pgSize = new iTextSharp.text.Rectangle(210, 1000);
            //Document document = new Document(pgSize, 5f, 5f, 20f, 20f);
            Document document = new Document(pgSize, 5f, 5f, 0, 0);
            MemoryStream stream = new MemoryStream();

            try
            {
                List<Pedido_BE> lista;
                Pedido_BE HeaderPedido;
                string usuario = Session["usuario"].ToString();
                var item = new Pedido_BE();
                item.MTIPO = 18;
                item.ID_PEDIDO_ENCABEZADO = idPedido;
                item.CREADO_POR = usuario;
                lista = Connect.Connect_Pedido(item);

                PdfWriter pdfWriter = PdfWriter.GetInstance(document, stream);
                pdfWriter.CloseStream = false;

                Font fontTitle = new Font(family: Font.FontFamily.HELVETICA, size: 14, style: Font.BOLD);
                Font fontCantidad = new Font(family: Font.FontFamily.HELVETICA, size: 12);
                Font fontMenu = new Font(family: Font.FontFamily.HELVETICA, size: 12);
                Font fontObservacion = new Font(family: Font.FontFamily.HELVETICA, size: 10);
                Font fontHeader = new Font(family: Font.FontFamily.HELVETICA, size: 9, style: Font.BOLD);
                Font fontFooter = new Font(family: Font.FontFamily.HELVETICA, size: 9, style: Font.BOLD);

                string textPedido = $"Pedido # {idPedido}                       ";
                int cont = textPedido.Length;

                var redListTextFont = FontFactory.GetFont("Helvetica", 15, BaseColor.WHITE);

                var chunkPedido = new Chunk(textPedido, redListTextFont);
                chunkPedido.SetBackground(new BaseColor(0, 0, 0));

                document.Open();
                document.Add(new Paragraph(chunk: chunkPedido));
                document.Add(new Paragraph("_____________________________"));
                document.Add(new Paragraph("       CANTIDAD   -   MENU", fontTitle));
                foreach (var row in lista)
                {
                    document.Add(new Paragraph("- - - - - - - - - - - - - - - - - - - - - - - - - - -"));
                    document.Add(new Paragraph($" {row.CANTIDAD} - {row.DESCRIPCION} {row.OBSERVACIONES}", fontMenu));
                }
                document.Add(new Paragraph("_____________________________"));
                if (lista.Count > 0)
                {
                    HeaderPedido = lista.FirstOrDefault();
                    document.Add(new Paragraph($"Mesero: {HeaderPedido.CREADO_POR.ToUpper()}", fontFooter));
                    document.Add(new Paragraph($"Mesa: {HeaderPedido.ID_MESA}", fontFooter));
                }
                document.Add(new Paragraph($"Hora: {DateTime.Now.ToString("HH:mm:ss")}", fontFooter));
            }
            catch (DocumentException de)
            {
                Console.Error.WriteLine(de.Message);
            }
            catch (IOException ioe)
            {
                Console.Error.WriteLine(ioe.Message);
            }

            document.Close();

            stream.Flush(); //Always catches me out
            stream.Position = 0; //Not sure if this is required

            return File(stream, "application/pdf", "DownloadName.pdf");
        }

        public void SetBackgroundItext(Chunk chunk, string text)
        {
            var TextFont = FontFactory.GetFont("Arial", 14, BaseColor.WHITE);
            var fuente = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, iTextSharp.text.Font.UNDERLINE);
            //chunk = new Chunk("      CANTIDAD   -   MENU         ", redListTextFont);
            chunk = new Chunk($"{chunk}", fuente);
            chunk.SetBackground(new BaseColor(0, 0, 0));
        }

    }
}
