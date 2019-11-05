namespace MiDepa.pe.DataTypes
{
    using System;
    
    public class Votacion
    {
        public int VotacionId { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
        public string Descripcion { get; set; }
        public string Titulo { get; set; }
        public int EstadoId { get; set; }
        public int UsuarioId { get; set; }
    }
}
