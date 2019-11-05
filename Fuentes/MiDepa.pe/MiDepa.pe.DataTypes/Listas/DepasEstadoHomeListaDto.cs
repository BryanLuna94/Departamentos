namespace MiDepa.pe.DataTypes.Listas
{
    public class DepasEstadoHomeListaDto
    {
        public int DepaId { get; set; }
        public string CodigoDepa { get; set; }
        public decimal Saldo { get; set; }
        public System.DateTime? FechaVencimiento { get; set; }
        public bool Debe { get; set; }
    }
}
