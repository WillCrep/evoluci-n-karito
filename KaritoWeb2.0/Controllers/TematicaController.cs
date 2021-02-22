using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaAccesoDatos;

namespace KaritoWeb2._0.Controllers
{
    public class TematicaController : Controller
    {
        //
        // GET: /Tematica/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ListarTematica()
        {
            ViewBag.usuario = Aiuda.Usuario;
            List<EntTematica> tematicas = DatTematica.Instancia.ListarTematica();
            return View(tematicas);
        }

        [HttpGet]
        public ActionResult InsertarTematica()
        {
            ViewBag.usuario = Aiuda.Usuario;
            return View();
        }

        [HttpPost]
        public ActionResult InsertarTematica(EntTematica Tematica)
        {
            try
            {
                Boolean inserta = DatTematica.Instancia.InsertarTematica(Tematica);
                if (inserta)
                {
                    return RedirectToAction("ListarTematica", "Tematica");
                }
                else
                {
                    return View(Tematica);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("InsertarTematica");
            }

        }

        [HttpGet]
        public ActionResult EditarTematica(int TematicaId)
        {
            ViewBag.usuario = Aiuda.Usuario;
            EntTematica Tematica = new EntTematica();
            Tematica = DatTematica.Instancia.BuscarTematica(TematicaId);
            return View(Tematica);
        }
        [HttpPost]
        public ActionResult EditarTematica(EntTematica Tematica)
        {
            try
            {
                Boolean edita = DatTematica.Instancia.EditarTematica(Tematica);
                if (edita)
                {
                    return RedirectToAction("ListarTematica", "Tematica");
                }
                else
                {
                    return View(Tematica);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("EditarTematica");
            }
        }
        [HttpGet]
        public ActionResult BorrarTematica(int TematicaId)
        {
            ViewBag.usuario = Aiuda.Usuario;
            Boolean elimina = DatTematica.Instancia.BorrarTematica(TematicaId);
            if (elimina)
            {
                List<EntTematica> lista = DatTematica.Instancia.ListarTematica();
                ViewBag.lista = lista;
                return RedirectToAction("ListarTematica");
            }
            else
            {
                return RedirectToAction("ListarTematica");
            }
        }
    }
}
