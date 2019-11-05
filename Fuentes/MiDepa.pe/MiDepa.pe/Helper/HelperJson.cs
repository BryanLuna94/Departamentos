namespace MiDepa.pe.Helper
{
    /// <summary>
    /// 
    /// </summary>
    internal static class HelperJson
    {


        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipoNotificacion"></param>
        /// <returns></returns>
        internal static object ConstruirJson(EnumTipoNotificacion tipoNotificacion)
        {
            return new
            {
                tipoNotificacion = tipoNotificacion.ToString(),
                string.Empty
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipoNotificacion"></param>
        /// <param name="mensaje"></param>
        /// <returns></returns>
        internal static object ConstruirJson(EnumTipoNotificacion tipoNotificacion, string mensaje)
        {
            return new
            {
                tipoNotificacion = tipoNotificacion.ToString(),
                mensaje
            };
        }        
    }
}