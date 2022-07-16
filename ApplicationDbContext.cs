using Microsoft.EntityFrameworkCore;
using WebApiAutores.Entidades;

namespace WebApiAutores
{
    public class ApplicationDbContext: DbContext
    {
        

        //constructor  a travez del cual se puede pasar config para EF
        public ApplicationDbContext(DbContextOptions options) : base(options)// puedo pasar cosas como ConnectionString que va a apuntar a base de datos
        {

        }


        //API FLUENT PARA CONFIGURAR CLAVES COMPUESTAS
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Assistance>()
                .HasKey(ass => new { ass.CourseId , ass.UserId } );

            base.OnModelCreating(modelBuilder);
        }

        //configurar las tablas o entidades a generar a travez de commands de EntityF
        public  DbSet<Autor> Autores { get; set; }//le digo creame una tabla a partir del schema o props de clase Autor
        public DbSet<Libro> Libros { get; set; }// ESTO es opcional pero me da comodidad a la horad etrabajar para poder hacer querys directamente o especifica a la tabla de libros tuviera que trabajar a travez d ela tabla de autores

        public DbSet<User> Users { get; set; }

        public DbSet<UserType> UserTypes { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Class> Classes { get; set; }

        public DbSet<Assistance> Assistances { get; set; }
    }
}
