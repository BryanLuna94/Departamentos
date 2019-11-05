namespace MiDepa.pe.DataTypes.Listas
{
    public class PagosPorEstadoCuentaListaDto
    {
        public int PagoId { get; set; }
        public decimal Monto { get; set; }
        public int EstadoId { get; set; }
        public string FechaPago { get; set; }
    }
}
