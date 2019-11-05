namespace MiDepa.pe.DataTypes.Listas
{
    public class OpcionesPorPerfilListaDto
    {
        public string Nombre { get; set; }
        public int CodigoOpcion { get; set; }
        public int CodigoPadre { get; set; }
        public bool Existe { get; set; }
    }
}
