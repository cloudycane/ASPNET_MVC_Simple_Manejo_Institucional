using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstitucionMVC.Models
{
    public class Curso
    {
        [Key]
        public int CursoId { get; set; }
        [Display(Name = "Nombre del Curso")]
        public string Nombre_Curso { get; set; }
        [ForeignKey("Matricula")]
        public int Matricula_Id { get; set; }
       // public Matricula Curso_Matricula { get; set; }
        [ForeignKey("Asignatura")]
        public int Asignatura_Id { get; set; }
        //public Asignatura Curso_Asignatura { get; set; }
    }
}
