using System;
using System.Collections.Generic;
using System.Linq;
using JBLV.BaseDatos;
using MiDepa.pe.DataTypes.Listas;
using MiDepa.pe.DataTypes.Filtros;
using MiDepa.pe.DataTypes;
using MiDepa.pe.Utility;
using System.Data;
using System.Data.SqlClient;

namespace MiDepa.pe.DataAccess
{
    public class EstadoCuentaDetalleData
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
        public static List<DetalleEstadoCuentaListaDto> ListaDetalleEstadoCuenta(int estadoCuentaId)
        {
            var objDatabase = new BaseDatos(BD.CadenaConexion.BDDEPA);
            List<DetalleEstadoCuentaListaDto> ListaMovimiento = new List<DetalleEstadoCuentaListaDto>();
            SqlCommand cmd;

            try
            {
                using (SqlConnection con = objDatabase.CrearConexion())
                {
                    con.Open();
                    try
                    {
                        cmd = objDatabase.ObtenerProcedimiento("dbo.sp_EstadoCuenta_Detalle_ListarPorEstadoCuenta");
                        cmd.CommandTimeout = BaseDatos.Timeout();
                        objDatabase.AgregarParametro(ref cmd, "@pEstadoCuentaId", SqlDbType.Int, estadoCuentaId);
                        using (var dr = objDatabase.ExecuteReader(cmd))
                        {
                            while (dr.Read())
                            {
                                ListaMovimiento.Add(new DetalleEstadoCuentaListaDto
                                {
                                    EstadoCuentaDetalleId = Convert.ToInt32(dr["EstadoCuentaDetalleId"]),
                                    Concepto = Convert.ToString(dr["Concepto"]),
                                    MontoPagar = Convert.ToDecimal(dr["MontoPagar"])
                                });
                            }
                        }
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            catch
            {
                throw;
            }
            return ListaMovimiento;
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
        public static void Insertar(EstadoCuenta_Detalle objEntidad)
        {
            var objDatabase = new BaseDatos(BD.CadenaConexion.BDDEPA);
            SqlCommand cmd;

            try
            {
                using (SqlConnection con = objDatabase.CrearConexion())
                {
                    con.Open();
                    try
                    {
                        cmd = objDatabase.ObtenerProcedimiento("dbo.sp_EstadoCuenta_Detalle_Insertar");
                        cmd.CommandTimeout = BaseDatos.Timeout();
                        objDatabase.AgregarParametro(ref cmd, "@pEstadoCuentaId", SqlDbType.Int, objEntidad.EstadoCuentaId);
                        objDatabase.AgregarParametro(ref cmd, "@pConceptoId", SqlDbType.Int, objEntidad.ConceptoId);
                        objDatabase.AgregarParametro(ref cmd, "@pMontoPagar", SqlDbType.Decimal, objEntidad.MontoPagar);
                        objDatabase.ExecuteNonQuery(cmd);
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
