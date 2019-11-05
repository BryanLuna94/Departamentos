using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MiDepa.pe.Helper
{
    public class Atributos
    {
        public class SessionExpireFilterAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                // Validar la información que se encuentra en la sesión.
                if (SesionModel.DatosSesion == null || SesionModel.DatosSesion.Usuario == null)
                {
                    // Si la información es nula, redireccionar a 
                    // página de error u otra página deseada.
                    var ruta = filterContext.RequestContext.HttpContext.Request.Url.AbsolutePath;
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary
                       {
                           { "action", "Login" },
                           { "controller", "Autenticacion" },
                           { "Area", string.Empty },
                           { "returnUrl", ruta }
                       });
                }

                base.OnActionExecuting(filterContext);
            }
        }

        public class AccesoAutorizadoFilterAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                // Validar la información que se encuentra en la sesión.
                if (SesionModel.DatosSesion != null && SesionModel.DatosSesion.Usuario != null)
                {
                    // Si la información es nula, redireccionar a 
                    // página de error u otra página deseada.
                    var ruta = filterContext.RequestContext.HttpContext.Request.Url.AbsolutePath;
                    var indice1 = ruta.LastIndexOf("/");
                    var rutaSinUltimoSlash = ruta.Substring(0, indice1);
                    var indice2 = rutaSinUltimoSlash.LastIndexOf("/");
                    ruta = ruta.Substring(indice2 + 1);

                    var existeAcceso = SesionModel.DatosSesion.PermisosUsuario.FirstOrDefault(x => x.Ruta == ruta);

                    if (existeAcceso == null)
                    {

                        filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary
                       {
                            { "action", "AccesoNoAutorizado" },
                            { "controller", "Error" },
                            { "Area", string.Empty },
                            { "returnUrl", ruta }
                       });
                    }


                }

                base.OnActionExecuting(filterContext);
            }
        }
    }
}