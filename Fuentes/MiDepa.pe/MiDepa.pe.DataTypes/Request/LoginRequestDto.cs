using MiDepa.pe.DataTypes.Filtros;
using MiDepa.pe.DataTypes;
using System.Runtime.Serialization;

namespace MiDepa.pe.DataTypes.Request
{
    [DataContract]
    public class LoginRequestDto
    {
        [DataMember]
        public string Usuario { get; set; }
        [DataMember]
        public string Clave { get; set; }
    }
}
