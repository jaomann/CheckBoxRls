using CheckBox.Core.Contracts.repositories;
using CheckBox.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckBox.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : EntityBase
    {
        private readonly Context _context;
        public BaseRepository(Context context)
        {
            this._context = context;
        }

        public void Add(T entity)
        {
            var dbset = this._context.Set<T>();
            dbset.Add(entity);
            this._context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var entity = GetbyID(id);
            if (entity != null)
            {
                _context.Remove(entity);
                _context.SaveChanges();
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T GetbyID(Guid id)
        {
            return _context.Set<T>().FirstOrDefault( x => x.Id == id);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}
