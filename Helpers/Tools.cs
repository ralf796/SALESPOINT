namespace Helpers
{
    public partial class Tools
    {
        protected Tools() { }
        #region Fechas
        public static string MesCorto(DateTime mes) => MesCorto(mes.Month);
        public static string MesCorto(int mes)
        {
            return MesEnLetras(mes).Substring(0, 3);
        }
        public static string MesEnLetras(DateTime mes) => MesEnLetras(mes.Month);
        public static string MesEnLetras(string mes) => MesEnLetras(int.Parse(mes));
        public static string MesEnLetras(int mes)
        {
            string resultado = "";

            switch (mes.ToString())
            {

                case "1":
                    resultado = "Enero";
                    break;
                case "2":
                    resultado = "Febrero";
                    break;
                case "3":
                    resultado = "Marzo";
                    break;
                case "4":
                    resultado = "Abril";
                    break;
                case "5":
                    resultado = "Mayo";
                    break;
                case "6":
                    resultado = "Junio";
                    break;
                case "7":
                    resultado = "Julio";
                    break;
                case "8":
                    resultado = "Agosto";
                    break;
                case "9":
                    resultado = "Septiembre";
                    break;
                case "10":
                    resultado = "Octubre";
                    break;
                case "11":
                    resultado = "Noviembre";
                    break;
                case "12":
                    resultado = "Diciembre";
                    break;



                default:
                    break;
            }



            return resultado;
        }
        public static string DiaSemana(DateTime dia) => DiaSemana((int)dia.DayOfWeek);
        public static string DiaSemana(int dia)
        {
            string resultado = "";

            switch (dia.ToString())
            {
                case "0":
                    resultado = "Domingo";
                    break;
                case "1":
                    resultado = "Lunes";
                    break;
                case "2":
                    resultado = "Martes";
                    break;
                case "3":
                    resultado = "Miercoles";
                    break;
                case "4":
                    resultado = "Jueves";
                    break;
                case "5":
                    resultado = "Viernes";
                    break;
                case "6":
                    resultado = "Sabado";
                    break;
                default:
                    break;
            }



            return resultado;
        }
        public static string FechaLarga(DateTime fecha)
        {
            string resultado = "";

            resultado += DiaSemana((int)fecha.DayOfWeek);
            resultado += ", " + fecha.Day.ToString();
            resultado += " de " + MesEnLetras(fecha.Month);
            resultado += " de " + fecha.Year.ToString();

            return resultado;
        }
        #endregion
    }
}
