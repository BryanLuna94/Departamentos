using MiDepa.pe.DataTypes.Filtros;
using MiDepa.pe.DataTypes.Listas;
using MiDepa.pe.DataTypes.Request;
using MiDepa.pe.DataTypes.Response;
using MiDepa.pe.Utility;
using System;
using System.Collections.Generic;
using MiDepa.pe.DataAccess;
using MiDepa.pe.DataTypes;
using System.Transactions;
using JBLV.Log;

namespace MiDepa.pe.BusinessLayer
{
    public class PagoLogic
    {
        /// <summary>Método que registra actividades.</summary>
        /// <param name="objPersona">Entidad con los datos de la entidad.</param>
        /// <returns>.</returns>
        /// <remarks><list type="bullet">
        /// <item><CreadoPor>Bryan Luna Vasquez</CreadoPor></item>
        /// <item><FecCrea>13/02/2018.</FecCrea></item></list>
        /// <list type="bullet">
        /// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        /// <item><Resp>Responsable.</Resp></item>
        /// <item><Mot>Motivo.</Mot></item></list></remarks>
        public static PagoResponseDto ObtenerEditorPago(int edificioId, int pagoId)
        {
            try
            {
                PagoResponseDto response;
                Pago objPago;
                List<GenericoListaDto> listaCuentasBancarias;
                List<ArchivoListaDto> listaArchivos;
                string tablaPago = Constantes.Tablas.PAGO;
                ArchivoListaDto objAdjunto1;
                ArchivoListaDto objAdjunto2;
                ArchivoListaDto objAdjunto3;

                objPago = PagoData.ObtenerPago(pagoId);
                listaCuentasBancarias = Edificio_CuentaBancariaData.ListaCuentas_Combo(edificioId);

                response = new PagoResponseDto
                {
                    Pago = objPago,
                    ListaCuentasBancarias = listaCuentasBancarias
                };

                if (objPago != null)
                {
                    listaArchivos = ArchivoData.ListarArchivos(tablaPago, objPago.PagoId.ToString());

                    if (listaArchivos.Count >= 1)
                    {
                        objAdjunto1 = listaArchivos[0];
                        response.Adjunto1 = objAdjunto1;
                    }

                    if (listaArchivos.Count >= 2)
                    {
                        objAdjunto2 = listaArchivos[1];
                        response.Adjunto2 = objAdjunto2;
                    }

                    if (listaArchivos.Count >= 3) {
                        objAdjunto3= listaArchivos[2];
                        response.Adjunto3 = objAdjunto3;
                    }                    
                }

                return response;
            }
            catch (Exception ex)
            {
                Log.RegistrarLog(NivelLog.Error, ex);
                throw;
            }
        }

        /// <summary>Método que registra actividades.</summary>
        /// <param name="objPersona">Entidad con los datos de la entidad.</param>
        /// <returns>.</returns>
        /// <remarks><list type="bullet">
        /// <item><CreadoPor>Bryan Luna Vasquez</CreadoPor></item>
        /// <item><FecCrea>13/02/2018.</FecCrea></item></list>
        /// <list type="bullet">
        /// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        /// <item><Resp>Responsable.</Resp></item>
        /// <item><Mot>Motivo.</Mot></item></list></remarks>
        public static void RegistrarPago(PagoRequestDto request)
        {
            Pago objPago;
            Archivo objAdjunto1;
            Archivo objAdjunto2;
            Archivo objAdjunto3;
            int idPago;
            int idTablaPago;

            objPago = request.Pago;
            objAdjunto1 = request.Adjunto1;
            objAdjunto2 = request.Adjunto2;
            objAdjunto3 = request.Adjunto3;
            objPago.EstadoId = Funciones.Check.Int32(Constantes.Tablas.EstadoAprobacion.PENDIENTE);
            objPago.FechaHoraPago = DateTime.Now;
            idTablaPago = Convert.ToInt32(Constantes.Tablas.PAGO);

            try
            {
                if (objAdjunto1 == null && objAdjunto2 == null && objAdjunto3 == null)
                {
                    BusinessException.Generar(Constantes.Mensajes.FOTO_PAGO_OBLIGATORIO);
                }

                using (TransactionScope tran = new TransactionScope())
                {
                    idPago = PagoData.Insertar(objPago);
                    VistoData.EliminarVistos(idTablaPago);
                    tran.Complete();
                }

                if (objAdjunto1 != null)
                {
                    objAdjunto1.Codigo = idPago.ToString();
                    ArchivoData.GuardarArchivo(objAdjunto1);
                }

                if (objAdjunto2 != null)
                {
                    objAdjunto2.Codigo = idPago.ToString();
                    ArchivoData.GuardarArchivo(objAdjunto2);
                }

                if (objAdjunto3 != null)
                {
                    objAdjunto3.Codigo = idPago.ToString();
                    ArchivoData.GuardarArchivo(objAdjunto3);
                }
            }
            catch (Exception ex)
            {
                Log.RegistrarLog(NivelLog.Error, ex);
                throw;
            }
        }

