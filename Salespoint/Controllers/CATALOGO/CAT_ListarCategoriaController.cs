using BE;
using Salespoint.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Salespoint.Controllers.CATALOGO
{
    public class CAT_ListarCategoriaController : Controller
    {
        // GET: CAT_ListarCategoria
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Listar()
        {
            var item = new Catalogo_BE();
            item.MTIPO = 1;
            List<Catalogo_BE> lista;
            lista = Connect.Connect_Catalogo(item);
            ViewBag.data = lista;
            return PartialView();
        }
    }
}