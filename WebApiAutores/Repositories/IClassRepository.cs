using WebApiAutores.Entidades;

namespace WebApiAutores.Repositories
{
    public interface IClassRepository
    {
        public void AddClass(Class classes);

        public Task<IEnumerable<Class>> GetAllClasses();

        public Task<IEnumerable<Class>> GetClassessByTitle(string Title);

        public Class GetClassById(int id);

        public Class EditClass(Class classes);

        public Task<IEnumerable<Class>> GetClassesByCourse(int Id);

    }
}
