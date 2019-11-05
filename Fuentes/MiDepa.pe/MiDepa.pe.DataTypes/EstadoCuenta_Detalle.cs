namespace MiDepa.pe.DataTypes
{
    public class EstadoCuenta_Detalle
    {
        public int EstadoCuentaDetalleId { get; set; }
        public int EstadoCuentaId { get; set; }
        public short ConceptoId { get; set; }
        public decimal MontoPagar { get; set; }
    }
}
