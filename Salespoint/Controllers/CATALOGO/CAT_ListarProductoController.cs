using BE;
using GenesysOracleSV.Clases;
using OfficeOpenXml;
using Salespoint.Class;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Salespoint.Controllers.INVENTARIO
{
    public class CAT_ListarProductoController : Controller
    {
        // GET: INV_Listar
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Listar()
        {
            var item = new Catalogo_BE();
            item.MTIPO = 1;
            List<Catalogo_BE> lista;
            lista = Connect.Connect_Producto(item);
            ViewBag.data = lista;
            return PartialView();
        }

        public PartialViewResult ListarCategorias()
        {
            var item = new Catalogo_BE();
            item.MTIPO = 5;
            List<Catalogo_BE> lista;
            lista = Connect.Connect_Producto(item);
            ViewBag.lista = lista;
            return PartialView();
        }

        [SessionExpireFilter]
        public JsonResult Guardar(FormCollection formCollection)
        {
            var respuesta = new Respuesta();
            try
            {
                string NOMBRE = Request.Form["NOMBRE"].ToString();
                string DESCRIPCION = Request.Form["DESCRIPCION"].ToString();
                int ID_CATEGORIA = Convert.ToInt32(Request.Form["ID_CATEGORIA"].ToString());
                decimal PRECIO_COSTO = Convert.ToDecimal(Request.Form["PRECIO_COSTO"].ToString());
                decimal PRECIO_VENTA = Convert.ToDecimal(Request.Form["PRECIO_VENTA"].ToString());
                int STOCK = Convert.ToInt32(Request.Form["STOCK"].ToString());
                decimal MARGEN = Convert.ToDecimal(Request.Form["MARGEN"].ToString());
                decimal TAMANIO = Convert.ToDecimal(Request.Form["TAMANIO"].ToString());
                decimal PROFUNDIDAD = Convert.ToDecimal(Request.Form["PROFUNDIDAD"].ToString());

                var randomNumber = new Random().Next(0, 100);
                string path = "", PATH_IMG = "";

                HttpPostedFileBase file = Request.Files["PATH_IMG"];
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    string fileName = file.FileName;
                    string[] separarNombre = fileName.Split('.');
                    Bitmap filee = new Bitmap(file.InputStream);

                    string directory = Server.MapPath(@"~\Content\Fotos_Productos");
                    if (!Directory.Exists(fileName))
                        Directory.CreateDirectory(directory);

                    path = Server.MapPath(@"~\Content\Fotos_Productos\" + separarNombre[0] + randomNumber + ".png");
                    filee.Save(path);

                    var urlBuilder = new System.UriBuilder(Request.Url.AbsoluteUri) { Path = Url.Content(@"~\Content\Fotos_Productos\" + separarNombre[0] + randomNumber + ".png"), Query = null, };
                    PATH_IMG = urlBuilder.ToString();
                }

                List<Catalogo_BE> RESULT_SP;
                Catalogo_BE item = new Catalogo_BE
                {
                    MTIPO = 2,
                    NOMBRE = NOMBRE,
                    DESCRIPCION = DESCRIPCION,
                    ID_CATEGORIA = ID_CATEGORIA,
                    PRECIO_COSTO = PRECIO_COSTO,
                    PRECIO_VENTA = PRECIO_VENTA,
                    STOCK = STOCK,
                    PATH_IMG = PATH_IMG,
                    MARGEN = MARGEN,
                    TAMANIO = TAMANIO,
                    PROFUNDIDAD = PROFUNDIDAD,
                    CREADO_POR = Session["usuario"].ToString()
                };
                RESULT_SP = Connect.Connect_Producto(item);

                if (RESULT_SP.Count == 0)
                {
                    respuesta.Codigo = 2;
                    respuesta.Descripcion = "No se ha podido guardar el producto.";
                }
                else
                {
                    respuesta.Codigo = 1;
                    respuesta.Descripcion = "Producto creado correctamente";
                }
            }
            catch (Exception ex)
            {
                respuesta.Codigo = -1;
                respuesta.Descripcion = $"Catch.Connect.Connect_Producto: {ex.Message}";
            }
            return Json(respuesta);
        }

        [SessionExpireFilter]
        public JsonResult Actualizar(FormCollection formCollection)
        {
            var respuesta = new Respuesta();
            try
            {
                int ID_PRODUCTO = Convert.ToInt32(Request.Form["ID_PRODUCTO"].ToString());
                string NOMBRE = Request.Form["NOMBRE"].ToString();
                string DESCRIPCION = Request.Form["DESCRIPCION"].ToString();
                int ID_CATEGORIA = Convert.ToInt32(Request.Form["ID_CATEGORIA"].ToString());
                decimal PRECIO_COSTO = Convert.ToDecimal(Request.Form["PRECIO_COSTO"].ToString());
                decimal PRECIO_VENTA = Convert.ToDecimal(Request.Form["PRECIO_VENTA"].ToString());
                int STOCK = Convert.ToInt32(Request.Form["STOCK"].ToString());
                decimal MARGEN = Convert.ToDecimal(Request.Form["MARGEN"].ToString());
                decimal TAMANIO = Convert.ToDecimal(Request.Form["TAMANIO"].ToString());
                decimal PROFUNDIDAD = Convert.ToDecimal(Request.Form["PROFUNDIDAD"].ToString());

                var randomNumber = new Random().Next(0, 100);
                string path = "", PATH_IMG = "";

                HttpPostedFileBase file = Request.Files["PATH_IMG"];
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    string fileName = file.FileName;
                    string[] separarNombre = fileName.Split('.');
                    Bitmap filee = new Bitmap(file.InputStream);

                    string directory = Server.MapPath(@"~\Content\Fotos_Productos");
                    if (!Directory.Exists(fileName))
                        Directory.CreateDirectory(directory);

                    path = Server.MapPath(@"~\Content\Fotos_Productos\" + separarNombre[0] + randomNumber + ".png");
                    filee.Save(path);

                    var urlBuilder = new System.UriBuilder(Request.Url.AbsoluteUri) { Path = Url.Content(@"~\Content\Fotos_Productos\" + separarNombre[0] + randomNumber + ".png"), Query = null, };
                    PATH_IMG = urlBuilder.ToString();
                }

                if (PATH_IMG == "")
                    PATH_IMG = null;

                List<Catalogo_BE> RESULT_SP;
                Catalogo_BE item = new Catalogo_BE
                {
                    ID_PRODUCTO = ID_PRODUCTO,
                    MTIPO = 3,
                    NOMBRE = NOMBRE,
                    DESCRIPCION = DESCRIPCION,
                    ID_CATEGORIA = ID_CATEGORIA,
                    PRECIO_COSTO = PRECIO_COSTO,
                    PRECIO_VENTA = PRECIO_VENTA,
                    STOCK = STOCK,
                    PATH_IMG = PATH_IMG,
                    MARGEN = MARGEN,
                    TAMANIO = TAMANIO,
                    PROFUNDIDAD = PROFUNDIDAD,
                    CREADO_POR = Session["usuario"].ToString()
                };
                RESULT_SP = Connect.Connect_Producto(item);

                if (RESULT_SP.Count == 0)
                {
                    respuesta.Codigo = 2;
                    respuesta.Descripcion = "No se ha podido actualizar el producto.";
                }
                else
                {
                    respuesta.Codigo = 1;
                    respuesta.Descripcion = "Producto actualizado correctamente";
                }
            }
            catch (Exception ex)
            {
                respuesta.Codigo = -1;
                respuesta.Descripcion = $"Catch.Connect.Connect_Producto: {ex.Message}";
            }
            return Json(respuesta);
        }

        [SessionExpireFilter]
        public JsonResult Eliminar(int id_producto = 0)
        {
            var respuesta = new Respuesta();
            try
            {
                List<Catalogo_BE> RESULT_SP;
                Catalogo_BE item = new Catalogo_BE
                {
                    MTIPO = 4,
                    ID_PRODUCTO = id_producto,
                    CREADO_POR = Session["usuario"].ToString()
                };
                RESULT_SP = Connect.Connect_Producto(item);

                if (RESULT_SP.Count == 0)
                {
                    respuesta.Codigo = 2;
                    respuesta.Descripcion = "No se ha podido inactivar el producto.";
                }
                else
                {
                    respuesta.Codigo = 1;
                    respuesta.Descripcion = "Producto inactivado correctamente";
                }
            }
            catch (Exception ex)
            {
                respuesta.Codigo = -1;
                respuesta.Descripcion = $"Mensaje: {ex.Message}";
            }
            return Json(respuesta);
        }

        public JsonResult CargaMasiva(FormCollection formCollection)
        {
            try
            {

                int ID_CATEGORIA = Convert.ToInt32(Request.Form["ID_CATEGORIA"].ToString());
                HttpPostedFileBase file = Request.Files["FileUpload"];
                List<Catalogo_BE> list = new List<Catalogo_BE>();

                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    string fileName = file.FileName;
                    string fileContentType = file.ContentType;
                    byte[] fileBytes = new byte[file.ContentLength];
                    var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));

                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    using (var package = new ExcelPackage(file.InputStream))
                    {
                        var currentSheet = package.Workbook.Worksheets;
                        var workSheet = currentSheet.First();
                        var noOfCol = workSheet.Dimension.End.Column;
                        var noOfRow = workSheet.Dimension.End.Row;

                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                        {
                            if (workSheet.Cells[rowIterator, 3].Value != null)
                            {
                                for (int i = 1; i <= 10; i++)
                                {
                                    if (workSheet.Cells[rowIterator, i].Value == null)
                                        workSheet.Cells[rowIterator, i].Value = "";
                                }

                                var row = new Catalogo_BE();
                                row.MTIPO = 2;
                                row.ID_CATEGORIA = ID_CATEGORIA;
                                row.CREADO_POR = Session["usuario"].ToString();

                                row.NOMBRE = NullString(workSheet.Cells[rowIterator, 1].Value.ToString());
                                row.DESCRIPCION = NullString(workSheet.Cells[rowIterator, 2].Value.ToString());
                                row.STOCK = NullInt(workSheet.Cells[rowIterator, 3].Value.ToString());
                                row.PRECIO_COSTO = NullDecimal(workSheet.Cells[rowIterator, 4].Value.ToString());
                                row.PRECIO_VENTA = NullDecimal(workSheet.Cells[rowIterator, 5].Value.ToString());
                                row.MARGEN = NullDecimal(workSheet.Cells[rowIterator, 6].Value.ToString());
                                row.TAMANIO = NullDecimal(workSheet.Cells[rowIterator, 7].Value.ToString());
                                row.PROFUNDIDAD = NullDecimal(workSheet.Cells[rowIterator, 8].Value.ToString());
                                row.PATH_IMG = NullString(workSheet.Cells[rowIterator, 9].Value.ToString());
                                list.Add(row);
                            }
                        }
                    }
                }
                foreach (var row in list)
                {
                    row.MTIPO = 2;
                    List<Catalogo_BE> RESULT_SP;
                    RESULT_SP = Connect.Connect_Producto(row);
                }
                return Json(new { State = 1, data = list }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { State = -1, Message = ex.Message.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }

        private string NullString(string cadena)
        {
            string respuesta = "";
            try
            {
                if (cadena == null)
                    respuesta = "";
                else if (cadena == "")
                    respuesta = "";
                else
                    respuesta = cadena;
            }
            catch
            {
                respuesta = "";
            }
            return respuesta;
        }
        private decimal NullDecimal(string cadena)
        {
            decimal respuesta = 0;
            try
            {
                if (cadena == null)
                    respuesta = 0;
                else if (cadena == "")
                    respuesta = 0;
                else
                    respuesta = Convert.ToDecimal(cadena);
            }
            catch
            {
                respuesta = 0;
            }
            return respuesta;
        }
        private int NullInt(string cadena)
        {
            int respuesta = 0;
            try
            {
                if (cadena == null)
                    respuesta = 0;
                else if (cadena == "")
                    respuesta = 0;
                else
                    respuesta = Convert.ToInt16(cadena);
            }
            catch
            {
                respuesta = 0;
            }
            return respuesta;
        }
    }
}