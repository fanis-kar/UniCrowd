using Model;

namespace Authentication.API.Services
{
    public interface IUserRepository
    {
        User GetUser(int id);
        User GetUserByUsername(string username);
        void AddUser(User user);
        bool UniqueUsername(string username);
        bool UniqueEmail(string email);
    }
}
