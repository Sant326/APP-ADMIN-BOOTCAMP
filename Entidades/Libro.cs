namespace WebApiAutores.Entidades
{
    public class Libro
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public int AutorId { get; set; }

        public Autor Autor { get; set; } // PROPIEDAD DE NAVEGACION PEMRITE CARGAR DESDE LIBRO LA DATA DEL AUTOR QUE ESCRIBIO EL LIBRO


    }
}
