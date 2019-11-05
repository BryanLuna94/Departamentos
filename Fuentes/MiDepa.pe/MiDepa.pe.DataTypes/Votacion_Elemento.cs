namespace MiDepa.pe.DataTypes
{ 
    public class Votacion_Elemento
    {
        public int ElementoVotacionId { get; set; }
        public int VotacionId { get; set; }
        public string Descripcion { get; set; }
        public int CantidadVotos { get; set; }
    }
}
