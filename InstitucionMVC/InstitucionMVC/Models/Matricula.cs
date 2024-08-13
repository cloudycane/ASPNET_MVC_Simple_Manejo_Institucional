using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstitucionMVC.Models
{
    public class Matricula
    {
        [Key]
        public int MatriculaId { get; set; }
        [Required]
        [Display(Name = "Fecha de Matricula")]
        public DateOnly Fecha_Matricula {  get; set; }
        [ForeignKey("Estudiante")]
        public int Estudiante_Id { get; set; }
        //public Estudiante Matricula_Estudiante { get; set; }
        [ForeignKey("Asignatura")]
        public int Asignatura_Id { get; set; }
        //public Asignatura Matricula_Asignatura { get; set; }

    }
}
