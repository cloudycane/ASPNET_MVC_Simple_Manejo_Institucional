using System.ComponentModel.DataAnnotations;

namespace InstitucionMVC.Models
{
    public class Estudiante
    {
        [Key]
        public int EstudianteId { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio. Hay que indicar el 'Nombre' del estudiante.")]
        [StringLength(50, ErrorMessage = "Los caracteres del {0} no deberían pasar a {1}.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio. Hay que indicar los Apellidos del estudiante.")]
        [StringLength(70, ErrorMessage = "Los caracteres del {0} no deberían pasar a {1}.")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio. Hay que indicar la 'Edad' del estudiante.")]
        [Range(0, 50, ErrorMessage = "La {0} del estudiante tiene un rango de {1} a {2}.")]
        public int Edad {  get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio. Indique su fecha de nacimiento.")]
        [Display(Name = "Fecha de Nacimiento")]
        public DateOnly Fecha_Nacimiento { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio. Indique su dirección.")]
        public string Direccion {  get; set; }
        [EmailAddress(ErrorMessage = "Por favor agrega un correo electrónico válido.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio. Indique su correo electrónico.")]
        [Display(Name = "Correo Electrónico")]
        public string Correo_Electronico { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio. Indique su estudio anterior realizado.")]
        [Display(Name = "Ultimo Estudio Realizado")]
        public string Ultimo_Estudio_Realizado { get; set; }
        
        
    }
}
