using System.Collections.Generic;
using System.Runtime.Serialization;
using MiDepa.pe.DataTypes.Listas;

namespace MiDepa.pe.DataTypes.Response
{
    [DataContract]
    public class HomeResponseDto
    {
        [DataMember]
        public decimal DeudaActual { get; set; }
        [DataMember]
        public int CampaniasDebe { get; set; }
        [DataMember]
        public string CampaniaActual { get; set; }
        [DataMember]
        public List<ReporteGastosMensualEdificioResumido> ListaGastosMensual { get; set; }
        [DataMember]
        public List<GenericoListaDto> ListaCampanias { get; set; }
        [DataMember]
        public List<DepasEstadoHomeListaDto> ListaDepasEstado { get; set; }
        [DataMember]
        public bool TieneRetraso { get; set; }
        [DataMember]
        public string TextoMostrarRetraso { get; set; }
        [DataMember]
        public string TextoAlDia { get; set; }
        [DataMember]
        public List<ReporteEstadoCuentaMensualResumidoListaDto> ListaReporteEstadoCuentaResumido { get; set; }
    }
}
