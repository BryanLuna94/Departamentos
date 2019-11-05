using System;
using System.Collections.Generic;
using System.Linq;
using MiDepa.pe.ServicioMiDepa;

namespace MiDepa.pe.Models
{
    public class DatosSesionViewModel
    {
        public DatosUsuarioListaDto Usuario { get; set; }
        public List<OpcionListaDto> PermisosUsuario { get; set; }
        public ArchivoListaDto FotoUsuario { get; set; }
    }
}