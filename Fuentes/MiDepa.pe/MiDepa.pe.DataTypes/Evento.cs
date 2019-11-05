namespace MiDepa.pe.DataTypes
{
    using System;
    
    public class Evento
    {
        public int EventoId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Titulo { get; set; }
        public string Comentario { get; set; }
        public string LugarEvento { get; set; }
        public int UsuarioRegistroId { get; set; }
        public bool Activo { get; set; }
    }
}
