using GenesysOracleSV.Clases;
using OfficeOpenXml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Parser.SyntaxTree;
using BE;
using BLL;

namespace Ventas.Controllers.Inventario
{
    public class INVMantenimientoController : Controller
    {
        #region VIEWS
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region BD
        private List<Inventario_BE> GetInventario_select_(Inventario_BE item)
        {
            List<Inventario_BE> lista = new List<Inventario_BE>();
            lista = Inventario_BLL.GetInventario_select(item);
            return lista;
        }
        #endregion

        #region JSON_RESULTS

        public JsonResult GetDatosTable(int tipo = 0, int id = 0, string modelo = "", string marcaVehiculo = "", string nombreLinea = "")
        {
            try
            {
                var item = new Inventario_BE();
                item.MTIPO = tipo;
                item.ID_UPDATE = id;
                if (modelo != "" && modelo != "0")
                    item.NOMBRE_MODELO = modelo;
                if (marcaVehiculo != "" && marcaVehiculo != "0")
                    item.NOMBRE_MARCA_VEHICULO = marcaVehiculo;
                if (nombreLinea != "" && nombreLinea != "0")
                    item.NOMBRE_LINEA_VEHICULO = nombreLinea;
                var lista = GetInventario_select_(item);
                return Json(new { State = 1, data = lista }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { State = -1, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region FUNCTIONS
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
        #endregion
    }
}