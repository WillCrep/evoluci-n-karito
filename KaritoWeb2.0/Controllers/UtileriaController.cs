using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaAccesoDatos;
using CapaEntidad;

namespace KaritoWeb2._0.Controllers
{
    public class UtileriaController : Controller
    {
        //
        // GET: /Utileria/

        public ActionResult Index()
        {
            return View();
        }
   
        [HttpGet]
        public ActionResult ListarUtileria()
        {
            ViewBag.usuario = Aiuda.Usuario;
            List<EntUtileria> utileria = DatUtileria.Instancia.ListarUtileria();
            return View(utileria);
        }

        [HttpGet]
        public ActionResult InsertarUtileria()
        {
            ViewBag.usuario = Aiuda.Usuario;
            return View();
        }

        [HttpPost]
        public ActionResult InsertarUtileria(EntUtileria Utileria)
        {
            try
            {
                Boolean inserta = DatUtileria.Instancia.InsertarUtileria(Utileria);
                if (inserta)
                {
                    return RedirectToAction("ListarUtileria", "Utileria");
                }
                else
                {
                    return View(Utileria);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("InsertarUtileria");
            }

        }

        [HttpGet]
        public ActionResult EditarUtileria(int UtileriaId)
        {
            ViewBag.usuario = Aiuda.Usuario;
            EntUtileria Utileria = new EntUtileria();
            Utileria = DatUtileria.Instancia.BuscarUtileria(UtileriaId);
            return View(Utileria);
        }
        [HttpPost]
        public ActionResult EditarUtileria(EntUtileria Utileria)
        {
            try
            {
                Boolean edita = DatUtileria.Instancia.EditarUtileria(Utileria);
                if (edita)
                {
                    return RedirectToAction("ListarUtileria", "Utileria");
                }
                else
                {
                    return View(Utileria);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("EditarUtileria");
            }
        }
        [HttpGet]
        public ActionResult BorrarUtileria(int UtileriaId)
        {
            ViewBag.usuario = Aiuda.Usuario;
            Boolean elimina = DatUtileria.Instancia.BorrarUtileria(UtileriaId);
            if (elimina)
            {
                List<EntUtileria> lista = DatUtileria.Instancia.ListarUtileria();
                ViewBag.lista = lista;
                return RedirectToAction("ListarUtileria");
            }
            else
            {
                return RedirectToAction("ListarUtileria");
            }
        }
    }
}
