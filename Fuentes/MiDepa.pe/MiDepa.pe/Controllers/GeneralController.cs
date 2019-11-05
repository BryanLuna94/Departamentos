using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Web.Routing;

namespace MiDepa.pe.Controllers
{
    public class GeneralController : Controller
    {
        public void CrearSesion(string name, string value)
        {
            Session[name] = value;
        }

        public JsonResult ObtenerSesion(string name)
        {
            var objSesion = Session[name];
            if (objSesion != null)
            {
                return Json(objSesion, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        public static string RutaRaiz(HttpRequestBase request)
        {
            var host = request.ApplicationPath;
            if (host.Length > 1) host += "/";
            return host;
        }

        public FileResult ExportarExcel(DataTable dt, HttpResponseBase response, string nombreArchivo)
        {
            DateTime fechaActual = DateTime.Now;
            string nombreArchivoFinal = string.Format("{0}_{1}_{2}.xlsx", nombreArchivo, fechaActual.ToShortDateString(), fechaActual.ToShortTimeString());

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", nombreArchivoFinal);
                }
            }

        }

        public static string RenderViewToString(ControllerContext context, string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = context.RouteData.GetRequiredString("action");

            var viewData = new ViewDataDictionary(model);

            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(context, viewName);
                var viewContext = new ViewContext(context, viewResult.View, viewData, new TempDataDictionary(), sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }
    }
}