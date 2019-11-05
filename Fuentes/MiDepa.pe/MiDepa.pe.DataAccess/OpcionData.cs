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
    public class OpcionData
    {
        /// <summary>Invoca al Procedimiento almacenado que lista Secciones.</summary>
        /// <param name="objFiltro">Parámetros para el filtro de Listar los Secciones</param>
        ///<remarks>
        ///<list type = "bullet">
        ///<item><CreadoPor>Bryan Luna Vasquez.</CreadoPor></item>
        ///<item><FecCrea>12/02/2018</FecCrea></item></list>        
        ///<list type="bullet">
        /// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        /// <item><Resp>Responsable.</Resp></item>
        /// <item><Mot>Motivo.</Mot></item></list></remarks>
        public static List<OpcionListaDto> ListaOpcionesPorModulo(int idModulo)
        {
            var objDatabase = new BaseDatos(BD.CadenaConexion.BDDEPA);
            List<OpcionListaDto> lista = new List<OpcionListaDto>();
            SqlCommand cmd;

            try
            {
                using (SqlConnection con = objDatabase.CrearConexion())
                {
                    con.Open();
                    try
                    {
                        cmd = objDatabase.ObtenerProcedimiento("dbo.sp_Opcion_ListarPorModulo");
                        cmd.CommandTimeout = BaseDatos.Timeout();
                        objDatabase.AgregarParametro(ref cmd, "@piCodOpcModulo", SqlDbType.Int, idModulo);
                        using (var dr = objDatabase.ExecuteReader(cmd))
                        {
                            while (dr.Read())
                            {
                                lista.Add(new OpcionListaDto
                                {
                                    Nombre = dr["Nombre"].ToString(),
                                    Codigo = Convert.ToInt32(dr["OpcionId"]),
                                    CodigoPadre = Convert.ToInt32(dr["OpcionPadreId"]),
                                    Orden = Convert.ToInt16(dr["Orden"]),
                                    Ruta = Convert.ToString(dr["Ruta"]),
                                    Clase = Convert.ToString(dr["Clase"]),
                                    TipoOpcion = Convert.ToInt32(dr["TipoOpcionId"]),
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
            return lista;
        }

        /// <summary>Invoca al Procedimiento almacenado que lista Secciones.</summary>
        /// <param name="objFiltro">Parámetros para el filtro de Listar los Secciones</param>
        ///<remarks>
        ///<list type = "bullet">
        ///<item><CreadoPor>Bryan Luna Vasquez.</CreadoPor></item>
        ///<item><FecCrea>12/02/2018</FecCrea></item></list>        
        ///<list type="bullet">
        /// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        /// <item><Resp>Responsable.</Resp></item>
        /// <item><Mot>Motivo.</Mot></item></list></remarks>
        public static List<OpcionListaDto> ListaOpcionesPorPerfil(short idPerfil)
        {
            var objDatabase = new BaseDatos(BD.CadenaConexion.BDDEPA);
            List<OpcionListaDto> lista = new List<OpcionListaDto>();
            SqlCommand cmd;

            try
            {
                using (SqlConnection con = objDatabase.CrearConexion())
                {
                    con.Open();
                    try
                    {
                        cmd = objDatabase.ObtenerProcedimiento("dbo.sp_Opcion_ListarPorPerfil");
                        cmd.CommandTimeout = BaseDatos.Timeout();
                        objDatabase.AgregarParametro(ref cmd, "@pPerfilId", SqlDbType.SmallInt, idPerfil);
                        using (var dr = objDatabase.ExecuteReader(cmd))
                        {
                            while (dr.Read())
                            {
                                lista.Add(new OpcionListaDto
                                {
                                    Nombre = dr["Nombre"].ToString(),
                                    Codigo = Convert.ToInt32(dr["OpcionId"]),
                                    CodigoPadre = Convert.ToInt32(dr["OpcionPadreId"]),
                                    Orden = Convert.ToInt16(dr["Orden"]),
                                    Ruta = Convert.ToString(dr["Ruta"]),
                                    Clase = Convert.ToString(dr["Clase"]),
                                    TipoOpcion = Convert.ToInt32(dr["TipoOpcionId"]),
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
            return lista;
        }
    }
}
