using DevFreela.Core.Entities;
using System.Threading.Tasks;

namespace DevFreela.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task Add(User user);
        Task<User> GetById(int id);
        Task<User> GetUserByLogin(string email, string password);
    }
}
