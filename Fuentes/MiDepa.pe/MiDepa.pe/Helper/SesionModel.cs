using System.Web;
using MiDepa.pe.Models;
using MiDepa.pe.Models.Pagos;

namespace MiDepa.pe.Helper
{
    public class SesionModel
    {
        private static DatosSesionViewModel _DatosSesion;
        public static DatosSesionViewModel DatosSesion
        {
            get
            {
                var session = (DatosSesionViewModel)HttpContext.Current.Session[HelperConstantes.GSesionDatos];
                if (session == null) session = new DatosSesionViewModel();
                _DatosSesion = session;
                return _DatosSesion;
            }
            set
            {
                HttpContext.Current.Session[HelperConstantes.GSesionDatos] = value;
            }
        }

        private static PagoGridViewModel _FiltrosPago;
        public static PagoGridViewModel FiltrosPago
        {
            get
            {
                var session = (PagoGridViewModel)HttpContext.Current.Session[HelperConstantes.GSesionFiltrosPago];
                if (session == null) session = new PagoGridViewModel();
                _FiltrosPago = session;
                return _FiltrosPago;
            }
            set
            {
                if (value == null)
                {
                    HttpContext.Current.Session.Remove(HelperConstantes.GSesionFiltrosPago);
                }
                else
                {
                    HttpContext.Current.Session[HelperConstantes.GSesionFiltrosPago] = value;
                }
            }
        }


    }
}