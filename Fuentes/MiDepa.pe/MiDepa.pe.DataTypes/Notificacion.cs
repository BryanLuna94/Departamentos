namespace MiDepa.pe.DataTypes
{    
    public class Notificacion
    {
        public int NotificacionId { get; set; }
        public int UsuarioRegistroId { get; set; }
        public string Descripcion { get; set; }
        public int EstadoAprobacionId { get; set; }
        public int TipoNotificacionId { get; set; }
    }
}
