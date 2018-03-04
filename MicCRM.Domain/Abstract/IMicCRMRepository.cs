using MicCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MicCRM.Domain.Abstract
{
    interface IMicCRMRepository<TEntity> : IDisposable where TEntity : class
    {
        void InsertOrUpdate(TEntity e);
        void Delete(int id);
        Task<int> SaveAsync();
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIDAsync(int id);
    }
}
 