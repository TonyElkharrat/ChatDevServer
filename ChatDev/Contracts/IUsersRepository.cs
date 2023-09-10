using ChatDev.Data;

namespace ChatDev.Contracts
{
    public interface IUsersRepository : IGenericRepository<User>
    {
        Task<User> GetUserByEmail(string email);
    }
}
