using System.Collections.Generic;
using MiDepa.pe.ServicioMiDepa;
using System.Web.Mvc;
using System.Web;

namespace MiDepa.pe.Models.Archivo
{
    public class ArchivosGridViewModel
    {
        public ArchivosGridViewModel() { }

        //public ArchivosGridViewModel(ArchivosResponseDto response)
        //{
        //    ListaArchivos = response.ListaArchivos;
        //}

        public List<ArchivoListaDto> ListaArchivos { get; set; }
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public HttpPostedFileBase Archivo { get; set; }
    }
}