using MiDepa.pe.DataTypes.Filtros;
using MiDepa.pe.DataTypes.Listas;
using MiDepa.pe.DataTypes.Request;
using MiDepa.pe.DataTypes.Response;
using MiDepa.pe.Utility;
using System;
using System.Collections.Generic;
using MiDepa.pe.DataAccess;
using MiDepa.pe.DataTypes;
using System.Transactions;
using JBLV.Log;
using System.Linq;

namespace MiDepa.pe.BusinessLayer
{
    public class PerfilLogic
    {
        ///// <summary>Invoca al Procedimiento almacenado que lista Perfiles.</summary>
        ///// <param name="objFiltro">Parámetros para el filtro de Listar las Perfiles</param>
        /////<remarks>
        /////<list type = "bullet">
        /////<item><CreadoPor>Bryan Luna Vasquez.</CreadoPor></item>
        /////<item><FecCrea>19/02/2018</FecCrea></item></list>        
        /////<list type="bullet">
        ///// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        ///// <item><Resp>Responsable.</Resp></item>
        ///// <item><Mot>Motivo.</Mot></item></list></remarks>
        //public static PerfilResponseDto ObtenerIndexPerfiles(PerfilRequestDto request)
        //{
        //    try
        //    {
        //        PerfilResponseDto response;
        //        PerfilFiltroDto objPerfilFiltro;
        //        List<PerfilListaDto> listaPerfiles;

        //        objPerfilFiltro = request.Filtro;
        //        listaPerfiles = CPMaePerfilData.ListaPerfiles(objPerfilFiltro);

        //        response = new PerfilResponseDto
        //        {
        //            ListaPerfiles = listaPerfiles
        //        };

        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.RegistrarLog(NivelLog.Error, ex);
        //        throw;
        //    }
        //}

        ///// <summary>Invoca al Procedimiento almacenado que lista Perfiles.</summary>
        ///// <param name="objFiltro">Parámetros para el filtro de Listar las Perfiles</param>
        /////<remarks>
        /////<list type = "bullet">
        /////<item><CreadoPor>Bryan Luna Vasquez.</CreadoPor></item>
        /////<item><FecCrea>19/02/2018</FecCrea></item></list>        
        /////<list type="bullet">
        ///// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        ///// <item><Resp>Responsable.</Resp></item>
        ///// <item><Mot>Motivo.</Mot></item></list></remarks>
        //public static PerfilResponseDto ListaPerfiles(PerfilRequestDto request)
        //{
        //    try
        //    {
        //        PerfilResponseDto response;
        //        PerfilFiltroDto objPerfilFiltro;
        //        List<PerfilListaDto> listaPerfiles;

        //        objPerfilFiltro = request.Filtro;
        //        listaPerfiles = CPMaePerfilData.ListaPerfiles(objPerfilFiltro);

        //        response = new PerfilResponseDto
        //        {
        //            ListaPerfiles = listaPerfiles
        //        };

        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.RegistrarLog(NivelLog.Error, ex);
        //        throw;
        //    }
        //}

        ///// <summary>Método que registra Perfiles.</summary>
        ///// <param name="objPersona">Entidad con los datos de la entidad.</param>
        ///// <returns>.</returns>
        ///// <remarks><list type="bullet">
        ///// <item><CreadoPor>Bryan Luna Vasquez</CreadoPor></item>
        ///// <item><FecCrea>13/02/2018.</FecCrea></item></list>
        ///// <list type="bullet">
        ///// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        ///// <item><Resp>Responsable.</Resp></item>
        ///// <item><Mot>Motivo.</Mot></item></list></remarks>
        //public static PerfilResponseDto ObtenerEditorPerfil(short IdPerfil = 0)
        //{
        //    try
        //    {
        //        PerfilResponseDto response;
        //        CPMaePerfil objPerfil;

        //        objPerfil = CPMaePerfilData.ObtenerPerfil(IdPerfil);

        //        response = new PerfilResponseDto
        //        {
        //            Perfil = objPerfil
        //        };

        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.RegistrarLog(NivelLog.Error, ex);
        //        throw;
        //    }
        //}

        ///// <summary>Método que registra Perfiles.</summary>
        ///// <param name="objPersona">Entidad con los datos de la entidad.</param>
        ///// <returns>.</returns>
        ///// <remarks><list type="bullet">
        ///// <item><CreadoPor>Bryan Luna Vasquez</CreadoPor></item>
        ///// <item><FecCrea>13/02/2018.</FecCrea></item></list>
        ///// <list type="bullet">
        ///// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        ///// <item><Resp>Responsable.</Resp></item>
        ///// <item><Mot>Motivo.</Mot></item></list></remarks>
        //public static int RegistrarPerfil(PerfilRequestDto request)
        //{
        //    CPMaePerfil objPerfil;
        //    int resultado;

