namespace MiDepa.pe.DataTypes.Listas
{
    public class ReporteEstadoCuentaMensualResumidoListaDto
    {
        public int MesId { get; set; }
        public int Anio { get; set; }
        public string Campania { get; set; }
        public bool AlDia { get; set; }
        public System.DateTime FechaVencimiento { get; set; }
        public decimal Saldo { get; set; }
    }
}
