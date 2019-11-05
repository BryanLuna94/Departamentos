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

namespace MiDepa.pe.BusinessLayer
{
    public class UsuarioLogic
    {
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
        public static LoginResponseDto Login(LoginRequestDto request)
        {
            try
            {
                LoginResponseDto response;
                LoginListaDto objLogin;
                ArchivoListaDto objArchivo;
                List<OpcionListaDto> listaOpcionesPerfil;
                Campania objCampaniaActual;
                DatosUsuarioListaDto objDatosUsuario;
                string usuario;
                string clave;
                string campania;

                usuario = request.Usuario;
                clave = request.Clave;
                objLogin = UsuarioData.Login(usuario);

                if (objLogin == null)
                {
                    BusinessException.Generar(Constantes.Mensajes.USUARIO_NO_EXISTE);
                }

                if (objLogin.Clave != Funciones.Encriptar(clave.ToUpper()))
                {
                    BusinessException.Generar(Constantes.Mensajes.CLAVE_USUARIO_INCORRECTA);
                }

                objDatosUsuario = UsuarioData.ListarDatosUsuario(objLogin.Codigo);

                objDatosUsuario.Codigo = objLogin.Codigo;
                objDatosUsuario.Clave = objLogin.Clave;
                objDatosUsuario.CodigoEdificio = objLogin.CodigoEdificio;
                objDatosUsuario.CodigoPerfil = objLogin.CodigoPerfil;
                objDatosUsuario.CodigoPersona = objLogin.CodigoPersona;
                objDatosUsuario.Nombre = objLogin.Nombre;
                objDatosUsuario.Usuario = objLogin.Usuario;
                objCampaniaActual = CampaniaData.ObtenerCampaniaActual((int)objDatosUsuario.CodigoEdificio);
                campania = objCampaniaActual.Codigo;
                objDatosUsuario.CampaniaActual = campania;
                listaOpcionesPerfil = OpcionData.ListaOpcionesPorPerfil(objLogin.CodigoPerfil);

                response = new LoginResponseDto
                {
                    ListaOpcionesPorPerfil = listaOpcionesPerfil,
                    Usuario = objDatosUsuario,
                    //FotoUsuario = objArchivo,
                };

                return response;
            }
            catch (Exception ex)
            {
                Log.RegistrarLog(NivelLog.Error, ex);
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
        public static DatosEstaticosResponseDto ListarDatosEstaticos(int idUsuario)
        {
            try
            {
                DatosEstaticosResponseDto response;
                int idTablaEvento;
                int idTablaNotificacion;
                int idTablaPago;
                int idTablaPaquetes;
                bool pagosVisto;
                bool notificacionesVisto;
                bool paquetesVisto;
                bool eventosVisto;
                DatosUsuarioListaDto objDatosUsuario;

                idTablaEvento = Convert.ToInt32(Constantes.Tablas.EVENTO);
                idTablaNotificacion = Convert.ToInt32(Constantes.Tablas.NOTIFICACION);
                idTablaPago = Convert.ToInt32(Constantes.Tablas.PAGO);
                idTablaPaquetes = Convert.ToInt32(Constantes.Tablas.PAQUETE);

                pagosVisto = VistoData.ConsultarVisto(idTablaPago, idUsuario);
                notificacionesVisto = VistoData.ConsultarVisto(idTablaNotificacion, idUsuario);
                eventosVisto = VistoData.ConsultarVisto(idTablaEvento, idUsuario);
                paquetesVisto = VistoData.ConsultarVisto(idTablaPaquetes, idUsuario);

                objDatosUsuario = UsuarioData.ListarDatosUsuario(idUsuario);

                response = new DatosEstaticosResponseDto
                {
                    VistoEventos = eventosVisto,
                    VistoNotificaciones = notificacionesVisto,
                    VistoPagos = pagosVisto,
                    VistoPaquetes = paquetesVisto
                };

                return response;
            }
            catch (Exception ex)
            {
                Log.RegistrarLog(NivelLog.Error, ex);
                throw;
            }
        }
    }
}
