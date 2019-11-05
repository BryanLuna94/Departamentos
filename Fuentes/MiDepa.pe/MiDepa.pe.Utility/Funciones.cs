using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MiDepa.pe.Utility
{
    public class Funciones
    {
        public class GenericoListaDto
        {
            public string Codigo { get; set; }
            public string Descripcion { get; set; }
        }

        public static string ObtenerDescripcionCampania(int mes, int anio, bool abrev = true)
        {
            string nombreMes;
            string descripcionCampania;

            nombreMes = NombreMes(mes);
            if (abrev) nombreMes = nombreMes.Substring(0, 3);
            descripcionCampania = nombreMes + " " + anio.ToString();

            return descripcionCampania;

        }

        public static List<GenericoListaDto> ListarCampaniasParaFiltro()
        {
            List<GenericoListaDto> listaFinal;
            int anioActual;
            int mesActual;
            string nombreMesActual;
            string codigoCampania;
            string descripcionCampania;

            listaFinal = new List<GenericoListaDto>();
            anioActual = DateTime.Now.Year;
            mesActual = DateTime.Now.Month;

            for (int i = 0; i < 5; i++)
            {
                nombreMesActual = NombreMes(mesActual);
                codigoCampania = anioActual.ToString() + mesActual.ToString("0#");
                descripcionCampania = nombreMesActual + " " + anioActual.ToString();

                listaFinal.Add(new GenericoListaDto { Codigo = codigoCampania, Descripcion = descripcionCampania });

                if (mesActual != 1)
                {
                    mesActual--;
                }
                else
                {
                    mesActual = 12;
                    anioActual--;
                }
            }

            return listaFinal;
        }

        public static string ObtenerNombreDiaSemana(DateTime fecha)
        {
            return fecha.ToString("ddd", new CultureInfo("es-ES"));
        }

        public static int ObtenerPorcentajeAvanceMes(DateTime fechaIni, DateTime fechaFin, DateTime fechaActual)
        {
            decimal porcentaje;
            int totalDias;
            int diasTranscurridos;

            if (fechaActual >= fechaFin)
            {
                return 100;
            }

            if (fechaActual <= fechaIni)
            {
                return 0;
            }

            totalDias = (fechaFin - fechaIni).Days + 1;
            diasTranscurridos = (fechaActual - fechaIni).Days + 1;
            porcentaje = (diasTranscurridos * 100) / totalDias;

            return Convert.ToInt32(decimal.Round(porcentaje, 0));
        }

        public static string NombreMes(int numeroMes)
        {
            try
            {
                return ListaMeses().Single(x => x.Codigo == numeroMes.ToString()).Descripcion;
            }
            catch (Exception)
            {
                throw new Exception("Mes no encontrado");
            }
        }

        public static List<GenericoListaDto> ListaMeses()
        {
            List<GenericoListaDto> listaMeses = new List<GenericoListaDto>
            {
                new GenericoListaDto { Codigo = "1", Descripcion = "ENERO" },
                new GenericoListaDto { Codigo = "2", Descripcion = "FEBRERO" },
                new GenericoListaDto { Codigo = "3", Descripcion = "MARZO" },
                new GenericoListaDto { Codigo = "4", Descripcion = "ABRIL" },
                new GenericoListaDto { Codigo = "5", Descripcion = "MAYO" },
                new GenericoListaDto { Codigo = "6", Descripcion = "JUNIO" },
                new GenericoListaDto { Codigo = "7", Descripcion = "JULIO" },
                new GenericoListaDto { Codigo = "8", Descripcion = "AGOSTO" },
                new GenericoListaDto { Codigo = "9", Descripcion = "SETIEMBRE" },
                new GenericoListaDto { Codigo = "10", Descripcion = "OCTUBRE" },
                new GenericoListaDto { Codigo = "11", Descripcion = "NOVIEMBRE" },
                new GenericoListaDto { Codigo = "12", Descripcion = "DICIEMBRE" }
            };

            return listaMeses;
        }

        public static string LeerConfig(string key)
        {
            string valor;

            valor = ConfigurationManager.AppSettings[key].ToString();

            return valor;
        }

        public static void FechaInicioFinPrograma(int dia, int mes, int anio, ref DateTime fechaInicio, ref DateTime fechaFin)
        {
            fechaInicio = new DateTime(anio, mes, dia);

            if (dia > 15)
            {
                fechaInicio = fechaInicio.AddMonths(-1);
                fechaFin = fechaInicio.AddMonths(1);
                fechaFin = fechaFin.AddDays(-1);
            }
            else
            {
                fechaFin = fechaInicio.AddMonths(1);
                fechaFin = fechaFin.AddDays(-1);
            }
        }

        public static string Encriptar(string texto)
        {
            //arreglo de bytes donde guardaremos la llave
            byte[] keyArray;
            //arreglo de bytes donde guardaremos el texto
            //que vamos a encriptar
            byte[] Arreglo_a_Cifrar =
            UTF8Encoding.UTF8.GetBytes(texto);

            //se utilizan las clases de encriptación
            //provistas por el Framework
            //Algoritmo MD5
            MD5CryptoServiceProvider hashmd5 =
            new MD5CryptoServiceProvider();
            //se guarda la llave para que se le realice
            //hashing
            keyArray = hashmd5.ComputeHash(
            UTF8Encoding.UTF8.GetBytes(Constantes.CLAVE));

            hashmd5.Clear();

            //Algoritmo 3DAS
            TripleDESCryptoServiceProvider tdes =
            new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            //se empieza con la transformación de la cadena
            ICryptoTransform cTransform =
            tdes.CreateEncryptor();

            //arreglo de bytes donde se guarda la
            //cadena cifrada
            byte[] ArrayResultado =
            cTransform.TransformFinalBlock(Arreglo_a_Cifrar,
            0, Arreglo_a_Cifrar.Length);

            tdes.Clear();

            //se regresa el resultado en forma de una cadena
            return Convert.ToBase64String(ArrayResultado,
            0, ArrayResultado.Length);
        }

        public static string Desencriptar(string textoEncriptado)
        {
            byte[] KeyArray;
            //convierte el texto en una secuencia de bytes
            byte[] Array_a_Descifrar = Convert.FromBase64String(textoEncriptado);

            //se llama a las clases que tienen los algoritmos de encriptación se le aplica hashing algoritmo MD5
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            KeyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Constantes.CLAVE));
            hashmd5.Clear();
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = KeyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateDecryptor();

            Byte[] resultArray = cTransform.TransformFinalBlock(Array_a_Descifrar, 0, Array_a_Descifrar.Length);
            tdes.Clear();

            //se regresa en forma de cadena
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        public static DateTime ObtenerFechaDeCadena(string fecha)
        {
            DateTime resultado;
            string dia;
            string mes;
            string anio;
            string[] arregloFecha;
            char delimiter = '/';

            arregloFecha = fecha.Split(delimiter);
            dia = arregloFecha[0];
            mes = arregloFecha[1];
            anio = arregloFecha[2];

            resultado = new DateTime(Convert.ToInt32(anio), Convert.ToInt32(mes), Convert.ToInt32(dia));

            return resultado;
        }

        public class Check
        {
            private static DateTime fechaValidar;

            public static short Int16(object entero)
            {
                if (entero == null || entero == DBNull.Value)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt16(entero);
                }
            }

            public static short? Int16Null(object entero)
            {
                if (entero == null || entero == DBNull.Value)
                {
                    return null;
                }
                else
                {
                    return Convert.ToInt16(entero);
                }
            }

            public static int Int32(object entero)
            {
                if (entero == null || entero == DBNull.Value)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(entero);
                }
            }

            public static int? Int32Null(object entero)
            {
                if (entero == null || entero == DBNull.Value)
                {
                    return null;
                }
                else
                {
                    return Convert.ToInt32(entero);
                }
            }

            public static string FechaCorta(object fecha)
            {
                string resultado;

                if (fecha == null || fecha == DBNull.Value)
                {
                    resultado = "";
                }
                else
                {
                    if (!DateTime.TryParse(fecha.ToString(), out fechaValidar))
                    {
                        resultado = "";
                    }
                    else
                    {
                        resultado = Convert.ToDateTime(fecha).ToString("dd/MM/yyyy");
                    }
                }
                return resultado;
            }

            public static string FechaLarga(object fecha, int horasSumar = 0)
            {
                string resultado;

                if (fecha == null || fecha == DBNull.Value)
                {
                    resultado = "";
                }
                else
                {
                    if (!DateTime.TryParse(fecha.ToString(), out fechaValidar))
                    {
                        resultado = "";
                    }
                    else
                    {
                        resultado = Convert.ToDateTime(fecha).AddHours(horasSumar).ToString("dd/MM/yyyy HH:mm:ss");
                    }
                }
                return resultado;
            }

            public static string Cadena(object cadena)
            {
                string resultado;

                resultado = (cadena == null) ? "" : cadena.ToString();

                return resultado;
            }

            public static DateTime? Datetime(object fecha)
            {
                DateTime? resultado;

                if (fecha == null || fecha == DBNull.Value)
                {
                    resultado = null;
                }
                else
                {
                    resultado = Convert.ToDateTime(fecha);
                }

                return resultado;
            }

            public static decimal Decimal(object numero)
            {
                if (numero == null || numero == DBNull.Value)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToDecimal(numero);
                }
            }
        }
    }
}
