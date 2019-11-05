namespace MiDepa.pe.DataTypes
{
    using System;

    public class Campania
    {
        public int CampaniaId { get; set; }
        public byte MesId { get; set; }
        public short Anio { get; set; }
        public decimal Total { get; set; }
        public int EdificioId { get; set; }
        public int EstadoId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Codigo { get; set; }
    }
}
