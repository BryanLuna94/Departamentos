using MiDepa.pe.ServicioMiDepa;

namespace MiDepa.pe.Models
{
    public class CabeceraViewModel
    {
        public CabeceraViewModel() { }

        public CabeceraViewModel(DatosEstaticosResponseDto response)
        {
            VistoEventos = response.VistoEventos;
            VistoNotificaciones = response.VistoNotificaciones;
            VistoPaquetes = response.VistoPaquetes;
            VistoPagos = response.VistoPagos;
        }

        public bool VistoEventos { get; set; }
        public bool VistoNotificaciones { get; set; }
        public bool VistoPaquetes { get; set; }
        public bool VistoPagos { get; set; }

    }
}