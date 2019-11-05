namespace MiDepa.pe.Helper
{
    /// <summary>
    /// Enumeración con los niveles de gravedad de los mensajes.
    /// </summary>
    public enum EnumTipoNotificacion
    {
        /// <summary>
        /// Mensaje con nivel de gravedad no identificado.
        /// </summary>
        Ninguno = 0,

        /// <summary>
        /// Indica que el mensaje es solo informativo.
        /// </summary>
        Informativo = 1,

        /// <summary>
        /// Indica que se produjo una alerta en el sistema.
        /// </summary>
        Alerta = 2,

        /// <summary>
        /// Indica un error del sistema.
        /// </summary>
        Error = 3,

        /// <summary>
        /// Indica que el proceso se realizo satisfactoriamente.
        /// </summary>
        Satisfactorio = 4,

        /// <summary>
        /// Indica que el proceso no se pudo realizar y presenta aadvertencias.
        /// </summary>
        Advertencia = 5
    }
}
