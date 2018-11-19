using GeneracionInvitaciones.Helpers;
using GeneracionInvitaciones.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GeneracionInvitaciones.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ViewResult Index()
        {
            DateTime fecha = DateTime.Now;
            string fechareunion = fecha.AddDays(5).ToShortDateString();          

            ViewBag.saludoInicial = "PROXIMA REUNION: " + fechareunion;
            return View();
        }

        public ViewResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public async Task<ViewResult> RsvpForm(RespuestaInvitado respuesta)
        {
            string to = respuesta.Correo;
            string subject = "Notificacion de Reunion";
            string body = string.Empty;
            string asistira = string.Empty;
            if (ModelState.IsValid)
            {
                if((bool)respuesta.Asistira)
                {
                    asistira = "asistencia";
                }
                else
                {
                    asistira = "no asistencia";
                }
                body = string.Format("Gracias {0} por completar el formulario de reunion, tu {1} ha sido confirmada ", 
                    respuesta.Nombre, asistira);
                await MailHelper.SendEmail(to,subject,body);
                return View("Gracias", respuesta);
            }
            return View();
        }
    }
}