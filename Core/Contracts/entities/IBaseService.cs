using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CheckBox.Core.Contracts.entities
{
    public interface IBaseService<T>
    {
        Task Create(T entity);
        Task Delete(uint id);
        Task<T> GetbyID(uint id);
        IEnumerable<T> GetAll();
        Task Update(T entity);

    }
}
