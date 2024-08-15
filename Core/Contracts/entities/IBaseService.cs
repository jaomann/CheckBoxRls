using System;
using System.Collections.Generic;
using System.Text;

namespace CheckBox.Core.Contracts.entities
{
    public interface IBaseService<T>
    {
        void Create(T entity);
        void Delete(uint id);
        T GetbyID(uint id);
        IEnumerable<T> GetAll();
        void Update(T entity);

    }
}
