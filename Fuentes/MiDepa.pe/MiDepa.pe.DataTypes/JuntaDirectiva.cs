namespace MiDepa.pe.DataTypes
{
    using System;
    
    public class JuntaDirectiva
    {
        public int JuntaDirectivaId { get; set; }
        public int UsuarioPresidenteId { get; set; }
        public int UsuarioSecretarioId { get; set; }
        public int UsuarioTesoreroId { get; set; }
        public int UsuarioVocalId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int EdificioId { get; set; }
        public bool Activo { get; set; }
    }
}
