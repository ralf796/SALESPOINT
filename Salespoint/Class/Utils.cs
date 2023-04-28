using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Style;
using System;
using System.Configuration;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;

namespace HELPERS
{
    public class Utils
    {

        public int GetUsuarioRol()
        {
            int respuesta = 0;
            return respuesta;
        }

        private static string ObtenerConexion()
        {
            return ConfigurationManager.ConnectionStrings["genesysConnectionString"].ToString();
        }

        public static string ObtenerServidor()
        {
            var server = ConfigurationManager.ConnectionStrings["genesysEntities"].ConnectionString;
            if (server.Contains("192.168.136.23"))
                server = "DESARROLLO";
            else if (server.Contains("dbgenesys"))
                server = "ORACLE AUTONOMOUS";
            else
                server = "SERVER UNKNOWN";
            return server;
        }

        public static string GenerarToken(string cadena)
        {
            int aleatorio = new Random().Next(10000, 99999);
            cadena += aleatorio.ToString() + DateTime.Now.ToString("ddMMyyyy").Trim().ToUpper();
            return Encryption.Instance.Encrypt(cadena);
        }


        public enum Roles : int
        {
            SUPER_USUARIO = 1,
            ADMINISTRADOR = 2,
            CAJERO = 3,
            BODEGUERO = 4,
            SECRETARIA = 5,
            VENDEDOR = 6
        }

        public static class RandomGenerator
        {
            // Generate a random number between two numbers    
            public static int RandomNumber(int min, int max)
            {
                Random random = new Random();
                return random.Next(min, max);
            }

            // Generate a random string with a given size    
            public static string RandomString(int size, bool lowerCase)
            {
                StringBuilder builder = new StringBuilder();
                Random random = new Random();
                char ch;
                for (int i = 0; i < size; i++)
                {
                    ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                    builder.Append(ch);
                }
                if (lowerCase)
                    return builder.ToString().ToLower();
                return builder.ToString();
            }

            // Generate a random password    
            public static string RandomPassword()
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(RandomString(4, true));
                builder.Append(RandomNumber(1000, 9999));
                builder.Append(RandomString(2, false));
                return builder.ToString();
            }
        }

        public static bool ValidarSesion(string usuario = "")
        {
            bool resultado = true;
            try
            {
                if (usuario == "" || usuario == null)
                {
                    resultado = false;
                }
            }
            catch
            {
                resultado = false;
            }
            return resultado;
        }

        public static void FillBackgroundColorCells(ExcelWorksheet workSheet, ExcelRange rango, int row, int col, string color)
        {
            rango = workSheet.Cells[row, col];
            rango.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;

            if (color == "gray1")   //TOTALES
                rango.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#D3D3D3"));
            else if (color == "gray2")
                rango.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#C0C0C0"));
            else if (color == "gray3")
                rango.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#EAECEE"));
            else if (color == "gray4")
                rango.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#A9A9A9"));
            else if (color == "gray5")
                rango.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#808080"));
            else if (color == "green1")
                rango.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#CCFF66"));
            else if (color == "green2")
                rango.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#ADFF2F"));
            else if (color == "blue1")
            {
                rango.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#0070C0"));
                rango.Style.Font.Color.SetColor(ColorTranslator.FromHtml("#FFFFFF"));
            }
        }

        public static void FillBackgroundRange(ExcelWorksheet workSheet, ExcelRange rango, int row, int col1, int col2, string color)
        {
            for (int i = col1; i <= col2; i++)
            {
                rango = workSheet.Cells[row, i];
                rango.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;

                if (color.ToUpper() == "GRAY1")   //TOTALES
                    rango.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#D3D3D3"));
                else if (color.ToUpper() == "GRAY2")
                    rango.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#C0C0C0"));
                else if (color.ToUpper() == "GRAY3")
                    rango.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#EAECEE"));
                else if (color.ToUpper() == "GRAY4")
                    rango.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#A9A9A9"));
                else if (color.ToUpper() == "GRAY5")
                    rango.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#808080"));
                else if (color.ToUpper() == "GREEN1")
                    rango.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#CCFF66"));
                else if (color.ToUpper() == "GREEN2")
                    rango.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#ADFF2F"));
                else if (color.ToUpper() == "BLUE1")
                {
                    rango.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#0070C0"));
                    rango.Style.Font.Color.SetColor(ColorTranslator.FromHtml("#FFFFFF"));
                }
                else if (color.ToUpper() == "BLACK")
                {
                    rango.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#000000"));
                    rango.Style.Font.Color.SetColor(ColorTranslator.FromHtml("#FFFFFF"));
                }
            }
        }

