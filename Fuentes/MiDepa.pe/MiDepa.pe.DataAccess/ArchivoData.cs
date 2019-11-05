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
    public class ArchivoData
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
        public static int GuardarArchivo(Archivo objParametros)
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
                        cmd = objDatabase.ObtenerProcedimiento("dbo.sp_Archivo_GuardarArchivo");
                        cmd.CommandTimeout = BaseDatos.Timeout();
                        objDatabase.AgregarParametro(ref cmd, "@Tabla", SqlDbType.VarChar, objParametros.Tabla);
                        objDatabase.AgregarParametro(ref cmd, "@Codigo", SqlDbType.VarChar, objParametros.Codigo);
                        objDatabase.AgregarParametro(ref cmd, "@BinData", SqlDbType.VarBinary, objParametros.BinData);
                        objDatabase.AgregarParametro(ref cmd, "@Descripcion", SqlDbType.VarChar, objParametros.Descripcion);
                        objDatabase.AgregarParametro(ref cmd, "@Nombre", SqlDbType.VarChar, objParametros.Nombre);
                        objDatabase.AgregarParametro(ref cmd, "@Extension", SqlDbType.VarChar, objParametros.Extension);
                        objDatabase.ExecuteNonQuery(cmd);
                        iResultado = 1;

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
            return iResultado;
        }

        /// <summary>Invoca al Procedimiento almacenado que lista Turnos.</summary>
        /// <param name="objFiltro">Parámetros para el filtro de Listar los Turnos</param>
        ///<remarks>
        ///<list type = "bullet">
        ///<item><CreadoPor>Bryan Luna Vasquez.</CreadoPor></item>
        ///<item><FecCrea>12/02/2018</FecCrea></item></list>        
        ///<list type="bullet">
        /// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        /// <item><Resp>Responsable.</Resp></item>
        /// <item><Mot>Motivo.</Mot></item></list></remarks>
        public static List<ArchivoListaDto> ListarArchivos(string tabla, string codigo)
        {
            var objDatabase = new BaseDatos(BD.CadenaConexion.BDDEPA);
            List<ArchivoListaDto> ListaArchivos = new List<ArchivoListaDto>();
            SqlCommand cmd;

            try
            {
                using (SqlConnection con = objDatabase.CrearConexion())
                {
                    con.Open();
                    try
                    {
                        cmd = objDatabase.ObtenerProcedimiento("dbo.sp_Archivo_Listar");
                        cmd.CommandTimeout = BaseDatos.Timeout();
                        objDatabase.AgregarParametro(ref cmd, "@Tabla", SqlDbType.VarChar, tabla);
                        objDatabase.AgregarParametro(ref cmd, "@Codigo", SqlDbType.VarChar, codigo);
                        using (var dr = objDatabase.ExecuteReader(cmd))
                        {
                            while (dr.Read())
                            {
                                ListaArchivos.Add(new ArchivoListaDto
                                {
                                    Descripcion = Funciones.Check.Cadena(dr["Descripcion"]),
                                    Id = Convert.ToString(dr["Id"]),
                                    Longitud = Convert.ToInt32(dr["Longitud"]),
                                    Archivo = (byte[])dr["BinData"],
                                    Codigo = Funciones.Check.Cadena(dr["Codigo"]),
                                    Nombre = Funciones.Check.Cadena(dr["Nombre"]),
                                    Extension = Funciones.Check.Cadena(dr["Extension"])
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
            return ListaArchivos;
        }

        /// <summary>Invoca al Procedimiento almacenado que lista Turnos.</summary>
        /// <param name="objFiltro">Parámetros para el filtro de Listar los Turnos</param>
        ///<remarks>
        ///<list type = "bullet">
        ///<item><CreadoPor>Bryan Luna Vasquez.</CreadoPor></item>
        ///<item><FecCrea>12/02/2018</FecCrea></item></list>        
        ///<list type="bullet">
        /// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        /// <item><Resp>Responsable.</Resp></item>
        /// <item><Mot>Motivo.</Mot></item></list></remarks>
        public static ArchivoListaDto ObtenerArchivoPorId(string id)
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
                        cmd = objDatabase.ObtenerProcedimiento("dbo.sp_Archivo_ObtenerPorId");
                        cmd.CommandTimeout = BaseDatos.Timeout();
                        objDatabase.AgregarParametro(ref cmd, "@Id", SqlDbType.VarChar, id);
                        using (var dr = objDatabase.ExecuteReader(cmd))
                        {
                            while (dr.Read())
                            {
                                return new ArchivoListaDto
                                {
                                    Longitud = Convert.ToInt32(dr["Longitud"]),
                                    Archivo = (byte[])dr["Archivo"],
                                    Codigo = Funciones.Check.Cadena(dr["Codigo"]),
                                    Nombre = Funciones.Check.Cadena(dr["Nombre"]),
                                    Extension = Funciones.Check.Cadena(dr["Extension"])
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
                        cmd = objDatabase.ObtenerProcedimiento("dbo.sp_Archivo_Eliminar");
                        cmd.CommandTimeout = BaseDatos.Timeout();
                        objDatabase.AgregarParametro(ref cmd, "@Id", SqlDbType.VarChar, id);
                        objDatabase.ExecuteNonQuery(cmd);
                        iResultado = 1;
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
            return iResultado;
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
        public static void EliminarArchivosPorRegistro(string tabla, string codigo)
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
                        cmd = objDatabase.ObtenerProcedimiento("dbo.sp_Archivo_EliminarPorRegistro");
                        cmd.CommandTimeout = BaseDatos.Timeout();
                        objDatabase.AgregarParametro(ref cmd, "@pTabla", SqlDbType.VarChar, tabla);
                        objDatabase.AgregarParametro(ref cmd, "@pCodigo", SqlDbType.VarChar, codigo);
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
