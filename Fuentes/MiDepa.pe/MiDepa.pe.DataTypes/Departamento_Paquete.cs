namespace MiDepa.pe.DataTypes
{    
    public class Departamento_Paquete
    {
        public int PaqueteId { get; set; }
        public int DepaId { get; set; }
        public System.DateTime FechaHoraRecepcion { get; set; }
        public string DescripcionPaquete { get; set; }
        public string PersonaEntrega { get; set; }
        public string PersonaRecibe { get; set; }
        public int UsuarioRegistroId { get; set; }
    }
}
