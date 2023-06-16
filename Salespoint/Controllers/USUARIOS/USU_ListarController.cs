using BE;
using HELPERS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RESTAURANTE
{
    public class USU_ListarController : Controller
    {
        #region VIEWS
        [SessionExpireFilter]
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Listar()
        {
            var item = new Usuarios_BE();
            item.MTIPO = 1;
            List<Usuarios_BE> lista = new List<Usuarios_BE>();
            lista = Connect.Connect_Usuarios(item);
            ViewBag.data = lista;
            return PartialView();
        }
        public PartialViewResult Select_RolUsuario()
        {
            var item = new Usuarios_BE();
            item.MTIPO = 4;
            List<Usuarios_BE> lista = new List<Usuarios_BE>();
            lista = Connect.Connect_Usuarios(item);
            ViewBag.lista = lista;
            return PartialView();
        }
        #endregion

        #region FUNTIONS
        public string GeneratorUser(string nombre, string apellido)
        {
            string respuesta = "";
            for (int i = 1; i <= apellido.Length; i++)
            {
                if (respuesta == "")
                {
                    List<Usuarios_BE> lista = new List<Usuarios_BE>();
                    var item = new Usuarios_BE();
                    item.MTIPO = 3;
                    item.USUARIO = $"{nombre.Trim()}.{apellido.Substring(0, i)}";
                    lista = Connect.Connect_Usuarios(item);
                    if (lista.Count() == 0)
                        respuesta = $"{nombre.Trim()}.{apellido.Substring(0, i)}";
                }
            }
            if (respuesta == "")
            {
                var randomNumber = new Random().Next(0, 10);
                respuesta = $"{nombre.Trim()}.{apellido.Substring(0, 1)}{randomNumber}";
            }

            return respuesta;
        }
        #endregion

        #region JSON RESULTS
        [SessionExpireFilter]
        public JsonResult Create(FormCollection formCollection)
        {
            var respuesta = new Respuesta();
            try
            {
                string primerNombre = Request.Form["primerNombre"].ToString();
                string segundoNombre = Request.Form["segundoNombre"].ToString();
                string primerApellido = Request.Form["primerApellido"].ToString();
                string segundoApellido = Request.Form["segundoApellido"].ToString();
                string telefono = Request.Form["telefono"].ToString();
                string direccion = Request.Form["direccion"].ToString();
                string email = Request.Form["email"].ToString();
                int idRol = Convert.ToInt16(Request.Form["idRol"]);
                string urlFoto = Request.Form["urlFoto"].ToString();

                var randomNumber = new Random().Next(0, 100);
                string path = "", url = "";

                HttpPostedFileBase file = Request.Files["foto"];
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    string fileName = file.FileName;
                    string[] separarNombre = fileName.Split('.');
                    string extension = separarNombre[1];
                    Bitmap filee = new Bitmap(file.InputStream);
                    //string rut = @"C:\Users\raul.lopez\Documents\REPOSSV\" + file.FileName;
                    //string rut = @"C:\Users\raul.lopez\source\repos\VENTAS\Ventas\Content\Fotografias\" + file.FileName;

                    string directory = Server.MapPath(@"~\Content\FotosUsuarios");
                    if (!Directory.Exists(fileName))
                        Directory.CreateDirectory(directory);

                    path = Server.MapPath(@"~\Content\FotosUsuarios\" + separarNombre[0] + randomNumber + ".png");
                    filee.Save(path);

                    var urlBuilder = new System.UriBuilder(Request.Url.AbsoluteUri) { Path = Url.Content(@"~\Content\FotosUsuarios\" + separarNombre[0] + randomNumber + ".png"), Query = null, };
                    Uri uri = urlBuilder.Uri;
                    url = urlBuilder.ToString();
                }

                string user = GeneratorUser(primerNombre, primerApellido);
                string password = "MAXIMA";

                var item = new Usuarios_BE();
                item.MTIPO = 2;
                item.PRIMER_NOMBRE = primerNombre;
                item.SEGUNDO_NOMBRE = segundoNombre;
                item.PRIMER_APELLIDO = primerApellido;
                item.SEGUNDO_APELLIDO = segundoApellido;
                item.DIRECCION = direccion;
                item.TELEFONO = telefono;
                item.EMAIL = email;

                if (url == "")
                    url = null;

                item.PATH = url;
                item.CREADO_POR = Session["usuario"].ToString();
                item.USUARIO = user;
                //item.PASSWORD = new Encryption().Encrypt(password.Trim());
                item.PASSWORD = password.ToUpper().Trim();
                item.ID_ROL = idRol;
                item = Connect.Connect_Usuarios(item).FirstOrDefault();

                if (item != null)
                {
                    respuesta.Codigo = item.RESPUESTA_CODIGO;
                    respuesta.Descripcion = item.RESPUESTA_DESCRIPCION;
                }
                else
                {
                    respuesta.Codigo = -2;
                    respuesta.Descripcion = "Catch.Connect.Connect_Usuarios Line 90";
                }
            }
            catch (Exception ex)
            {
                respuesta.Codigo = -1;
                respuesta.Descripcion = $"Catch {ex.Message}";
            }
            return Json(respuesta);
        }

        public JsonResult Update(FormCollection formCollection)
        {
            var respuesta = new Respuesta();
            try
            {
                int idEmpleado = Convert.ToInt16(Request.Form["idEmpleado"]);
                string primerNombre = Request.Form["primerNombre"].ToString();
                string segundoNombre = Request.Form["segundoNombre"].ToString();
                string primerApellido = Request.Form["primerApellido"].ToString();
                string segundoApellido = Request.Form["segundoApellido"].ToString();
                string telefono = Request.Form["telefono"].ToString();
                string direccion = Request.Form["direccion"].ToString();
                string email = Request.Form["email"].ToString();
                int idRol = Convert.ToInt16(Request.Form["idRol"]);
                string urlFoto = Request.Form["urlFoto"].ToString();

                var randomNumber = new Random().Next(0, 100);
                string path = "", url = "";

                HttpPostedFileBase file = Request.Files["foto"];
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    string fileName = file.FileName;
                    string[] separarNombre = fileName.Split('.');
                    string extension = separarNombre[1];
                    Bitmap filee = new Bitmap(file.InputStream);
                    //string rut = @"C:\Users\raul.lopez\source\repos\VENTAS\Ventas\Content\Fotografias\" + file.FileName;

                    string directory = Server.MapPath(@"~\Content\FotosUsuarios");
                    if (!Directory.Exists(fileName))
                        Directory.CreateDirectory(directory);

                    path = Server.MapPath(@"~\Content\FotosUsuarios\" + separarNombre[0] + randomNumber + ".png");
                    filee.Save(path);

                    var urlBuilder = new System.UriBuilder(Request.Url.AbsoluteUri) { Path = Url.Content(@"~\Content\FotosUsuarios\" + separarNombre[0] + randomNumber + ".png"), Query = null, };
                    Uri uri = urlBuilder.Uri;
                    url = urlBuilder.ToString();
                }
                var item = new Usuarios_BE();
                item.MTIPO = 5;
                item.ID_EMPLEADO = idEmpleado;
                item.PRIMER_NOMBRE = primerNombre;
                item.SEGUNDO_NOMBRE = segundoNombre;
                item.PRIMER_APELLIDO = primerApellido;
                item.SEGUNDO_APELLIDO = segundoApellido;
                item.DIRECCION = direccion;
                item.TELEFONO = telefono;
                item.EMAIL = email;
                item.PATH = url;
                item.ID_ROL = idRol;
                item = Connect.Connect_Usuarios(item).FirstOrDefault();

                if (item != null)
                {
                    respuesta.Codigo = item.RESPUESTA_CODIGO;
                    respuesta.Descripcion = item.RESPUESTA_DESCRIPCION;
                }
                else
                {
                    respuesta.Codigo = -2;
                    respuesta.Descripcion = "Catch.Connect.Connect_Usuarios Line 206";
                }
            }
            catch (Exception ex)
            {
                respuesta.Codigo = -1;
                respuesta.Descripcion = $"Catch {ex.Message}";
            }
            return Json(respuesta);
        }

        public JsonResult Delete(int ID_EMPLEADO = 0)
        {
            var respuesta = new Respuesta();
            try
            {
                List<Usuarios_BE> RESULT_SP = new List<Usuarios_BE>();
                var item = new Usuarios_BE();
                item.MTIPO = 6;
                item.ID_EMPLEADO=ID_EMPLEADO;
                item = Connect.Connect_Usuarios(item).FirstOrDefault();

                if (RESULT_SP.Count() == 0)
                {
                    respuesta.Codigo = item.RESPUESTA_CODIGO;
                    respuesta.Descripcion = item.RESPUESTA_DESCRIPCION;
                }
                else
                {
                    respuesta.Codigo = -2;
                    respuesta.Descripcion = "Catch.Connect.Connect_Usuarios Line 236";
                }
            }
            catch (Exception ex)
            {
                respuesta.Codigo = -1;
                respuesta.Descripcion = $"Catch {ex.Message}";
            }
            return Json(respuesta);
        }

        #endregion
    }
}