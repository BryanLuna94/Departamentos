using System.Web.Mvc;
using MiDepa.pe.ServicioMiDepa;
using System.Threading.Tasks;
using System.ServiceModel;
using MiDepa.pe.Helper;
using System.Web.UI.WebControls;
using MiDepa.pe.Utility;
using System.Web.Routing;
using System.Data;
using System.IO;
using MiDepa.pe.Models;

namespace MiDepa.pe.Controllers
{
    public class AutenticacionController : Controller
    {
        ServicioMiDepaClient _ServicioMiDepa = new ServicioMiDepaClient();

        // GET: Autenticacion
        public ActionResult Login(string returnUrl = null)
        {
            var modelo = new LoginViewModel
            {
                Usuario = string.Empty,
                Clave = string.Empty
            };
            return View(modelo);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        //[OutputCache(NoStore = true, Duration = 0)]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            try
            {
                var request = new LoginRequestDto
                {
                    Usuario = model.Usuario,
                    Clave = model.Clave
                };

                var response = await _ServicioMiDepa.LoginAsync(request);
                var host = GeneralController.RutaRaiz(Request);

                var sesioModel = new DatosSesionViewModel
                {
                    Usuario = response.Usuario,
                    PermisosUsuario = response.ListaOpcionesPorPerfil,
                    FotoUsuario = response.FotoUsuario
                };

                SesionModel.DatosSesion = sesioModel;

                model.ReturnURL = model.ReturnURL ?? host + "Home/Index";

                return Json(model.ReturnURL);
            }
            catch (FaultException<ServiceErrorResponseType> ex)
            {
                //Como existe excepción de lógica de negocio, lo enviamos al Vehiculo para ser procesado por este
                return Json(HelperJson.ConstruirJson(EnumTipoNotificacion.Advertencia, ex.Detail.Message), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Logout()
        {
            SesionModel.DatosSesion = null;

            return RedirectToAction("Login", "Autenticacion");
        }
    }
}