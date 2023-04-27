using BE;
using DAL;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class sp_store_procedure_BLL : IDisposable
    {
        public void Dispose() { }

        #region PROCESO ACCESOS
        public static List<Usuarios_BE> BLL_sp_usuarios(Usuarios_BE item)
        {
            List<Usuarios_BE> data = null;
            using (var model = new sp_store_procedure_DAL())
            {
                data = model.DAL_sp_usuarios(item);
            }
            return data;
        }
        public static List<Cotizaciones_BE> BLL_sp_cotizaciones(Cotizaciones_BE item)
        {
            List<Cotizaciones_BE> data = null;
            using (var model = new sp_store_procedure_DAL())
            {
                data = model.DAL_sp_cotizaciones(item);
            }
            return data;
        }
        public static List<Ventas_BE> BLL_sp_ventas(Ventas_BE item)
        {
            List<Ventas_BE> data = null;
            using (var model = new sp_store_procedure_DAL())
            {
                data = model.DAL_sp_ventas(item);
            }
            return data;
        }
        public static List<Clientes_BE> BLL_sp_clientes(Clientes_BE item)
        {
            List<Clientes_BE> data = null;
            using (var model = new sp_store_procedure_DAL())
            {
                data = model.DAL_sp_clientes(item);
            }
            return data;
        }
        public static List<Catalogo_BE> BLL_sp_catalogo(Catalogo_BE item)
        {
            List<Catalogo_BE> data = null;
            using (var model = new sp_store_procedure_DAL())
            {
                data = model.DAL_sp_catalogo(item);
            }
            return data;
        }
        public static List<Catalogo_BE> BLL_sp_producto(Catalogo_BE item)
        {
            List<Catalogo_BE> data = null;
            using (var model = new sp_store_procedure_DAL())
            {
                data = model.DAL_sp_producto(item);
            }
            return data;
        }

        public static List<Usuarios_BE> GetSPLogin(Usuarios_BE item)
        {
            List<Usuarios_BE> data = null;
            using (var model = new sp_store_procedure_DAL())
            {
                data = model.GetSPLogin(item);
            }
            return data;
        }
        public static List<Accesos_BE> GetAccesos(Accesos_BE item)
        {
            List<Accesos_BE> data = null;
            using (var model = new sp_store_procedure_DAL())
            {
                data = model.GetAccesos(item);
            }
            return data;
        }
        public static List<Pedido_BE> BLL_sp_pedido(Pedido_BE item)
        {
            List<Pedido_BE> data = null;
            using (var model = new sp_store_procedure_DAL())
            {
                data = model.DAL_sp_pedido(item);
            }
            return data;
        }

        #endregion
    }
}