        /// <summary>Método que registra actividades.</summary>
        /// <param name="objPersona">Entidad con los datos de la entidad.</param>
        /// <returns>.</returns>
        /// <remarks><list type="bullet">
        /// <item><CreadoPor>Bryan Luna Vasquez</CreadoPor></item>
        /// <item><FecCrea>13/02/2018.</FecCrea></item></list>
        /// <list type="bullet">
        /// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        /// <item><Resp>Responsable.</Resp></item>
        /// <item><Mot>Motivo.</Mot></item></list></remarks>
        public static void ActualizarPago(PagoRequestDto request)
        {
            Pago objPago;

            objPago = request.Pago;
            objPago.EstadoId = Funciones.Check.Int32(Constantes.Tablas.EstadoAprobacion.PENDIENTE);
            objPago.FechaHoraPago = DateTime.Now;

            try
            {
                //if (CPMaeActividadData.ValidaExiste(objActividad))
                //{
                //    BusinessException.Generar(Constantes.Mensajes.ACTIVIDAD_YA_EXISTE);
                //}

                using (TransactionScope tran = new TransactionScope())
                {
                    PagoData.Actualizar(objPago);
                    tran.Complete();
                }
            }
            catch (Exception ex)
            {
                Log.RegistrarLog(NivelLog.Error, ex);
                throw;
            }
        }

        /// <summary>Método que registra actividades.</summary>
        /// <param name="objPersona">Entidad con los datos de la entidad.</param>
        /// <returns>.</returns>
        /// <remarks><list type="bullet">
        /// <item><CreadoPor>Bryan Luna Vasquez</CreadoPor></item>
        /// <item><FecCrea>13/02/2018.</FecCrea></item></list>
        /// <list type="bullet">
        /// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        /// <item><Resp>Responsable.</Resp></item>
        /// <item><Mot>Motivo.</Mot></item></list></remarks>
        public static void EliminarPago(int id)
        {
            Pago objPago;
            int estadoPendiente;
            string tablaPago;

            objPago = PagoData.ObtenerPago(id);
            estadoPendiente = Convert.ToInt32(Constantes.Tablas.EstadoAprobacion.PENDIENTE);
            tablaPago = Constantes.Tablas.PAGO;

            try
            {
                if (objPago.EstadoId != estadoPendiente)
                {
                    BusinessException.Generar(Constantes.Mensajes.PAGO_NOELIMINAR);
                }

                using (TransactionScope tran = new TransactionScope())
                {
                    PagoData.Eliminar(id);
                    ArchivoData.EliminarArchivosPorRegistro(tablaPago, id.ToString());
                    tran.Complete();
                }
            }
            catch (Exception ex)
            {
                Log.RegistrarLog(NivelLog.Error, ex);
                throw;
            }
        }

        /// <summary>Método que registra actividades.</summary>
        /// <param name="objPersona">Entidad con los datos de la entidad.</param>
        /// <returns>.</returns>
        /// <remarks><list type="bullet">
        /// <item><CreadoPor>Bryan Luna Vasquez</CreadoPor></item>
        /// <item><FecCrea>13/02/2018.</FecCrea></item></list>
        /// <list type="bullet">
        /// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        /// <item><Resp>Responsable.</Resp></item>
        /// <item><Mot>Motivo.</Mot></item></list></remarks>
        public static void AprobarPago(PagoRequestDto request)
        {
            int estadoAprobado;
            int estadoPendiente;
            Pago objPagoDatos;
            Pago objPago;

            objPago = request.Pago;
            objPagoDatos = PagoData.ObtenerPago(objPago.PagoId);
            estadoAprobado = Convert.ToInt32(Constantes.Tablas.EstadoAprobacion.APROBADO);
            estadoPendiente = Convert.ToInt32(Constantes.Tablas.EstadoAprobacion.PENDIENTE);
            objPago.EstadoId = estadoAprobado;
            objPago.FechaHoraAprobacion = DateTime.Now;

            try
            {
                if (objPagoDatos.EstadoId != estadoPendiente)
                {
                    BusinessException.Generar(Constantes.Mensajes.PAGO_NOELIMINAR);
                }

                using (TransactionScope tran = new TransactionScope())
                {
                    PagoData.CambiarEstado(objPago);
                    EstadoCuentaData.AgregarPago(objPagoDatos.EstadoCuentaId, objPagoDatos.Monto);
                    tran.Complete();
                }
            }
            catch (Exception ex)
            {
                Log.RegistrarLog(NivelLog.Error, ex);
                throw;
            }
        }

