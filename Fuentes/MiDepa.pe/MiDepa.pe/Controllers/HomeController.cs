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
    [Atributos.SessionExpireFilter]
    public class HomeController : Controller
    {
        ServicioMiDepaClient _ServicioMiDepa = new ServicioMiDepaClient();

        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Dashboard1()
        {
            try
            {
                var datosSesion = SesionModel.DatosSesion;
                //Invocamos al servicio
                var response = await _ServicioMiDepa.ListaDatosHomeAsync((int)datosSesion.Usuario.DepaId);

                //Construimos el modelo
                var model = new HomeViewModel(response);

                //Retornamos vista con modelo
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> DatosEstaticos()
        {
            try
            {
                var datosSesion = SesionModel.DatosSesion;
                //Invocamos al servicio
                var response = await _ServicioMiDepa.ListarDatosEstaticosAsync(datosSesion.Usuario.Codigo);

                //Construimos el modelo
                var model = new CabeceraViewModel(response);

                //Retornamos vista con modelo
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

    }
}