namespace MiDepa.pe.DataTypes
{
    public class Cliente_Contacto
    {
        public int ClienteContactoId { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Comentario { get; set; }
        public int ClienteId { get; set; }
    }
}
