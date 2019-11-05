using System.Runtime.Serialization;

namespace MiDepa.pe.DataTypes.Response
{
    [DataContract]
    public class DatosEstaticosResponseDto
    {
        [DataMember]
        public bool VistoEventos { get; set; }
        [DataMember]
        public bool VistoNotificaciones { get; set; }
        [DataMember]
        public bool VistoPaquetes { get; set; }
        [DataMember]
        public bool VistoPagos { get; set; }
    }
}
