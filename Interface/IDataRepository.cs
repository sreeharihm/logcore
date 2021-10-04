using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IotLog.Interface
{
    public interface IDataRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Get(long id);
        Task Add(List<TEntity> entity);
        Task Update(TEntity dbEntity, TEntity entity);
        Task Delete(TEntity entity);
    }
}
