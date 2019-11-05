using System.Collections.Generic;
using MiDepa.pe.ServicioMiDepa.pe;
using System.Web.Mvc;

namespace MiDepa.pe.Models.Perfil
{
    public class PerfilEditorViewModel
    {
        public PerfilEditorViewModel() { }

        public PerfilEditorViewModel(PerfilResponseDto response)
        {
            Perfil = response.Perfil;
        }

        public GEN_MaePerfil Perfil { get; set; }
    }
}