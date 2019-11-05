namespace MiDepa.pe.DataTypes.Listas
{
    public class LoginListaDto
    {
        public short Codigo { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public int? CodigoPersona { get; set; }
        public short CodigoPerfil { get; set; }
        public int? CodigoEdificio { get; set; }
    }
}
