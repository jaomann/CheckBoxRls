using System;
using System.Collections.Generic;
using System.Text;

namespace CheckBox.Core.Contracts.entities
{
    public interface IBaseService<T>
    {
        void Create(T entity);
        void Delete(Guid id);
        T GetbyID(Guid id);
        IEnumerable<T> GetAll();
        void Update(T entity);

    }
}
