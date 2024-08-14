using CheckBox.Core.Entities;
using System;
using System.Threading.Tasks;

namespace CheckBox.Core.Contracts.entities
{
    public interface IUserService : IBaseService<User>
    {
        Task<User> ValidateUser(User entity);
        Task<bool> Exists(string email);
        string GenerateHashCode(string entity);
        
    }
}
