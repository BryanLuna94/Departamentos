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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioMiDepa" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioMiDepa
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
        [OperationContract, FaultContract(typeof(ServiceErrorResponseType))]
        [WebInvoke(Method = "POST",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Bare,
                UriTemplate = "Login")]
        LoginResponseDto Login(LoginRequestDto request);

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
        [OperationContract, FaultContract(typeof(ServiceErrorResponseType))]
        [WebInvoke(Method = "POST",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Bare,
                UriTemplate = "ListarDatosEstaticos")]
        DatosEstaticosResponseDto ListarDatosEstaticos(int usuarioId);

        #endregion

        #region HOME

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
        [OperationContract, FaultContract(typeof(ServiceErrorResponseType))]
        [WebInvoke(Method = "POST",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Bare,
                UriTemplate = "ListaDatosHome")]
        HomeResponseDto ListaDatosHome(int depaId);

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
        [OperationContract, FaultContract(typeof(ServiceErrorResponseType))]
        [WebInvoke(Method = "POST",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Bare,
                UriTemplate = "ObtenerIndexEstadoCuenta")]
        EstadoCuentaResponseDto ObtenerIndexEstadoCuenta();

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
        [OperationContract, FaultContract(typeof(ServiceErrorResponseType))]
        [WebInvoke(Method = "POST",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Bare,
                UriTemplate = "ListarDatosEstadoCuentaPorCampania")]
        EstadoCuentaResponseDto ListarDatosEstadoCuentaPorCampania(int depaId, string codigoCampania);

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
        [OperationContract, FaultContract(typeof(ServiceErrorResponseType))]
        [WebInvoke(Method = "POST",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Bare,
                UriTemplate = "ObtenerEditorPago")]
        PagoResponseDto ObtenerEditorPago(int edificioId, int pagoId);

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
        [OperationContract, FaultContract(typeof(ServiceErrorResponseType))]
        [WebInvoke(Method = "POST",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Bare,
                UriTemplate = "InsertarPago")]
        void InsertarPago(PagoRequestDto request);

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
        [OperationContract, FaultContract(typeof(ServiceErrorResponseType))]
        [WebInvoke(Method = "POST",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Bare,
                UriTemplate = "ActualizarPago")]
        void ActualizarPago(PagoRequestDto request);

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
        [OperationContract, FaultContract(typeof(ServiceErrorResponseType))]
        [WebInvoke(Method = "POST",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Bare,
                UriTemplate = "EliminarPago")]
        void EliminarPago(int id);

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
        [OperationContract, FaultContract(typeof(ServiceErrorResponseType))]
        [WebInvoke(Method = "POST",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Bare,
                UriTemplate = "AprobarPago")]
        void AprobarPago(PagoRequestDto request);

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
        [OperationContract, FaultContract(typeof(ServiceErrorResponseType))]
        [WebInvoke(Method = "POST",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Bare,
                UriTemplate = "RechazarPago")]
        void RechazarPago(PagoRequestDto request);

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
        [OperationContract, FaultContract(typeof(ServiceErrorResponseType))]
        [WebInvoke(Method = "POST",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Bare,
                UriTemplate = "ListarPagos")]
        PagoResponseDto ListarPagos(PagoRequestDto request);

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
        [OperationContract, FaultContract(typeof(ServiceErrorResponseType))]
        [WebInvoke(Method = "POST",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Bare,
                UriTemplate = "ListadoArchivos")]
        ArchivoResponseDto ListadoArchivos(string tabla, int id);

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
        [OperationContract, FaultContract(typeof(ServiceErrorResponseType))]
        [WebInvoke(Method = "POST",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Bare,
                UriTemplate = "ObtenerArchivoPorId")]
        ArchivoResponseDto ObtenerArchivoPorId(string id);

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
        [OperationContract, FaultContract(typeof(ServiceErrorResponseType))]
        [WebInvoke(Method = "POST",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Bare,
                UriTemplate = "ObtenerArchivoPorId")]
        void GuardarArchivo(ArchivoRequestDto request);

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
        [OperationContract, FaultContract(typeof(ServiceErrorResponseType))]
        [WebInvoke(Method = "POST",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Bare,
                UriTemplate = "EliminarArchivo")]
        int EliminarArchivo(string id);

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
        //[OperationContract, FaultContract(typeof(ServiceErrorResponseType))]
        //[WebInvoke(Method = "POST",
        //        ResponseFormat = WebMessageFormat.Json,
        //        RequestFormat = WebMessageFormat.Json,
        //        BodyStyle = WebMessageBodyStyle.Bare,
        //        UriTemplate = "ObtenerIndexPerfiles")]
        //PerfilResponseDto ObtenerIndexPerfiles(PerfilRequestDto request);

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
        //[OperationContract, FaultContract(typeof(ServiceErrorResponseType))]
        //[WebInvoke(Method = "POST",
        //        ResponseFormat = WebMessageFormat.Json,
        //        RequestFormat = WebMessageFormat.Json,
        //        BodyStyle = WebMessageBodyStyle.Bare,
        //        UriTemplate = "ListaPerfiles")]
        //PerfilResponseDto ListaPerfiles(PerfilRequestDto request);

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
        //[OperationContract, FaultContract(typeof(ServiceErrorResponseType))]
        //[WebInvoke(Method = "POST",
        //        ResponseFormat = WebMessageFormat.Json,
        //        RequestFormat = WebMessageFormat.Json,
        //        BodyStyle = WebMessageBodyStyle.Bare,
        //        UriTemplate = "ObtenerEditorPerfil")]
        //PerfilResponseDto ObtenerEditorPerfil(short IdPerfil = 0);

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
        //[OperationContract, FaultContract(typeof(ServiceErrorResponseType))]
        //[WebInvoke(Method = "POST",
        //        ResponseFormat = WebMessageFormat.Json,
        //        RequestFormat = WebMessageFormat.Json,
        //        BodyStyle = WebMessageBodyStyle.Bare,
        //        UriTemplate = "RegistrarPerfil")]
        //int RegistrarPerfil(PerfilRequestDto request);

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
        //[OperationContract, FaultContract(typeof(ServiceErrorResponseType))]
        //[WebInvoke(Method = "POST",
        //        ResponseFormat = WebMessageFormat.Json,
        //        RequestFormat = WebMessageFormat.Json,
        //        BodyStyle = WebMessageBodyStyle.Bare,
        //        UriTemplate = "ActualizarPerfil")]
        //int ActualizarPerfil(PerfilRequestDto request);

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
        //[OperationContract, FaultContract(typeof(ServiceErrorResponseType))]
        //[WebInvoke(Method = "POST",
        //        ResponseFormat = WebMessageFormat.Json,
        //        RequestFormat = WebMessageFormat.Json,
        //        BodyStyle = WebMessageBodyStyle.Bare,
        //        UriTemplate = "EliminarPerfil")]
        //int EliminarPerfil(PerfilRequestDto request);

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
        [OperationContract, FaultContract(typeof(ServiceErrorResponseType))]
        [WebInvoke(Method = "POST",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Bare,
                UriTemplate = "ListaOpcionesPorPerfil")]
        PerfilResponseDto ListaOpcionesPorPerfil(short idPerfil);

        /// <summary>Método que devuelve el response para la pantalla index de ruta</summary>
        /// <param name="request">Objeto request</param>
        /// <returns>Response de index para ruta</returns>
        /// <remarks><list type="bullet">
        /// <item><CreadoPor>Wilmer Gómez Prado</CreadoPor></item>
        /// <item><FecCrea>02/02/2018</FecCrea></item>w
        /// </list>
        /// <list type="bullet" >
        /// <item><FecActu>XXXX</FecActu></item>
        /// <item><Resp>XXXX</Resp></item>
        /// <item><Mot>XXXX</Mot></item></list></remarks>
        [OperationContract, FaultContract(typeof(ServiceErrorResponseType))]
        [WebInvoke(Method = "POST",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Bare,
                UriTemplate = "ListaOpcionesPorPerfil_Menu")]
        PerfilResponseDto ListaOpcionesPorPerfil_Menu(short idPerfil);

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
        //[OperationContract, FaultContract(typeof(ServiceErrorResponseType))]
        //[WebInvoke(Method = "POST",
        //        ResponseFormat = WebMessageFormat.Json,
        //        RequestFormat = WebMessageFormat.Json,
        //        BodyStyle = WebMessageBodyStyle.Bare,
        //        UriTemplate = "GrabarOpcionesPorPerfil")]
        //int GrabarOpcionesPorPerfil(PerfilRequestDto request);

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
        [OperationContract, FaultContract(typeof(ServiceErrorResponseType))]
        [WebInvoke(Method = "POST",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Bare,
                UriTemplate = "ListarCampanias")]
        CampaniaResponseDto ListarCampanias(CampaniaRequestDto request);


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
        [OperationContract, FaultContract(typeof(ServiceErrorResponseType))]
        [WebInvoke(Method = "POST",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Bare,
                UriTemplate = "ObtenerEditorCampania")]
        CampaniaResponseDto ObtenerEditorCampania(int edificioId, int campaniaId);

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
        [OperationContract, FaultContract(typeof(ServiceErrorResponseType))]
        [WebInvoke(Method = "POST",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Bare,
                UriTemplate = "InsertarCampania")]
        void InsertarCampania(CampaniaRequestDto request);

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
        [OperationContract, FaultContract(typeof(ServiceErrorResponseType))]
        [WebInvoke(Method = "POST",
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Bare,
                UriTemplate = "ActualizarCampania")]
        void ActualizarCampania(CampaniaRequestDto request);

        #endregion

    }
}
