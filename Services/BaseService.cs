using CheckBox.Core.Contracts.entities;
using CheckBox.Core.Contracts.repositories;
using CheckBox.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CheckBox.Services
{
    public class BaseService<T> : IBaseService<T> where T : EntityBase
    {
        private readonly IBaseRepository<T> _baseRepository;
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public virtual void Create(T entity)
        {
            _baseRepository.Add(entity);
        }

        public void Delete(uint id)
        {
            _baseRepository.Delete(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public async Task<T> GetbyID(uint id)
        {
            return await _baseRepository.GetbyID(id);
        }
        public void Update(T entity)
        {
            _baseRepository.Update(entity);
        }
    }
}
