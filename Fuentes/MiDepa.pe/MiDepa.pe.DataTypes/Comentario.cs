namespace MiDepa.pe.DataTypes
{
    public class Comentario
    {
        public int ComentarioId { get; set; }
        public int TablaId { get; set; }
        public int ItemId { get; set; }
        public int UsuarioId { get; set; }
        public string Descripcion { get; set; }
    }
}
