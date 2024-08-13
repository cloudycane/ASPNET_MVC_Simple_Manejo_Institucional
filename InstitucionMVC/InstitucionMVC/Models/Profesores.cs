using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstitucionMVC.Models
{
    public class Profesores
    {
        [Key]
        public int ProfesorId { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio. Por favor, indique su nombre.")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio. Por favor, indique su appellidos.")]
        [StringLength(70)]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio. Por favor, indique su dirección.")]
        public string Direccion {  get; set; }
        [EmailAddress(ErrorMessage = "Por favor, agrega un correo electrónico válido.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio. Por favor, indique su correo electrónico.")]
        public string Correo_Electronico { get; set; }
        //[Phone(ErrorMessage = "Por favor, agrega un número de teléfono válido.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio. Por favor, indique su número de teléfono.")]
        [Display(Name = "Número de teléfono")]
        public int Num_Telefono { get; set; }
        //[CreditCard(ErrorMessage = "Por favor, agrega una tarjeta de crédito válido.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio. Por favor, indique su tarjeta de crédito.")] 
        public string Tarjeta_Credito { get; set; }

        [ForeignKey("Asignatura")]
        public int Asignatura_Id { get; set; }
        
        //public string Nombre_Asignatura { get; set; }
        //public Asignatura Profesores_Asignatura { get; set; }
    }
}
