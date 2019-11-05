namespace MiDepa.pe.DataTypes
{
    public class Pago
    {
        public int PagoId { get; set; }
        public int EstadoCuentaId { get; set; }
        public System.DateTime FechaHoraPago { get; set; }
        public decimal Monto { get; set; }
        public string NroVoucher { get; set; }
        public short CuentaBancariaId { get; set; }
        public int EstadoId { get; set; }
        public int? UsuarioAprobacionId { get; set; }
        public System.DateTime? FechaHoraAprobacion { get; set; }
        public System.DateTime FechaHoraRegistro { get; set; }
        public string Observacion { get; set; }
    }
}
