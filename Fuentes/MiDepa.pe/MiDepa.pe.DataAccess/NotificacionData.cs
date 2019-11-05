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
    public class NotificacionData
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
        public static int ObtenerCantidad()
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
                        cmd = objDatabase.ObtenerProcedimiento("dbo.sp_Notificacion_ObtenerCantidad");
                        cmd.CommandTimeout = BaseDatos.Timeout();
                        using (var dr = objDatabase.ExecuteReader(cmd))
                        {
                            while (dr.Read())
                            {
                                return Funciones.Check.Int32(dr["Cantidad"]);
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
            return 0;
        }
    }
}
