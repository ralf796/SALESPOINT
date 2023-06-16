using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ventas.Class;
using BE;
using BLL;
using DISTRIBUIDORA_EL_EDEN;

namespace Ventas.Controllers.Devoluciones
{
    public class DEVCrearDevolucionController : Controller
    {
        // GET: DEVCrearDevolucion
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetVenta(int ID_VENTA = 0)
        {
            try
            {
                var item = new Devoluciones_BE();
                List<Devoluciones_BE> lista = new List<Devoluciones_BE>();
                item.ID_VENTA = ID_VENTA;
                item.MTIPO = 1;
                item.OBSERVACIONES = "";
                item.CREADO_POR = "";

                Devoluciones_BE encabezado = Connect.Connect_Devoluciones(item).FirstOrDefault();

                if (encabezado != null)
                {
                    encabezado.FECHA_STRING = encabezado.FECHA.ToString("dd/MM/yyyy hh:mm tt");
                    encabezado.FECHA_CERTIFICACION_STRING = encabezado.FECHA_CERTIFICACION.ToString("dd/MM/yyyy hh:mm tt");

                    item.MTIPO = 2;
                    lista = Connect.Connect_Devoluciones(item);
                }

                return Json(new { State = 1, data = encabezado, data_lista = lista }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { State = -1, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }



        private List<Caja_BE> GetDatosCaja_(Caja_BE item)
        {
            List<Caja_BE> lista = new List<Caja_BE>();
            lista = Caja_BLL.GetSPCaja(item);
            return lista;
        }
        public void AnularVenta(int id_venta = 0, string usuario = "")
        {
            var itemV = new Devoluciones_BE();
            itemV.ID_VENTA = id_venta;
            itemV.MTIPO = 4;
            itemV.OBSERVACIONES = "";
            itemV.CREADO_POR = "";
            itemV = Connect.Connect_Devoluciones(itemV).FirstOrDefault();

            int fel = 0;

            if (itemV != null)
                fel = itemV.FEL;

            if (fel == 1)
            {
                try
                {
                    var itemAnula = new FEL_BE();
                    itemAnula.ID_VENTA = id_venta;
                    var respuestaFEL = Certificador_FEL.Anulador_XML_FEL(itemAnula);
                }
                catch
                {

                }
            }

            var item = new Caja_BE();
            item.ID_VENTA = id_venta;
            item.MTIPO = 5;
            item.CREADO_POR = usuario;
            var lista = GetDatosCaja_(item);
        }
        public void SaveDevolucion(int id_venta_anterior = 0, int id_venta_actual = 0, string usuario = "")
        {
            var itemV = new Devoluciones_BE();
            itemV.ID_VENTA_ANTERIOR = id_venta_anterior;
            itemV.ID_VENTA_NUEVA = id_venta_actual;
            itemV.MTIPO = 3;
            itemV.OBSERVACIONES = "";
            itemV.CREADO_POR = usuario;
            itemV = Connect.Connect_Devoluciones(itemV).FirstOrDefault();
        }
        private bool SaveHeader(int idVenta = 0, string serie = "", decimal correlativo = 0, int idCliente = 0, decimal total = 0, decimal descuento = 0, decimal subtotal = 0, string usuario = "", int fel = 0)
        {
            bool respuesta = false;
            var item = new Ventas__BE();
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
            var item = new Ventas__BE();
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
            var item = new Ventas__BE();
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
        private bool DescontProduct(int idVenta = 0)
        {
            bool respuesta = false;
            var item = new Ventas__BE();
            item.MTIPO = 7;
            item.ID_VENTA = idVenta;
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
        public JsonResult SaveOrder(string encabezado = "", string detalles = "", int fel = 0, int id_venta_anterior = 0)
        {
            try
            {
                var item = JsonConvert.DeserializeObject<Ventas__BE>(encabezado);
                List<Ventas__BE> listaDetalles = JsonConvert.DeserializeObject<List<Ventas__BE>>(detalles);
                string usuario = Session["usuario"].ToString();
                item.CREADO_POR = usuario;
                int state = 1;
                bool banderaDetail = false;

                var itemID = new Ventas__BE();
                itemID.MTIPO = 6;
                item.ID_VENTA = GetDatosSP_Ventas(itemID).FirstOrDefault().ID_VENTA;

                if (SaveHeader(Convert.ToInt32(item.ID_VENTA), "", 1, item.ID_CLIENTE, item.TOTAL, item.TOTAL_DESCUENTO, item.SUBTOTAL, usuario, fel) == true)
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

                if (banderaDetail == true)
                    state = 2;
                else
                {
                    AnularVenta(id_venta_anterior, usuario);
                    DescontProduct(Convert.ToInt32(item.ID_VENTA));
                    SaveDevolucion(id_venta_anterior, Convert.ToInt32(item.ID_VENTA),usuario);
                }
                return Json(new { State = state, ORDEN_COMPRA = item.ID_VENTA }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { State = -1, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}