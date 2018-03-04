using MicCRM.Domain.Abstract;
using MicCRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MicCRM.Domain.Concrete
{
    public class MicCRMRepository<TEntity> : IMicCRMRepository<TEntity> where TEntity : Entity
    {

       internal readonly MicCRMContext _context;

        public List<TEntity> GetAll()
        {
            List<TEntity> List = null;
            List = _context.Set<TEntity>().ToList();
            return List;
        }
        public MicCRMRepository()
        {
            _context = new MicCRMContext();
        }
        
        public async virtual void Delete(int id)
        {
            var entity = await GetByIDAsync(id);
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public virtual void InsertOrUpdate(TEntity e)
        {
            _context.Entry(e).State = e.ID == 0 ?
                                       EntityState.Added :
                                       EntityState.Modified;
        }
        public void Insert(TEntity e)
        { 
            _context.Entry(e).State = EntityState.Added;
        } 
        public void Update(TEntity e)
        {
            _context.Entry(e).State = EntityState.Modified;
        } 
        public async virtual Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async virtual Task<TEntity> GetByIDAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
        public async virtual Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
         
        public async void Update(int id)
        {
            TEntity t = await _context.Set<TEntity>().FindAsync(id);
            _context.Entry(t).State = EntityState.Modified; 
        }
        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

      
        #endregion
    }
}
