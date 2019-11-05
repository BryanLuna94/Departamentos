using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiDepa.pe.ServicioMiDepa;


namespace MiDepa.pe.Models.Campania
{
    public class CampaniaGridViewModel
    {
        public CampaniaGridViewModel() { }

        public CampaniaGridViewModel(CampaniaResponseDto response)
        {
            ListaCampanias = response.ListaCampanias;
        }

        public List<CampaniaListaDto> ListaCampanias { get; set; }
        public CampaniaFiltroDto Filtro { get; set; }
    }
}