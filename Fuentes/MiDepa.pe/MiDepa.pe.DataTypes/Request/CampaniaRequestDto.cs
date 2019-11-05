using MiDepa.pe.DataTypes.Filtros;
using MiDepa.pe.DataTypes.Listas;
using MiDepa.pe.DataTypes;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace MiDepa.pe.DataTypes.Request
{
    [DataContract]
    public class CampaniaRequestDto
    {
        [DataMember]
        public CampaniaFiltroDto Filtro { get; set; }
        [DataMember]
        public Campania Campania { get; set; }
        [DataMember]
        public List<ConceptoListaDto> ListaConceptos { get; set; }
    }
}
