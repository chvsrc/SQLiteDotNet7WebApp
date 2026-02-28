using AspMvcSqliteWebApplication.DatabaseContexts;
using AspMvcSqliteWebApplication.Entities;
using AspMvcSqliteWebApplication.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AspMvcSqliteWebApplication.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly CompanyContext context;
        private readonly DbSet<Employee> dbSet;

        public EmployeeRepository(CompanyContext context)
        {
            this.context = context;
            dbSet = context.Set<Employee>();
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<Employee?> GetById(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task Add(Employee entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task Update(Employee entity)
        {
            Employee? entityData = await dbSet.FindAsync(entity.Id);
            if (entityData != null)
            {
                dbSet.Remove(entityData);
                await dbSet.AddAsync(entity);
            }
        }

        public async Task Delete(Guid id)
        {
            Employee? entity = await dbSet.FindAsync(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
            }
        }

        public async Task<int> SaveChanges()
        {
            return await context.SaveChangesAsync();
        }
    }
}
