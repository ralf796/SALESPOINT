namespace Helpers
{
    public partial class Tools
    {
        #region Porcentaje
        public static decimal Porcentaje(object value1, object value2)
        {
            try
            {
                return (Convert.ToDecimal(value1) / Convert.ToDecimal(value2)) * 100;
            }
            catch
            {
                return 0.00m;
            }
        }
        public static decimal PorcentajeDecimal(object value1, object value2)
        {
            return Porcentaje(value1, value2) / 100;
        }
        public static string PorcentajeTexto(object value1, object value2, int decimales = 0)
        {
            return $"{Math.Round(Porcentaje(value1, value2), decimales)}%";
        }
        #endregion
        #region Division
        public static decimal Dividir(decimal value1, decimal value2)
        {
            try
            {
                if (value2 == 0)
                    return 0.00m;
                else
                    return value1 / value2;
            }
            catch
            {
                return 0.00m;
            }
        }
        public static int Dividir(int value1, int value2)
        {
            try
            {
                if (value2 == 0)
                    return 0;
                else
                    return value1 / value2;
            }
            catch
            {
                return 0;
            }
        }
        #endregion
    }
}
