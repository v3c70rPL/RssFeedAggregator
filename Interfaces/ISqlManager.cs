using System.Threading.Tasks;
using System.Collections.Generic;
using RssFeedAggregator.Domain;


namespace RssFeedAggregator.Interfaces
{
    public interface ISqlManager<T> where T : ModelBase
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Add(T model);
        Task<T> Update(T model);
        Task Delete(T model);
        Task<bool> IsAlive();
    }
}