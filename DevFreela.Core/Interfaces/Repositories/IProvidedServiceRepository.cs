using DevFreela.Core.Entities;
using System.Threading.Tasks;

namespace DevFreela.Core.Interfaces.Repositories
{
    public interface IProvidedServiceRepository
    {
        Task Add(ProvidedService providedService);
        Task<ProvidedService> GetById(int id);
        Task AddMessage(ProvidedServiceMessage message);
        Task SaveChanges();
    }
}
