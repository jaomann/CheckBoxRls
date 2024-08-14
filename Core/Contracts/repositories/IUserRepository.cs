using CheckBox.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CheckBox.Core.Contracts.repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<bool> Exists(string email);
        Task<User> GetbyEmail(string email);
    }
}
