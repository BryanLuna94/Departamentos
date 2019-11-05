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
using MiDepa.pe.Models.Campania;
using System;

namespace MiDepa.pe.Controllers
{
    [Atributos.SessionExpireFilter]
    public class CampaniaController : Controller
    {
        ServicioMiDepaClient _ServicioMiDepa = new ServicioMiDepaClient();

        /// <summary>Método que devuelve el modelo para la vista de la grilla</summary>
        /// <param name="model">Modelo del request</param>
        /// <returns>Modelo para la vista de al grilla</returns>
        /// <remarks><list type="bullet">
        /// <item><CreadoPor>Bryan Luna Vásquez</CreadoPor></item>
        /// <item><FecCrea>05/02/2018</FecCrea></item>
        /// </list>
        /// <list type="bullet" >
        /// <item><FecActu>XXXX</FecActu></item>
        /// <item><Resp>XXXX</Resp></item>
        /// <item><Mot>XXXX</Mot></item></list></remarks>
        [HttpGet]
        //[Atributos.AccesoAutorizadoFilter]
        public async Task<ActionResult> Index(CampaniaGridViewModel model)
        {
            try
            {
                //Construimos el modelo
                model = await ObtenerModelGrid(model);

                //Retornamos vista con modelo
                return View(model);
            }
            catch (FaultException<ServiceErrorResponseType> ex)
            {
                //Como existe excepción de lógica de negocio, lo enviamos al Vehiculo para ser procesado por este
                return Json(HelperJson.ConstruirJson(EnumTipoNotificacion.Advertencia, ex.Detail.Message), JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>Método que devuelve el modelo para la vista de la grilla</summary>
        /// <param name="model">Modelo del request</param>
        /// <returns>Modelo para la vista de al grilla</returns>
        /// <remarks><list type="bullet">
        /// <item><CreadoPor>Bryan Luna Vásquez</CreadoPor></item>
        /// <item><FecCrea>05/02/2018</FecCrea></item>
        /// </list>
        /// <list type="bullet" >
        /// <item><FecActu>XXXX</FecActu></item>
        /// <item><Resp>XXXX</Resp></item>
        /// <item><Mot>XXXX</Mot></item></list></remarks>
        private async Task<CampaniaGridViewModel> ObtenerModelGrid(CampaniaGridViewModel model)
        {
            model.Filtro = model.Filtro ?? new CampaniaFiltroDto();
            var sesionUsuario = SesionModel.DatosSesion.Usuario;
            model.Filtro.EdificioId = (int)sesionUsuario.CodigoEdificio;
            //Construimos el request 
            var request = new CampaniaRequestDto
            {
                Filtro = model.Filtro
            };

            //Invocamos al servicio
            var response = await _ServicioMiDepa.ListarCampaniasAsync(request);

            //Construimos el modelo
            model = new CampaniaGridViewModel(response)
            {
                Filtro = request.Filtro
            };

            //Retornamos el modelo
            return model;
        }

        /// <summary>Método que actualiza la vista de la grilla</summary>
        /// <param name="model">Modelo del request</param>
        /// <returns>Modelo para la vista de al grilla</returns>
        /// <remarks><list type="bullet">
        /// <item><CreadoPor>Bryan Luna Vásquez</CreadoPor></item>
        /// <item><FecCrea>16/01/2018</FecCrea></item>
        /// </list>
        /// <list type="bullet" >
        /// <item><FecActu>XXXX</FecActu></item>
        /// <item><Resp>XXXX</Resp></item>
        /// <item><Mot>XXXX</Mot></item></list></remarks>
        [HttpGet]
        public async Task<ActionResult> Refrescar(CampaniaGridViewModel model)
        {
            try
            {
                //Construimos el modelo
                model = await ObtenerModelGrid(model);

                //Retornamos vista con modelo
                return PartialView("_Index.Grid", model);
            }
            catch (FaultException<ServiceErrorResponseType> ex)
            {
                //Como existe excepción de lógica de negocio, lo enviamos al Vehiculo para ser procesado por este
                return Json(HelperJson.ConstruirJson(EnumTipoNotificacion.Advertencia, ex.Detail.Message), JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>Método que devuelve el modelo para la vista de la grilla</summary>
        /// <param name="model">Modelo del request</param>
        /// <returns>Modelo para la vista de al grilla</returns>
        /// <remarks><list type="bullet">
        /// <item><CreadoPor>Bryan Luna Vásquez</CreadoPor></item>
        /// <item><FecCrea>05/02/2018</FecCrea></item>
        /// </list>
        /// <list type="bullet" >
        /// <item><FecActu>XXXX</FecActu></item>
        /// <item><Resp>XXXX</Resp></item>
        /// <item><Mot>XXXX</Mot></item></list></remarks>
        [HttpGet]
        public async Task<ActionResult> Editor(int id = 0)
        {
            try
            {
                //Construimos el modelo
                var sesionUsuario = SesionModel.DatosSesion.Usuario;
                var response = await _ServicioMiDepa.ObtenerEditorCampaniaAsync((int)sesionUsuario.CodigoEdificio, id);

                var model = new CampaniaEditorViewModel(response);

                //Retornamos vista con modelo
                return PartialView("_Editor", model);
            }
            catch (FaultException<ServiceErrorResponseType> ex)
            {
                //Como existe excepción de lógica de negocio, lo enviamos al Vehiculo para ser procesado por este
                return Json(HelperJson.ConstruirJson(EnumTipoNotificacion.Advertencia, ex.Detail.Message), JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>Método que graba la Problema</summary>
        /// <param name="model">Modelo del request</param>
        /// <returns>Vista Refrescar</returns>
        /// <remarks><list type="bullet">
        /// <item><CreadoPor>Bryan Luna Vásquez</CreadoPor></item>
        /// <item><FecCrea>05/02/2018</FecCrea></item>
        /// </list>
        /// <list type="bullet" >
        /// <item><FecActu>XXXX</FecActu></item>
        /// <item><Resp>XXXX</Resp></item>
        /// <item><Mot>XXXX</Mot></item></list></remarks>
        [HttpPost]
        public async Task<ActionResult> Agregar(CampaniaEditorViewModel model)
        {
            try
            {
                var sesionUsuario = SesionModel.DatosSesion.Usuario;

                var request = new CampaniaRequestDto
                {
                    Campania = model.Campania,
                    ListaConceptos = model.ListaConceptos
                };

                request.Campania.EdificioId = (int)sesionUsuario.CodigoEdificio;

                //Invocamos al servicio
                await _ServicioMiDepa.InsertarCampaniaAsync(request);

                //Refrescamos la pagina con los registros actuales
                return RedirectToAction("Refrescar");
            }
            catch (FaultException<ServiceErrorResponseType> ex)
            {
                //Como existe excepción de lógica de negocio, lo enviamos al Vehiculo para ser procesado por este
                return Json(HelperJson.ConstruirJson(EnumTipoNotificacion.Advertencia, ex.Detail.Message), JsonRequestBehavior.AllowGet);
            }
        }

        ///// <summary>Método que actualiza la Problema</summary>
        ///// <param name="model">Modelo del request</param>
        ///// <returns>Vista Refrescar</returns>
        ///// <remarks><list type="bullet">
        ///// <item><CreadoPor>Bryan Luna Vásquez</CreadoPor></item>
        ///// <item><FecCrea>05/02/2018</FecCrea></item>
        ///// </list>
        ///// <list type="bullet" >
        ///// <item><FecActu>XXXX</FecActu></item>
        ///// <item><Resp>XXXX</Resp></item>
        ///// <item><Mot>XXXX</Mot></item></list></remarks>
        //[HttpPost]
        //public async Task<ActionResult> Modificar(PagoEditorViewModel model)
        //{
        //    try
        //    {
        //        //Construimos el request
        //        var request = new PagoRequestDto
        //        {
        //            Pago = model.Pago
        //        };

        //        //Invocamos al servicio
        //        await _ServicioMiDepa.ActualizarPagoAsync(request);

        //        //Refrescamos la pagina con los registros actuales
        //        return RedirectToAction("Refrescar");
        //    }
        //    catch (FaultException<ServiceErrorResponseType> ex)
        //    {
        //        //Como existe excepción de lógica de negocio, lo enviamos al Vehiculo para ser procesado por este
        //        return Json(HelperJson.ConstruirJson(EnumTipoNotificacion.Advertencia, ex.Detail.Message), JsonRequestBehavior.AllowGet);
        //    }
        //}

        ///// <summary>Método que elimina la Problema</summary>
        ///// <param name="model">Modelo del request</param>
        ///// <returns>Vista Refrescar</returns>
        ///// <remarks><list type="bullet">
        ///// <item><CreadoPor>Bryan Luna Vásquez</CreadoPor></item>
        ///// <item><FecCrea>05/02/2018</FecCrea></item>
        ///// </list>
        ///// <list type="bullet" >
        ///// <item><FecActu>XXXX</FecActu></item>
        ///// <item><Resp>XXXX</Resp></item>
        ///// <item><Mot>XXXX</Mot></item></list></remarks>
        //[HttpPost]
        //public async Task<ActionResult> Eliminar(int id)
        //{
        //    try
        //    {
        //        //Invocamos al servicio
        //        await _ServicioMiDepa.EliminarPagoAsync(id);

        //        //Refrescamos la pagina con los registros actuales
        //        return Json("OK");
        //    }
        //    catch (FaultException<ServiceErrorResponseType> ex)
        //    {
        //        //Como existe excepción de lógica de negocio, lo enviamos al Vehiculo para ser procesado por este
        //        return Json(HelperJson.ConstruirJson(EnumTipoNotificacion.Advertencia, ex.Detail.Message), JsonRequestBehavior.AllowGet);
        //    }
        //}
    }
}