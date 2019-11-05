using MiDepa.pe.BusinessLayer;
using MiDepa.pe.DataTypes.Request;
using MiDepa.pe.DataTypes.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MiDepa.pe.Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioMiDepa" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioMiDepa.svc o ServicioMiDepa.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioMiDepa : IServicioMiDepa
    {
        #region USUARIO

        /// <summary>Invoca al Procedimiento almacenado que lista Usuarios.</summary>
        /// <param name="objFiltro">Parámetros para el filtro de Listar las Usuarios</param>
        ///<remarks>
        ///<list type = "bullet">
        ///<item><CreadoPor>Bryan Luna Vasquez.</CreadoPor></item>
        ///<item><FecCrea>19/02/2018</FecCrea></item></list>        
        ///<list type="bullet">
        /// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        /// <item><Resp>Responsable.</Resp></item>
        /// <item><Mot>Motivo.</Mot></item></list></remarks>
        public LoginResponseDto Login(LoginRequestDto request)
        {
            try
            {
                return UsuarioLogic.Login(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>Invoca al Procedimiento almacenado que lista Usuarios.</summary>
        /// <param name="objFiltro">Parámetros para el filtro de Listar las Usuarios</param>
        ///<remarks>
        ///<list type = "bullet">
        ///<item><CreadoPor>Bryan Luna Vasquez.</CreadoPor></item>
        ///<item><FecCrea>19/02/2018</FecCrea></item></list>        
        ///<list type="bullet">
        /// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        /// <item><Resp>Responsable.</Resp></item>
        /// <item><Mot>Motivo.</Mot></item></list></remarks>
        public DatosEstaticosResponseDto ListarDatosEstaticos(int usuarioId)
        {
            try
            {
                return UsuarioLogic.ListarDatosEstaticos(usuarioId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>Invoca al Procedimiento almacenado que lista Usuarios.</summary>
        /// <param name="objFiltro">Parámetros para el filtro de Listar las Usuarios</param>
        ///<remarks>
        ///<list type = "bullet">
        ///<item><CreadoPor>Bryan Luna Vasquez.</CreadoPor></item>
        ///<item><FecCrea>19/02/2018</FecCrea></item></list>        
        ///<list type="bullet">
        /// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        /// <item><Resp>Responsable.</Resp></item>
        /// <item><Mot>Motivo.</Mot></item></list></remarks>
        public HomeResponseDto ListaDatosHome(int depaId)
        {
            try
            {
                return HomeLogic.ListaDatosHome(depaId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region ESTADO CUENTA

        /// <summary>Invoca al Procedimiento almacenado que lista Usuarios.</summary>
        /// <param name="objFiltro">Parámetros para el filtro de Listar las Usuarios</param>
        ///<remarks>
        ///<list type = "bullet">
        ///<item><CreadoPor>Bryan Luna Vasquez.</CreadoPor></item>
        ///<item><FecCrea>19/02/2018</FecCrea></item></list>        
        ///<list type="bullet">
        /// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        /// <item><Resp>Responsable.</Resp></item>
        /// <item><Mot>Motivo.</Mot></item></list></remarks>
        public EstadoCuentaResponseDto ObtenerIndexEstadoCuenta()
        {
            try
            {
                return EstadoCuentaLogic.ObtenerIndexEstadoCuenta();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>Invoca al Procedimiento almacenado que lista Usuarios.</summary>
        /// <param name="objFiltro">Parámetros para el filtro de Listar las Usuarios</param>
        ///<remarks>
        ///<list type = "bullet">
        ///<item><CreadoPor>Bryan Luna Vasquez.</CreadoPor></item>
        ///<item><FecCrea>19/02/2018</FecCrea></item></list>        
        ///<list type="bullet">
        /// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        /// <item><Resp>Responsable.</Resp></item>
        /// <item><Mot>Motivo.</Mot></item></list></remarks>
        public EstadoCuentaResponseDto ListarDatosEstadoCuentaPorCampania(int depaId, string codigoCampania)
        {
            try
            {
                return EstadoCuentaLogic.ListarDatosEstadoCuentaPorCampania(depaId, codigoCampania);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region PAGO

        /// <summary>Invoca al Procedimiento almacenado que lista Usuarios.</summary>
        /// <param name="objFiltro">Parámetros para el filtro de Listar las Usuarios</param>
        ///<remarks>
        ///<list type = "bullet">
        ///<item><CreadoPor>Bryan Luna Vasquez.</CreadoPor></item>
        ///<item><FecCrea>19/02/2018</FecCrea></item></list>        
        ///<list type="bullet">
        /// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        /// <item><Resp>Responsable.</Resp></item>
        /// <item><Mot>Motivo.</Mot></item></list></remarks>
        public PagoResponseDto ObtenerEditorPago(int edificioId, int pagoId)
        {
            try
            {
                return PagoLogic.ObtenerEditorPago(edificioId, pagoId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>Invoca al Procedimiento almacenado que lista Usuarios.</summary>
        /// <param name="objFiltro">Parámetros para el filtro de Listar las Usuarios</param>
        ///<remarks>
        ///<list type = "bullet">
        ///<item><CreadoPor>Bryan Luna Vasquez.</CreadoPor></item>
        ///<item><FecCrea>19/02/2018</FecCrea></item></list>        
        ///<list type="bullet">
        /// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        /// <item><Resp>Responsable.</Resp></item>
        /// <item><Mot>Motivo.</Mot></item></list></remarks>
        public void InsertarPago(PagoRequestDto request)
        {
            try
            {
                PagoLogic.RegistrarPago(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>Invoca al Procedimiento almacenado que lista Usuarios.</summary>
        /// <param name="objFiltro">Parámetros para el filtro de Listar las Usuarios</param>
        ///<remarks>
        ///<list type = "bullet">
        ///<item><CreadoPor>Bryan Luna Vasquez.</CreadoPor></item>
        ///<item><FecCrea>19/02/2018</FecCrea></item></list>        
        ///<list type="bullet">
        /// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        /// <item><Resp>Responsable.</Resp></item>
        /// <item><Mot>Motivo.</Mot></item></list></remarks>
        public void ActualizarPago(PagoRequestDto request)
        {
            try
            {
                PagoLogic.ActualizarPago(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>Invoca al Procedimiento almacenado que lista Usuarios.</summary>
        /// <param name="objFiltro">Parámetros para el filtro de Listar las Usuarios</param>
        ///<remarks>
        ///<list type = "bullet">
        ///<item><CreadoPor>Bryan Luna Vasquez.</CreadoPor></item>
        ///<item><FecCrea>19/02/2018</FecCrea></item></list>        
        ///<list type="bullet">
        /// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        /// <item><Resp>Responsable.</Resp></item>
        /// <item><Mot>Motivo.</Mot></item></list></remarks>
        public void EliminarPago(int id)
        {
            try
            {
                PagoLogic.EliminarPago(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>Invoca al Procedimiento almacenado que lista Usuarios.</summary>
        /// <param name="objFiltro">Parámetros para el filtro de Listar las Usuarios</param>
        ///<remarks>
        ///<list type = "bullet">
        ///<item><CreadoPor>Bryan Luna Vasquez.</CreadoPor></item>
        ///<item><FecCrea>19/02/2018</FecCrea></item></list>        
        ///<list type="bullet">
        /// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        /// <item><Resp>Responsable.</Resp></item>
        /// <item><Mot>Motivo.</Mot></item></list></remarks>
        public void AprobarPago(PagoRequestDto request)
        {
            try
            {
                PagoLogic.AprobarPago(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>Invoca al Procedimiento almacenado que lista Usuarios.</summary>
        /// <param name="objFiltro">Parámetros para el filtro de Listar las Usuarios</param>
        ///<remarks>
        ///<list type = "bullet">
        ///<item><CreadoPor>Bryan Luna Vasquez.</CreadoPor></item>
        ///<item><FecCrea>19/02/2018</FecCrea></item></list>        
        ///<list type="bullet">
        /// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        /// <item><Resp>Responsable.</Resp></item>
        /// <item><Mot>Motivo.</Mot></item></list></remarks>
        public void RechazarPago(PagoRequestDto request)
        {
            try
            {
                PagoLogic.RechazarPago(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>Invoca al Procedimiento almacenado que lista Usuarios.</summary>
        /// <param name="objFiltro">Parámetros para el filtro de Listar las Usuarios</param>
        ///<remarks>
        ///<list type = "bullet">
        ///<item><CreadoPor>Bryan Luna Vasquez.</CreadoPor></item>
        ///<item><FecCrea>19/02/2018</FecCrea></item></list>        
        ///<list type="bullet">
        /// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        /// <item><Resp>Responsable.</Resp></item>
        /// <item><Mot>Motivo.</Mot></item></list></remarks>
        public PagoResponseDto ListarPagos(PagoRequestDto request)
        {
            try
            {
                return PagoLogic.ListarPagos(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region ARCHIVO

        /// <summary>Método que registra Movimientos.</summary>
        /// <param name="objPersona">Entidad con los datos de la entidad.</param>
        /// <returns>.</returns>
        /// <remarks><list type="bullet">
        /// <item><CreadoPor>Bryan Luna Vasquez</CreadoPor></item>
        /// <item><FecCrea>13/02/2018.</FecCrea></item></list>
        /// <list type="bullet">
        /// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        /// <item><Resp>Responsable.</Resp></item>
        /// <item><Mot>Motivo.</Mot></item></list></remarks>
        public ArchivoResponseDto ListadoArchivos(string tabla, int id)
        {
            try
            {
                return ArchivoLogic.ListadoArchivos(tabla, id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>Método que registra Movimientos.</summary>
        /// <param name="objPersona">Entidad con los datos de la entidad.</param>
        /// <returns>.</returns>
        /// <remarks><list type="bullet">
        /// <item><CreadoPor>Bryan Luna Vasquez</CreadoPor></item>
        /// <item><FecCrea>13/02/2018.</FecCrea></item></list>
        /// <list type="bullet">
        /// <item><FecActu>XX/XX/XXXX.</FecActu></item>
        /// <item><Resp>Responsable.</Resp></item>
        /// <item><Mot>Motivo.</Mot></item></list></remarks>
        public ArchivoResponseDto ObtenerArchivoPorId(string id)
        {
            try
            {
                return ArchivoLogic.ObtenerArchivoPorId(id);
            }
            catch (Exception)
            {
                throw;
            }
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
        public void GuardarArchivo(ArchivoRequestDto request)
        {
            try
            {
                ArchivoLogic.GuardarArchivo(request);
            }
            catch (Exception)
            {
                throw;
            }
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
        public int EliminarArchivo(string id)
        {
            try
            {
                return ArchivoLogic.EliminarArchivo(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region PERFIL

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
        //public PerfilResponseDto ObtenerIndexPerfiles(PerfilRequestDto request)
        //{
        //    try
        //    {
        //        return PerfilLogic.ObtenerIndexPerfiles(request);
        //    }
        //    catch (Exception)
        //    {
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
        //public PerfilResponseDto ListaPerfiles(PerfilRequestDto request)
        //{
        //    try
        //    {
        //        return PerfilLogic.ListaPerfiles(request);
        //    }
        //    catch (Exception)
        //    {
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
        //public PerfilResponseDto ObtenerEditorPerfil(short IdPerfil = 0)
        //{
        //    try
        //    {
        //        return PerfilLogic.ObtenerEditorPerfil(IdPerfil);
        //    }
        //    catch (Exception)
        //    {
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
        //public int RegistrarPerfil(PerfilRequestDto request)
        //{
        //    try
        //    {
        //        return PerfilLogic.RegistrarPerfil(request);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
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
        //public int ActualizarPerfil(PerfilRequestDto request)
        //{
        //    try
        //    {
        //        return PerfilLogic.ActualizarPerfil(request);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
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
        //public int EliminarPerfil(PerfilRequestDto request)
        //{
        //    try
        //    {
        //        return PerfilLogic.EliminarPerfil(request);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
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
        public PerfilResponseDto ListaOpcionesPorPerfil(short idPerfil)
        {
            try
            {
                return PerfilLogic.ListaOpcionesPorPerfil(idPerfil);
            }
            catch (Exception)
            {
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
        public PerfilResponseDto ListaOpcionesPorPerfil_Menu(short idPerfil)
        {
            try
            {
                return PerfilLogic.ListaOpcionesPorPerfil_Menu(idPerfil);
            }
            catch (Exception)
            {
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
        //public int GrabarOpcionesPorPerfil(PerfilRequestDto request)
        //{
        //    try
        //    {
        //        return PerfilLogic.GrabarOpcionesPorPerfil(request);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        #endregion

        #region CAMPANIA

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
        public CampaniaResponseDto ListarCampanias(CampaniaRequestDto request)
        {
            try
            {
                return CampaniaLogic.ListarCampanias(request);
            }
            catch (Exception)
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
        public CampaniaResponseDto ObtenerEditorCampania(int edificioId, int campaniaId)
        {
            try
            {
                return CampaniaLogic.ObtenerEditorCampania(edificioId, campaniaId);
            }
            catch (Exception)
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
        public void InsertarCampania(CampaniaRequestDto request)
        {
            try
            {
                CampaniaLogic.InsertarCampania(request);
            }
            catch (Exception)
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
        public void ActualizarCampania(CampaniaRequestDto request)
        {
            try
            {
                CampaniaLogic.ActualizarCampania(request);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

    }
}
