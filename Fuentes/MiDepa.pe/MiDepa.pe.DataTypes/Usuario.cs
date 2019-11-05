namespace MiDepa.pe.DataTypes
{    
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string UsuarioAcceso { get; set; }
        public string Clave { get; set; }
        public int? PersonaId { get; set; }
        public string NombreUsuario { get; set; }
        public int PerfilId { get; set; }
        public bool Activo { get; set; }
        public int EdificioId { get; set; }
    }
}
