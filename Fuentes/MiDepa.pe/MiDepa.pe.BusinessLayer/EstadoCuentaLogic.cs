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
    public class EstadoCuentaLogic
    {
        /// <summary>Invoca al Procedimiento almacenado que lista Usuarios.</summary>
        /// <param name="objFiltro">Parámetros para el filtro de Listar las Usuarios</param>
        ///<remarks>
        ///<list type = "bullet">
        ///<item><CreadoPor>Bryan Luna Vasquez.</CreadoPor></item>
        ///<item><FecCrea>19/02/2018</FecCrea></item></list>        
        ///<list type="bullet">
        /// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        /// <item><Resp>Responsable.</Resp></item>
        /// <item><Mot>Motivo.</Mot></item></list></remarks>
        public static EstadoCuentaResponseDto ObtenerIndexEstadoCuenta()
        {
            try
            {
                EstadoCuentaResponseDto response;
                List<GenericoListaDto> listaCampanias;

                listaCampanias = new List<GenericoListaDto>();
                foreach (var item in Funciones.ListarCampaniasParaFiltro()) listaCampanias.Add(new GenericoListaDto { Codigo = item.Codigo, Descripcion = item.Descripcion });

                response = new EstadoCuentaResponseDto
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

        /// <summary>Invoca al Procedimiento almacenado que lista Usuarios.</summary>
        /// <param name="objFiltro">Parámetros para el filtro de Listar las Usuarios</param>
        ///<remarks>
        ///<list type = "bullet">
        ///<item><CreadoPor>Bryan Luna Vasquez.</CreadoPor></item>
        ///<item><FecCrea>19/02/2018</FecCrea></item></list>        
        ///<list type="bullet">
        /// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        /// <item><Resp>Responsable.</Resp></item>
        /// <item><Mot>Motivo.</Mot></item></list></remarks>
        public static EstadoCuentaResponseDto ListarDatosEstadoCuentaPorCampania(int depaId, string codigoCampania)
        {
            try
            {
                EstadoCuentaResponseDto response;
                MontosEstadoCuentaListaDto montosEstadoCuenta;
                List<DetalleEstadoCuentaListaDto> listaDetalleEstadoCuenta;
                List<PagosPorEstadoCuentaListaDto> listaPagosPorEstadoCuenta;
                int diasRetraso;
                DateTime fechaActual;
                DateTime fechaVencimiento;

                fechaActual = DateTime.Now;
                montosEstadoCuenta = EstadoCuentaData.ObtenerMontosPeriodo(depaId, codigoCampania);
                if (montosEstadoCuenta == null)
                {
                    listaDetalleEstadoCuenta = new List<DetalleEstadoCuentaListaDto>();
                    listaPagosPorEstadoCuenta = new List<PagosPorEstadoCuentaListaDto>();
                    diasRetraso = 0;
                    montosEstadoCuenta = new MontosEstadoCuentaListaDto();
                    fechaVencimiento = new DateTime();
                }
                else
                {
                    listaDetalleEstadoCuenta = EstadoCuentaDetalleData.ListaDetalleEstadoCuenta(montosEstadoCuenta.EstadoCuentaId);
                    listaPagosPorEstadoCuenta = PagoData.ListaPagosPorEstadoCuenta(montosEstadoCuenta.EstadoCuentaId);
                    fechaVencimiento = Funciones.Check.Datetime(montosEstadoCuenta.FechaVencimiento).Value;

                    if (montosEstadoCuenta.Saldo > 0)
                    {
                        diasRetraso = (fechaActual - fechaVencimiento).Days;
                        if (diasRetraso < 0) diasRetraso = 0;
                    }
                    else
                    {
                        diasRetraso = 0;
                    }
                }

                response = new EstadoCuentaResponseDto
                {
                    MontosEstadoCuenta = montosEstadoCuenta,
                    DiasRetraso = diasRetraso,
                    ListaDetalleEstadoCuenta = listaDetalleEstadoCuenta,
                    ListaPagosEstadoCuenta = listaPagosPorEstadoCuenta
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
