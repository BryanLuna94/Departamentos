using System.Collections.Generic;
using System.Runtime.Serialization;
using MiDepa.pe.DataTypes.Listas;

namespace MiDepa.pe.DataTypes.Response
{
    [DataContract]
    public class PerfilResponseDto
    {
        [DataMember]
        public List<PerfilListaDto> ListaPerfiles { get; set; }
        [DataMember]
        public Perfil Perfil { get; set; }
        [DataMember]
        public List<OpcionesPorPerfilListaDto> ListaOpciones { get; set; }
        [DataMember]
        public List<OpcionListaDto> ListaOpcionesMenu { get; set; }
    }
}
