using System.ComponentModel.DataAnnotations;

namespace Turnos.Models
{
    public class Especialidad
    {
        [Key]
        public int IdEspecialidad { get; set; }
        [Required(ErrorMessage = "Debe ingresar una descipción")]
        [Display(Name = "Descripción", Prompt = "Ingrese una descripción")]
        [StringLength(200, ErrorMessage = "El campo descipción debe tener maximo 200 caracteres")]
        public string Descripcion { get; set; }

        public List<MedicoEspecialidad> MedicoEspecialidad { get; set; }
    }
}