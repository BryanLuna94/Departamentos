namespace MiDepa.pe.DataTypes
{
    public class Edificio
    {    
        public int EdificioId { get; set; }
        public int ClienteId { get; set; }
        public byte CantidadPisos { get; set; }
        public short CantidadDepas { get; set; }
        public string Comentarios { get; set; }
        public bool Activo { get; set; }
    }
}
