namespace MiDepa.pe.DataTypes.Listas
{
    public class CampaniaListaDto
    {
        public int CampaniaId { get; set; }
        public int MesId { get; set; }
        public int Anio { get; set; }
        public decimal Total { get; set; }
        public int EstadoId { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string Codigo { get; set; }
    }
}
