using CapaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KaritoWeb2._0.Controllers
{
    public class ReporteController : Controller
    {
        //
        // GET: /Reporte/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MostrarGananciaPorMeses()
        {
            float ganancia = DatPago.Instancia.GananciaDelMes(7);
            ViewBag.ganancia = ganancia;
            return View();
        }

    }
}
