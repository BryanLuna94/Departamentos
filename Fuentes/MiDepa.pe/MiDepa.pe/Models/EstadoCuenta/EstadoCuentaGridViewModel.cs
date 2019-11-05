using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiDepa.pe.ServicioMiDepa;

namespace MiDepa.pe.Models.EstadoCuenta
{
    public class EstadoCuentaGridViewModel
    {
        public EstadoCuentaGridViewModel() { }

        public EstadoCuentaGridViewModel(EstadoCuentaResponseDto response)
        {
            LstCampanias = new List<SelectListItem>();

            if (response.ListaCampanias != null) foreach (GenericoListaDto item in response.ListaCampanias) LstCampanias.Add(new SelectListItem { Value = item.Codigo, Text = item.Descripcion });

            DiasRetraso = response.DiasRetraso;
            ListaDetalleEstadoCuenta = response.ListaDetalleEstadoCuenta;
            ListaPagosEstadoCuenta = response.ListaPagosEstadoCuenta;
            MontosEstadoCuenta = response.MontosEstadoCuenta;
        }

        public List<SelectListItem> LstCampanias { get; set; }
        public string CodigoCampania { get; set; }
        public MontosEstadoCuentaListaDto MontosEstadoCuenta { get; set; }
        public int DiasRetraso { get; set; }
        public List<DetalleEstadoCuentaListaDto> ListaDetalleEstadoCuenta { get; set; }
        public List<PagosPorEstadoCuentaListaDto> ListaPagosEstadoCuenta { get; set; }
    }
}