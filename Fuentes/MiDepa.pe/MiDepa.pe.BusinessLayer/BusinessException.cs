using System.ServiceModel;
using MiDepa.pe.DataTypes.Response;

namespace MiDepa.pe.BusinessLayer
{
    public class BusinessException
    {
        public static FaultException<ServiceErrorResponseType> Generar(string strMensaje)
        {
            dynamic serviceErrorResponse = new ServiceErrorResponseType();
            serviceErrorResponse.Message = strMensaje;
            throw new FaultException<ServiceErrorResponseType>(serviceErrorResponse, new FaultReason("Advertencia del lado del servidor"));
        }
    }
}
