using BE;
using System;
using System.Collections.Generic;
namespace DAL
{
    public class Store_Procedure_DistribuidoraElEden_DAL : IDisposable
    {
        public void Dispose() { }

        DateTime FECHA_CREACION_DAL = DateTime.Now;

        public List<Anulacion_BE> DAL_sp_anulacion(Anulacion_BE item)
        {
            List<Anulacion_BE> result = new List<Anulacion_BE>();
            using (var model = new UnitOfWork_DistribuidoraElEden("sp_anulaciones"))
            {
                model.Command.Parameters.AddWithValue("@ID_VENTA", item.ID_VENTA);
                model.Command.Parameters.AddWithValue("@CREADO_POR", item.CREADO_POR);
                model.Command.Parameters.AddWithValue("@FECHA", item.FECHA);
                model.Command.Parameters.AddWithValue("@MTIPO", item.MTIPO);
                result = model.GetData<Anulacion_BE>();
            }
            return result;
        }
        public List<Caja_BE> DAL_sp_caja(Caja_BE item)
        {
            List<Caja_BE> result = new List<Caja_BE>();
            using (var model = new UnitOfWork_DistribuidoraElEden("sp_caja"))
            {
                model.Command.Parameters.AddWithValue("@ID_VENTA", item.ID_VENTA);
                model.Command.Parameters.AddWithValue("@NOMBRE", item.NOMBRE);
                model.Command.Parameters.AddWithValue("@TOTAL", item.TOTAL);
                model.Command.Parameters.AddWithValue("@CREADO_POR", item.CREADO_POR);
                model.Command.Parameters.AddWithValue("@CANTIDAD", item.CANTIDAD);
                model.Command.Parameters.AddWithValue("@PRECIO_UNITARIO", item.PRECIO_UNITARIO);
                model.Command.Parameters.AddWithValue("@DESCUENTO", item.DESCUENTO);
                model.Command.Parameters.AddWithValue("@SUBTOTAL", item.SUBTOTAL);
                model.Command.Parameters.AddWithValue("@TIPO_COBRO", item.TIPO_COBRO);
                model.Command.Parameters.AddWithValue("@ID_DETALLE_VENTA", 0);
                model.Command.Parameters.AddWithValue("@MTIPO", item.MTIPO);
                result = model.GetData<Caja_BE>();
            }
            return result;
        }
        public List<Cartera_BE> DAL_sp_cartera(Cartera_BE item)
        {
            List<Cartera_BE> result = new List<Cartera_BE>();
            using (var model = new UnitOfWork_DistribuidoraElEden("sp_cartera"))
            {
                model.Command.Parameters.AddWithValue("@ID_VENTA", item.ID_VENTA);
                model.Command.Parameters.AddWithValue("@CREADO_POR", item.CREADO_POR);
                model.Command.Parameters.AddWithValue("@ABONO", item.ABONO);
                model.Command.Parameters.AddWithValue("@OBSERVACIONES", item.OBSERVACIONES);
                model.Command.Parameters.AddWithValue("@FECHA_PAGO", item.FECHA_PAGO ?? DateTime.Now);
                model.Command.Parameters.AddWithValue("@NIT", item.NIT);
                model.Command.Parameters.AddWithValue("@ID_CLIENTE", item.ID_CLIENTE);
                model.Command.Parameters.AddWithValue("@MTIPO", item.MTIPO);
                result = model.GetData<Cartera_BE>();
            }
            return result;
        }
        public List<Clientes_BE> DAL_sp_clientes(Clientes_BE item)
        {
            List<Clientes_BE> result = new List<Clientes_BE>();
            using (var model = new UnitOfWork_DistribuidoraElEden("sp_clientes"))
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
        public List<Devoluciones_BE> DAL_sp_devoluciones(Devoluciones_BE item)
        {
            List<Devoluciones_BE> result = new List<Devoluciones_BE>();
            using (var model = new UnitOfWork_DistribuidoraElEden("sp_devoluciones"))
            {
                model.Command.Parameters.AddWithValue("@ID_VENTA", item.ID_VENTA);
                model.Command.Parameters.AddWithValue("@CREADO_POR", item.CREADO_POR);
                model.Command.Parameters.AddWithValue("@OBSERVACIONES", item.OBSERVACIONES);
                model.Command.Parameters.AddWithValue("@ID_VENTA_NUEVA", item.ID_VENTA_NUEVA);
                model.Command.Parameters.AddWithValue("@ID_VENTA_ANTERIOR", item.ID_VENTA_ANTERIOR);
                model.Command.Parameters.AddWithValue("@MTIPO", item.MTIPO);
                result = model.GetData<Devoluciones_BE>();
            }
            return result;
        }
        public List<FEL_BE> DAL_sp_fel(FEL_BE item)
        {
            if (item.MTIPO != 5)
                item.FECHA_CERTIFICACION = null;

            List<FEL_BE> result = new List<FEL_BE>();
            using (var model = new UnitOfWork_DistribuidoraElEden("sp_fel"))
            {
                model.Command.Parameters.AddWithValue("@MTIPO", item.MTIPO);
                model.Command.Parameters.AddWithValue("@ID_VENTA", item.ID_VENTA);
                model.Command.Parameters.AddWithValue("@UUID", item.UUID);
                model.Command.Parameters.AddWithValue("@SERIE_FEL", item.SERIE_FEL);
                model.Command.Parameters.AddWithValue("@NUMERO_FEL", item.NUMERO_FEL);
                model.Command.Parameters.AddWithValue("@FECHA_CERTIFICACION", item.FECHA_CERTIFICACION);
                model.Command.Parameters.AddWithValue("@FEL", item.FEL);
                result = model.GetData<FEL_BE>();
            }
            return result;
        }
        public List<FEL_BE> DAL_sp_log(FEL_BE item)
        {
            List<FEL_BE> result = new List<FEL_BE>();
            using (var model = new UnitOfWork_DistribuidoraElEden("sp_log"))
            {
                model.Command.Parameters.AddWithValue("@MTIPO", item.MTIPO);
                model.Command.Parameters.AddWithValue("@DESCRIPCION", item.DESCRIPCION);
                model.Command.Parameters.AddWithValue("@ES_ANULACION", item.ES_ANULACION);
                model.Command.Parameters.AddWithValue("@ID_VENTA", item.ID_VENTA);
                model.Command.Parameters.AddWithValue("@PETICION", item.PETICION);
                model.Command.Parameters.AddWithValue("@REPUESTA", item.RESPUESTA);
                model.Command.Parameters.AddWithValue("@ESTADO", item.ESTADO);
                model.Command.Parameters.AddWithValue("@CREADO_POR", item.CREADO_POR);
                result = model.GetData<FEL_BE>();
            }
            return result;
        }
        public List<Inventario_BE> DAL_sp_inventario(Inventario_BE item)
        {
            List<Inventario_BE> result = new List<Inventario_BE>();
            using (var model = new UnitOfWork_DistribuidoraElEden("sp_inventario"))
            {
                model.Command.Parameters.AddWithValue("@NOMBRE", item.NOMBRE);
                model.Command.Parameters.AddWithValue("@DESCRIPCION", item.DESCRIPCION);
                model.Command.Parameters.AddWithValue("@CREADO_POR", item.CREADO_POR);
                model.Command.Parameters.AddWithValue("@ID_PRODUCTO", item.ID_PRODUCTO);
                model.Command.Parameters.AddWithValue("@ID_MODELO", item.ID_MODELO);
                model.Command.Parameters.AddWithValue("@ID_BODEGA", item.ID_BODEGA);
                model.Command.Parameters.AddWithValue("@ID_SUBCATEGORIA", item.ID_SUBCATEGORIA);
                model.Command.Parameters.AddWithValue("@ID_PROVEEDOR", item.ID_PROVEEDOR);
                model.Command.Parameters.AddWithValue("@ID_MARCA_REPUESTO", item.ID_MARCA_REPUESTO);
                model.Command.Parameters.AddWithValue("@ID_SERIE_VEHICULO", item.ID_SERIE_VEHICULO);
                model.Command.Parameters.AddWithValue("@PRECIO_COSTO", item.PRECIO_COSTO);
                model.Command.Parameters.AddWithValue("@PRECIO_VENTA", item.PRECIO_VENTA);
                model.Command.Parameters.AddWithValue("@STOCK", item.STOCK);
                model.Command.Parameters.AddWithValue("@CODIGO", item.CODIGO);
                model.Command.Parameters.AddWithValue("@CODIGO2", item.CODIGO2);
                model.Command.Parameters.AddWithValue("@NOMBRE_MARCA_REPUESTO", item.NOMBRE_MARCA_REPUESTO);
                model.Command.Parameters.AddWithValue("@NOMBRE_MARCA_VEHICULO", item.NOMBRE_MARCA_VEHICULO);
                model.Command.Parameters.AddWithValue("@NOMBRE_LINEA_VEHICULO", item.NOMBRE_SERIE_VEHICULO);
                model.Command.Parameters.AddWithValue("@NOMBRE_DISTRIBUIDOR", item.NOMBRE_DISTRIBUIDOR);
                model.Command.Parameters.AddWithValue("@PATH", item.PATH_IMAGEN);
                model.Command.Parameters.AddWithValue("@ANIO_INICIAL", item.ANIO_INICIAL);
                model.Command.Parameters.AddWithValue("@ANIO_FINAL", item.ANIO_FINAL);
                model.Command.Parameters.AddWithValue("@MTIPO", item.MTIPO);
                result = model.GetData<Inventario_BE>();
            }
            return result;
        }
        public List<Inventario_BE> DAL_sp_inventario_select(Inventario_BE item)
        {
            List<Inventario_BE> result = new List<Inventario_BE>();
            using (var model = new UnitOfWork_DistribuidoraElEden("sp_inventario_select"))
            {
                model.Command.Parameters.AddWithValue("@MTIPO", item.MTIPO);
                model.Command.Parameters.AddWithValue("@ID", item.ID_UPDATE);
                model.Command.Parameters.AddWithValue("@nombreModelo", item.NOMBRE_MODELO);
                model.Command.Parameters.AddWithValue("@nombreMarcaVehiculo", item.NOMBRE_MARCA_VEHICULO);
                model.Command.Parameters.AddWithValue("@nombreLineaVehiculo", item.NOMBRE_LINEA_VEHICULO);
                model.Command.Parameters.AddWithValue("@ANIO_INICIAL", item.ANIO_INICIAL);
                model.Command.Parameters.AddWithValue("@ANIO_FINAL", item.ANIO_FINAL);
                result = model.GetData<Inventario_BE>();
            }
            return result;
        }
        public List<Inventario_BE> DAL_sp_inventario_delete(Inventario_BE item)
        {
            List<Inventario_BE> result = new List<Inventario_BE>();
            using (var model = new UnitOfWork_DistribuidoraElEden("sp_inventario_delete"))
            {
                model.Command.Parameters.AddWithValue("@ID", item.ID_DELETE);
                model.Command.Parameters.AddWithValue("@MTIPO", item.MTIPO);
                result = model.GetData<Inventario_BE>();
            }
            return result;
        }
        public List<Inventario_BE> DAL_sp_compras(Inventario_BE item)
        {
            List<Inventario_BE> result = new List<Inventario_BE>();
            using (var model = new UnitOfWork_DistribuidoraElEden("sp_compras"))
            {
                model.Command.Parameters.AddWithValue("@MTIPO", item.MTIPO);
                model.Command.Parameters.AddWithValue("@ID_COMPRA", item.ID_PRODUCTO);
                model.Command.Parameters.AddWithValue("@NOMBRE_PROVEEDOR", item.NOMBRE_PROVEEDOR);
                model.Command.Parameters.AddWithValue("@CONTACTO_PROVEEDOR", item.CONTACTO_PROVEEDOR);
                model.Command.Parameters.AddWithValue("@FECHA_PEDIDO", item.FECHA_PEDIDO);
                model.Command.Parameters.AddWithValue("@FECHA_PAGO", item.FECHA_PAGO);
                model.Command.Parameters.AddWithValue("@FECHA_ENTREGA", item.FECHA_ENTREGA);
                model.Command.Parameters.AddWithValue("@TELEFONO_PROVEEDOR", item.TELEFONO);
                model.Command.Parameters.AddWithValue("@NO_FACTURA", item.NO_FACTURA);
                model.Command.Parameters.AddWithValue("@MONTO_FACTURA", item.MONTO_FACTURA);
                model.Command.Parameters.AddWithValue("@SERIE_FACTURA", item.SERIE_FACTURA);
                model.Command.Parameters.AddWithValue("@CREADO_POR", item.CREADO_POR);
                model.Command.Parameters.AddWithValue("@FILE1", item.FILE1);
                model.Command.Parameters.AddWithValue("@FILE2", item.FILE2);
                result = model.GetData<Inventario_BE>();
            }
            return result;
        }
        public List<Reportes_BE> DAL_sp_reportes(Reportes_BE item)
        {
            List<Reportes_BE> result = new List<Reportes_BE>();
            using (var model = new UnitOfWork_DistribuidoraElEden("sp_reportes"))
            {
                model.Command.Parameters.AddWithValue("@FECHA_INICIAL", item.FECHA_INICIAL);
                model.Command.Parameters.AddWithValue("@FECHA_FINAL", item.FECHA_FINAL);
                model.Command.Parameters.AddWithValue("@ID_VENTA", item.ID_VENTA);
                model.Command.Parameters.AddWithValue("@CODIGO", item.CODIGO);
                model.Command.Parameters.AddWithValue("@MTIPO", item.MTIPO);
                result = model.GetData<Reportes_BE>();
            }
            return result;
        }
        public List<Usuarios_BE> DAL_sp_usuarios(Usuarios_BE item)
        {
            List<Usuarios_BE> result = new List<Usuarios_BE>();
            using (var model = new UnitOfWork_DistribuidoraElEden("sp_usuarios"))
            {
                model.Command.Parameters.AddWithValue("@PRIMER_NOMBRE", item.PRIMER_NOMBRE);
                model.Command.Parameters.AddWithValue("@SEGUNDO_NOMBRE", item.SEGUNDO_NOMBRE);
                model.Command.Parameters.AddWithValue("@PRIMER_APELLIDO", item.PRIMER_APELLIDO);
                model.Command.Parameters.AddWithValue("@SEGUNDO_APELLIDO", item.SEGUNDO_APELLIDO);
                model.Command.Parameters.AddWithValue("@DIRECCION", item.DIRECCION);
                model.Command.Parameters.AddWithValue("@TELEFONO", item.TELEFONO);
                model.Command.Parameters.AddWithValue("@ID_TIPO_EMPLEADO", item.ID_TIPO_EMPLEADO);
                model.Command.Parameters.AddWithValue("@EMAIL", item.EMAIL);
                model.Command.Parameters.AddWithValue("@CREADO_POR", item.CREADO_POR);
                model.Command.Parameters.AddWithValue("@USUARIO", item.USUARIO);
                model.Command.Parameters.AddWithValue("@PASSWORD", item.PASSWORD);
                model.Command.Parameters.AddWithValue("@ID_ROL", item.ID_ROL);
                model.Command.Parameters.AddWithValue("@URL_FOTOGRAFIA", item.PATH);
                model.Command.Parameters.AddWithValue("@MTIPO", item.MTIPO);
                model.Command.Parameters.AddWithValue("@ID_EMPLEADO_EDITAR", item.ID_EMPLEADO);
                result = model.GetData<Usuarios_BE>();
            }
            return result;
        }
        public List<Usuarios_BE> DAL_sp_login(Usuarios_BE item)
        {
            List<Usuarios_BE> result = new List<Usuarios_BE>();
            using (var model = new UnitOfWork_DistribuidoraElEden("sp_login"))
            {
                model.Command.Parameters.AddWithValue("@USUARIO", item.USUARIO);
                model.Command.Parameters.AddWithValue("@PASSWORD", item.PASSWORD);
                model.Command.Parameters.AddWithValue("@CORREO", item.EMAIL);
                model.Command.Parameters.AddWithValue("@MTIPO", item.MTIPO);
                result = model.GetData<Usuarios_BE>();
            }
            return result;
        }
        public List<Ventas__BE> DAL_sp_ventas(Ventas__BE item)
        {
            List<Ventas__BE> result = new List<Ventas__BE>();
            using (var model = new UnitOfWork_DistribuidoraElEden("sp_ventas"))
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
                model.Command.Parameters.AddWithValue("@FECHA_FACTURA", item.FECHA_FACTURA);
                //model.Command.Parameters.AddWithValue("@FEL", item.FEL);
                //model.Command.Parameters.AddWithValue("@NOMBREDESC", item.NOMBRE);
                result = model.GetData<Ventas__BE>();
            }
            return result;
        }
    }
}
