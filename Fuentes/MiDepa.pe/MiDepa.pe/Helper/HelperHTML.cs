using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiDepa.pe.Helper
{
    public class HelperHTML
    {
        public static IHtmlString IconoCambioPlanEnProceso(bool condicion)
        {
            if (condicion)
            {
                 return new HtmlString("<span title='' class='fa fa-warning'>");
            }
            else
            {
                return null;
            }
            
        }

        public static IHtmlString IconoSMART(bool condicion)
        {
            if (condicion)
            {
                return new HtmlString("<span title='Esta programación se creó automaticamente' class='label label-info'>SM</span>");
            }
            else
            {
                return null;
            }

        }

        public static IHtmlString CrearLinkSiTienePermiso(int codigoPermiso, string eventoOnClick, string parametrosEvento, string title, string clase, string claseIcono, bool condicionAdicional = true)
        {
            if (HelperFunciones.ValidaTienePermiso(codigoPermiso) && condicionAdicional == true)
            {
                string cadenaUrl = string.Format("<a href='javascript: void(0)' onclick='{0}(\"{1}\")' title='{2}' class='{3}'><i class='{4}'></i></a>", eventoOnClick, parametrosEvento, title, clase, claseIcono);
                return new HtmlString(cadenaUrl);
            }
            else
            {
                return null;
            }
        }
    }
}