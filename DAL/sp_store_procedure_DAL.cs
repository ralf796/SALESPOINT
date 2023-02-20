using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class sp_store_procedure_DAL : IDisposable
    {
        public void Dispose() { }

        public List<Usuarios_BE> DAL_sp_usuarios(Usuarios_BE item)
        {
            List<Usuarios_BE> result = new List<Usuarios_BE>();
            using (var model = new Base_SQL("sp_usuario"))
            {
                model.Command.Parameters.AddWithValue("@MTIPO", item.MTIPO);
                model.Command.Parameters.AddWithValue("@PRIMER_NOMBRE", item.PRIMER_NOMBRE);
                model.Command.Parameters.AddWithValue("@SEGUNDO_NOMBRE", item.SEGUNDO_NOMBRE);
                model.Command.Parameters.AddWithValue("@PRIMER_APELLIDO", item.PRIMER_APELLIDO);
                model.Command.Parameters.AddWithValue("@SEGUNDO_APELLIDO", item.SEGUNDO_APELLIDO);
                model.Command.Parameters.AddWithValue("@DIRECCION", item.DIRECCION);
                model.Command.Parameters.AddWithValue("@ID_TIPO_EMPLEADO", item.ID_TIPO_EMPLEADO);
                model.Command.Parameters.AddWithValue("@TELEFONO", item.TELEFONO);
                model.Command.Parameters.AddWithValue("@EMAIL", item.EMAIL);
                model.Command.Parameters.AddWithValue("@URL_FOTO", item.PATH);
                model.Command.Parameters.AddWithValue("@USUARIO", item.USUARIO);
                model.Command.Parameters.AddWithValue("@PASSWORD", item.PASSWORD);
                model.Command.Parameters.AddWithValue("@CREADO_POR", item.CREADO_POR);
                model.Command.Parameters.AddWithValue("@ID_EMPLEADO", item.ID_EMPLEADO);
                model.Command.Parameters.AddWithValue("@ID_ROL", item.ID_ROL);
                model.Command.Parameters.AddWithValue("@LINK_DEFAULT", item.URL_PANTALLA);
                result = model.GetData<Usuarios_BE>();
            }
            return result;
        }
        public List<Cotizaciones_BE> DAL_sp_cotizaciones(Cotizaciones_BE item)
        {
            List<Cotizaciones_BE> result = new List<Cotizaciones_BE>();
            using (var model = new Base_SQL("sp_cotizaciones"))
            {
                model.Command.Parameters.AddWithValue("@MTIPO", item.MTIPO);
                model.Command.Parameters.AddWithValue("@ID_VENTA", item.ID_VENTA);                
                model.Command.Parameters.AddWithValue("@CREADO_POR", item.CREADO_POR);
                result = model.GetData<Cotizaciones_BE>();
            }
            return result;
        }
        public List<Ventas_BE> DAL_sp_ventas(Ventas_BE item)
        {
            List<Ventas_BE> result = new List<Ventas_BE>();
            using (var model = new Base_SQL("sp_ventas"))
            {
                model.Command.Parameters.AddWithValue("@MTIPO", item.MTIPO);
                model.Command.Parameters.AddWithValue("@NIT", item.NIT);
                model.Command.Parameters.AddWithValue("@ID_VENTA", item.ID_VENTA);
                model.Command.Parameters.AddWithValue("@SERIE", item.SERIE);
                model.Command.Parameters.AddWithValue("@CORRELATIVO", item.CORRELATIVO);
                model.Command.Parameters.AddWithValue("@ID_CLIENTE", item.ID_CLIENTE);
                model.Command.Parameters.AddWithValue("@TOTAL", item.TOTAL);
                model.Command.Parameters.AddWithValue("@SUBTOTAL", item.SUBTOTAL);
                model.Command.Parameters.AddWithValue("@TOTAL_DESCUENTO", item.TOTAL_DESCUENTO);
                model.Command.Parameters.AddWithValue("@PRECIO", item.PRECIO_VENTA);
                model.Command.Parameters.AddWithValue("@CANTIDAD", item.CANTIDAD);
                model.Command.Parameters.AddWithValue("@ID_PRODUCTO", item.ID_PRODUCTO);
                model.Command.Parameters.AddWithValue("@CREADO_POR", item.CREADO_POR);
                model.Command.Parameters.AddWithValue("@nombreModelo", item.NOMBRE_MODELO);
                model.Command.Parameters.AddWithValue("@nombreMarcaVehiculo", item.NOMBRE_MARCA_VEHICULO);
                model.Command.Parameters.AddWithValue("@nombreLineaVehiculo", item.NOMBRE_LINEA_VEHICULO);
                model.Command.Parameters.AddWithValue("@anioVehiculo", item.ANIO_VEHICULO);
                model.Command.Parameters.AddWithValue("@CODIGO", item.CODIGO);
                model.Command.Parameters.AddWithValue("@CODIGO2", item.CODIGO2);
                model.Command.Parameters.AddWithValue("@ANIO_INICIAL", item.ANIO_INICIAL);
                model.Command.Parameters.AddWithValue("@ANIO_FINAL", item.ANIO_FINAL);
                result = model.GetData<Ventas_BE>();
            }
            return result;
        }
        public List<Clientes_BE> DAL_sp_clientes(Clientes_BE item)
        {
            List<Clientes_BE> result = new List<Clientes_BE>();
            using (var model = new Base_SQL("sp_clientes"))
            {
                model.Command.Parameters.AddWithValue("@ID_CLIENTE", item.ID_CLIENTE);
                model.Command.Parameters.AddWithValue("@NOMBRE", item.NOMBRE);
                model.Command.Parameters.AddWithValue("@DIRECCION", item.DIRECCION);
                model.Command.Parameters.AddWithValue("@TELEFONO", item.TELEFONO);
                model.Command.Parameters.AddWithValue("@EMAIL", item.EMAIL);
                model.Command.Parameters.AddWithValue("@NIT", item.NIT);
                model.Command.Parameters.AddWithValue("@CREADO_POR", item.CREADO_POR);
                model.Command.Parameters.AddWithValue("@MTIPO", item.MTIPO);
                result = model.GetData<Clientes_BE>();
            }
            return result;
        }
        public List<Catalogo_BE> DAL_sp_catalogo(Catalogo_BE item)
        {
            List<Catalogo_BE> result = new List<Catalogo_BE>();
            using (var model = new Base_SQL("sp_catalogo"))
            {
                model.Command.Parameters.AddWithValue("@MTIPO", item.MTIPO);
                model.Command.Parameters.AddWithValue("@NOMBRE_CATEGORIA", item.NOMBRE_CATEGORIA);
                result = model.GetData<Catalogo_BE>();
            }
            return result;
        }

        public List<Usuarios_BE> GetSPLogin(Usuarios_BE item)
        {
            List<Usuarios_BE> result = new List<Usuarios_BE>();
            using (var model = new Base_SQL("sp_login"))
            {
                model.Command.Parameters.AddWithValue("@USUARIO", item.USUARIO);
                model.Command.Parameters.AddWithValue("@PASSWORD", item.PASSWORD);
                model.Command.Parameters.AddWithValue("@CORREO", item.EMAIL);
                model.Command.Parameters.AddWithValue("@MTIPO", item.MTIPO);
                result = model.GetData<Usuarios_BE>();
            }
            return result;
        }
        public List<Accesos_BE> GetAccesos(Accesos_BE item)
        {
            List<Accesos_BE> result = new List<Accesos_BE>();
            using (var model = new Base_SQL("sp_login"))
            {
                model.Command.Parameters.AddWithValue("@USUARIO", item.USUARIO);
                model.Command.Parameters.AddWithValue("@PASSWORD", item.PASSWORD);
                model.Command.Parameters.AddWithValue("@CORREO", item.EMAIL);
                model.Command.Parameters.AddWithValue("@MTIPO", item.MTIPO);
                result = model.GetData<Accesos_BE>();
            }
            return result;
        }
    
    }
}
