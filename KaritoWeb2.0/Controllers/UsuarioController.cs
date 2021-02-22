using CapaAccesoDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KaritoWeb2._0.Controllers
{
    public class UsuarioController : Controller
    {
        public EntUsuario greg;
        //
        // GET: /Usuario/

        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult InsertarUsuario()
        {
            return View();
        }




        [HttpPost]
        public ActionResult InsertarUsuario(EntUsuario usuario, FormCollection frm)
        {

            try
            {
                bool inserta = false;
                bool personaExistente = false;
                bool usuarioExistente = false;

                List<EntPersona> listaPersona = DatPersona.Instancia.ListarPersona();

                foreach (EntPersona personaAux in listaPersona)
                {
                    if (personaAux.DniPersona.Equals(usuario.persona.DniPersona) /*|| personaAux.EmailPersona.Equals(usuario.persona.EmailPersona)*/) personaExistente = true;
                }

                List<EntUsuario> listaUsuario = DatUsuario.Instancia.ListarUsuario();

                foreach (EntUsuario usuarioAux in listaUsuario)
                {
                    if (usuarioAux.Username.Equals(usuario.Username)) usuarioExistente = true;
                }

                if (!usuarioExistente && !personaExistente)
                {
                    inserta = DatPersona.Instancia.InsertarPersona(usuario.persona);
                    inserta = DatUsuario.Instancia.InsertarUsuario(usuario);
                }

                return RedirectToAction("Index", "Home");
            }

            catch (ApplicationException ex)
            {
                return RedirectToAction("Index", new { mesjExceptio = ex.Message });
            }

        }
        [HttpGet]
        public ActionResult loginCliente()
        {
            return View();
        }
        [HttpPost]
        public ActionResult loginCliente(FormCollection frm)
        {
            try
            {
                String Usuario = frm["txtUsuario"];
                String Password = frm["txtPassword"];
                EntUsuario u = DatUsuario.Instancia.VerificarAcceso(Usuario, Password);
                if (u != null)
                {
                    if (u.EstadoUsuario)
                    {
                        TempData["usuario"] = u;

                        Aiuda.Usuario = u;

                        if (u.Rol.Equals("Cliente"))
                        {
                            return RedirectToAction("IndexCliente", "Home");
                        }
                        else
                        {
                            return RedirectToAction("IndexAdministrador", "Home");
                        }
                    }
                    else
                    {
                        ViewBag.mensajito = "Usuario ha sido dado de baja";
                        return View();
                    }
                }
                else
                {
                    ViewBag.mensajito = "Usuario o password no valido!";
                    return View();
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "jaLARON", new { mensaje = ex.Message });
            }
        }
    }
}
