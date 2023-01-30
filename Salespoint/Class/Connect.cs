using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Salespoint.Class
{
    public class Connect
    {
        public static List<Usuarios_BE> Connect_Usuarios(Usuarios_BE item)
        {
            List<Usuarios_BE> lista = new List<Usuarios_BE>();
            lista = sp_store_procedure_BLL.BLL_sp_usuarios(item);
            return lista;
        }
    }
}