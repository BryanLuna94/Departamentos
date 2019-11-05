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
    public class Edificio_CuentaBancariaData
    {
        /// <summary>Invoca al Procedimiento almacenado que lista Nivels.</summary>
        /// <param name="objFiltro">Parámetros para el filtro de Listar los Nivels</param>
        ///<remarks>
        ///<list type = "bullet">
        ///<item><CreadoPor>Bryan Luna Vasquez.</CreadoPor></item>
        ///<item><FecCrea>12/02/2018</FecCrea></item></list>        
        ///<list type="bullet">
        /// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        /// <item><Resp>Responsable.</Resp></item>
        /// <item><Mot>Motivo.</Mot></item></list></remarks>
        public static List<GenericoListaDto> ListaCuentas_Combo(int edificioId)
        {
            var objDatabase = new BaseDatos(BD.CadenaConexion.BDDEPA);
            List<GenericoListaDto> ListaCuentas = new List<GenericoListaDto>();
            SqlCommand cmd;

            try
            {
                using (SqlConnection con = objDatabase.CrearConexion())
                {
                    con.Open();
                    try
                    {
                        cmd = objDatabase.ObtenerProcedimiento("dbo.sp_Edificio_CuentaBancaria_ListarCombo");
                        cmd.CommandTimeout = BaseDatos.Timeout();
                        objDatabase.AgregarParametro(ref cmd, "@pEdificioId", SqlDbType.Int, edificioId);
                        using (var dr = objDatabase.ExecuteReader(cmd))
                        {
                            while (dr.Read())
                            {
                                ListaCuentas.Add(new GenericoListaDto
                                {
                                    Codigo = Convert.ToString(dr["CuentaBancariaId"]),
                                    Descripcion = Convert.ToString(dr["Banco"]) + " " + Convert.ToString(dr["NumeroCuenta"])
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
            return ListaCuentas;
        }
    }
}
