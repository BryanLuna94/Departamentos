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
    public class ConceptoData
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
        public static List<GenericoListaDto> ListarConceptos(int edificioId)
        {
            var objDatabase = new BaseDatos(BD.CadenaConexion.BDDEPA);
            List<GenericoListaDto> ListaMovimiento = new List<GenericoListaDto>();
            SqlCommand cmd;

            try
            {
                using (SqlConnection con = objDatabase.CrearConexion())
                {
                    con.Open();
                    try
                    {
                        cmd = objDatabase.ObtenerProcedimiento("dbo.sp_Concepto_Listar");
                        cmd.CommandTimeout = BaseDatos.Timeout();
                        objDatabase.AgregarParametro(ref cmd, "@pEdificioId", SqlDbType.Int, edificioId);
                        using (var dr = objDatabase.ExecuteReader(cmd))
                        {
                            while (dr.Read())
                            {
                                ListaMovimiento.Add(new GenericoListaDto
                                {
                                    Codigo = Convert.ToString(dr["ConceptoId"]),
                                    Descripcion = Convert.ToString(dr["Descripcion"])
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
    }
}
