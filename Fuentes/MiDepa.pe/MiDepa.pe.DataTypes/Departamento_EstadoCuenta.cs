namespace MiDepa.pe.DataTypes
{
    using System;
    
    public class Departamento_EstadoCuenta
    {
        public int EstadoCuentaId { get; set; }
        public string Correlativo { get; set; }
        public int DepaId { get; set; }
        public byte MesId { get; set; }
        public short Anio { get; set; }
        public decimal MontoPagar { get; set; }
        public decimal MontoPagado { get; set; }
        public decimal Saldo { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal TotalInteres { get; set; }
        public int EstadoId { get; set; }
        public string CodigoCampania { get; set; }
    }
}
