using System;
using System.Collections.Generic;
using System.Text;

namespace CheckBox.Core.Contracts.repositories
{
    public interface IBaseRepository<T>
    {
        void Add(T entity);
        void Delete(Guid id);
        T GetbyID(Guid id);
        IEnumerable<T> GetAll();
        void Update(T entity);
    }
}
