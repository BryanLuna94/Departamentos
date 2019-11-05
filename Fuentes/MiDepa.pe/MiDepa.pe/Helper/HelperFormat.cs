using System;

namespace MiDepa.pe.Helper
{
    public class HelperFormat
    {
        private static readonly string[] FechasNulas = new string[] { "01/01/1800", "01/01/0001", "01/01/1900", "01/01/1000" };
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public static string FechaCorta(DateTime? fecha)
        {
            string fechaResult = (fecha == null) ? string.Empty : fecha.Value.ToString("dd/MM/yyyy");
            return (Array.Exists(FechasNulas, (fechaResult.Contains))) ? string.Empty : fechaResult;
        }

        public static string FechaInputDate(DateTime? fecha)
        {
            string fechaResult = (fecha == null) ? string.Empty : fecha.Value.ToString("yyyy-MM-dd");
            return (Array.Exists(FechasNulas, (fechaResult.Contains))) ? string.Empty : fechaResult;
        }

        public static string QuitarCeros(string texto)
        {
            string numero = " ";

            if (texto == null)
            {
                numero = " ";
            }
            else
            {
                int num = 0;
                int.TryParse(texto, out num);

                numero = num == 0 ? " " : num.ToString();
            }
            return numero;
        }

        public static string Numero(decimal? moneda)
        {
            if (moneda == null)
                return string.Empty;
            return moneda.Value.ToString("###,###,##0.00");
        }

        public static string Moneda(decimal moneda)
        {
            return "S/. " + moneda.ToString("#,##0.00");
        }

        public static string SiNo(bool estado)
        {
            return estado ? "Si" : "No";
        }
    }
}