using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace CodeCampRestora.Infrastructure.Data.Repositories;

public class GenericRepository<T> : IRepository<T> where T : class
{
    private readonly AppDbContext _applicationDbContext;

    public GenericRepository(AppDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<IList<T>> GetAllAsync()
    {
        return await _applicationDbContext.Set<T>().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _applicationDbContext.Set<T>().FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await _applicationDbContext.Set<T>().AddAsync(entity);
        await _applicationDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var result = await GetByIdAsync(id);
        if (result is null)
        {
            return;
        }
        _applicationDbContext.Set<T>().Remove(result);
        await _applicationDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, T entity)
    {
        _applicationDbContext.Set<T>().Update(entity);
        await _applicationDbContext.SaveChangesAsync();
    }
}
