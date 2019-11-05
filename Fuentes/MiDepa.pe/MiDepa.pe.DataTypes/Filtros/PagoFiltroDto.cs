namespace MiDepa.pe.DataTypes.Filtros
{
    public class PagoFiltroDto
    {
        public string CodigoCampania { get; set; }
        public string FechaPagoIni { get; set; }
        public string FechaPagoFin { get; set; }
        public string Depa { get; set; }
        public string NroVoucher { get; set; }
        public int EstadoId { get; set; }
    }
}
