using MiDepa.pe.DataTypes.Filtros;
using MiDepa.pe.DataTypes;
using System.Runtime.Serialization;

namespace MiDepa.pe.DataTypes.Request
{
    [DataContract]
    public class PagoRequestDto
    {
        [DataMember]
        public Pago Pago { get; set; }
        [DataMember]
        public Archivo Adjunto3 { get; set; }
        [DataMember]
        public Archivo Adjunto2 { get; set; }
        [DataMember]
        public Archivo Adjunto1 { get; set; }
        [DataMember]
        public PagoFiltroDto Filtro { get; set; }
        [DataMember]
        public int CodigoUsuario { get; set; }
    }
}
