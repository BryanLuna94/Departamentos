using System.Collections.Generic;
using System.Runtime.Serialization;
using MiDepa.pe.DataTypes.Listas;

namespace MiDepa.pe.DataTypes.Response
{
    [DataContract]
    public class EstadoCuentaResponseDto
    {
        [DataMember]
        public MontosEstadoCuentaListaDto MontosEstadoCuenta { get; set; }
        [DataMember]
        public List<GenericoListaDto> ListaCampanias { get; set; }
        [DataMember]
        public int DiasRetraso { get; set; }
        [DataMember]
        public List<DetalleEstadoCuentaListaDto> ListaDetalleEstadoCuenta { get; set; }
        [DataMember]
        public List<PagosPorEstadoCuentaListaDto> ListaPagosEstadoCuenta { get; set; }
    }
}
