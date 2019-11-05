using System;

namespace MiDepa.pe.DataTypes.Listas
{
    public class MontosEstadoCuentaListaDto
    {
        public int EstadoCuentaId { get; set; }
        public decimal Saldo { get; set; }
        public decimal MontoPagado { get; set; }
        public decimal MontoPagar { get; set; }
        public decimal TotalInteres { get; set; }
        public string FechaVencimiento { get; set; }
        public string FechaEmision { get; set; }
    }
}
