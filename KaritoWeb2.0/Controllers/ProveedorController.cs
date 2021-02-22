using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaAccesoDatos;
using CapaEntidad;

namespace KaritoWeb2._0.Controllers
{
    public class ProveedorController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.usuario = Aiuda.Usuario;
            return View();
        }

        [HttpGet]
        public ActionResult ListarProveedor()
        {
            ViewBag.usuario = Aiuda.Usuario;
            List<EntProveedor> proveedor = DatProveedor.Instancia.ListarProveedor();
            return View(proveedor);
        }

        [HttpGet]
        public ActionResult InsertarProveedor()
        {
            ViewBag.usuario = Aiuda.Usuario;
            return View();
        }

        [HttpPost]
        public ActionResult InsertarProveedor(EntProveedor Proveedor)
        {
            try
            {
                Boolean inserta = DatProveedor.Instancia.InsertarProveedor(Proveedor);
                if (inserta)
                {
                    return RedirectToAction("ListarProveedor", "Proveedor");
                }
                else
                {
                    return View(Proveedor);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("InsertarProveedor");
            }

        }

        [HttpGet]
        public ActionResult EditarProveedor(int ProveedorId)
        {
            ViewBag.usuario = Aiuda.Usuario;
            EntProveedor Proveedor = new EntProveedor();
            Proveedor = DatProveedor.Instancia.BuscarProveedor(ProveedorId);
            return View(Proveedor);
        }
        [HttpPost]
        public ActionResult EditarProveedor(EntProveedor Proveedor)
        {
            try
            {
                Boolean edita = DatProveedor.Instancia.EditarProveedor(Proveedor);
                if (edita)
                {
                    return RedirectToAction("ListarProveedor", "Proveedor");
                }
                else
                {
                    return View(Proveedor);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("EditarProveedor");
            }
        }
        [HttpGet]
        public ActionResult BorrarProveedor(int ProveedorId)
        {
            ViewBag.usuario = Aiuda.Usuario;
            Boolean elimina = DatProveedor.Instancia.BorrarProveedor(ProveedorId);
            if (elimina)
            {
                List<EntProveedor> lista = DatProveedor.Instancia.ListarProveedor();
                ViewBag.lista = lista;
                return RedirectToAction("ListarProveedor");
            }
            else
            {
                return RedirectToAction("ListarProveedor");
            }
        }
    }
}
