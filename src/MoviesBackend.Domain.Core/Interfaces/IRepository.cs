using System;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesBackend.Domain.Core.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetById(int id);

        TEntity Create(TEntity entity);

        TEntity Update(TEntity entity);

        Task Delete(int id);

        Task<int> SaveChangesAsync();
    }
}