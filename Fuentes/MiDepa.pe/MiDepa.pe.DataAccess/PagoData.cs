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
    public class PagoData
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
        public static List<PagosPorEstadoCuentaListaDto> ListaPagosPorEstadoCuenta(int estadoCuentaId)
        {
            var objDatabase = new BaseDatos(BD.CadenaConexion.BDDEPA);
            List<PagosPorEstadoCuentaListaDto> ListaMovimiento = new List<PagosPorEstadoCuentaListaDto>();
            SqlCommand cmd;

            try
            {
                using (SqlConnection con = objDatabase.CrearConexion())
                {
                    con.Open();
                    try
                    {
                        cmd = objDatabase.ObtenerProcedimiento("dbo.sp_Pago_ListarPorEstadoCuenta");
                        cmd.CommandTimeout = BaseDatos.Timeout();
                        objDatabase.AgregarParametro(ref cmd, "@pEstadoCuentaId", SqlDbType.Int, estadoCuentaId);
                        using (var dr = objDatabase.ExecuteReader(cmd))
                        {
                            while (dr.Read())
                            {
                                ListaMovimiento.Add(new PagosPorEstadoCuentaListaDto
                                {
                                    PagoId = Convert.ToInt32(dr["PagoId"]),
                                    FechaPago = Funciones.Check.FechaCorta(dr["FechaHoraPago"]),
                                    Monto = Convert.ToDecimal(dr["Monto"]),
                                    EstadoId = Convert.ToInt32(dr["EstadoId"])
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
        public static int Insertar(Pago objEntidad)
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
                        cmd = objDatabase.ObtenerProcedimiento("dbo.sp_Pago_Insertar");
                        cmd.CommandTimeout = BaseDatos.Timeout();
                        objDatabase.AgregarParametro(ref cmd, "@pEstadoCuentaId", SqlDbType.Int, objEntidad.EstadoCuentaId);
                        objDatabase.AgregarParametro(ref cmd, "@pFechaHoraPago", SqlDbType.DateTime, objEntidad.FechaHoraPago);
                        objDatabase.AgregarParametro(ref cmd, "@pMonto", SqlDbType.Decimal, objEntidad.Monto);
                        objDatabase.AgregarParametro(ref cmd, "@pNroVoucher", SqlDbType.VarChar, objEntidad.NroVoucher);
                        objDatabase.AgregarParametro(ref cmd, "@pCuentaBancariaId", SqlDbType.Int, objEntidad.CuentaBancariaId);
                        objDatabase.AgregarParametro(ref cmd, "@pNuevoId", SqlDbType.Int, 0, true);
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
        public static void Actualizar(Pago objEntidad)
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
                        cmd = objDatabase.ObtenerProcedimiento("dbo.sp_Pago_Actualizar");
                        cmd.CommandTimeout = BaseDatos.Timeout();
                        objDatabase.AgregarParametro(ref cmd, "@pPagoId", SqlDbType.Int, objEntidad.PagoId);
                        objDatabase.AgregarParametro(ref cmd, "@pFechaHoraPago", SqlDbType.DateTime, objEntidad.FechaHoraPago);
                        objDatabase.AgregarParametro(ref cmd, "@pMonto", SqlDbType.Decimal, objEntidad.Monto);
                        objDatabase.AgregarParametro(ref cmd, "@pNroVoucher", SqlDbType.VarChar, objEntidad.NroVoucher);
                        objDatabase.AgregarParametro(ref cmd, "@pCuentaBancariaId", SqlDbType.Int, objEntidad.CuentaBancariaId);
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
        public static void CambiarEstado(Pago objEntidad)
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
                        cmd = objDatabase.ObtenerProcedimiento("dbo.sp_Pago_CambiarEstado");
                        cmd.CommandTimeout = BaseDatos.Timeout();
                        objDatabase.AgregarParametro(ref cmd, "@pPagoId", SqlDbType.Int, objEntidad.PagoId);
                        objDatabase.AgregarParametro(ref cmd, "@pEstadoId", SqlDbType.Int, objEntidad.EstadoId);
                        objDatabase.AgregarParametro(ref cmd, "@pUsuarioAprobacionId", SqlDbType.Int, objEntidad.UsuarioAprobacionId);
                        objDatabase.AgregarParametro(ref cmd, "@pObservacion", SqlDbType.VarChar, objEntidad.Observacion);
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
        public static Pago ObtenerPago(int pagoId)
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
                        cmd = objDatabase.ObtenerProcedimiento("dbo.sp_Pago_ListarPorId");
                        cmd.CommandTimeout = BaseDatos.Timeout();
                        objDatabase.AgregarParametro(ref cmd, "@pPagoId", SqlDbType.Int, pagoId);
                        using (var dr = objDatabase.ExecuteReader(cmd))
                        {
                            while (dr.Read())
                            {
                                return new Pago
                                {
                                    PagoId = Convert.ToInt32(dr["PagoId"]),
                                    EstadoCuentaId = Convert.ToInt32(dr["EstadoCuentaId"]),
                                    FechaHoraRegistro = Funciones.Check.Datetime(dr["FechaHoraRegistro"]).Value,
                                    FechaHoraPago = Funciones.Check.Datetime(dr["FechaHoraPago"]).Value,
                                    FechaHoraAprobacion = Funciones.Check.Datetime(dr["FechaHoraAprobacion"]),
                                    Monto = Convert.ToDecimal(dr["Monto"]),
                                    NroVoucher = Convert.ToString(dr["NroVoucher"]),
                                    CuentaBancariaId = Convert.ToInt16(dr["CuentaBancariaId"]),
                                    EstadoId = Convert.ToInt32(dr["EstadoId"]),
                                    UsuarioAprobacionId = Funciones.Check.Int32Null(dr["UsuarioAprobacionId"]),
                                    Observacion = Funciones.Check.Cadena(dr["Observacion"])
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
        public static void Eliminar(int id)
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
                        cmd = objDatabase.ObtenerProcedimiento("dbo.sp_Pago_Eliminar");
                        cmd.CommandTimeout = BaseDatos.Timeout();
                        objDatabase.AgregarParametro(ref cmd, "@pPagoId", SqlDbType.Int, id);
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
        public static List<PagoListaDto> ListarPagos(PagoFiltroDto objFiltro)
        {
            var objDatabase = new BaseDatos(BD.CadenaConexion.BDDEPA);
            List<PagoListaDto> ListaMovimiento = new List<PagoListaDto>();
            SqlCommand cmd;

            try
            {
                using (SqlConnection con = objDatabase.CrearConexion())
                {
                    con.Open();
                    try
                    {
                        cmd = objDatabase.ObtenerProcedimiento("dbo.sp_Pago_Listar");
                        cmd.CommandTimeout = BaseDatos.Timeout();
                        objDatabase.AgregarParametro(ref cmd, "@pCodigoCampania", SqlDbType.VarChar, objFiltro.CodigoCampania);
                        objDatabase.AgregarParametro(ref cmd, "@pFechaHoraPagoIni", SqlDbType.VarChar, objFiltro.FechaPagoIni);
                        objDatabase.AgregarParametro(ref cmd, "@pFechaHoraPagoFin", SqlDbType.VarChar, objFiltro.FechaPagoFin);
                        objDatabase.AgregarParametro(ref cmd, "@pDepa", SqlDbType.VarChar, objFiltro.Depa);
                        objDatabase.AgregarParametro(ref cmd, "@pNroVoucher", SqlDbType.VarChar, objFiltro.NroVoucher);
                        objDatabase.AgregarParametro(ref cmd, "@pEstadoId", SqlDbType.Int, objFiltro.EstadoId);
                        using (var dr = objDatabase.ExecuteReader(cmd))
                        {
                            while (dr.Read())
                            {
                                ListaMovimiento.Add(new PagoListaDto
                                {
                                    PagoId = Convert.ToInt32(dr["PagoId"]),
                                    Anio = Convert.ToInt32(dr["Anio"]),
                                    Monto = Convert.ToDecimal(dr["Monto"]),
                                    EstadoId = Convert.ToInt32(dr["EstadoId"]),
                                    Depa = Convert.ToString(dr["Depa"]),
                                    EstadoCuentaId = Convert.ToInt32(dr["EstadoCuentaId"]),
                                    FechaHoraPago = Funciones.Check.FechaCorta(dr["FechaHoraPago"]),
                                    MesId = Convert.ToInt32(dr["MesId"]),
                                    Campania = Funciones.ObtenerDescripcionCampania(Convert.ToInt32(dr["MesId"]), Convert.ToInt32(dr["Anio"])) ,
                                    Estado = Convert.ToString(dr["Estado"]),
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
                        cmd = objDatabase.ObtenerProcedimiento("dbo.sp_Pago_ObtenerCantidad");
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
