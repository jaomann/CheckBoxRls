using CheckBox.Core.Contracts.repositories;
using CheckBox.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckBox.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : EntityBase
    {
        private readonly Context _context;
        public BaseRepository(Context context)
        {
            this._context = context;
        }

        public async void Add(T entity)
        {
            var dbset = this._context.Set<T>();
            dbset.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async void Delete(uint id)
        {
            var entity = await GetbyID(id);
            if (entity != null)
            {
                entity.Inactive = true;
                _context.Set<T>().Update(entity);
                await _context.SaveChangesAsync();
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public async Task<T> GetbyID(uint id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
