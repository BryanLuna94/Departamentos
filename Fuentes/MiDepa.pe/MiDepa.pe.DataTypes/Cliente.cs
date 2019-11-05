namespace MiDepa.pe.DataTypes
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public int EstadoId { get; set; }
        public bool Activo { get; set; }
    }
}
