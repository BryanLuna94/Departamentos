namespace MiDepa.pe.DataTypes
{
    public class Persona
    {
        public int PersonaId { get; set; }
        public int DepaId { get; set; }
        public string Nombre { get; set; }
        public string NumeroDocumento { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public bool EsPropietario { get; set; }
        public bool ViveEnDepa { get; set; }
    }
}
