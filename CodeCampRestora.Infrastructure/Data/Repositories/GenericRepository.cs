using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace CodeCampRestora.Infrastructure.Data.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _blogDbContext;

        public GenericRepository(AppDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await _blogDbContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _blogDbContext.Set<T>().FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _blogDbContext.Set<T>().AddAsync(entity);
            await _blogDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await GetByIdAsync(id);
            if (result is null)
            {
                return;
            }
            _blogDbContext.Set<T>().Remove(result);
            await _blogDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, T entity)
        {
            _blogDbContext.Set<T>().Update(entity);
            await _blogDbContext.SaveChangesAsync();
        }
    }
}
