using MiDepa.pe.DataTypes.Filtros;
using MiDepa.pe.DataTypes;
using System.Runtime.Serialization;

namespace MiDepa.pe.DataTypes.Request
{
    [DataContract]
    public class ArchivoRequestDto
    {
        [DataMember]
        public Archivo Archivo { get; set; }
    }
}
