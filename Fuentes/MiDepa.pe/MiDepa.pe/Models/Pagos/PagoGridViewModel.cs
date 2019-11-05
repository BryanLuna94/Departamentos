using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiDepa.pe.ServicioMiDepa;

namespace MiDepa.pe.Models.Pagos
{
    public class PagoGridViewModel
    {
        public PagoGridViewModel() { }

        public PagoGridViewModel(PagoResponseDto response)
        {
            LstCampanias = new List<SelectListItem>();
            LstEstados = new List<SelectListItem>();

            if (response.ListaCampanias != null) foreach (GenericoListaDto item in response.ListaCampanias) LstCampanias.Add(new SelectListItem { Value = item.Codigo, Text = item.Descripcion });
            if (response.ListaEstados != null) foreach (GenericoListaDto item in response.ListaEstados) LstEstados.Add(new SelectListItem { Value = item.Codigo, Text = item.Descripcion });
            ListaPagos = response.ListaPagos;
        }

        public List<PagoListaDto> ListaPagos { get; set; }
        public PagoFiltroDto Filtro { get; set; }
        public List<SelectListItem> LstCampanias { get; set; }
        public List<SelectListItem> LstEstados { get; set; }
        public int CodigoPago { get; set; }
    }
}