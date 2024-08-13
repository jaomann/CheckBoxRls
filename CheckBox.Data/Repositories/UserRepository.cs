using CheckBox.Core.Contracts.repositories;
using CheckBox.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CheckBox.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly Context _context;
        public UserRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> Exists(string email)
        {
            return await _context.Set<User>().AnyAsync(x => x.Email == email);
        }
        public async Task<User> GetbyEmail(string email)
        {
            return await _context.Set<User>().FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
