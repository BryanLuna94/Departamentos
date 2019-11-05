namespace MiDepa.pe.DataTypes
{
    using System;

    public partial class Departamento_Visita
    {
        public int VisitaId { get; set; }
        public int DepaId { get; set; }
        public string DocumentoIdentidad { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaHoraIngreso { get; set; }
        public DateTime FechaHoraSalida { get; set; }
        public string Observacion { get; set; }
        public int UsuarioRegistroId { get; set; }
    }
}
