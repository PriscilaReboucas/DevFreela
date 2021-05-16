using DevFreela.Core.Entities;
using DevFreela.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class ProvidedServiceRepository : IProvidedServiceRepository
    {
        private readonly DevFreelaDbContext _dbContext;
        public ProvidedServiceRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(ProvidedService providedService)
        {
            await _dbContext.ProvidedServices.AddAsync(providedService);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddMessage(ProvidedServiceMessage message)
        {
            await _dbContext.AddAsync(message);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ProvidedService> GetById(int id)
        {
            return await _dbContext
                .ProvidedServices
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .Include(p => p.Messages)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
