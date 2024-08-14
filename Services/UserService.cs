using CheckBox.Core.Contracts.entities;
using CheckBox.Core.Contracts.repositories;
using CheckBox.Core.Entities;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckBox.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository):base(userRepository)
        {
            _userRepository = userRepository;
        }

        public string GenerateHashCode(string entity)
        {
            var md5 = MD5.Create();
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(entity);
            byte[] hash = md5.ComputeHash(bytes);

            var sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public async Task<User> ValidateUser(User entity)
        {
            var real_user = await _userRepository.GetbyEmail(entity.Email);
            if (real_user is not null && real_user.Password.Equals(GenerateHashCode(entity.Password)))
                return real_user;
            return null;
            
        }
        public override void Create(User entity)
        {
            _userRepository.Add(entity);
        }

        public async Task<bool> Exists(string email)
        {
            return await _userRepository.Exists(email);
        }
    }
}
