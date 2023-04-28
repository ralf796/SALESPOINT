using System;
namespace RESTAURANTE
{
    public class Catalogo_BE
    {
        public int MTIPO { get; set; }
        public int ID_VENTA { get; set; }
        public string NOMBRE_CATEGORIA { get; set; }
        public int ID_PRODUCTO { get; set; }
        public string NOMBRE { get; set; }
        public decimal PRECIO_VENTA { get; set; }
        public int STOCK { get; set; }
        public string PATH_IMG { get; set; }
        public int ID_CATEGORIA { get; set; }
        public string DESCRIPCION { get; set; }
        public DateTime FECHA_CREACION { get; set; }
        public string CREADO_POR { get; set; }
        public int ESTADO { get; set; }
        public decimal PRECIO_COSTO { get; set; }
        public decimal MARGEN { get; set; }
        public decimal PROFUNDIDAD { get; set; }
        public decimal TAMANIO { get; set; }
    }
}
