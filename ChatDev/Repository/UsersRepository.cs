using ChatDev.Contracts;
using ChatDev.Data;
using Microsoft.EntityFrameworkCore;

namespace ChatDev.Repository
{
    public class UsersRepository : GenericRepository<User>,IUsersRepository
    {
       private readonly ChatDevDbContext _context;
        public UsersRepository(ChatDevDbContext chatDevDbContext) : base(chatDevDbContext)
        {
                this._context = chatDevDbContext;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
     
    }
}
