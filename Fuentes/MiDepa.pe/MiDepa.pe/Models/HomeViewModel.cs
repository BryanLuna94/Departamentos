using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiDepa.pe.ServicioMiDepa;

namespace MiDepa.pe.Models
{
    public class HomeViewModel
    {
        public HomeViewModel() { }

        public HomeViewModel(HomeResponseDto response)
        {
            LstCampanias = new List<SelectListItem>();

            if (response.ListaCampanias != null) foreach (GenericoListaDto item in response.ListaCampanias) LstCampanias.Add(new SelectListItem { Value = item.Codigo, Text = item.Descripcion });
            DeudaActual = response.DeudaActual;
            CampaniasDebe = response.CampaniasDebe;
            CampaniaActual = response.CampaniaActual;
            ListaGastosMensual = response.ListaGastosMensual;
            ListaDepasEstado = response.ListaDepasEstado;
            TieneRetraso = response.TieneRetraso;
            TextoMostrarRetraso = response.TextoMostrarRetraso;
            TextoAlDia = response.TextoAlDia;
            ListaEstadoCuentaMensualResumido = response.ListaReporteEstadoCuentaResumido;
        }


        public decimal DeudaActual { get; set; }
        public int CampaniasDebe { get; set; }
        public string CampaniaActual { get; set; }
        public List<ReporteGastosMensualEdificioResumido> ListaGastosMensual { get; set; }
        public List<SelectListItem> LstCampanias { get; set; }
        public List<DepasEstadoHomeListaDto> ListaDepasEstado { get; set; }
        public bool TieneRetraso { get; set; }
        public string TextoMostrarRetraso { get; set; }
        public string TextoAlDia { get; set; }
        public List<ReporteEstadoCuentaMensualResumidoListaDto> ListaEstadoCuentaMensualResumido { get; set; }
        
    }
}