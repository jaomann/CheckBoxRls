using System;
using System.Collections.Generic;
using System.Text;

namespace CheckBox.Core.Contracts.repositories
{
    public interface IBaseRepository<T>
    {
        void Add(T entity);
        void Delete(uint id);
        T GetbyID(uint id);
        IEnumerable<T> GetAll();
        void Update(T entity);
    }
}
