using System;
namespace RESTAURANTE
{
    public class Clientes_BE
    {
        public int? ID_CLIENTE { get; set; }
        public string NOMBRE { get; set; }
        public string DIRECCION_PRINCIPAL { get; set; }
        public string TELEFONO_PRINCIPAL { get; set; }
        public string EMAIL { get; set; }
        public string NIT { get; set; }
        public string CREADO_POR { get; set; }
        public int? MTIPO { get; set; }
        public int? ESTADO { get; set; }
        public string RESPUESTA { get; set; }
        public string Descripcion { get; set; }
        public bool Resultado { get; set; }
    }
}
