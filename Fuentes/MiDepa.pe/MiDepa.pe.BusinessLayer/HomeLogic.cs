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
using System.Linq;

namespace MiDepa.pe.BusinessLayer
{
    public class HomeLogic
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
        public static HomeResponseDto ListaDatosHome(int depaId)
        {
            try
            {
                HomeResponseDto response;
                string campaniaActual;
                decimal deudaActual;
                int campaniasDebe;
                int diasRetraso;
                string textoMostrarDias;
                string textoAlDia;
                bool tieneRetraso;
                DateTime? fechaUltimoVencimiento;
                List<GenericoListaDto> listaCampanias;
                List<ReporteGastosMensualEdificioResumido> listaGastosMensualResumido;
                List<DepasEstadoHomeListaDto> listaDepasEstado;
                List<ReporteEstadoCuentaMensualResumidoListaDto> listaReporteEstadoCuentaMensualResumido;
                DateTime fechaActual;
                int edificioId;
                Departamento objDepa;
                Campania objCampaniaActual;

                objDepa = DepartamentoData.ObtenerDepartamento(depaId);
                edificioId = objDepa.EdificioId;
                deudaActual = DepartamentoData.ObtenerDeudaActual(depaId);
                campaniasDebe = DepartamentoData.ObtenerCampaniasDebe(depaId);
                listaCampanias = new List<GenericoListaDto>();
                foreach (var item in Funciones.ListarCampaniasParaFiltro()) listaCampanias.Add(new GenericoListaDto { Codigo = item.Codigo, Descripcion = item.Descripcion });
                listaGastosMensualResumido = CampaniaData.ReporteProgresoMensualEdificioResumido(edificioId);
                listaGastosMensualResumido = listaGastosMensualResumido.OrderBy(x => x.Campania).ToList();
                fechaUltimoVencimiento = EstadoCuentaData.ObtenerFechaPrimerVencido(depaId);
                fechaActual = DateTime.Now;
                diasRetraso = (fechaActual - fechaUltimoVencimiento).Value.Days;
                objCampaniaActual = CampaniaData.ObtenerCampaniaActual(edificioId);
                listaReporteEstadoCuentaMensualResumido = EstadoCuentaData.ReporteMensualResumido(depaId);
                listaReporteEstadoCuentaMensualResumido = listaReporteEstadoCuentaMensualResumido.OrderBy(x => x.Anio).ThenBy(x => x.MesId).ToList();
                //listaReporteEstadoCuentaMensualResumido = listaReporteEstadoCuentaMensualResumido.OrderBy(x => x.MesId).ToList();
                campaniaActual = objCampaniaActual.Codigo;

                if (diasRetraso > 0)
                {
                    tieneRetraso = true;
                    textoAlDia = Constantes.Mensajes.TEXTO_NOAL_DIA;
                    textoMostrarDias = string.Format(Constantes.Mensajes.DIAS_RETRASO, diasRetraso);
                }
                else if (diasRetraso < 0)
                {
                    tieneRetraso = false;
                    textoAlDia = Constantes.Mensajes.TEXTO_AL_DIA;
                    textoMostrarDias = string.Format(Constantes.Mensajes.DIAS_FALTANTES, diasRetraso);
                }
                else
                {
                    tieneRetraso = true;
                    textoAlDia = Constantes.Mensajes.TEXTO_NOAL_DIA;
                    textoMostrarDias = string.Format(Constantes.Mensajes.HOY_DIOPAGO);
                }

                listaDepasEstado = DepartamentoData.ListarEstadosHome(edificioId);

                foreach (var item in listaDepasEstado)
                {
                    item.Debe = ((item.FechaVencimiento <= fechaActual || item.FechaVencimiento == null)&& item.Saldo > 0);
                }

                foreach (var item in listaReporteEstadoCuentaMensualResumido)
                {
                    item.Campania = Funciones.ObtenerDescripcionCampania(item.MesId, item.Anio);
                    item.AlDia = !(item.FechaVencimiento <= fechaActual && item.Saldo > 0);
                }

                response = new HomeResponseDto
                {
                    CampaniaActual = campaniaActual,
                    DeudaActual = deudaActual,
                    CampaniasDebe = campaniasDebe,
                    ListaCampanias = listaCampanias,
                    ListaDepasEstado = listaDepasEstado,
                    ListaGastosMensual = listaGastosMensualResumido,
                    TieneRetraso = tieneRetraso,
                    TextoMostrarRetraso = textoMostrarDias,
                    TextoAlDia = textoAlDia,
                    ListaReporteEstadoCuentaResumido = listaReporteEstadoCuentaMensualResumido
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