        public static void FillBorderCellsAll(ExcelWorksheet workSheet, string rango)
        {
            using (ExcelRange Rng = workSheet.Cells[rango])
            {
                Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                Rng.Style.Border.Top.Color.SetColor(Color.Black);
                Rng.Style.Border.Bottom.Color.SetColor(Color.Black);
                Rng.Style.Border.Left.Color.SetColor(Color.Black);
                Rng.Style.Border.Right.Color.SetColor(Color.Black);
                workSheet.Cells.AutoFitColumns();
            }
        }

        public static void AddTextCells(ExcelWorksheet workSheet, string position, string text, int row, int col)
        {
            workSheet.Cells[row, col].Value = text;

            if (position.ToUpper() == "L")
                workSheet.Cells[row, col].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
            else if (position.ToUpper() == "R")
                workSheet.Cells[row, col].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
            else if (position.ToUpper() == "C")
                workSheet.Cells[row, col].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
        }

        public static void MergeCellsExcel(ExcelWorksheet workSheet, ExcelRange rango, int row, int col1, int col2, string texto, int fontSize, bool bold, string position)
        {
            workSheet.Cells[row, col1].Value = texto;
            workSheet.Select(ExcelAddress.GetAddress(row, col1, row, col2));
            workSheet.Cells[row, col1].Style.Font.Bold = bold;
            workSheet.Cells[row, col1].Style.Font.Size = fontSize;
            //workSheet.Cells[row, col1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

            if (position.ToUpper() == "L")
                workSheet.Cells[row, col1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
            else if (position.ToUpper() == "R")
                workSheet.Cells[row, col1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
            else if (position.ToUpper() == "C")
                workSheet.Cells[row, col1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

            rango = workSheet.SelectedRange;
            rango.Merge = true;
        }

        public static void AddText(ExcelWorksheet workSheet, int row, int col, string texto, decimal valor, int size, bool bold, string position, int formatCell)
        {
            if (texto != "")
                workSheet.Cells[row, col].Value = texto;
            else
                workSheet.Cells[row, col].Value = valor;

            workSheet.Cells[row, col].Style.Font.Size = size;
            workSheet.Cells[row, col].Style.Font.Bold = bold;
            workSheet.Cells[row, col].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;

            if (position.ToUpper() == "L")
                workSheet.Cells[row, col].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
            else if (position.ToUpper() == "R")
                workSheet.Cells[row, col].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
            else if (position.ToUpper() == "C")
                workSheet.Cells[row, col].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

            if (formatCell == 1)
            {
                workSheet.Cells[row, col].Style.Numberformat.Format = "#,##0.00";
            }
        }

        public static void MergeCell(ExcelWorksheet workSheet, ExcelRange rango, string ini, string fin)
        {
            rango = workSheet.Cells[$"{ini}:{fin}"];
            rango.Merge = true;
        }

        public static void SizeColumn(ExcelWorksheet workSheet, int column, int size)
        {
            workSheet.Column(column).Width = size;
        }

        public static void GridLinesExcel(ExcelWorksheet workSheet, bool lines)
        {
            workSheet.View.ShowGridLines = lines;
        }

        public static void ChartProperties(ExcelChart chart, string titleChart, int sizeChart1, int sizeChart2, int positionRow, int positionCol, bool showTable)
        {
            chart.Title.Text = titleChart;
            chart.SetSize(sizeChart1, sizeChart2);
            chart.SetPosition(positionRow, 0, positionCol, 0);

            if (showTable)
                chart.PlotArea.CreateDataTable();
        }

        public static void SerieChartProperties(ExcelChart chart, ExcelBarChartSerie serie, bool bold, bool showValue, bool showPercent, bool showLeaderLines, bool showTable, eLabelPosition position)
        {
            serie.DataLabel.Font.Bold = bold;
            serie.DataLabel.ShowValue = showValue;
            serie.DataLabel.ShowPercent = showPercent;
            serie.DataLabel.ShowLeaderLines = showLeaderLines;
            serie.DataLabel.Position = position;

            if (showTable)
                chart.PlotArea.CreateDataTable();
        }
        public static void CellBold(ExcelWorksheet workSheet, int row, int col, bool bold, int fontSize)
        {
            workSheet.Cells[row, col].Style.Font.Bold = bold;
            workSheet.Cells[row, col].Style.Font.Size = fontSize;
        }

        public static int GetPaisSocio(string codCliente = "")
        {
            int codEmp = 0;

            char[] charArray = codCliente.ToCharArray();
            char prefijo = charArray[0];

            switch (prefijo.ToString())
            {
                case "G":
                    codEmp = 1;
                    break;
                case "E":
                    codEmp = 2;
                    break;
                case "H":
                    codEmp = 3;
                    break;
                case "N":
                    codEmp = 4;
                    break;
                case "C":
                    codEmp = 5;
                    break;
                case "D":
                    codEmp = 5;
                    break;
                case "R":
                    codEmp = 8;
                    break;
                case "T":
                    codEmp = 8;
                    break;
            }
            return codEmp;
        }
        public static string mes_letras(int mes)
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
        public static string Dia_Semana(int dia)
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
        public static string Fecha_Larga_Letras(DateTime fecha)
        {
            string resultado = "";

            resultado += Dia_Semana((int)fecha.DayOfWeek);
            resultado += ", " + fecha.Day.ToString();
            resultado += " de " + mes_letras(fecha.Month);
            resultado += " de " + fecha.Year.ToString();


            return resultado;
        }
        public static string Mes_Corto_Letras(int mes)
        {
            string resultado = "";

            switch (mes.ToString())
            {

                case "1":
                    resultado = "Ene";
                    break;
                case "2":
                    resultado = "Feb";
                    break;
                case "3":
                    resultado = "Mar";
                    break;
                case "4":
                    resultado = "Abr";
                    break;
                case "5":
                    resultado = "May";
                    break;
                case "6":
                    resultado = "Jun";
                    break;
                case "7":
                    resultado = "Jul";
                    break;
                case "8":
                    resultado = "Ago";
                    break;
                case "9":
                    resultado = "Sep";
                    break;
                case "10":
                    resultado = "Oct";
                    break;
                case "11":
                    resultado = "Nov";
                    break;
                case "12":
                    resultado = "Dic";
                    break;



                default:
                    break;
            }



            return resultado;
        }
        public static string Mes_Completo_Letras(int mes)
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

        public static string ValidarNit(string numeronit)
        {
            string nitvalido = null;
            numeronit = numeronit.ToUpper();
            numeronit = numeronit.Trim();

            //expresion regular que valida si el el string cumple con el patron del nit
            string strPatron = @"^[0-9]+-([K]|[0-9])$";

            bool coincide = Regex.IsMatch(numeronit, strPatron);

            if (coincide == true & numeronit.Length > 3)
            {
                //obtiene la posicion del guion 
                int pos = numeronit.IndexOf("-");

                //obtiene los numeros antes del guion
                string strCorrelativo = numeronit.Substring(0, pos);
                //obtiene el Digito Verificador
                string strDigitoVerificador = numeronit.Substring(pos + 1);
                strDigitoVerificador = strDigitoVerificador.Trim();

                //variables para la validacion
                int Factor = strCorrelativo.Length + 1;
                int Suma = 0;
                int Valor = 0;

                //empieza el proceso de la validacion
                for (int x = 0; x <= pos - 1; x++)
                {
                    Valor = Int32.Parse(numeronit.Substring(x, 1));
                    Suma = Suma + (Valor * Factor);
                    Factor = Factor - 1;
                }

                //Se obtiene el residuo para validar con el Digito Verificador
                double xMod11 = 0;
                xMod11 = (11 - (Suma % 11)) % 11;
                string verificador = Math.Floor(xMod11).ToString();

                if ((verificador.Equals(strDigitoVerificador)) | (xMod11 == 10 && strDigitoVerificador.Equals("K")))
                {
                    nitvalido = numeronit;

                    nitvalido = nitvalido.Replace("-", "");

                    string ceros = "";

                    //se complementa con ceros el nit validado
                    for (int g = 0; g < 12 - nitvalido.Length; g++)
                    {
                        //ceros += "0";
                        ceros += "";
                    }

                    nitvalido = ceros + nitvalido;
                }
                else
                {
                    nitvalido = "CF";
                }

            }
            else
            {
                string nit = "";

                if (numeronit.Length >= 1)
                {
                    nit = numeronit.Substring(0, 1);

                    if (nit.Equals("C"))
                    {
                        nitvalido = "CF";
                    }
                    else
                    {
                        nitvalido = "CF";
                    }
                }
                else
                {
                    nitvalido = "CF";
                }
            }

            //retorna el nit ya validado y con el formato requerido para el XML
            return nitvalido;

        }


        public static string NullString(string cadena)
        {
            string respuesta = "";
            try
            {
                if (cadena == null)
                    respuesta = "";
                else if (cadena == "")
                    respuesta = "";
                else
                    respuesta = cadena;
            }
            catch
            {
                respuesta = "";
            }
            return respuesta;
        }
        public static decimal NullDecimal(string cadena)
        {
            decimal respuesta = 0;
            try
            {
                if (cadena == null)
                    respuesta = 0;
                else if (cadena == "")
                    respuesta = 0;
                else
                    respuesta = Convert.ToDecimal(cadena);
            }
            catch
            {
                respuesta = 0;
            }
            return respuesta;
        }
        public static int NullInt(string cadena)
        {
            int respuesta = 0;
            try
            {
                if (cadena == null)
                    respuesta = 0;
                else if (cadena == "")
                    respuesta = 0;
                else
                    respuesta = Convert.ToInt16(cadena);
            }
            catch
            {
                respuesta = 0;
            }
            return respuesta;
        }


        #region CONVERTIR NUMEROS A LETRAS
        public static string[] UNIDADES = { "", "un ", "dos ", "tres ", "cuatro ", "cinco ", "seis ", "siete ", "ocho ", "nueve " };
        public static string[] DECENAS = {"diez ", "once ", "doce ", "trece ", "catorce ", "quince ", "dieciseis ",
        "diecisiete ", "dieciocho ", "diecinueve", "veinte ", "treinta ", "cuarenta ",
        "cincuenta ", "sesenta ", "setenta ", "ochenta ", "noventa "};
        public static string[] CENTENAS = {"", "ciento ", "doscientos ", "trescientos ", "cuatrocientos ", "quinientos ", "seiscientos ",
        "setecientos ", "ochocientos ", "novecientos "};

        public Regex r;        
        public static string Convertir(string numero, bool mayusculas, string moneda = "GTQ")
        {

            string literal = "";
            string parte_decimal = "";
            //si el numero utiliza (,) en lugar de (.) -> se reemplaza
            numero = numero.Replace(",", ".");

            //si el numero no tiene parte decimal, se le agrega ,00
            if (numero.IndexOf(".") == -1)
            {
                numero = numero + ".00";
            }
            else
            {
                if (numero.Length - 1 - numero.IndexOf(".") == 1)
                {
                    numero = numero + "0";
                }
            }
            //se valida formato de entrada -> 0,00 y 999 999 999,00
            // r = new Regex(@"\d{1,9}.\d{1,2}");
            // MatchCollection mc = r.Matches(numero);
            //    if (mc.Count > 0)
            //    {
            //se divide el numero 0000000,00 -> entero y decimal
            string[] Num = numero.Split('.');

            //se da formato al numero decimal
            string texto = moneda == "GTQ" ? "/100 QUETZALES" : "/100 DOLARES";
            parte_decimal = numero.Substring(numero.IndexOf(".") + 1, 2) + texto;
            //se convierte el numero a literal
            if (int.Parse(Num[0]) == 0)
            {//si el valor es cero                
                literal = "cero ";
            }
            else if (int.Parse(Num[0]) > 999999)
            {//si es millon
                literal = getMillones(Num[0]);
            }
            else if (int.Parse(Num[0]) > 999)
            {//si es miles
                literal = getMiles(Num[0]);
            }
            else if (int.Parse(Num[0]) > 99)
            {//si es centena
                literal = getCentenas(Num[0]);
            }
            else if (int.Parse(Num[0]) > 9)
            {//si es decena
                literal = getDecenas(Num[0]);
            }
            else
            {//sino unidades -> 9
                literal = getUnidades(Num[0]);
            }
            //devuelve el resultado en mayusculas o minusculas
            if (mayusculas)
            {
                return (literal + parte_decimal).ToUpper();
            }
            else
            {
                return (literal + parte_decimal);
            }
            //  }
            //   else
            //  {//error, no se puede convertir
            //     return literal = null;
            // }
        }
        public static string getUnidades(String numero)
        {   // 1 - 9            
            //si tuviera algun 0 antes se lo quita -> 09 = 9 o 009=9
            String num = numero.Substring(numero.Length - 1);
            return UNIDADES[int.Parse(num)];
        }
        public static string getDecenas(String num)
        {// 99                        
            int n = int.Parse(num);
            if (n < 10)
            {//para casos como -> 01 - 09
                return getUnidades(num);
            }
            else if (n > 19)
            {//para 20...99
                String u = getUnidades(num);
                if (u.Equals(""))
                { //para 20,30,40,50,60,70,80,90
                    return DECENAS[int.Parse(num.Substring(0, 1)) + 8];
                }
                else
                {
                    return DECENAS[int.Parse(num.Substring(0, 1)) + 8] + "y " + u;
                }
            }
            else
            {//numeros entre 11 y 19
                return DECENAS[n - 10];
            }
        }
        public static String getCentenas(String num)
        {// 999 o 099
            if (int.Parse(num) > 99)
            {//es centena
                if (int.Parse(num) == 100)
                {//caso especial
                    return " cien ";
                }
                else
                {
                    return CENTENAS[int.Parse(num.Substring(0, 1))] + getDecenas(num.Substring(1));
                }
            }
            else
            {//por Ej. 099 
                //se quita el 0 antes de convertir a decenas
                return getDecenas(int.Parse(num) + "");
            }
        }
        public static String getMiles(String numero)
        {// 999 999
            //obtiene las centenas
            String c = numero.Substring(numero.Length - 3);
            //obtiene los miles
            String m = numero.Substring(0, numero.Length - 3);
            String n = "";
            //se comprueba que miles tenga valor entero
            if (int.Parse(m) > 0)
            {
                n = getCentenas(m);
                return n + "mil " + getCentenas(c);
            }
            else
            {
                return "" + getCentenas(c);
            }

        }
        public static String getMillones(String numero)
        { //000 000 000        
            //se obtiene los miles
            String miles = numero.Substring(numero.Length - 6);
            //se obtiene los millones
            String millon = numero.Substring(0, numero.Length - 6);
            String n = "";
            if (millon.Length > 1)
            {
                n = getCentenas(millon) + "millones ";
            }
            else
            {
                n = getUnidades(millon) + "millon ";
            }
            return n + getMiles(miles);
        }
        #endregion

        public static bool ValidarDPI(string dpi)
        {
            var regex = "^[0-9]{4}[0-9]{5}[0-9]{4}$";
            var test = Regex.IsMatch(dpi, regex);

            if (!test)
            {
                return false;
            }

            var cui = dpi.Replace("-", "");
            var cui2 = cui.Replace(" ", "");

            cui = "";
            cui = cui2;

            var numero = cui.Substring(0, 8);


            var depto = Convert.ToInt32(cui.Substring(9, 2));
            var muni = Convert.ToInt32(cui.Substring(11, 2));

            var validador = Convert.ToInt32(cui.Substring(8, 1));

            // Conteo de municipios por departamento  
            int[] munisPorDepto =
            {  
                /* 01 - Guatemala    */ 17,  
                /* 02 - El Progreso   */ 8,  
                /* 03 - Sacatepéquez  */ 16,  
                /* 04 - Chimaltenango  */ 16,  
                /* 05 - Escuintla    */ 14,  
                /* 06 - Santa Rosa   */ 14,  
                /* 07 - Sololá     */ 19,  
                /* 08 - Totonicapán   */ 8,  
                /* 09 - Quetzaltenango */ 24,  
                /* 10 - Suchitepéquez  */ 21,  
                /* 11 - Retalhuleu   */ 9,  
                /* 12 - San Marcos   */ 30,  
                /* 13 - Huehuetenango  */ 33,  
                /* 14 - Quiché     */ 21,  
                /* 15 - Baja Verapaz  */ 8,  
                /* 16 - Alta Verapaz  */ 17,  
                /* 17 - Petén      */ 14,  
                /* 18 - Izabal     */ 5,  
                /* 19 - Zacapa     */ 11,  
                /* 20 - Chiquimula   */ 11,  
                /* 21 - Jalapa     */ 7,  
                /* 22 - Jutiapa     */ 17
            };

            if (muni == 0 || depto == 0)
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

            int total = 0;
            for (int i = 0; i < numero.Length; i++)
            {
                total += (Convert.ToInt32(numero.Substring(i, 1))) * (i + 2);
            }

            int modulo = total % 11;

            return modulo == validador;
        }
    }
}