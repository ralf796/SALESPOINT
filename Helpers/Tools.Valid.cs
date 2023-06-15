using System.Text.RegularExpressions;
namespace Helpers
{
    public partial class Tools
    {
        public static bool ValidarCUI(string cui)
        {
            try
            {
                if (string.IsNullOrEmpty(cui))
                    return false;


                Regex regex = new Regex("^[0-9]{4}[0-9]{5}[0-9]{4}$", RegexOptions.None, TimeSpan.FromSeconds(5));

                if (!regex.IsMatch(cui))
                    return false;


                var depto = int.Parse(cui.Substring(9, 2));
                var muni = int.Parse(cui.Substring(11, 2));
                var numero = cui.Substring(0, 8);
                var verificador = int.Parse(cui.Substring(8, 1));

                // Se asume que la codificación de Municipios y 
                // departamentos es la misma que esta publicada en 
                // http://goo.gl/EsxN1a

                // Listado de municipios actualizado segun:
                // http://goo.gl/QLNglm

                // Este listado contiene la cantidad de municipios
                // existentes en cada departamento para poder 
                // determinar el código máximo aceptado por cada 
                // uno de los departamentos.
                int[] munisPorDepto = {
                    /* 01 - Guatemala tiene:      */ 17 /* municipios. */,
                    /* 02 - El Progreso tiene:    */  8 /* municipios. */,
                    /* 03 - Sacatepéquez tiene:   */ 16 /* municipios. */,
                    /* 04 - Chimaltenango tiene:  */ 16 /* municipios. */,
                    /* 05 - Escuintla tiene:      */ 13 /* municipios. */,
                    /* 06 - Santa Rosa tiene:     */ 14 /* municipios. */,
                    /* 07 - Sololá tiene:         */ 19 /* municipios. */,
                    /* 08 - Totonicapán tiene:    */  8 /* municipios. */,
                    /* 09 - Quetzaltenango tiene: */ 24 /* municipios. */,
                    /* 10 - Suchitepéquez tiene:  */ 21 /* municipios. */,
                    /* 11 - Retalhuleu tiene:     */  9 /* municipios. */,
                    /* 12 - San Marcos tiene:     */ 30 /* municipios. */,
                    /* 13 - Huehuetenango tiene:  */ 32 /* municipios. */,
                    /* 14 - Quiché tiene:         */ 21 /* municipios. */,
                    /* 15 - Baja Verapaz tiene:   */  8 /* municipios. */,
                    /* 16 - Alta Verapaz tiene:   */ 17 /* municipios. */,
                    /* 17 - Petén tiene:          */ 14 /* municipios. */,
                    /* 18 - Izabal tiene:         */  5 /* municipios. */,
                    /* 19 - Zacapa tiene:         */ 11 /* municipios. */,
                    /* 20 - Chiquimula tiene:     */ 11 /* municipios. */,
                    /* 21 - Jalapa tiene:         */  7 /* municipios. */,
                    /* 22 - Jutiapa tiene:        */ 17 /* municipios. */
                };

                if (depto == 0 || muni == 0)
                {
                    return false;
                }

                if (depto > munisPorDepto.Length)
                {
                    return false;
                }

                if (muni > munisPorDepto[depto - 1])
                {
                    return false;
                }

                // Se verifica el correlativo con base 
                // en el algoritmo del complemento 11.
                var total = 0;

                for (var i = 0; i < numero.Length; i++)
                {
                    total += numero[i] * (i + 2);
                }

                var modulo = (total % 11);

                return modulo == verificador;



            }
            catch
            {
                return false;
            }
        }
        public static bool ValidarNIT(string nit)
        {
            bool retorno = false;
            try
            {
                nit = nit.Replace("-", "").Replace(".", "").Replace("/", "").Trim();
                if (string.IsNullOrEmpty(nit))
                    retorno = false;
                else if (nit.Equals("CF"))
                    retorno = true;
                else
                {
                    int pos = nit.Trim().Length - 1;
                    string correlativo = nit.Substring(0, pos);
                    string verificador = nit.Substring(pos, 1);
                    int resultado = 0;
                    int resultadofactor = 0;
                    int operacion = 0;
                    int valida = 0;

                    try
                    {
                        int suma = 0;

                        for (int x = 0; x <= pos - 1; x++)
                            suma += Convert.ToInt32(correlativo.Substring(x, 1)) * ((pos + 1) - x);

                        //Buscamos el factor
                        resultado = suma / 11;
                        resultadofactor = resultado * 11;
                        operacion = suma - resultadofactor;

                        //Buscamos el operador
                        resultado = operacion / 11;
                        resultadofactor = resultado * 11;
                        operacion -= resultadofactor;

                        valida = 11 - operacion;

                        return (valida.ToString() == verificador) || (verificador == "0") || (verificador.ToUpper().Equals("K"));
                    }
                    catch
                    {
                        if (verificador == "0" || verificador.ToUpper() == "K")
                            retorno = true;
                        else
                            retorno = false;
                    }
                }
            }
            catch
            {
                retorno = false;
            }
            return retorno;
        }
        public static bool ValidarCreditCard(string cardNumber)
        {
            int nDigits = cardNumber.Length;

            int nSum = 0;
            bool isSecond = false;
            for (int i = nDigits - 1; i >= 0; i--)
            {

                int d = cardNumber[i] - '0';

                if (isSecond == true)
                    d = d * 2;

                // We add two digits to handle
                // cases that make two digits 
                // after doubling
                nSum += d / 10;
                nSum += d % 10;

                isSecond = !isSecond;
            }
            return (nSum % 10 == 0);
        }
        public static bool ValidarCorreo(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                    return false;
                else
                {
                    System.Net.Mail.MailAddress m = new System.Net.Mail.MailAddress(email);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public static bool ValidarCUILength(string cod_emp = "", string cui = "", bool esPasaporte = false, string codCliente = "")
        {
            bool respuesta = false;
            try
            {
                int largodpi = cui.Length;

                int largonacionalidad = 0;
                if (esPasaporte)
                    largonacionalidad = 9;
                else
                    largonacionalidad = 12;

                if ((cod_emp == "1" || cod_emp == "3") && largodpi == 13)
                    respuesta = true;
                else if (cod_emp == "2" && largodpi == 9)
                    respuesta = true;
                else if (cod_emp == "4" && largodpi == 14)
                    respuesta = true;
                else if (cod_emp == "5" && largodpi == largonacionalidad)
                    respuesta = true;
                else if (cod_emp == "8")
                    respuesta = (largodpi == 11 && codCliente.ToUpper().Substring(0) == "R") || (largodpi == 4);
            }
            catch
            {
                respuesta = false;
            }
            return respuesta;
        }
        public static int GetCUILength(string cod_emp = "", bool esPasaporte = false, bool esHaiti = false)
        {
            int largodpi = 0;
            try
            {
                if (cod_emp == "1" || cod_emp == "3")
                    largodpi = 13;
                else if (cod_emp == "2")
                    largodpi = 9;
                else if (cod_emp == "4")
                    largodpi = 14;
                else if (cod_emp == "5")
                {
                    if (esPasaporte)
                        largodpi = 9;
                    else
                        largodpi = 12;
                }
                else if (cod_emp == "8")
                {
                    if (esHaiti)
                        largodpi = 4;
                    else
                        largodpi = 11;
                }
            }
            catch
            {
                largodpi = 0;
            }
            return largodpi;
        }
    }
}