namespace MiDepa.pe.DataTypes
{
    public class Opcion
    {
        public int OpcionId { get; set; }
        public string Nombre { get; set; }
        public int? OpcionPadreId { get; set; }
        public string Ruta { get; set; }
        public short Orden { get; set; }
        public int TipoOpcionId { get; set; }
        public string Clase { get; set; }
    }
}
