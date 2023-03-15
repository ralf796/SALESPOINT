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
            List<Usuarios_BE> lista ;
            lista = sp_store_procedure_BLL.BLL_sp_usuarios(item);
            return lista;
        }
        public static List<Cotizaciones_BE> Connect_Cotizacion(Cotizaciones_BE item)
        {
            List<Cotizaciones_BE> lista ;
            lista = sp_store_procedure_BLL.BLL_sp_cotizaciones(item);
            return lista;
        }
        public static List<Ventas_BE> Connect_Ventas(Ventas_BE item)
        {
            List<Ventas_BE> lista ;
            lista = sp_store_procedure_BLL.BLL_sp_ventas(item);
            return lista;
        }
        public static List<Clientes_BE> Connect_Clientes(Clientes_BE item)
        {
            List<Clientes_BE> lista ;
            lista = sp_store_procedure_BLL.BLL_sp_clientes(item);
            return lista;
        }
        public static List<Catalogo_BE> Connect_Catalogo(Catalogo_BE item)
        {
            List<Catalogo_BE> lista ;
            lista = sp_store_procedure_BLL.BLL_sp_catalogo(item);
            return lista;
        }
        public static List<Catalogo_BE> Connect_Producto(Catalogo_BE item)
        {
            List<Catalogo_BE> lista ;
            lista = sp_store_procedure_BLL.BLL_sp_producto(item);
            return lista;
        }
    }
}