        //    objPerfil = request.Perfil;

        //    try
        //    {
        //        if (CPMaePerfilData.ValidaExiste(objPerfil))
        //        {
        //            BusinessException.Generar(Constantes.Mensajes.PERFIL_YA_EXISTE);
        //        }

        //        using (TransactionScope tran = new TransactionScope())
        //        {
        //            resultado = CPMaePerfilData.RegistrarPerfil(objPerfil);
        //            tran.Complete();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.RegistrarLog(NivelLog.Error, ex);
        //        throw;
        //    }
        //    return resultado;
        //}

        ///// <summary>Método que Actualiza maestro de Perfil.</summary>
        ///// <param name="objPersona">Entidad con los datos de la entidad.</param>
        ///// <returns>.</returns>
        ///// <remarks><list type="bullet">
        ///// <item><CreadoPor>Bryan Luna Vasquez</CreadoPor></item>
        ///// <item><FecCrea>13/02/2018.</FecCrea></item></list>
        ///// <list type="bullet">
        ///// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        ///// <item><Resp>Responsable.</Resp></item>
        ///// <item><Mot>Motivo.</Mot></item></list></remarks>
        //public static int ActualizarPerfil(PerfilRequestDto request)
        //{
        //    CPMaePerfil objPerfil;
        //    CPMaePerfil objPerfilAnterior;
        //    int resultado;

        //    objPerfil = request.Perfil;
        //    objPerfilAnterior = CPMaePerfilData.ObtenerPerfil(objPerfil.siCodPer);

        //    try
        //    {
        //        if (objPerfil.vNombre != objPerfilAnterior.vNombre)
        //        {
        //            if (CPMaePerfilData.ValidaExiste(objPerfil))
        //            {
        //                BusinessException.Generar(Constantes.Mensajes.PERFIL_YA_EXISTE);
        //            }
        //        }

        //        using (TransactionScope tran = new TransactionScope())
        //        {
        //            resultado = CPMaePerfilData.ActualizarPerfil(objPerfil);
        //            tran.Complete();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.RegistrarLog(NivelLog.Error, ex);
        //        throw;
        //    }
        //    return resultado;
        //}

        ///// <summary>Método que elimina Perfiles.</summary>
        ///// <param name="objPersona">Entidad con los datos de la Perfil.</param>
        ///// <returns>Respuesta entero.</returns>
        ///// <remarks><list type="bullet">
        ///// <item><CreadoPor>Bryan Luna Vasquez</CreadoPor></item>
        ///// <item><FecCrea>13/02/2018.</FecCrea></item></list>
        ///// <list type="bullet">
        ///// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        ///// <item><Resp>Responsable.</Resp></item>
        ///// <item><Mot>Motivo.</Mot></item></list></remarks>
        //public static int EliminarPerfil(PerfilRequestDto request)
        //{
        //    CPMaePerfil objPerfil;
        //    int resultado;

        //    objPerfil = request.Perfil;

        //    try
        //    {
        //        if (CPMaePerfilData.ValidaTieneUsuarios(objPerfil))
        //        {
        //            BusinessException.Generar(Constantes.Mensajes.PERFIL_TIENE_USUARIO);
        //        }

        //        using (TransactionScope tran = new TransactionScope())
        //        {
        //            resultado = CPMaePerfilData.EliminarPerfil(objPerfil);
        //            tran.Complete();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.RegistrarLog(NivelLog.Error, ex);
        //        throw;
        //    }
        //    return resultado;
        //}

