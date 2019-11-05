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
using MiDepa.pe.Models.Pagos;
using System;

namespace MiDepa.pe.Controllers
{
    [Atributos.SessionExpireFilter]
    public class PagoController : Controller
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
        public async Task<ActionResult> Index(PagoGridViewModel model)
        {
            try
            {
                //model = SesionModel.FiltrosAlmacen;
                //SesionModel.FiltrosAlmacen = null;

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
        private async Task<PagoGridViewModel> ObtenerModelGrid(PagoGridViewModel model)
        {
            model.Filtro = model.Filtro ?? new PagoFiltroDto { EstadoId = Convert.ToInt32(Constantes.Tablas.EstadoAprobacion.PENDIENTE) };
            var sesionUsuario = SesionModel.DatosSesion.Usuario;

            //Construimos el request 
            var request = new PagoRequestDto
            {
                Filtro = model.Filtro,
                CodigoUsuario = sesionUsuario.Codigo
            };

            //Invocamos al servicio
            var response = await _ServicioMiDepa.ListarPagosAsync(request);

            //Construimos el modelo
            model = new PagoGridViewModel(response)
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
        public async Task<ActionResult> Refrescar(PagoGridViewModel model)
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
        public async Task<ActionResult> EditorAprobacion(int id)
        {
            try
            {
                //Construimos el modelo
                var sesionUsuario = SesionModel.DatosSesion.Usuario;
                var response = await _ServicioMiDepa.ObtenerEditorPagoAsync((int)sesionUsuario.CodigoEdificio, id);

                var model = new PagoEditorViewModel(response);

                //Retornamos vista con modelo
                return PartialView("_Aprobacion", model);
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
        public async Task<ActionResult> EditorRO(int id)
        {
            try
            {
                //Construimos el modelo
                var sesionUsuario = SesionModel.DatosSesion.Usuario;
                var response = await _ServicioMiDepa.ObtenerEditorPagoAsync((int)sesionUsuario.CodigoEdificio, id);

                var model = new PagoEditorViewModel(response);

                //Retornamos vista con modelo
                return PartialView("_EditorPagoRO", model);
            }
            catch (FaultException<ServiceErrorResponseType> ex)
            {
                //Como existe excepción de lógica de negocio, lo enviamos al Vehiculo para ser procesado por este
                return Json(HelperJson.ConstruirJson(EnumTipoNotificacion.Advertencia, ex.Detail.Message), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public async Task<ActionResult> EditorPago(int id = 0)
        {
            try
            {
                var datosSesion = SesionModel.DatosSesion;
                //Invocamos al servicio
                var response = await _ServicioMiDepa.ObtenerEditorPagoAsync(Convert.ToInt32(datosSesion.Usuario.CodigoEdificio), id);

                //Construimos el modelo
                var model = new PagoEditorViewModel(response);

                //Retornamos vista con modelo
                return PartialView("_EditorPago", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>Método que actualiza la Problema</summary>
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
        public async Task<ActionResult> Aprobar(PagoEditorViewModel model)
        {
            try
            {
                //Construimos el request
                var request = new PagoRequestDto
                {
                    Pago = model.Pago
                };

                //Invocamos al servicio
                await _ServicioMiDepa.AprobarPagoAsync(request);

                //Refrescamos la pagina con los registros actuales
                return RedirectToAction("Refrescar");
            }
            catch (FaultException<ServiceErrorResponseType> ex)
            {
                //Como existe excepción de lógica de negocio, lo enviamos al Vehiculo para ser procesado por este
                return Json(HelperJson.ConstruirJson(EnumTipoNotificacion.Advertencia, ex.Detail.Message), JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>Método que actualiza la Problema</summary>
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
        public async Task<ActionResult> Rechazar(PagoEditorViewModel model)
        {
            try
            {
                //Construimos el request
                var request = new PagoRequestDto
                {
                    Pago = model.Pago
                };

                //Invocamos al servicio
                await _ServicioMiDepa.RechazarPagoAsync(request);

                //Refrescamos la pagina con los registros actuales
                return RedirectToAction("Refrescar");
            }
            catch (FaultException<ServiceErrorResponseType> ex)
            {
                //Como existe excepción de lógica de negocio, lo enviamos al Vehiculo para ser procesado por este
                return Json(HelperJson.ConstruirJson(EnumTipoNotificacion.Advertencia, ex.Detail.Message), JsonRequestBehavior.AllowGet);
            }
        }
    }
}