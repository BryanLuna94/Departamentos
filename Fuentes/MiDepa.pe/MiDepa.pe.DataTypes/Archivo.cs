namespace MiDepa.pe.DataTypes
{ 
    public class Archivo
    {
        public string Tabla { get; set; }
        public string Codigo { get; set; }
        public byte[] BinData { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public string Extension { get; set; }
    }
}
