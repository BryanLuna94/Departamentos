namespace MiDepa.pe.DataTypes
{
    public class Documento
    {
        public int DocumentoId { get; set; }
        public int TipoDocumentoId { get; set; }
        public string Serie { get; set; }
        public string Numero { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Impuesto { get; set; }
        public decimal MontoTotal { get; set; }
        public string DocumentoIdentidad { get; set; }
        public string Emisor { get; set; }
        public System.DateTime FechaEmision { get; set; }
        public string Comentario { get; set; }
        public int TipoMovimientoId { get; set; }
    }
}
