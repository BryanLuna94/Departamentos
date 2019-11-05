using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiDepa.pe.ServicioMiDepa;
using MiDepa.pe.Helper;

namespace MiDepa.pe.Models.EstadoCuenta
{
    public class PagoEditorViewModel
    {
        public PagoEditorViewModel() { }

        public PagoEditorViewModel(PagoResponseDto response)
        {
            LstCuentasBancarias = new List<SelectListItem>();

            if (response.ListaCuentasBancarias != null) foreach (GenericoListaDto item in response.ListaCuentasBancarias) LstCuentasBancarias.Add(new SelectListItem { Value = item.Codigo, Text = item.Descripcion });
            Pago = response.Pago;
            if (response.Adjunto1 != null) RutaImagen1 = HelperFunciones.ConvertirArrayEnImgSrc(response.Adjunto1);
            if (response.Adjunto2 != null) RutaImagen2 = HelperFunciones.ConvertirArrayEnImgSrc(response.Adjunto2);
            if (response.Adjunto3 != null) RutaImagen3 = HelperFunciones.ConvertirArrayEnImgSrc(response.Adjunto3);
        }

        public List<SelectListItem> LstCuentasBancarias { get; set; }
        public Pago Pago { get; set; }
        public HttpPostedFileBase Adjunto1 { get; set; }
        public HttpPostedFileBase Adjunto2 { get; set; }
        public HttpPostedFileBase Adjunto3 { get; set; }
        public string RutaImagen1 { get; set; }
        public string RutaImagen2 { get; set; }
        public string RutaImagen3 { get; set; }

        

    }
}