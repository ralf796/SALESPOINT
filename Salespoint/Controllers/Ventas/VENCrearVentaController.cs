using GenesysOracle.Clases;
using GenesysOracleSV.Clases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using BE;
using BLL;
using Newtonsoft.Json;
using SelectPdf;

namespace Ventas.Controllers.Ventas
{
    public class VENCrearVentaController : Controller
    {
        // GET: VENCrearVenta
        [SessionExpireFilter]
        public ActionResult Index()
        {
            return View();
        }

    }
}