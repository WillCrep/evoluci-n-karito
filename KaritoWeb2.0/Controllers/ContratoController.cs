using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaAccesoDatos;
using CapaEntidad;
using System.Net;
using System.Text;
using System.IO;

namespace KaritoWeb2._0.Controllers
{
    public class ContratoController : Controller
    {
        //
        // GET: /Contrato/
        public EntUsuario UsuarioAux = null;
        private List<EntUtileria> ListaUtileriaAux = DatUtileria.Instancia.ListarUtileria();
        private List<EntServicio> ListaServiciosAux = DatServicio.Instancia.ListarServicio();
        private double MontoTotal = 0;
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult DetallarContrato(int ContratoId)
        {
            ViewBag.usuario = Aiuda.Usuario;

            EntContrato Contrato = DatContrato.Instancia.DetallarContrato(ContratoId);

            List<EntDetalleServicio> listaServicios = new List<EntDetalleServicio>();
            listaServicios = Contrato.Paquete.Servicios;
            ViewBag.listaServicios = new MultiSelectList(listaServicios, "DetalleServicioId", "NombreServicio");

            List<EntDetalleUtileria> listaUtileria = new List<EntDetalleUtileria>();
            listaUtileria = Contrato.Paquete.Utileria;
            ViewBag.listaUtileria = new MultiSelectList(listaUtileria, "DetalleUtileriaId", "NombreUtileria");


            return View(Contrato);
        }


        [HttpGet]
        public ActionResult ListarContrato()
        {
            var usuarioModel = TempData["usuario"];
            ViewBag.usuario = usuarioModel;
            UsuarioAux = ViewBag.usuario;

            EntUsuario u = DatUsuario.Instancia.VerificarAcceso(UsuarioAux.Username, UsuarioAux.Password);

            TempData["usuario"] = u;


            List<EntContrato> listaContrato = DatContrato.Instancia.ListarContrato(Aiuda.Usuario.UsuarioId);

            return View(listaContrato);
        }






        [HttpGet]
        public ActionResult InsertarContrato()
        {
            var usuarioModel = TempData["usuario"];
            ViewBag.usuario = usuarioModel;


            EntUsuario u = DatUsuario.Instancia.VerificarAcceso(ViewBag.usuario.Username, ViewBag.usuario.Password);
            TempData["usuario"] = u;

            Aiuda.Usuario = u;
            ViewBag.usuario = Aiuda.Usuario;
            List<EntTematica> listaTematica = new List<EntTematica>();
            listaTematica = DatTematica.Instancia.ListarTematica();
            var lsTematicas = new SelectList(listaTematica, "TematicaId", "NombreTematica");
            ViewBag.listaTematicas = lsTematicas;

            List<EntServicio> listaServicios = new List<EntServicio>();
            listaServicios = DatServicio.Instancia.ListarServicio();
            ViewBag.listaServicios = new MultiSelectList(listaServicios, "ServicioId", "NombreServicio", ViewBag.ServiciosSeleccionados);

            List<EntUtileria> listaUtilerias = new List<EntUtileria>();
            listaUtilerias = DatUtileria.Instancia.ListarUtileria();
            ViewBag.listaUtilerias = new MultiSelectList(listaUtilerias, "UtileriaId", "NombreUtileria", ViewBag.UtileriaSeleccionada);

            return View();
        }


        [HttpPost]
        public ActionResult InsertarContrato(EntContrato contrato, FormCollection frm, String command)
        {

            try
            {
                bool inserta = false;

                contrato.FechaEvento = Convert.ToDateTime(frm["FrmFechaEvento"]);
                inserta = DatContrato.Instancia.InsertarContrato(contrato);

                EntPaquete paquete = new EntPaquete();
                paquete.Tematica = new EntTematica();
                paquete.Tematica.TematicaId = Convert.ToInt32(frm["cboTematica"]);

                inserta = DatPaquete.Instancia.InsertarPaquete(paquete);

                string ServiciosSeleccionados = frm["cboServicios"];
                string[] ServiciosIds = ServiciosSeleccionados.Split(',');
                DatDetalleServicio datDetalleServicio = new DatDetalleServicio();
                foreach (string ServicioId in ServiciosIds)
                {
                    inserta = datDetalleServicio.InsertarDetalleServicio(Convert.ToInt32(ServicioId));
                    foreach (EntServicio ServicioAux in ListaServiciosAux)
                    {
                        if (ServicioId.Equals(ServicioAux.ServicioId)) MontoTotal += ServicioAux.PrecioServicio;
                    }
                }

                string UtileriasSeleccionadas = frm["cboUtilerias"];
                string[] UtileriasIds = UtileriasSeleccionadas.Split(',');
                DatDetalleUtileria datDetalleUtileria = new DatDetalleUtileria();
                foreach (string UtileriaId in UtileriasIds)
                {
                    inserta = datDetalleUtileria.InsertarDetalleUtileria(Convert.ToInt32(UtileriaId), 1); //Arreglar cantidad
                    foreach (EntUtileria UtileriaAux in ListaUtileriaAux)
                    {
                        if (UtileriaId.Equals(UtileriaAux.UtileriaId)) MontoTotal += UtileriaAux.PrecioUtileria;
                    }
                }

                inserta = DatPaquete.Instancia.CalcularMontoTotal();



                return RedirectToAction("ListarContrato", "Contrato");
            }

            catch (ApplicationException ex)
            {
                return RedirectToAction("Index", new { mesjExceptio = ex.Message });
            }

        }




    }
}
