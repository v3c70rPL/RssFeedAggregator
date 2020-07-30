using RssFeedAggregator.Domain;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RssFeedAggregator.Interfaces
{
    public interface ISqlRepository<T> where T : ModelBase
    {
        T Add(T model);
        T Update(T model);
        void Delete(int id);
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<int> SaveChangesAsync();
    }
}