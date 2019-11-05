namespace MiDepa.pe.DataTypes
{
    using System;
    
    public class Cliente_Contrato
    {
        public int ContratoId { get; set; }
        public int ClienteId { get; set; }
        public byte CantidadMeses { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal Mensualidad { get; set; }
        public int EstadoId { get; set; }
    }
}
