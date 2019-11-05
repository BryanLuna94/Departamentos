using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using MiDepa.pe.Utility;
using MiDepa.pe.ServicioMiDepa;

namespace MiDepa.pe.Helper
{
    public class HelperFunciones
    {
        public static string ConvertirArrayEnImgSrc(ArchivoListaDto archivo)
        {
            var base64 = Convert.ToBase64String(archivo.Archivo);
            var imgSrc = String.Format("data:image/gif;base64,{0}", base64);
            return imgSrc;
        }

        public static string FormatearNumeroDecimales(decimal? numero, int decimales = 2)
        {
            if (numero != null)
            {
                string formato = string.Empty;
                decimal numeroFormatear = 0;
                formato = "F" + decimales.ToString();
                numeroFormatear = (decimal)numero;

                return numeroFormatear.ToString(formato);
            }
            else
            {
                return "";
            }
        }

        public static string IsNull_ParametroReporte(string texto)
        {
            if (texto == null)
            {
                return " ";
            }
            else
            {
                return texto;
            }
        }

        public static DateTime FechaHoy()
        {
            return DateTime.Now;
        }

        public static DataColumn CrearColumnaGrid(string Texto, string Value)
        {
            DataColumn bf = new DataColumn();
            bf.Caption = Texto;
            bf.ColumnName = Value;
            return bf;
        }

        public static List<OpcionesPorPerfilListaDto> ListaOpcionesPorPadre(List<OpcionesPorPerfilListaDto> data, int idPadre)
        {
            return data.Where(x => x.CodigoPadre == idPadre).ToList();
        }

        public static List<OpcionListaDto> ListaOpcionesPorPadre_Menu(List<OpcionListaDto> data, int idPadre)
        {
            return data.Where(x => x.CodigoPadre == idPadre).ToList();
        }

        public static string FotoUsuario()
        {
            var foto = string.Empty;
            var datosSesion = SesionModel.DatosSesion;
            if (datosSesion != null)
            {
                var objFoto = datosSesion.FotoUsuario;
                if (objFoto != null)
                {

                    //String url = RouteTable.Routes.GetVirtualPath(((MvcHandler)HttpContext.Current.CurrentHandler).RequestContext, new RouteValueDictionary(
                    // new
                    // {
                    //     controller = "MyController",
                    //     action = "CheckState",
                    //     siCodUsu = datosSesion.Usuario.Codigo.ToString()
                    // })).VirtualPath;

                    foto = "/Usuario/ObtenerImagen?siCodUsu=" + datosSesion.Usuario.Codigo.ToString();
                }
                else
                {
                    foto = "../wwwroot/plugins/images/users/no-imagen.jpg";
                }
            }
            return foto;
        }

        public static string NombreUsuario()
        {
            var nombre = string.Empty;
            var datosSesion = SesionModel.DatosSesion;
            if (datosSesion != null && datosSesion.Usuario != null)
            {
                nombre = datosSesion.Usuario.Nombre;
            }
            return nombre;
        }

        public static string CorreoUsuario()
        {
            var nombre = string.Empty;
            var datosSesion = SesionModel.DatosSesion;
            if (datosSesion != null)
            {
                //nombre = datosSesion.Usuario.Correo;
            }
            return nombre;
        }

        public static bool ValidaTienePermiso(int codigoPermiso)
        {
            bool permitido = false;
            var datosSesion = SesionModel.DatosSesion;
            if (datosSesion != null)
            {
                permitido = datosSesion.PermisosUsuario.Exists(x => x.Codigo == codigoPermiso);
            }

            return permitido;
        }

        public static string CheckedSi(bool chek)
        {
            string result;
            result = (chek) ? "checked='checked'" : "";
            return result;
        }
    }
}