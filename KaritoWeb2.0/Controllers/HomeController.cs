using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;

namespace KaritoWeb2._0.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexCliente()
        {
            ViewBag.usuario = Aiuda.Usuario;
            return View();
        }

        public ActionResult IndexAdministrador()
        {
            ViewBag.usuario = Aiuda.Usuario;
            return View();
        }
    }
}
