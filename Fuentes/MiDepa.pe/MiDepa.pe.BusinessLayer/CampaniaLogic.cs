using MiDepa.pe.DataTypes.Filtros;
using MiDepa.pe.DataTypes.Listas;
using MiDepa.pe.DataTypes.Request;
using MiDepa.pe.DataTypes.Response;
using MiDepa.pe.Utility;
using System;
using System.Linq;
using System.Collections.Generic;
using MiDepa.pe.DataAccess;
using MiDepa.pe.DataTypes;
using System.Transactions;
using JBLV.Log;

namespace MiDepa.pe.BusinessLayer
{
    public class CampaniaLogic
    {
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
        public static CampaniaResponseDto ListarCampanias(CampaniaRequestDto request)
        {
            try
            {
                CampaniaResponseDto response;
                List<CampaniaListaDto> listaCampanias;
                CampaniaFiltroDto objFiltro;

                objFiltro = request.Filtro;

                listaCampanias = CampaniaData.ListarCampanias(objFiltro);

                response = new CampaniaResponseDto
                {
                    ListaCampanias = listaCampanias
                };

                return response;
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
        public static CampaniaResponseDto ObtenerEditorCampania(int edificioId, int campaniaId)
        {
            try
            {
                CampaniaResponseDto response;
                List<GenericoListaDto> listaMeses;
                List<GenericoListaDto> listaConceptosGenerales;
                List<CampaniaDetalle> listaConceptosPorCampania;
                List<ConceptoListaDto> listaConceptos;
                Campania objCampania;
                Campania objCampaniaAnterior;
                List<GenericoListaDto> listaCampanias;

                listaConceptosGenerales = ConceptoData.ListarConceptos(edificioId);
                listaMeses = new List<GenericoListaDto>();
                foreach (var item in Funciones.ListaMeses()) listaMeses.Add(new GenericoListaDto { Codigo = item.Codigo, Descripcion = item.Descripcion });
                objCampania = CampaniaData.ObtenerCampania(campaniaId);
                listaConceptosPorCampania = new List<CampaniaDetalle>();
                listaConceptos = new List<ConceptoListaDto>();
                listaCampanias = new List<GenericoListaDto>();
                foreach (var item in Funciones.ListarCampaniasParaFiltro()) listaCampanias.Add(new GenericoListaDto { Codigo = item.Codigo, Descripcion = item.Descripcion });

                if (objCampania != null)
                {
                    listaConceptosPorCampania = CampaniaDetalleData.ListarPorCampania(campaniaId);

                    foreach (var item in listaConceptosGenerales)
                    {
                        var objConcepto = listaConceptosPorCampania.FirstOrDefault(x => x.ConceptoId.ToString() == item.Codigo);

                        listaConceptos.Add(new ConceptoListaDto
                        {
                            ConceptoId = Convert.ToInt32(item.Codigo),
                            NombreConcepto = item.Descripcion,
                            Monto = (objConcepto != null) ? objConcepto.Monto : 0,
                            Existe = (objConcepto != null)
                        });
                    }
                }
                else
                {
                    objCampaniaAnterior = CampaniaData.ObtenerUltimaCampania(edificioId);

                    listaConceptosPorCampania = CampaniaDetalleData.ListarPorCampania(objCampaniaAnterior.CampaniaId);

                    foreach (var item in listaConceptosGenerales)
                    {
                        var objConcepto = listaConceptosPorCampania.FirstOrDefault(x => x.ConceptoId.ToString() == item.Codigo);

                        listaConceptos.Add(new ConceptoListaDto
                        {
                            ConceptoId = Convert.ToInt32(item.Codigo),
                            NombreConcepto = item.Descripcion,
                            Monto = (objConcepto != null) ? objConcepto.Monto : 0,
                            Existe = (objConcepto != null)
                        });
                    }
                }

                

                response = new CampaniaResponseDto
                {
                    ListaMeses = listaMeses,
                    ListaConceptos = listaConceptos,
                    Campania = objCampania,
                    ListaCampaniasPlantilla = listaCampanias
                };

                return response;
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
        public static void InsertarCampania(CampaniaRequestDto request)
        {
            Campania objCampania;
            List<ConceptoListaDto> listaConceptos;
            List<ConceptoListaDto> listaConceptosSeleccionados;
            int idCampania;
            int estadoActivo;
            decimal totalCampania;

            totalCampania = 0;
            estadoActivo = 1;
            objCampania = request.Campania;
            listaConceptos = request.ListaConceptos;
            objCampania.Codigo = objCampania.Anio + objCampania.MesId.ToString("0#");
            objCampania.EstadoId = estadoActivo;
            listaConceptosSeleccionados = new List<ConceptoListaDto>();

            //INICIO VALIDACIONES
            if (CampaniaData.ValidaExisteFecha(objCampania))
            {
                BusinessException.Generar("Las fechas ingresadas ya están ocupadas por otra campaña");
            }

            if (CampaniaData.ValidaExiste(objCampania))
            {
                BusinessException.Generar("La campaña que está intentado registrar ya fué registrada anteriormente");
            }

            foreach (var item in listaConceptos) if (item.Existe) listaConceptosSeleccionados.Add(item);

            if (listaConceptos.Count == 0)
            {
                BusinessException.Generar("Debe seleccionar por lo menos un gasto");
            }

            foreach (var item in listaConceptosSeleccionados)
            {
                if (item.Monto <= 0)
                {
                    BusinessException.Generar("Los conceptos seleccionados deben tener un monto mayor a 0");
                }
                totalCampania += item.Monto;
            }
            //FIN VALIDACIONES
            objCampania.Total = totalCampania;

            try
            {
                using (TransactionScope tran = new TransactionScope())
                {
                    idCampania = CampaniaData.Insertar(objCampania);

                    foreach (var item in listaConceptosSeleccionados)
                    {
                        var objDetalle = new CampaniaDetalle
                        {
                            CampaniaId = idCampania,
                            ConceptoId = item.ConceptoId,
                            Monto = item.Monto
                        };
                        CampaniaDetalleData.Insertar(objDetalle);
                    }

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
        public static void ActualizarCampania(CampaniaRequestDto request)
        {
            Campania objCampania;
            Campania objCampaniaAnterior;
            List<ConceptoListaDto> listaConceptos;
            int idCampania;

            objCampania = request.Campania;
            idCampania = objCampania.CampaniaId;
            objCampaniaAnterior = CampaniaData.ObtenerCampania(idCampania);
            objCampania.Codigo = objCampania.Anio + objCampania.MesId.ToString("0#");
            listaConceptos = request.ListaConceptos;

            //VALIDACIONES
            if (objCampaniaAnterior.FechaInicio != objCampania.FechaInicio || objCampaniaAnterior.FechaFin != objCampania.FechaFin)
            {
                if (CampaniaData.ValidaExisteFecha(objCampania))
                {
                    BusinessException.Generar("Las fechas ingresadas ya están ocupadas por otra campaña");
                }
            }

            if (objCampaniaAnterior.Codigo != objCampania.Codigo)
            {
                if (CampaniaData.ValidaExiste(objCampania))
                {
                    BusinessException.Generar("La campaña que está intentado registrar ya fué registrada anteriormente");
                }
            }


            try
            {
                using (TransactionScope tran = new TransactionScope())
                {
                    CampaniaData.Actualizar(objCampania);
                    CampaniaDetalleData.EliminarPorCampania(idCampania);

                    foreach (var item in listaConceptos)
                    {
                        if (item.Existe)
                        {
                            var objDetalle = new CampaniaDetalle
                            {
                                CampaniaId = idCampania,
                                ConceptoId = item.ConceptoId,
                                Monto = item.Monto
                            };
                            CampaniaDetalleData.Insertar(objDetalle);
                        }
                    }

                    tran.Complete();
                }


            }
            catch (Exception ex)
            {
                Log.RegistrarLog(NivelLog.Error, ex);
                throw;
            }
        }
    }
}
