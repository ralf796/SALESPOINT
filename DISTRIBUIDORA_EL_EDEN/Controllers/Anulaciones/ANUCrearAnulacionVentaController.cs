﻿//using conectorfelv2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ventas.Class;
using BE;
using BLL;
using DISTRIBUIDORA_EL_EDEN;

namespace Ventas.Controllers.Anulaciones
{
    public class ANUCrearAnulacionVentaController : Controller
    {
        // GET: ANUCrearAnulacionVenta
        [SessionExpireFilter]
        public ActionResult Index()
        {
            if (Session["usuario"] == null)
                return RedirectToAction("Index", "Home");
            return View();
        }
        public JsonResult GetDatosSP(string fecha = "", int idVenta = 0, int tipo = 0, int fel = 0)
        {
            try
            {
                var item = new Anulacion_BE();
                item.MTIPO = tipo;
                item.CREADO_POR = Session["usuario"].ToString();
                if (tipo == 1)
                    item.FECHA = Convert.ToDateTime(fecha);
                else
                    item.FECHA = DateTime.Now;
                item.ID_VENTA = idVenta;

                if (tipo == 2)
                {
                    if (fel == 1)
                    {
                        try
                        {
                            var itemAnula = new FEL_BE();
                            itemAnula.ID_VENTA = idVenta;
                            var respuestaFEL = Certificador_FEL.Anulador_XML_FEL(itemAnula);
                            if (!respuestaFEL.RESULTADO)
                                return Json(new { State = 3, Message = respuestaFEL.MENSAJE_FEL }, JsonRequestBehavior.AllowGet);
                        }
                        catch
                        {

                        }
                    }
                }

                var lista =Connect.Connect_Anulacion(item);
                int estado = 1;
                if (tipo == 2)
                {
                    if (lista != null)
                    {
                        if (lista.FirstOrDefault().RESPUESTA == "0")
                            estado = 2;
                        else
                            RevertirVenta(idVenta);
                    }
                    else estado = 2;
                }
                else
                {
                    foreach (var row in lista)
                    {
                        row.FECHA_CREACION_STRING = row.FECHA.ToString("dd/MM/yyyy hh:mm tt");
                    }
                }


                return Json(new { State = estado, data = lista }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { State = -1, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        private void RevertirVenta(int idVenta = 0)
        {
            var item = new Caja_BE();
            item.ID_VENTA = idVenta;
            item.MTIPO = 5;
            var lista = Connect.Connect_Caja(item);
        }
    }
}