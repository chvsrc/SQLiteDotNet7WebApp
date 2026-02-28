using AspMvcSqliteWebApplication.DatabaseContexts;
using AspMvcSqliteWebApplication.Entities;
using AspMvcSqliteWebApplication.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AspMvcSqliteWebApplication.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly CompanyContext context;
        private readonly DbSet<Department> dbSet;

        public DepartmentRepository(CompanyContext context)
        {
            this.context = context;
            dbSet = context.Set<Department>();
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<Department?> GetById(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task Add(Department entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task Update(Department entity)
        {
            Department? entityData = await dbSet.FindAsync(entity.Id);
            if (entityData != null)
            {
                dbSet.Remove(entityData);
                await dbSet.AddAsync(entity);
            }
        }

        public async Task Delete(Guid id)
        {
            Department? entity = await dbSet.FindAsync(id);
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
