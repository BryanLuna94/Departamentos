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
    public class ResumenPeriodoController : Controller
    {
        // GET: ResumenPeriodo
        public ActionResult Index()
        {
            return View();
        }
    }
}