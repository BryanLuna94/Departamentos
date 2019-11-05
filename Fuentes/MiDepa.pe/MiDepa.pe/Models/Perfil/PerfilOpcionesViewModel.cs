using System.Collections.Generic;
using MiDepa.pe.ServicioMiDepa.pe;
using System.Web.Mvc;

namespace MiDepa.pe.Models.Perfil
{
    public class PerfilOpcionesViewModel
    {
        public PerfilOpcionesViewModel() { }

        public PerfilOpcionesViewModel(PerfilResponseDto response)
        {
            ListaOpciones = response.ListaOpciones;
        }

        public List<OpcionesPorPerfilListaDto> ListaOpciones { get; set; }
        public short IdPerfil { get; set; }
    }
}