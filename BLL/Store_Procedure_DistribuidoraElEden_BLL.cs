using BE;
using DAL;
using System;
using System.Collections.Generic;
namespace BLL
{
    public class Store_Procedure_DistribuidoraElEden_BLL : IDisposable
    {
        public void Dispose() { }
        public static List<Anulacion_BE> BLL_sp_anulacion(Anulacion_BE item)
        {
            List<Anulacion_BE> data = null;
            using (var model = new Store_Procedure_DistribuidoraElEden_DAL())
            {
                data = model.DAL_sp_anulacion(item);
            }
            return data;
        }
        public static List<Caja_BE> BLL_sp_caja(Caja_BE item)
        {
            List<Caja_BE> data = null;
            using (var model = new Store_Procedure_DistribuidoraElEden_DAL())
            {
                data = model.DAL_sp_caja(item);
            }
            return data;
        }
        public static List<Cartera_BE> BLL_sp_cartera(Cartera_BE item)
        {
            List<Cartera_BE> data = null;
            using (var model = new Store_Procedure_DistribuidoraElEden_DAL())
            {
                data = model.DAL_sp_cartera(item);
            }
            return data;
        }
        public static List<Clientes_BE> BLL_sp_clientes(Clientes_BE item)
        {
            List<Clientes_BE> data = null;
            using (var model = new Store_Procedure_DistribuidoraElEden_DAL())
            {
                data = model.DAL_sp_clientes(item);
            }
            return data;
        }
        public static List<Devoluciones_BE> BLL_sp_devoluciones(Devoluciones_BE item)
        {
            List<Devoluciones_BE> data = null;
            using (var model = new Store_Procedure_DistribuidoraElEden_DAL())
            {
                data = model.DAL_sp_devoluciones(item);
            }
            return data;
        }
        public static List<FEL_BE> BLL_sp_fel(FEL_BE item)
        {
            List<FEL_BE> data = null;
            using (var model = new Store_Procedure_DistribuidoraElEden_DAL())
            {
                data = model.DAL_sp_fel(item);
            }
            return data;
        }
        public static List<FEL_BE> BLL_sp_log(FEL_BE item)
        {
            List<FEL_BE> data = null;
            using (var model = new Store_Procedure_DistribuidoraElEden_DAL())
            {
                data = model.DAL_sp_log(item);
            }
            return data;
        }
        public static List<Inventario_BE> BLL_sp_inventario(Inventario_BE item)
        {
            List<Inventario_BE> data = null;
            using (var model = new Store_Procedure_DistribuidoraElEden_DAL())
            {
                data = model.DAL_sp_inventario(item);
            }
            return data;
        }
        public static List<Inventario_BE> BLL_sp_inventario_select(Inventario_BE item)
        {
            List<Inventario_BE> data = null;
            using (var model = new Store_Procedure_DistribuidoraElEden_DAL())
            {
                data = model.DAL_sp_inventario_select(item);
            }
            return data;
        }
        public static List<Inventario_BE> BLL_sp_inventario_delete(Inventario_BE item)
        {
            List<Inventario_BE> data = null;
            using (var model = new Store_Procedure_DistribuidoraElEden_DAL())
            {
                data = model.DAL_sp_inventario_delete(item);
            }
            return data;
        }
        public static List<Inventario_BE> BLL_sp_compras(Inventario_BE item)
        {
            List<Inventario_BE> data = null;
            using (var model = new Store_Procedure_DistribuidoraElEden_DAL())
            {
                data = model.DAL_sp_compras(item);
            }
            return data;
        }
        public static List<Reportes_BE> BLL_sp_reportes(Reportes_BE item)
        {
            List<Reportes_BE> data = null;
            using (var model = new Store_Procedure_DistribuidoraElEden_DAL())
            {
                data = model.DAL_sp_reportes(item);
            }
            return data;
        }
        public static List<Usuarios_BE> BLL_sp_usuarios(Usuarios_BE item)
        {
            List<Usuarios_BE> data = null;
            using (var model = new Store_Procedure_DistribuidoraElEden_DAL())
            {
                data = model.DAL_sp_usuarios(item);
            }
            return data;
        }
        public static List<Usuarios_BE> BLL_sp_login(Usuarios_BE item)
        {
            List<Usuarios_BE> data = null;
            using (var model = new Store_Procedure_DistribuidoraElEden_DAL())
            {
                data = model.DAL_sp_login(item);
            }
            return data;
        }
        public static List<Ventas__BE> BLL_sp_ventas(Ventas__BE item)
        {
            List<Ventas__BE> data = null;
            using (var model = new Store_Procedure_DistribuidoraElEden_DAL())
            {
                data = model.DAL_sp_ventas(item);
            }
            return data;
        }
    }
}