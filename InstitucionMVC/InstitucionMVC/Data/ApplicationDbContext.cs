using InstitucionMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace InstitucionMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Profesores> Profesores { get; set; }
        public DbSet<ProfesoresViewModel> profesoresViewModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Estudiante>().HasData(
                new Estudiante
                {
                    EstudianteId = 1,
                    Nombre = "Juan",
                    Apellidos = "Dela Cruz",
                    Edad = 16,
                    Fecha_Nacimiento = DateOnly.Parse("12/12/08"), 
                    Correo_Electronico = "Juan23@hotmail.com", 
                    Direccion = "Avenida Berry, Oviedo, City", 
                    Ultimo_Estudio_Realizado = "3 Eso", 
                    

                });

            modelBuilder.Entity<Matricula>().HasData(
                new Matricula
                {
                    MatriculaId = 1, 
                    Fecha_Matricula = DateOnly.Parse("12/08/24"),
                    Estudiante_Id = 1,
                    Asignatura_Id = 1,

                });

            modelBuilder.Entity<Curso>().HasData(
                new Curso
                {
                    CursoId = 1,
                    Nombre_Curso = "1 ESO", 
                    Matricula_Id = 1, 
                    Asignatura_Id = 1

                });

            modelBuilder.Entity<Asignatura>().HasData(
                new Asignatura
                {
                    Asignatura_Id = 1, 
                    Nombre_Asignatura = "Lengua Castellana Y Literatura", 
                    Descripcion = "Lorem ipsum", 
                    Modulos = "Lorem ipsum"
                });

            modelBuilder.Entity<Profesores>().HasData(
                new Profesores
                {
                    ProfesorId = 1,
                    Nombre = "Juana", 
                    Apellidos = "Dela Rosa", 
                    Correo_Electronico = "juana23@gmail.com", 
                    Num_Telefono = 603147973, 
                    Tarjeta_Credito = "4548812049400004", 
                    Asignatura_Id = 1, 
                    Direccion = "Calle Rosal Oviedo City"
                });

            modelBuilder.Entity<ProfesoresViewModel>().HasData(
                new ProfesoresViewModel
                {
                    ProfesorViewModelId = 1,
                    ProfesorId = 1,
                    Asignatura_Id = 1,
                    
                });

        }


    }


}
