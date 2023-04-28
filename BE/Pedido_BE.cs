using System;
namespace RESTAURANTE
{
    public class Pedido_BE
    {
        public int MTIPO { get; set; }
        public int ID_MESA_MENU { get; set; }
        public int ID_CATEGORIA { get; set; }
        public int ID_MESA { get; set; }
        public int ID_PEDIDO { get; set; }
        public int ID_PRODUCTO { get; set; }
        public int ID_MENU_RESTAURANTE { get; set; }
        public int ID_DETALLE_PEDIDO { get; set; }
        public string OBSERVACIONES { get; set; } = string.Empty;
        public string CREADO_POR { get; set; } = string.Empty;
        public string NOMBRE { get; set; } = string.Empty;
        public string DESCRIPCION { get; set; } = string.Empty;
        public string BG_COLOR { get; set; } = string.Empty;
        public string PATH_IMAGEN { get; set; } = string.Empty;
        public string CODIGO_RESPUESTA { get; set; } = string.Empty;
        public int CANTIDAD { get; set; }
        public decimal PRECIO { get; set; }
        public decimal SUBTOTAL { get; set; }
        public decimal PRECIO_VENTA { get; set; }
        public decimal PRECIO_COSTO { get; set; }
        public int NUMERO { get; set; }
        public int ESTADO { get; set; }
        public int ID_PEDIDO_ENCABEZADO { get; set; }
    }
}
