using WebApiAutores.DTOS;
using WebApiAutores.Entidades;

namespace WebApiAutores.Services
{
    public interface IClassService
    {
        public void AddClass(ClassCreacionDTO classes); //AddCourse

        public Task<IEnumerable<ClassDTO>> GetAllClasses();

        public Task<IEnumerable<ClassDTO>> GetClassesByTitle(string Title);

        public ClassDTO GetClassById(int Id);

        public Task<IEnumerable<ClassCreacionDTO>> GetClassesByCourse(int Id);



        public Class EditClass(int Id, ClassDTO classes); //EditCourse
    }
}
