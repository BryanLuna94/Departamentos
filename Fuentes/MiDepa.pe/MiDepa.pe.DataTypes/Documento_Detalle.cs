namespace MiDepa.pe.DataTypes
{
    public class Documento_Detalle
    {
        public int DocumentoDetalleId { get; set; }
        public int DocumentoId { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnit { get; set; }
        public short Cantidad { get; set; }
        public decimal Total { get; set; }
    }
}
