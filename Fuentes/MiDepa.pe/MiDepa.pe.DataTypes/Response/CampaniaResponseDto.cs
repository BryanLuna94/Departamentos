using MiDepa.pe.DataTypes.Listas;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MiDepa.pe.DataTypes.Response
{
    [DataContract]
    public class CampaniaResponseDto
    {
        [DataMember]
        public List<CampaniaListaDto> ListaCampanias { get; set; }
        [DataMember]
        public List<GenericoListaDto> ListaMeses { get; set; }
        [DataMember]
        public List<ConceptoListaDto> ListaConceptos { get; set; }
        [DataMember]
        public Campania Campania { get; set; }
        [DataMember]
        public List<GenericoListaDto> ListaCampaniasPlantilla { get; set; }
    }
}
