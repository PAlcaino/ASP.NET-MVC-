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
            string to = "palcaino.lleite@gmail.com";
            string subject = "Notificacion de Reunion";
            string body = string.Empty;

            if(ModelState.IsValid)
            {
                body = string.Format("Gracias"+ ViewBag.Nombre);
                await MailHelper.SendEmail(to,subject,body);
                return View("Gracias", respuesta);
            }
            return View();
        }
    }
}