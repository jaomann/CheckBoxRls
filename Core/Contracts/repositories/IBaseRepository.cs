using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CheckBox.Core.Contracts.repositories
{
    public interface IBaseRepository<T>
    {
        Task Add(T entity);
        Task Delete(uint id);
        Task<T> GetbyID(uint id);
        IEnumerable<T> GetAll();
        Task Update(T entity);
    }
}
