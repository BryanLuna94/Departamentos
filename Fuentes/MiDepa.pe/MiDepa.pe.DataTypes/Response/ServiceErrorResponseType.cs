using System;
using System.Runtime.Serialization;

namespace MiDepa.pe.DataTypes.Response
{
    [Serializable()]
    [DataContract()]
    public class ServiceErrorResponseType
    {
        [DataMember(EmitDefaultValue = false)]
        public string Code { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Description { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Message { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string SubCode { get; set; }
    }
}