        /// <summary>Método que registra actividades.</summary>
        /// <param name="objPersona">Entidad con los datos de la entidad.</param>
        /// <returns>.</returns>
        /// <remarks><list type="bullet">
        /// <item><CreadoPor>Bryan Luna Vasquez</CreadoPor></item>
        /// <item><FecCrea>13/02/2018.</FecCrea></item></list>
        /// <list type="bullet">
        /// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        /// <item><Resp>Responsable.</Resp></item>
        /// <item><Mot>Motivo.</Mot></item></list></remarks>
        public static void RechazarPago(PagoRequestDto request)
        {
            int estadoRechazado;
            int estadoPendiente;
            Pago objPago;
            Pago objPagoDatos;

            objPago = request.Pago;
            objPagoDatos = PagoData.ObtenerPago(objPago.PagoId);
            estadoRechazado = Convert.ToInt32(Constantes.Tablas.EstadoAprobacion.RECHAZADO);
            estadoPendiente = Convert.ToInt32(Constantes.Tablas.EstadoAprobacion.PENDIENTE);
            objPago.EstadoId = estadoRechazado;
            objPago.FechaHoraAprobacion = DateTime.Now;

            try
            {
                if (objPagoDatos.EstadoId != estadoPendiente)
                {
                    BusinessException.Generar(Constantes.Mensajes.PAGO_NOELIMINAR);
                }

                using (TransactionScope tran = new TransactionScope())
                {
                    PagoData.CambiarEstado(objPago);
                    tran.Complete();
                }
            }
            catch (Exception ex)
            {
                Log.RegistrarLog(NivelLog.Error, ex);
                throw;
            }
        }

        /// <summary>Invoca al Procedimiento Movimientoado que lista Descripcion Base.</summary>
        /// <param name="objFiltro">Parámetros para el filtro de Listar los Descripcion Base</param>
        ///<remarks>
        ///<list type = "bullet">
        ///<item><CreadoPor>Bryan Luna Vasquez.</CreadoPor></item>
        ///<item><FecCrea>12/02/2018</FecCrea></item></list>        
        ///<list type="bullet">
        /// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        /// <item><Resp>Responsable.</Resp></item>
        /// <item><Mot>Motivo.</Mot></item></list></remarks>
        public static PagoResponseDto ListarPagos(PagoRequestDto request)
        {
            try
            {
                PagoResponseDto response;
                List<PagoListaDto> listaPagos;
                PagoFiltroDto objFiltro;
                List<GenericoListaDto> listaCampanias;
                List<GenericoListaDto> listaEstados;
                int idTablaPago;
                int codigoUsuario;

                objFiltro = request.Filtro;
                
                listaPagos = PagoData.ListarPagos(objFiltro);
                idTablaPago = Convert.ToInt32(Constantes.Tablas.PAGO);
                codigoUsuario = request.CodigoUsuario;

                listaCampanias = new List<GenericoListaDto>();
                foreach (var item in Funciones.ListarCampaniasParaFiltro()) listaCampanias.Add(new GenericoListaDto { Codigo = item.Codigo, Descripcion = item.Descripcion });
                listaEstados = new List<GenericoListaDto>
                {
                    new GenericoListaDto { Codigo = Constantes.Tablas.EstadoAprobacion.PENDIENTE, Descripcion = "PENDIENTE" },
                    new GenericoListaDto { Codigo = Constantes.Tablas.EstadoAprobacion.APROBADO, Descripcion = "APROBADO" },
                    new GenericoListaDto { Codigo = Constantes.Tablas.EstadoAprobacion.RECHAZADO, Descripcion = "RECHAZADO" }
                };

                //visto pagos
                VistoData.Insertar(idTablaPago, codigoUsuario);

                response = new PagoResponseDto
                {
                    ListaPagos = listaPagos,
                    ListaCampanias = listaCampanias,
                    ListaEstados = listaEstados
                };

                return response;
            }
            catch (Exception ex)
            {
                Log.RegistrarLog(NivelLog.Error, ex);
                throw;
            }
        }
    }
}
