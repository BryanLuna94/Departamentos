namespace MiDepa.pe.DataTypes
{
    using System;
    
    public class Reserva
    {
        public int ReservaId { get; set; }
        public int DepaId { get; set; }
        public int EspacioComunId { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public int EstadoAprobacionId { get; set; }
        public string Observacion { get; set; }
        public int UsuarioRegistroId { get; set; }
        public int? UsuarioAprobacionId { get; set; }
    }
}
