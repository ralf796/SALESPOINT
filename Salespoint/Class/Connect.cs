using RESTAURANTE;
using System.Collections.Generic;
namespace HELPERS
{
    public class Connect
    {
        public static List<Usuarios_BE> Connect_Usuarios(Usuarios_BE item)
        {
            List<Usuarios_BE> lista ;
            lista = Store_Procedure_Maxima_BLL.BLL_sp_usuarios(item);
            return lista;
        }
        public static List<Cotizaciones_BE> Connect_Cotizacion(Cotizaciones_BE item)
        {
            List<Cotizaciones_BE> lista ;
            lista = Store_Procedure_Maxima_BLL.BLL_sp_cotizaciones(item);
            return lista;
        }
        public static List<Ventas_BE> Connect_Ventas(Ventas_BE item)
        {
            List<Ventas_BE> lista ;
            lista = Store_Procedure_Maxima_BLL.BLL_sp_ventas(item);
            return lista;
        }
        public static List<Clientes_BE> Connect_Clientes(Clientes_BE item)
        {
            List<Clientes_BE> lista ;
            lista = Store_Procedure_Maxima_BLL.BLL_sp_clientes(item);
            return lista;
        }
        public static List<Catalogo_BE> Connect_Catalogo(Catalogo_BE item)
        {
            List<Catalogo_BE> lista ;
            lista = Store_Procedure_Maxima_BLL.BLL_sp_catalogo(item);
            return lista;
        }
        public static List<Catalogo_BE> Connect_Producto(Catalogo_BE item)
        {
            List<Catalogo_BE> lista ;
            lista = Store_Procedure_Maxima_BLL.BLL_sp_producto(item);
            return lista;
        }
        public static List<Pedido_BE> Connect_Pedido(Pedido_BE item)
        {
            List<Pedido_BE> lista ;
            lista = Store_Procedure_Maxima_BLL.BLL_sp_pedido(item);
            return lista;
        }
        public static List<Caja_BE> Connect_Caja(Caja_BE item)
        {
            List<Caja_BE> lista;
            lista = Store_Procedure_Maxima_BLL.BLL_sp_caja(item);
            return lista;
        }
    }
}