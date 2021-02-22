using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaAccesoDatos;
namespace KaritoWeb2._0.Controllers
{
    public class PagoController : Controller
    {
        public float aux;
        [HttpGet]
        public ActionResult InsertarPago(int ContratoId, float MontoTotal, float MontoCancelado)
        {

            ViewBag.usuario = Aiuda.Usuario;
            ViewBag.ContratoId = ContratoId;
            Aiuda.aux = (MontoTotal - MontoCancelado);
            ViewBag.MontoRestante = (MontoTotal - MontoCancelado);
            return View();
        }

        [HttpPost]
        public ActionResult InsertarPago(EntPago Pago)
        {
            ViewBag.usuario = Aiuda.Usuario;
            try
            {
                if (Pago.MontoPagado <= Aiuda.aux)
                {
                    Boolean inserta = DatPago.Instancia.InsertarPago(Pago);
                    return RedirectToAction("ListarContrato", "Contrato");
                    
                }
                else
                {
                    return RedirectToAction("ListarContrato", "Contrato");
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("InsertarPago");
            }

        }
    }
}
