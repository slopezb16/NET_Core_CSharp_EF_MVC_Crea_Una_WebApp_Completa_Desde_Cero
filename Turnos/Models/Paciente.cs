using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Turnos.Models
{
    public class Paciente
    {
        [Key]
        public int IdPaciente { get; set; }
        [Required(ErrorMessage = "Nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Apellido es obligatorio")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Direccion es obligatorio")]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Telefono es obligatorio")]
        [Display(Name = "Télefono")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Email es obligatorio")]
        [EmailAddress(ErrorMessage = "Ingrese una direccion de correo valida")]
        public string Email { get; set; }
        public List<Turno> Turno { get; set; }
    }
}