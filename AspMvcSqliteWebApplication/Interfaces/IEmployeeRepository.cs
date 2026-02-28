using AspMvcSqliteWebApplication.Entities;

namespace AspMvcSqliteWebApplication.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee?> GetById(Guid id);
        Task Add(Employee entity);
        Task Update(Employee entity);
        Task Delete(Guid id);
        Task<int> SaveChanges();
    }
}
