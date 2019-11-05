namespace MiDepa.pe.DataTypes
{
    public class Contrato_Mensualidad
    {
        public int MensualidadId { get; set; }
        public int ContratoId { get; set; }
        public byte NumeroMes { get; set; }
        public decimal MontoPagar { get; set; }
        public decimal MontoPagado { get; set; }
        public decimal Saldo { get; set; }
        public System.DateTime FechaVencimiento { get; set; }
    }
}
