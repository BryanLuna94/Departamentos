using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiDepa.pe.ServicioMiDepa;

namespace MiDepa.pe.Models.Campania
{
    public class CampaniaEditorViewModel
    {
        public CampaniaEditorViewModel () { }

        public CampaniaEditorViewModel (CampaniaResponseDto response)
        {
            Campania = response.Campania;
            ListaConceptos = response.ListaConceptos;
            LstMeses = new List<SelectListItem>();
            LstCampaniasPlantilla = new List<SelectListItem>();

            if (response.ListaMeses != null) foreach (GenericoListaDto item in response.ListaMeses) LstMeses.Add(new SelectListItem { Value = item.Codigo, Text = item.Descripcion });
            if (response.ListaCampaniasPlantilla != null) foreach (GenericoListaDto item in response.ListaCampaniasPlantilla) LstCampaniasPlantilla.Add(new SelectListItem { Value = item.Codigo, Text = item.Descripcion });
        }

        public ServicioMiDepa.Campania Campania { get; set; }
        public List<SelectListItem> LstMeses { get; set; }
        public List<ConceptoListaDto> ListaConceptos { get; set; }
        public List<SelectListItem> LstCampaniasPlantilla { get; set; }
        public int CampaniaPlantillaId { get; set; }

    }
}