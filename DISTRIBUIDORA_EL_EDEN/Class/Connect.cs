using BE;
using BLL;
using System.Collections.Generic;
namespace DISTRIBUIDORA_EL_EDEN
{
    public class Connect
    {
        public static List<Anulacion_BE> Connect_Anulacion(Anulacion_BE item)
        {
            List<Anulacion_BE> lista;
            lista = Store_Procedure_DistribuidoraElEden_BLL.BLL_sp_anulacion(item);
            return lista;
        }
        public static List<Caja_BE> Connect_Caja(Caja_BE item)
        {
            List<Caja_BE> lista;
            lista = Store_Procedure_DistribuidoraElEden_BLL.BLL_sp_caja(item);
            return lista;
        }
        public static List<Cartera_BE> Connect_Cartera(Cartera_BE item)
        {
            List<Cartera_BE> lista;
            lista = Store_Procedure_DistribuidoraElEden_BLL.BLL_sp_cartera(item);
            return lista;
        }
        public static List<Clientes_BE> Connect_Clientes(Clientes_BE item)
        {
            List<Clientes_BE> lista;
            lista = Store_Procedure_DistribuidoraElEden_BLL.BLL_sp_clientes(item);
            return lista;
        }
        public static List<Devoluciones_BE> Connect_Devoluciones(Devoluciones_BE item)
        {
            List<Devoluciones_BE> lista;
            lista = Store_Procedure_DistribuidoraElEden_BLL.BLL_sp_devoluciones(item);
            return lista;
        }
        public static List<FEL_BE> Connect_FEL(FEL_BE item)
        {
            List<FEL_BE> lista;
            lista = Store_Procedure_DistribuidoraElEden_BLL.BLL_sp_fel(item);
            return lista;
        }
        public static List<FEL_BE> Connect_Log(FEL_BE item)
        {
            List<FEL_BE> lista;
            lista = Store_Procedure_DistribuidoraElEden_BLL.BLL_sp_log(item);
            return lista;
        }
        public static List<Inventario_BE> Connect_Inventario(Inventario_BE item)
        {
            List<Inventario_BE> lista;
            lista = Store_Procedure_DistribuidoraElEden_BLL.BLL_sp_inventario(item);
            return lista;
        }
        public static List<Inventario_BE> Connect_Inventario_Select(Inventario_BE item)
        {
            List<Inventario_BE> lista;
            lista = Store_Procedure_DistribuidoraElEden_BLL.BLL_sp_inventario_select(item);
            return lista;
        }
        public static List<Inventario_BE> Connect_Devoluciones_Delete(Inventario_BE item)
        {
            List<Inventario_BE> lista;
            lista = Store_Procedure_DistribuidoraElEden_BLL.BLL_sp_inventario_delete(item);
            return lista;
        }
        public static List<Inventario_BE> Connect_Compras(Inventario_BE item)
        {
            List<Inventario_BE> lista;
            lista = Store_Procedure_DistribuidoraElEden_BLL.BLL_sp_compras(item);
            return lista;
        }
        public static List<Reportes_BE> Connect_Reportes(Reportes_BE item)
        {
            List<Reportes_BE> lista;
            lista = Store_Procedure_DistribuidoraElEden_BLL.BLL_sp_reportes(item);
            return lista;
        }
        public static List<Usuarios_BE> Connect_Usuarios(Usuarios_BE item)
        {
            List<Usuarios_BE> lista;
            lista = Store_Procedure_DistribuidoraElEden_BLL.BLL_sp_usuarios(item);
            return lista;
        }
        public static List<Usuarios_BE> Connect_Login(Usuarios_BE item)
        {
            List<Usuarios_BE> lista;
            lista = Store_Procedure_DistribuidoraElEden_BLL.BLL_sp_login(item);
            return lista;
        }
        public static List<Ventas__BE> Connect_Ventas(Ventas__BE item)
        {
            List<Ventas__BE> lista;
            lista = Store_Procedure_DistribuidoraElEden_BLL.BLL_sp_ventas(item);
            return lista;
        }
    }
}