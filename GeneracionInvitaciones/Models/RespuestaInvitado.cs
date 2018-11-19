using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeneracionInvitaciones.Models
{
    public class RespuestaInvitado
    {
        [Required(ErrorMessage = "Debe ingresar un nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe ingresar un correo")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Ingrese un email valido.")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "Debe ingresar un telefono")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Debe seleccionar una opcion")]
        public bool? Asistira { get; set; }
    }
}