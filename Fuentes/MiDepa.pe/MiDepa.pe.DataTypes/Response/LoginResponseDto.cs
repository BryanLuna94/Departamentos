using MiDepa.pe.DataTypes.Listas;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MiDepa.pe.DataTypes.Response
{
    [DataContract]
    public class LoginResponseDto
    {
        [DataMember]
        public DatosUsuarioListaDto Usuario { get; set; }
        [DataMember]
        public List<OpcionListaDto> ListaOpcionesPorPerfil { get; set; }
        [DataMember]
        public ArchivoListaDto FotoUsuario { get; set; }
    }
}
