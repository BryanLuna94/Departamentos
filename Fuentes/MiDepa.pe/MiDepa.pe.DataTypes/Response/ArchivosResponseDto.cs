using MiDepa.pe.DataTypes.Listas;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MiDepa.pe.DataTypes.Response
{
    [DataContract]
    public class ArchivoResponseDto
    {
        [DataMember]
        public List<ArchivoListaDto> ListaArchivos { get; set; }
        [DataMember]
        public ArchivoListaDto Archivo { get; set; }
    }
}
