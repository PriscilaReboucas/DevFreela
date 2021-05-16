using DevFreela.Core.Entities;
using System.Threading.Tasks;

namespace DevFreela.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task Add(User user);
    }
}
