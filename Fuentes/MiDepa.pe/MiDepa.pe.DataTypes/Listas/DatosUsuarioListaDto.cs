namespace MiDepa.pe.DataTypes.Listas
{
    public class DatosUsuarioListaDto : LoginListaDto
    {
        public string Edificio { get; set; }
        public int? DepaId { get; set; }
        public string Depa { get; set; }
        public string CampaniaActual { get; set; }
    }
}
