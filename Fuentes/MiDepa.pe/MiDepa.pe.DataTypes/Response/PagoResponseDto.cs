using System.Collections.Generic;
using System.Runtime.Serialization;
using MiDepa.pe.DataTypes.Listas;

namespace MiDepa.pe.DataTypes.Response
{
    [DataContract]
    public class PagoResponseDto
    {
        [DataMember]
        public List<GenericoListaDto> ListaCuentasBancarias { get; set; }
        [DataMember]
        public List<GenericoListaDto> ListaCampanias { get; set; }
        [DataMember]
        public List<GenericoListaDto> ListaEstados { get; set; }
        [DataMember]
        public Pago Pago { get; set; }
        [DataMember]
        public ArchivoListaDto Adjunto3 { get; set; }
        [DataMember]
        public ArchivoListaDto Adjunto2 { get; set; }
        [DataMember]
        public ArchivoListaDto Adjunto1 { get; set; }
        [DataMember]
        public List<PagoListaDto> ListaPagos { get; set; }
    }
}
