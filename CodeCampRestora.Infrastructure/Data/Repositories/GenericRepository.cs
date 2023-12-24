using CodeCampRestora.Application.Common.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Infrastructure.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        public Task<T?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
