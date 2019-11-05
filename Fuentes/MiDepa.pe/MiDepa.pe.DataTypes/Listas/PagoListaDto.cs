namespace MiDepa.pe.DataTypes.Listas
{
    public class PagoListaDto
    {
        public int PagoId { get; set; }
        public int EstadoCuentaId { get; set; }
        public string FechaHoraPago { get; set; }
        public decimal Monto { get; set; }
        public int EstadoId { get; set; }
        public int MesId { get; set; }
        public int Anio { get; set; }
        public string Depa { get; set; }
        public string Campania { get; set; }
        public string Estado { get; set; }
    }
}