        /// <summary>Método que devuelve el response para la pantalla index de ruta</summary>
        /// <param name="request">Objeto request</param>
        /// <returns>Response de index para ruta</returns>
        /// <remarks><list type="bullet">
        /// <item><CreadoPor>Wilmer Gómez Prado</CreadoPor></item>
        /// <item><FecCrea>02/02/2018</FecCrea></item>
        /// </list>
        /// <list type="bullet" >
        /// <item><FecActu>XXXX</FecActu></item>
        /// <item><Resp>XXXX</Resp></item>
        /// <item><Mot>XXXX</Mot></item></list></remarks>
        public static PerfilResponseDto ListaOpcionesPorPerfil(short idPerfil)
        {
            try
            {
                PerfilResponseDto response;
                List<OpcionListaDto> listaOpcionesPorModulo;
                List<OpcionListaDto> listaOpcionesPorPerfil;
                List<OpcionesPorPerfilListaDto> listaOpciones;
                int moduloLiqPeajes;
                bool existe;

                moduloLiqPeajes = Convert.ToInt32(Constantes.DatosAplicacion.MODULO_COMERCIAL);
                listaOpcionesPorModulo = OpcionData.ListaOpcionesPorModulo(moduloLiqPeajes);
                listaOpcionesPorPerfil = OpcionData.ListaOpcionesPorPerfil(idPerfil);

                listaOpciones = new List<OpcionesPorPerfilListaDto>();
                foreach (var item in listaOpcionesPorModulo)
                {
                    existe = listaOpcionesPorPerfil.Exists(x => x.Codigo == item.Codigo);
                    listaOpciones.Add(new OpcionesPorPerfilListaDto
                    {
                        Nombre = item.Nombre,
                        Existe = existe,
                        CodigoOpcion = item.Codigo,
                        CodigoPadre = item.CodigoPadre
                    });
                }

                response = new PerfilResponseDto
                {
                    ListaOpciones = listaOpciones
                };

                return response;
            }
            catch (Exception ex)
            {
                Log.RegistrarLog(NivelLog.Error, ex);
                throw;
            }
        }

        /// <summary>Método que devuelve el response para la pantalla index de ruta</summary>
        /// <param name="request">Objeto request</param>
        /// <returns>Response de index para ruta</returns>
        /// <remarks><list type="bullet">
        /// <item><CreadoPor>Wilmer Gómez Prado</CreadoPor></item>
        /// <item><FecCrea>02/02/2018</FecCrea></item>
        /// </list>
        /// <list type="bullet" >
        /// <item><FecActu>XXXX</FecActu></item>
        /// <item><Resp>XXXX</Resp></item>
        /// <item><Mot>XXXX</Mot></item></list></remarks>
        public static PerfilResponseDto ListaOpcionesPorPerfil_Menu(short idPerfil)
        {
            try
            {
                PerfilResponseDto response;
                List<OpcionListaDto> listaOpcionesPorPerfil;
                int moduloLiqPeajes;

                moduloLiqPeajes = Convert.ToInt32(Constantes.DatosAplicacion.MODULO_COMERCIAL);
                listaOpcionesPorPerfil = OpcionData.ListaOpcionesPorPerfil(idPerfil).Where(x => x.TipoOpcion == 1).ToList();

                response = new PerfilResponseDto
                {
                    ListaOpcionesMenu = listaOpcionesPorPerfil
                };

                return response;
            }
            catch (Exception ex)
            {
                Log.RegistrarLog(NivelLog.Error, ex);
                throw;
            }
        }

        ///// <summary>Método que devuelve el response para la pantalla index de ruta</summary>
        ///// <param name="request">Objeto request</param>
        ///// <returns>Response de index para ruta</returns>
        ///// <remarks><list type="bullet">
        ///// <item><CreadoPor>Wilmer Gómez Prado</CreadoPor></item>
        ///// <item><FecCrea>02/02/2018</FecCrea></item>
        ///// </list>
        ///// <list type="bullet" >
        ///// <item><FecActu>XXXX</FecActu></item>
        ///// <item><Resp>XXXX</Resp></item>
        ///// <item><Mot>XXXX</Mot></item></list></remarks>
        //public static int GrabarOpcionesPorPerfil(PerfilRequestDto request)
        //{
        //    try
        //    {
        //        List<OpcionesPorPerfilListaDto> listaOpciones;
        //        CPTabPerfilOpcion objPerfilOpcion;
        //        short idPerfil;

        //        listaOpciones = request.ListaOpciones;
        //        idPerfil = request.IdPerfil;

        //        foreach (var item in listaOpciones)
        //        {
        //            objPerfilOpcion = new CPTabPerfilOpcion
        //            {
        //                iCodOpc = item.CodigoOpcion,
        //                siCodPer = idPerfil
        //            };

        //            if (item.Existe)
        //            {
        //                CPTabPerfilOpcionData.InsertarSiExiste(objPerfilOpcion);
        //            }
        //            else
        //            {
        //                CPTabPerfilOpcionData.Eliminar(objPerfilOpcion);
        //            }
        //        }

        //        return idPerfil;
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.RegistrarLog(NivelLog.Error, ex);
        //        throw;
        //    }
        //}
    }
}
