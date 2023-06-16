using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ventas.Class;
using BE;
using BLL;
using DISTRIBUIDORA_EL_EDEN;

namespace Ventas.Controllers.Clientes
{
    public class CLIListarClientesController : Controller
    {
        // GET: CLIListarClientes
        [SessionExpireFilter]
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetClientes(int tipo = 0)
        {
            try
            {
                var item = new Clientes_BE();
                item.MTIPO = tipo;
                var lista = Connect.Connect_Clientes(item);
                return Json(new { State = 1, data = lista }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { State = -1, Message = ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }

        public JsonResult GuardarCliente(string nombre = "", string direccion = "", string telefono = "", string email = "", string nit = "")
        {
            try
            {
                string respuesta = "";
                var item = new Clientes_BE();
                item.NOMBRE = nombre;
                item.DIRECCION = direccion;
                item.TELEFONO = telefono;
                item.EMAIL = email;
                item.NIT = nit;
                item.CREADO_POR = Session["usuario"].ToString();
                item.MTIPO = 1;
                var lista = Connect.Connect_Clientes(item);

                if (lista.Count > 0)
                {
                    if (lista.FirstOrDefault().RESPUESTA != "")
                    {
                        respuesta = lista.FirstOrDefault().RESPUESTA;
                    }
                }
                return Json(new { State = 1 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { State = -1, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult UpdateClientes(int id = 0, string nombre = "", string direccion = "", string telefono = "", string email = "", string nit = "")
        {
            try
            {
                string respuesta = "";
                var item = new Clientes_BE();
                item.MTIPO = 2;
                item.ID_CLIENTE = id;
                item.NOMBRE = nombre;
                item.DIRECCION = direccion;
                item.TELEFONO = telefono;
                item.EMAIL = email;
                item.NIT = nit;
                var lista = Connect.Connect_Clientes(item);
                if (lista.Count > 0)
                {
                    if (lista.FirstOrDefault().RESPUESTA != "")
                    {
                        respuesta = lista.FirstOrDefault().RESPUESTA;
                    }
                }
                return Json(new { State = 1 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { State = -1, Message = ex.Message }, JsonRequestBehavior.AllowGet);

            }
        }

        public JsonResult Delete(int id = 0)
        {
            try
            {
                string respuesta = "";
                var item = new Clientes_BE();
                item.ID_CLIENTE = id;
                item.MTIPO = 3;
                var lista = Connect.Connect_Clientes(item);
                if (lista != null)
                {
                    if (lista.FirstOrDefault().RESPUESTA != "")
                    {
                        respuesta = lista.FirstOrDefault().RESPUESTA;
                    }
                }
                return Json(new { State = 1 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { State = -1, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}