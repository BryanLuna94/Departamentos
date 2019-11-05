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
    public class ArchivoLogic
    {
        /// <summary>Método que registra MaestroStopees.</summary>
        /// <param name="objPersona">Entidad con los datos de la entidad.</param>
        /// <returns>.</returns>
        /// <remarks><list type="bullet">
        /// <item><CreadoPor>David Castañeda</CreadoPor></item>
        /// <item><FecCrea>13/02/2018.</FecCrea></item></list>
        /// <list type="bullet">
        /// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        /// <item><Resp>Responsable.</Resp></item>
        /// <item><Mot>Motivo.</Mot></item></list></remarks>
        public static void GuardarArchivo(ArchivoRequestDto request)
        {
            try
            {
                Archivo objArchivo;

                objArchivo = request.Archivo;

                using (TransactionScope tran = new TransactionScope())
                {
                    ArchivoData.GuardarArchivo(objArchivo);

                    tran.Complete();
                }
            }
            catch (Exception ex)
            {
                Log.RegistrarLog(NivelLog.Error, ex);
                throw;
            }
        }

        /// <summary>Método que registra MaestroStopees.</summary>
        /// <param name="objPersona">Entidad con los datos de la entidad.</param>
        /// <returns>.</returns>
        /// <remarks><list type="bullet">
        /// <item><CreadoPor>David Castañeda</CreadoPor></item>
        /// <item><FecCrea>13/02/2018.</FecCrea></item></list>
        /// <list type="bullet">
        /// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        /// <item><Resp>Responsable.</Resp></item>
        /// <item><Mot>Motivo.</Mot></item></list></remarks>
        public static int EliminarArchivo(string id)
        {
            try
            {
                ArchivoListaDto objArchivo;

                objArchivo = ArchivoData.ObtenerArchivoPorId(id);

                using (TransactionScope tran = new TransactionScope())
                {
                    ArchivoData.EliminarArchivo(id);

                    tran.Complete();
                }

                return Convert.ToInt32(objArchivo.Codigo);
            }
            catch (Exception ex)
            {
                Log.RegistrarLog(NivelLog.Error, ex);
                throw;
            }
        }

        /// <summary>Método que registra Movimientos.</summary>
        /// <param name="objPersona">Entidad con los datos de la entidad.</param>
        /// <returns>.</returns>
        /// <remarks><list type="bullet">
        /// <item><CreadoPor>Bryan Luna Vasquez</CreadoPor></item>
        /// <item><FecCrea>13/02/2018.</FecCrea></item></list>
        /// <list type="bullet">
        /// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        /// <item><Resp>Responsable.</Resp></item>
        /// <item><Mot>Motivo.</Mot></item></list></remarks>
        public static ArchivoResponseDto ListadoArchivos(string tabla, int id)
        {
            try
            {
                ArchivoResponseDto response;
                List<ArchivoListaDto> listaArchivos;

                listaArchivos = ArchivoData.ListarArchivos(tabla, id.ToString());

                response = new ArchivoResponseDto
                {
                    ListaArchivos = listaArchivos
                };

                return response;
            }
            catch (Exception ex)
            {
                Log.RegistrarLog(NivelLog.Error, ex);
                throw;
            }
        }

        /// <summary>Método que registra Movimientos.</summary>
        /// <param name="objPersona">Entidad con los datos de la entidad.</param>
        /// <returns>.</returns>
        /// <remarks><list type="bullet">
        /// <item><CreadoPor>Bryan Luna Vasquez</CreadoPor></item>
        /// <item><FecCrea>13/02/2018.</FecCrea></item></list>
        /// <list type="bullet">
        /// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        /// <item><Resp>Responsable.</Resp></item>
        /// <item><Mot>Motivo.</Mot></item></list></remarks>
        public static ArchivoResponseDto ObtenerArchivoPorId(string id)
        {
            try
            {
                ArchivoResponseDto response;
                ArchivoListaDto objArchivo;

                objArchivo = ArchivoData.ObtenerArchivoPorId(id);

                response = new ArchivoResponseDto
                {
                    Archivo = objArchivo
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
