namespace WebApiAutores.Entidades
{
    public class Autor
    {
        public int Id { get; set; }

        public string  Nombre  { get; set; }

        public List<Libro> Libros { get; set; }//propiedad de navegacion me permite cargar los libros de un autor 
    }
}
