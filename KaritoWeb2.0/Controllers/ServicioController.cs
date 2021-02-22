using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaAccesoDatos;
namespace KaritoWeb2._0.Controllers
{
    public class ServicioController : Controller
    {
        //
        // GET: /Servicio/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ListarServicio()
        {
            List<EntServicio> servicios = DatServicio.Instancia.ListarServicio();
            ViewBag.usuario = Aiuda.Usuario;
            return View(servicios);
        }

        [HttpGet]
        public ActionResult InsertarServicio()
        {
            ViewBag.usuario = Aiuda.Usuario;
            return View();
        }

        [HttpPost]
        public ActionResult InsertarServicio(EntServicio Servicio)
        {
            try
            {
                Boolean inserta = DatServicio.Instancia.InsertarServicio(Servicio);
                if (inserta)
                {
                    return RedirectToAction("ListarServicio","Servicio");
                }
                else
                {
                    return View(Servicio);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("InsertarServicio");
            }

        }


        [HttpGet]
        public ActionResult EditarServicio(int ServicioId)
        {
            ViewBag.usuario = Aiuda.Usuario;
            EntServicio Servicio = new EntServicio();
            Servicio = DatServicio.Instancia.BuscarServicio(ServicioId);
            return View(Servicio);
        }
        [HttpPost]
        public ActionResult EditarServicio(EntServicio Servicio)
        {
            try
            {
                Boolean edita = DatServicio.Instancia.EditarServicio(Servicio);
                if (edita)
                {
                    return RedirectToAction("ListarServicio","Servicio");
                }
                else
                {
                    return View(Servicio);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("EditarServicio");
            }
        }
        [HttpGet]
        public ActionResult BorrarServicio(int ServicioId)
        {
            ViewBag.usuario = Aiuda.Usuario;
            Boolean elimina = DatServicio.Instancia.BorrarServicio(ServicioId);
            if (elimina)
            {
                List<EntServicio> lista = DatServicio.Instancia.ListarServicio();
                ViewBag.lista = lista;
                return RedirectToAction("ListarServicio");
            }
            else
            {
                return RedirectToAction("ListarServicio");
            }
        }
    }
}
