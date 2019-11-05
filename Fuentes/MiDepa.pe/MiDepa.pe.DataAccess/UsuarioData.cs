using System;
using System.Collections.Generic;
using System.Linq;
using JBLV.BaseDatos;
using MiDepa.pe.DataTypes.Listas;
//using MiDepa.pe.DataTypes.Filtros;
using MiDepa.pe.DataTypes;
using MiDepa.pe.Utility;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

namespace MiDepa.pe.DataAccess
{
    public class UsuarioData
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
        public static LoginListaDto Login(string usuario)
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
                        cmd = objDatabase.ObtenerProcedimiento("dbo.sp_Usuario_Login");
                        cmd.CommandTimeout = BaseDatos.Timeout();
                        objDatabase.AgregarParametro(ref cmd, "@pUsuarioAcceso", SqlDbType.VarChar, usuario);
                        using (var dr = objDatabase.ExecuteReader(cmd))
                        {
                            while (dr.Read())
                            {
                                return new LoginListaDto
                                {
                                    Clave = Convert.ToString(dr["Clave"]),
                                    Nombre = dr["NombreUsuario"].ToString(),
                                    CodigoPerfil = Convert.ToInt16(dr["PerfilId"]),
                                    Codigo = Convert.ToInt16(dr["UsuarioId"]),
                                    Usuario = Convert.ToString(dr["UsuarioAcceso"]),
                                    CodigoEdificio= Funciones.Check.Int32Null(dr["EdificioId"]),
                                    CodigoPersona = Funciones.Check.Int32Null(dr["PersonaId"])
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
        public static DatosUsuarioListaDto ListarDatosUsuario(int usuarioId)
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
                        cmd = objDatabase.ObtenerProcedimiento("dbo.sp_Usuario_ListarDatos");
                        cmd.CommandTimeout = BaseDatos.Timeout();
                        objDatabase.AgregarParametro(ref cmd, "@pUsuarioId", SqlDbType.Int, usuarioId);
                        using (var dr = objDatabase.ExecuteReader(cmd))
                        {
                            while (dr.Read())
                            {
                                return new DatosUsuarioListaDto
                                {
                                    Edificio = Funciones.Check.Cadena(dr["CodigoEdificio"]),
                                    Depa = Funciones.Check.Cadena(dr["CodigoDepa"]),
                                    DepaId = Funciones.Check.Int32Null(dr["DepaId"])
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
    }
}
