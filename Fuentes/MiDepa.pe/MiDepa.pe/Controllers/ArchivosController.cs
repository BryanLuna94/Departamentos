using System.Web.Mvc;
using MiDepa.pe.ServicioMiDepa;
using System.Threading.Tasks;
using System.ServiceModel;
using MiDepa.pe.Helper;
using System.Web.UI.WebControls;
using MiDepa.pe.Utility;
using System.Web.Routing;
using System.Data;  
//using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using MiDepa.pe.Models.Archivo;
using System;

namespace MiDepa.pe.Controllers
{
    [Atributos.SessionExpireFilter]
    public class ArchivosController : Controller
    {
        ServicioMiDepaClient _ServicioMiDepa = new ServicioMiDepaClient();

        [HttpGet]
        public async Task<FileResult> Descargar(string id)
        {
            var response = await _ServicioMiDepa.ObtenerArchivoPorIdAsync(id);

            return File(response.Archivo.Archivo, response.Archivo.Extension, response.Archivo.Nombre);
        }
    }
}