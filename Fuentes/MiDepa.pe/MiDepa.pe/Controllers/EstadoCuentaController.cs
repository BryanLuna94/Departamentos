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
using MiDepa.pe.Models.EstadoCuenta;
using System;

namespace MiDepa.pe.Controllers
{
    [Atributos.SessionExpireFilter]
    public class EstadoCuentaController : Controller
    {
        ServicioMiDepaClient _ServicioMiDepa = new ServicioMiDepaClient();
        // GET: EstadoCuenta
        public ActionResult Index()
        {
            try
            {
                var response = _ServicioMiDepa.ObtenerIndexEstadoCuenta();

                var model = new EstadoCuentaGridViewModel(response);

                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> ListarDatosEstadoCuenta(string id)
        {
            try
            {
                var datosSesion = SesionModel.DatosSesion;
                //Invocamos al servicio
                var response = await _ServicioMiDepa.ListarDatosEstadoCuentaPorCampaniaAsync((int)datosSesion.Usuario.DepaId, id);

                //Construimos el modelo
                var model = new EstadoCuentaGridViewModel(response);

                //Retornamos vista con modelo
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
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
        public async Task<ActionResult> Agregar(PagoEditorViewModel model)
        {
            try
            {
                var tabla = Constantes.Tablas.PAGO;

                var request = new PagoRequestDto
                {
                    Pago = model.Pago
                };

                if (model.Adjunto1 != null)
                {
                    Stream str = model.Adjunto1.InputStream;
                    BinaryReader Br = new BinaryReader(str);
                    Byte[] foto = Br.ReadBytes((Int32)str.Length);
                    request.Adjunto1 = new Archivo
                    {
                        BinData = foto,
                        Extension = model.Adjunto1.ContentType,
                        Nombre = model.Adjunto1.FileName,
                        Tabla = tabla
                    };
                }

                if (model.Adjunto2 != null)
                {
                    Stream str = model.Adjunto2.InputStream;
                    BinaryReader Br = new BinaryReader(str);
                    Byte[] foto = Br.ReadBytes((Int32)str.Length);
                    request.Adjunto2 = new Archivo
                    {
                        BinData = foto,
                        Extension = model.Adjunto2.ContentType,
                        Nombre = model.Adjunto2.FileName,
                        Tabla = tabla
                    };
                }

                if (model.Adjunto3 != null)
                {
                    Stream str = model.Adjunto3.InputStream;
                    BinaryReader Br = new BinaryReader(str);
                    Byte[] foto = Br.ReadBytes((Int32)str.Length);
                    request.Adjunto3 = new Archivo
                    {
                        BinData = foto,
                        Extension = model.Adjunto3.ContentType,
                        Nombre = model.Adjunto3.FileName,
                        Tabla = tabla
                    };
                }


                //Invocamos al servicio
                await _ServicioMiDepa.InsertarPagoAsync(request);

                //Refrescamos la pagina con los registros actuales
                return Json("OK");
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
        public async Task<ActionResult> Modificar(PagoEditorViewModel model)
        {
            try
            {
                //Construimos el request
                var request = new PagoRequestDto
                {
                    Pago = model.Pago
                };

                //Invocamos al servicio
                await _ServicioMiDepa.ActualizarPagoAsync(request);

                //Refrescamos la pagina con los registros actuales
                return Json("OK");
            }
            catch (FaultException<ServiceErrorResponseType> ex)
            {
                //Como existe excepción de lógica de negocio, lo enviamos al Vehiculo para ser procesado por este
                return Json(HelperJson.ConstruirJson(EnumTipoNotificacion.Advertencia, ex.Detail.Message), JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>Método que elimina la Problema</summary>
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
        public async Task<ActionResult> Eliminar(int id)
        {
            try
            {
                //Invocamos al servicio
                await _ServicioMiDepa.EliminarPagoAsync(id);

                //Refrescamos la pagina con los registros actuales
                return Json("OK");
            }
            catch (FaultException<ServiceErrorResponseType> ex)
            {
                //Como existe excepción de lógica de negocio, lo enviamos al Vehiculo para ser procesado por este
                return Json(HelperJson.ConstruirJson(EnumTipoNotificacion.Advertencia, ex.Detail.Message), JsonRequestBehavior.AllowGet);
            }
        }
    }
}