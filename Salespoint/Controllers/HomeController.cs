using RESTAURANTE;
using HELPERS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Text;

namespace Ventas.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        private List<Usuarios_BE> GetSPLogin_(Usuarios_BE item)
        {
            List<Usuarios_BE> lista = new List<Usuarios_BE>();
            lista = sp_store_procedure_BLL.GetSPLogin(item);
            return lista;
        }
        private List<Accesos_BE> GetAccesos_(Accesos_BE item)
        {
            List<Accesos_BE> lista = new List<Accesos_BE>();
            lista = sp_store_procedure_BLL.GetAccesos(item);
            return lista;
        }
        public JsonResult ValidarLogin(string usuario = "", string password = "")
        {
            try
            {
                StringBuilder html = new StringBuilder();
                string url = "";
                var item = new Usuarios_BE();
                item.EMAIL = usuario.ToUpper();
                item.USUARIO = usuario.ToUpper();
                //item.PASSWORD = new Encryption().Encrypt(password.ToUpper().Trim());
                item.PASSWORD =password.ToUpper().Trim();
                item.MTIPO = 1;
                item = GetSPLogin_(item).FirstOrDefault();
                if (item != null)
                {
                    Session["id_usuario"] = item.ID_USUARIO.ToString().ToUpper();
                    Session["usuario"] = item.USUARIO.ToString().ToUpper();
                    Session["primer_nombre"] = item.PRIMER_NOMBRE.ToUpper();
                    Session["segundo_nombre"] = item.SEGUNDO_NOMBRE.ToUpper();
                    Session["primer_apellido"] = item.PRIMER_APELLIDO.ToUpper();
                    Session["segundo_apellido"] = item.SEGUNDO_APELLIDO.ToUpper();
                    Session["id_rol"] = Convert.ToInt16(item.ID_ROL);
                    Session["url_fotografia"] = item.PATH;

                    var urlBuilder = new System.UriBuilder(Request.Url.AbsoluteUri) { Path = Url.Content(@"~\"), Query = null, };
                    url = urlBuilder.ToString() + item.URL_PANTALLA;

                    item.URL_PANTALLA = url;
                    Session["url_pantalla"] = url;

                    List<Accesos_BE> Accesos = new List<Accesos_BE>();
                    var itemAcceso = new Accesos_BE
                    {
                        USUARIO = item.USUARIO,
                        MTIPO = 8
                    };
                    //model.Menus = GetAccesos_(itemAcceso);
                    Session["lista_accesos"] = GetAccesos_(itemAcceso);


                    var listado = Session["lista_accesos"];
                    string sss = "";
                    /*
                    html.AppendLine("'");
                    foreach (var row1 in model.Menus)
                    {
                        html.AppendLine($@"
                            <li class=""nav-item"">
                                <a href=""#"" class=""nav-link"">
                                    <i class=""far fa-inventory""></i>
                                    <p>{row1.NOMBRE}<i class=""fas fa-angle-left right""></i>
                                    </p>
                                </a>
                        ");
                        foreach (var row2 in model.Menus.Where(x => x.ID_PADRE == row1.ID_MENU_SYS))
                        {
                            html.AppendLine($@"
                                    <ul class=""nav nav-treeview"">
                                        <li class=""nav-item"">
                                        </li>
                                        <li class=""nav-item"">
                                            <a href=""{row2.LINK}"" class=""nav-link"">
                                                <i class=""{row1.ICONO}"" style=""color:white""></i>
                                                <p>{row2.NOMBRE}</p>
                                            </a>
                                        </li>
                                    </ul>
                            ");
                        }
                        html.AppendLine($@"</li>");
                    }
                    html.AppendLine("'");
                    */
                }
                else
                    item = null;

                //string htmlString = html.ToString().Replace("\r\n", "").Replace("\n", "").Replace("\r", "");

                return Json(new { State = 1, data = item}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { State = -1, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult ChangePassword(string correo = "", string usuario = "", string password = "")
        {
            try
            {
                string url = "";
                var item = new Usuarios_BE();
                item.USUARIO = usuario.ToUpper().Trim();
                item.PASSWORD = "";
                item.EMAIL = correo.ToUpper().Trim();
                item.MTIPO = 5;
                item = GetSPLogin_(item).FirstOrDefault();
                if (item != null)
                {
                    item.MTIPO = 6;
                    item.USUARIO = usuario.ToUpper().Trim();
                    item.PASSWORD = new Encryption().Encrypt(password.ToUpper().Trim());
                    item = GetSPLogin_(item).FirstOrDefault();
                }
                else
                    item = null;

                return Json(new { State = 1, data = item }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { State = -1, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult CerrarSesion()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}