using AspMvcSqliteWebApplication.Entities;

namespace AspMvcSqliteWebApplication.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAll();
        Task<Department?> GetById(Guid id);
        Task Add(Department entity);
        Task Update(Department entity);
        Task Delete(Guid id);
        Task<int> SaveChanges();
    }
}
