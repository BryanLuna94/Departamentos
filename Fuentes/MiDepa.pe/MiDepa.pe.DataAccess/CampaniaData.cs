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
    public class CampaniaData
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
        public static Campania ObtenerCampaniaActual(int edificioId)
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
                        cmd = objDatabase.ObtenerProcedimiento("dbo.sp_Campania_ObtenerActual");
                        cmd.CommandTimeout = BaseDatos.Timeout();
                        objDatabase.AgregarParametro(ref cmd, "@pEdificioId", SqlDbType.VarChar, edificioId);
                        using (var dr = objDatabase.ExecuteReader(cmd))
                        {
                            while (dr.Read())
                            {
                                return new Campania
                                {
                                    Anio = Convert.ToInt16(dr["Anio"]),
                                    CampaniaId = Convert.ToInt32(dr["CampaniaId"]),
                                    EdificioId = Convert.ToInt32(dr["EdificioId"]),
                                    EstadoId = Convert.ToInt32(dr["EstadoId"]),
                                    FechaFin = Convert.ToDateTime(dr["FechaFin"]),
                                    FechaInicio = Convert.ToDateTime(dr["FechaInicio"]),
                                    MesId = Convert.ToByte(dr["MesId"]),
                                    Total = Convert.ToDecimal(dr["Total"]),
                                    Codigo = Convert.ToString(dr["Codigo"])
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
        public static Campania ObtenerCampania(int campaniaId)
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
                        cmd = objDatabase.ObtenerProcedimiento("dbo.sp_Campania_ObtenerPorId");
                        cmd.CommandTimeout = BaseDatos.Timeout();
                        objDatabase.AgregarParametro(ref cmd, "@pCampaniaId", SqlDbType.Int, campaniaId);
                        using (var dr = objDatabase.ExecuteReader(cmd))
                        {
                            while (dr.Read())
                            {
                                return new Campania
                                {
                                    Anio = Convert.ToInt16(dr["Anio"]),
                                    CampaniaId = Convert.ToInt32(dr["CampaniaId"]),
                                    EdificioId = Convert.ToInt32(dr["EdificioId"]),
                                    EstadoId = Convert.ToInt32(dr["EstadoId"]),
                                    FechaFin = Convert.ToDateTime(dr["FechaFin"]),
                                    FechaInicio = Convert.ToDateTime(dr["FechaInicio"]),
                                    MesId = Convert.ToByte(dr["MesId"]),
                                    Total = Convert.ToDecimal(dr["Total"]),
                                    Codigo = Convert.ToString(dr["Codigo"])
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
        public static Campania ObtenerUltimaCampania(int edificioId)
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
                        cmd = objDatabase.ObtenerProcedimiento("dbo.sp_Campania_ObtenerUltima");
                        cmd.CommandTimeout = BaseDatos.Timeout();
                        objDatabase.AgregarParametro(ref cmd, "@pEdificioId", SqlDbType.Int, edificioId);
                        using (var dr = objDatabase.ExecuteReader(cmd))
                        {
                            while (dr.Read())
                            {
                                return new Campania
                                {
                                    Anio = Convert.ToInt16(dr["Anio"]),
                                    CampaniaId = Convert.ToInt32(dr["CampaniaId"]),
                                    EdificioId = Convert.ToInt32(dr["EdificioId"]),
                                    EstadoId = Convert.ToInt32(dr["EstadoId"]),
                                    FechaFin = Convert.ToDateTime(dr["FechaFin"]),
                                    FechaInicio = Convert.ToDateTime(dr["FechaInicio"]),
                                    MesId = Convert.ToByte(dr["MesId"]),
                                    Total = Convert.ToDecimal(dr["Total"]),
                                    Codigo = Convert.ToString(dr["Codigo"])
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
        public static Campania ObtenerCampaniaPorCodigo(int edificioId,string codigo)
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
                        cmd = objDatabase.ObtenerProcedimiento("dbo.sp_Campania_ObtenerPorCodigo");
                        cmd.CommandTimeout = BaseDatos.Timeout();
                        objDatabase.AgregarParametro(ref cmd, "@pEdificioId", SqlDbType.Int, edificioId);
                        objDatabase.AgregarParametro(ref cmd, "@pCodigo", SqlDbType.VarChar, codigo);
                        using (var dr = objDatabase.ExecuteReader(cmd))
                        {
                            while (dr.Read())
                            {
                                return new Campania
                                {
                                    Anio = Convert.ToInt16(dr["Anio"]),
                                    CampaniaId = Convert.ToInt32(dr["CampaniaId"]),
                                    EdificioId = Convert.ToInt32(dr["EdificioId"]),
                                    EstadoId = Convert.ToInt32(dr["EstadoId"]),
                                    FechaFin = Convert.ToDateTime(dr["FechaFin"]),
                                    FechaInicio = Convert.ToDateTime(dr["FechaInicio"]),
                                    MesId = Convert.ToByte(dr["MesId"]),
                                    Total = Convert.ToDecimal(dr["Total"]),
                                    Codigo = Convert.ToString(dr["Codigo"])
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
        public static List<ReporteGastosMensualEdificio> ReporteProgresoMensualEdificio(int edificioId)
        {
            var objDatabase = new BaseDatos(BD.CadenaConexion.BDDEPA);
            List<ReporteGastosMensualEdificio> ListaMovimiento = new List<ReporteGastosMensualEdificio>();
            SqlCommand cmd;

            try
            {
                using (SqlConnection con = objDatabase.CrearConexion())
                {
                    con.Open();
                    try
                    {
                        cmd = objDatabase.ObtenerProcedimiento("dbo.sp_Campania_ReporteListarProgreso");
                        cmd.CommandTimeout = BaseDatos.Timeout();
                        objDatabase.AgregarParametro(ref cmd, "@pEdificioId", SqlDbType.Int, edificioId);
                        using (var dr = objDatabase.ExecuteReader(cmd))
                        {
                            while (dr.Read())
                            {
                                ListaMovimiento.Add(new ReporteGastosMensualEdificio
                                {
                                    Anio = Convert.ToInt16(dr["Anio"]),
                                    Concepto = Convert.ToString(dr["Concepto"]),
                                    Mes = Convert.ToByte(dr["MesId"]),
                                    Monto = Convert.ToDecimal(dr["Monto"]),
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
        public static List<ReporteGastosMensualEdificioResumido> ReporteProgresoMensualEdificioResumido(int edificioId)
        {
            var objDatabase = new BaseDatos(BD.CadenaConexion.BDDEPA);
            List<ReporteGastosMensualEdificioResumido> ListaMovimiento = new List<ReporteGastosMensualEdificioResumido>();
            SqlCommand cmd;

            try
            {
                using (SqlConnection con = objDatabase.CrearConexion())
                {
                    con.Open();
                    try
                    {
                        cmd = objDatabase.ObtenerProcedimiento("dbo.sp_Campania_ReporteListarProgresoResumido");
                        cmd.CommandTimeout = BaseDatos.Timeout();
                        objDatabase.AgregarParametro(ref cmd, "@pEdificioId", SqlDbType.Int, edificioId);
                        using (var dr = objDatabase.ExecuteReader(cmd))
                        {
                            while (dr.Read())
                            {
                                ListaMovimiento.Add(new ReporteGastosMensualEdificioResumido
                                {
                                    Anio = Convert.ToInt16(dr["Anio"]),
                                    Campania = Convert.ToString(dr["Codigo"]),
                                    Mes = Convert.ToByte(dr["MesId"]),
                                    Monto = Convert.ToDecimal(dr["Total"]),
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
        public static int Insertar(Campania objEntidad)
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
                        cmd = objDatabase.ObtenerProcedimiento("dbo.sp_Campania_Insertar");
                        cmd.CommandTimeout = BaseDatos.Timeout();
                        objDatabase.AgregarParametro(ref cmd, "@pMesId", SqlDbType.TinyInt, objEntidad.MesId);
                        objDatabase.AgregarParametro(ref cmd, "@pAnio", SqlDbType.SmallInt, objEntidad.Anio);
                        objDatabase.AgregarParametro(ref cmd, "@pTotal", SqlDbType.Decimal, objEntidad.Total);
                        objDatabase.AgregarParametro(ref cmd, "@pEdificioId", SqlDbType.Int, objEntidad.EdificioId);
                        objDatabase.AgregarParametro(ref cmd, "@pEstadoId", SqlDbType.Int, objEntidad.EstadoId);
                        objDatabase.AgregarParametro(ref cmd, "@pFechaInicio", SqlDbType.SmallDateTime, objEntidad.FechaInicio);
                        objDatabase.AgregarParametro(ref cmd, "@pFechaFin", SqlDbType.SmallDateTime, objEntidad.FechaFin);
                        objDatabase.AgregarParametro(ref cmd, "@pCodigo", SqlDbType.VarChar, objEntidad.Codigo);
                        objDatabase.AgregarParametro(ref cmd, "@pCampaniaId", SqlDbType.Int, 0, true);
                        objDatabase.ExecuteNonQuery(cmd);
                        nuevoId = Convert.ToInt32(objDatabase.ObtenerParametro(cmd, "@pCampaniaId"));
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
        public static void Actualizar(Campania objEntidad)
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
                        cmd = objDatabase.ObtenerProcedimiento("dbo.sp_Campania_Actualizar");
                        cmd.CommandTimeout = BaseDatos.Timeout();
                        objDatabase.AgregarParametro(ref cmd, "@pCampaniaId", SqlDbType.Int, objEntidad.CampaniaId);
                        objDatabase.AgregarParametro(ref cmd, "@pMesId", SqlDbType.TinyInt, objEntidad.MesId);
                        objDatabase.AgregarParametro(ref cmd, "@pAnio", SqlDbType.SmallInt, objEntidad.Anio);
                        objDatabase.AgregarParametro(ref cmd, "@pTotal", SqlDbType.Decimal, objEntidad.Total);                        
                        objDatabase.AgregarParametro(ref cmd, "@pFechaInicio", SqlDbType.SmallDateTime, objEntidad.FechaInicio);
                        objDatabase.AgregarParametro(ref cmd, "@pFechaFin", SqlDbType.SmallDateTime, objEntidad.FechaFin);
                        objDatabase.AgregarParametro(ref cmd, "@pCodigo", SqlDbType.VarChar, objEntidad.Codigo);
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
        public static List<CampaniaListaDto> ListarCampanias(CampaniaFiltroDto objFiltro)
        {
            var objDatabase = new BaseDatos(BD.CadenaConexion.BDDEPA);
            List<CampaniaListaDto> ListaMovimiento = new List<CampaniaListaDto>();
            SqlCommand cmd;

            try
            {
                using (SqlConnection con = objDatabase.CrearConexion())
                {
                    con.Open();
                    try
                    {
                        cmd = objDatabase.ObtenerProcedimiento("dbo.sp_Campania_Listar");
                        cmd.CommandTimeout = BaseDatos.Timeout();
                        objDatabase.AgregarParametro(ref cmd, "@pCodigo", SqlDbType.VarChar, objFiltro.Codigo);
                        objDatabase.AgregarParametro(ref cmd, "@pAnio", SqlDbType.SmallInt, objFiltro.Anio);
                        objDatabase.AgregarParametro(ref cmd, "@pEdificioId", SqlDbType.Int, objFiltro.EdificioId);
                        using (var dr = objDatabase.ExecuteReader(cmd))
                        {
                            while (dr.Read())
                            {
                                ListaMovimiento.Add(new CampaniaListaDto
                                {
                                    CampaniaId = Convert.ToInt32(dr["CampaniaId"]),
                                    MesId = Convert.ToInt32(dr["MesId"]),
                                    Anio = Convert.ToInt32(dr["Anio"]),
                                    Total = Convert.ToDecimal(dr["Total"]),
                                    EstadoId = Convert.ToInt32(dr["EstadoId"]),
                                    FechaInicio = Funciones.Check.FechaCorta(dr["FechaInicio"]),
                                    FechaFin = Funciones.Check.FechaCorta(dr["FechaFin"]),
                                    Codigo = Convert.ToString(dr["Codigo"]),
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

        /// <summary>Método que valida si existe maestro de niveles.</summary>
        /// <param name="objParametros">Entidad con los datos de la entidad.</param>
        /// <returns>.</returns>
        /// <remarks><list type="bullet">
        /// <item><CreadoPor>Bryan Luna Vásquez</CreadoPor></item>
        /// <item><FecCrea>22/02/2018.</FecCrea></item></list>
        /// <list type="bullet">
        /// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        /// <item><Resp>Responsable.</Resp></item>
        /// <item><Mot>Motivo.</Mot></item></list></remarks>
        public static bool ValidaExisteFecha(Campania objParametros)
        {
            var objDatabase = new BaseDatos(BD.CadenaConexion.BDDEPA);
            int iResultado;
            SqlCommand cmd;

            try
            {
                using (SqlConnection con = objDatabase.CrearConexion())
                {
                    con.Open();
                    try
                    {
                        cmd = objDatabase.ObtenerProcedimiento("dbo.sp_Campania_ValidaFecha");
                        cmd.CommandTimeout = BaseDatos.Timeout();
                        objDatabase.AgregarParametro(ref cmd, "@pFechaInicio", SqlDbType.VarChar, objParametros.FechaInicio.ToShortDateString());
                        objDatabase.AgregarParametro(ref cmd, "@pFechaFin", SqlDbType.VarChar, objParametros.FechaFin.ToShortDateString());
                        objDatabase.AgregarParametro(ref cmd, "@pExiste", SqlDbType.Int, 0, true);
                        objDatabase.ExecuteNonQuery(cmd);
                        iResultado = Convert.ToInt32(objDatabase.ObtenerParametro(cmd, "@pExiste"));

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
            return (iResultado > 0);
        }

        /// <summary>Método que valida si existe maestro de niveles.</summary>
        /// <param name="objParametros">Entidad con los datos de la entidad.</param>
        /// <returns>.</returns>
        /// <remarks><list type="bullet">
        /// <item><CreadoPor>Bryan Luna Vásquez</CreadoPor></item>
        /// <item><FecCrea>22/02/2018.</FecCrea></item></list>
        /// <list type="bullet">
        /// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        /// <item><Resp>Responsable.</Resp></item>
        /// <item><Mot>Motivo.</Mot></item></list></remarks>
        public static bool ValidaExiste(Campania objParametros)
        {
            var objDatabase = new BaseDatos(BD.CadenaConexion.BDDEPA);
            int iResultado;
            SqlCommand cmd;

            try
            {
                using (SqlConnection con = objDatabase.CrearConexion())
                {
                    con.Open();
                    try
                    {
                        cmd = objDatabase.ObtenerProcedimiento("dbo.sp_Campania_ValidaExiste");
                        cmd.CommandTimeout = BaseDatos.Timeout();
                        objDatabase.AgregarParametro(ref cmd, "@pCodigo", SqlDbType.VarChar, objParametros.Codigo);
                        objDatabase.AgregarParametro(ref cmd, "@pExiste", SqlDbType.Int, 0, true);
                        objDatabase.ExecuteNonQuery(cmd);
                        iResultado = Convert.ToInt32(objDatabase.ObtenerParametro(cmd, "@pExiste"));

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
            return (iResultado > 0);
        }
    }
}
