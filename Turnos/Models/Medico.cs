using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Turnos.Models
{
    public class Medico
    {
        [Key]
        public int IdMedico { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Display(Name = "Télefono")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [EmailAddress(ErrorMessage = "Ingrese una direccion de correo valida")]
        public string Email { get; set; }
        [Display(Name = "Horario desde")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime HorarioAtencionDesde { get; set; }
        [Display(Name = "Horario hasta")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime HorarioAtencionHasta { get; set; }
        public List<MedicoEspecialidad> MedicoEspecialidad { get; set; }
        public List<Turno> Turno { get; set; }
    }
}