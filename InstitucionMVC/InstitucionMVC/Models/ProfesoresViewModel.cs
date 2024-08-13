using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstitucionMVC.Models
{
    public class ProfesoresViewModel
    {
        [Key]
        public int ProfesorViewModelId { get; set; }
        public int ProfesorId { get; set; }
        [NotMapped]
        public string Nombre_Profesor { get; set; }
        public int Asignatura_Id { get; set; }
        [NotMapped]
        public string Nombre_Asignatura { get; set; } 


    }
}
