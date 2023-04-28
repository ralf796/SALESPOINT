using System;
namespace RESTAURANTE
{
    public class Accesos_BE
    {
        public int ID_ACCESO { get; set; }
        public string USUARIO { get; set; }
        public int ID_MENU_SYS { get; set; }
        public string NOMBRE { get; set; }
        public string LINK { get; set; }
        public string ICONO { get; set; }
        public int ID_PADRE { get; set; }
        public int ID_MODULO { get; set; }
        public int ORDEN { get; set; }
        public int ESTADO { get; set; }
        public int TIPO { get; set; }
        public string PASSWORD { get; set; }
        public string EMAIL { get; set; }
        public int MTIPO { get; set; }
        public int ES_PADRE { get; set; }
    }
}
