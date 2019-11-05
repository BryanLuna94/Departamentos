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
    public class EstadoCuentaData
    {
        /// <summary>Invoca al Procedimiento almacenado que lista Usuarios.</summary>
        /// <param name="objFiltro">Parámetros para el filtro de Listar los Usuarios</param>
        ///<remarks>
        ///<list type = "bullet">
        ///<item><CreadoPor>Bryan Luna Vasquez.</CreadoPor></item>
        ///<item><FecCrea>12/02/2018</FecCrea></item></list>        
        ///<list type="bullet">
        /// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        /// <item><Resp>Responsable.</Resp></item>
        /// <item><Mot>Motivo.</Mot></item></list></remarks>
        public static DateTime? ObtenerFechaPrimerVencido(int depaId)
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
                        cmd = objDatabase.ObtenerProcedimiento("dbo.sp_EstadoCuenta_ObtenerPrimerVencido");
                        cmd.CommandTimeout = BaseDatos.Timeout();
                        objDatabase.AgregarParametro(ref cmd, "@pDepaId", SqlDbType.Int, depaId);
                        using (var dr = objDatabase.ExecuteReader(cmd))
                        {
                            while (dr.Read())
                            {
                                return Funciones.Check.Datetime(dr["FechaVencimiento"]);
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
            return null;
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
        public static List<ReporteEstadoCuentaMensualResumidoListaDto> ReporteMensualResumido(int depaId)
        {
            var objDatabase = new BaseDatos(BD.CadenaConexion.BDDEPA);
            List<ReporteEstadoCuentaMensualResumidoListaDto> ListaMovimiento = new List<ReporteEstadoCuentaMensualResumidoListaDto>();
            SqlCommand cmd;

            try
            {
                using (SqlConnection con = objDatabase.CrearConexion())
                {
                    con.Open();
                    try
                    {
                        cmd = objDatabase.ObtenerProcedimiento("dbo.sp_Departamento_EstadoCuenta_ReporteMensualResumido");
                        cmd.CommandTimeout = BaseDatos.Timeout();
                        objDatabase.AgregarParametro(ref cmd, "@pDepaId", SqlDbType.Int, depaId);
                        using (var dr = objDatabase.ExecuteReader(cmd))
                        {
                            while (dr.Read())
                            {
                                ListaMovimiento.Add(new ReporteEstadoCuentaMensualResumidoListaDto
                                {
                                    Anio = Convert.ToInt16(dr["Anio"]),
                                    Saldo = Convert.ToDecimal(dr["Saldo"]),
                                    MesId = Convert.ToByte(dr["MesId"]),
                                    FechaVencimiento = Convert.ToDateTime(dr["FechaVencimiento"]),
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
        public static MontosEstadoCuentaListaDto ObtenerMontosPeriodo(int depaId, string codigoCampania)
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
                        cmd = objDatabase.ObtenerProcedimiento("dbo.sp_Departamento_EstadoCuenta_DatosPorCampania");
                        cmd.CommandTimeout = BaseDatos.Timeout();
                        objDatabase.AgregarParametro(ref cmd, "@pDepaId", SqlDbType.Int, depaId);
                        objDatabase.AgregarParametro(ref cmd, "@pCodigoCampania", SqlDbType.VarChar, codigoCampania);
                        using (var dr = objDatabase.ExecuteReader(cmd))
                        {
                            while (dr.Read())
                            {
                                return new MontosEstadoCuentaListaDto
                                {
                                    EstadoCuentaId = Convert.ToInt32(dr["EstadoCuentaId"]),
                                    MontoPagado = Convert.ToDecimal(dr["MontoPagado"]),
                                    MontoPagar = Convert.ToDecimal(dr["MontoPagar"]),
                                    Saldo = Convert.ToDecimal(dr["Saldo"]),
                                    TotalInteres = Convert.ToDecimal(dr["TotalInteres"]),
                                    FechaEmision = Funciones.Check.FechaCorta(dr["FechaEmision"]),
                                    FechaVencimiento = Funciones.Check.FechaCorta(dr["FechaVencimiento"]),
                                };
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
            return null;
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
        public static void AgregarPago(int estadoCuentaId, decimal monto)
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
                        cmd = objDatabase.ObtenerProcedimiento("dbo.sp_EstadoCuenta_AgregarPago");
                        cmd.CommandTimeout = BaseDatos.Timeout();
                        objDatabase.AgregarParametro(ref cmd, "@pEstadoCuentaId", SqlDbType.Int, estadoCuentaId);
                        objDatabase.AgregarParametro(ref cmd, "@pMonto", SqlDbType.Decimal, monto);
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
        public static int Insertar(Departamento_EstadoCuenta objEntidad)
        {
            var objDatabase = new BaseDatos(BD.CadenaConexion.BDDEPA);
            SqlCommand cmd;
            int nuevoId;

            try
            {
                using (SqlConnection con = objDatabase.CrearConexion())
                {
                    con.Open();
                    try
                    {
                        cmd = objDatabase.ObtenerProcedimiento("dbo.sp_Departamento_EstadoCuenta_Insertar");
                        cmd.CommandTimeout = BaseDatos.Timeout();
                        objDatabase.AgregarParametro(ref cmd, "@pCorrelativo", SqlDbType.VarChar, objEntidad.Correlativo);
                        objDatabase.AgregarParametro(ref cmd, "@pDepaId", SqlDbType.Int, objEntidad.DepaId);
                        objDatabase.AgregarParametro(ref cmd, "@pMesId", SqlDbType.TinyInt, objEntidad.MesId);
                        objDatabase.AgregarParametro(ref cmd, "@pAnio", SqlDbType.SmallInt, objEntidad.Anio);
                        objDatabase.AgregarParametro(ref cmd, "@pMontoPagar", SqlDbType.Decimal, objEntidad.MontoPagar);
                        objDatabase.AgregarParametro(ref cmd, "@pMontoPagado", SqlDbType.Decimal, objEntidad.MontoPagado);
                        objDatabase.AgregarParametro(ref cmd, "@pSaldo", SqlDbType.Decimal, objEntidad.Saldo);
                        objDatabase.AgregarParametro(ref cmd, "@pFechaEmision", SqlDbType.Date, objEntidad.FechaEmision);
                        objDatabase.AgregarParametro(ref cmd, "@pFechaVencimiento", SqlDbType.Date, objEntidad.FechaVencimiento);
                        objDatabase.AgregarParametro(ref cmd, "@pTotalInteres", SqlDbType.Decimal, objEntidad.TotalInteres);
                        objDatabase.AgregarParametro(ref cmd, "@pEstadoId", SqlDbType.Int, objEntidad.EstadoId);
                        objDatabase.AgregarParametro(ref cmd, "@pCodigoCampania", SqlDbType.VarChar, objEntidad.CodigoCampania);
                        objDatabase.AgregarParametro(ref cmd, "@pEstadoCuentaId", SqlDbType.Int, 0, true);
                        objDatabase.ExecuteNonQuery(cmd);
                        nuevoId = Convert.ToInt32(objDatabase.ObtenerParametro(cmd, "@pNuevoId"));
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
            return nuevoId;
        }
    }
}
