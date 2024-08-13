using System.ComponentModel.DataAnnotations;

namespace InstitucionMVC.Models
{
    public class Asignatura
    {
        [Key]
        public int Asignatura_Id { get; set; }
        [Display(Name = "Nombre Asignatura")]
        public string Nombre_Asignatura { get; set; }
        [Display(Name = "Módulos")]
        public string Modulos { get; set; }
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
    }
}
