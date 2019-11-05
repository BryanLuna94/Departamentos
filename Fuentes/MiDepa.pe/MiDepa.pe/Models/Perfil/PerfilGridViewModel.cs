using System.Collections.Generic;
using MiDepa.pe.ServicioMiDepa.pe;
using System.Web.Mvc;

namespace MiDepa.pe.Models.Perfil
{
    public class PerfilGridViewModel
    {
        public PerfilGridViewModel() { }

        public PerfilGridViewModel(PerfilResponseDto response)
        {
            ListaPerfiles = response.ListaPerfiles;
        }

        public List<PerfilListaDto> ListaPerfiles { get; set; }
        public PerfilFiltroDto Filtro { get; set; }
    }
}