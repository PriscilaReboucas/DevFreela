using DevFreela.Core.Interfaces.Repositories;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetProvidedService
{
    public class GetProvidedServiceQueryHandler
        : IRequestHandler<GetProvidedServiceQuery, GetProvidedServiceViewModel>
    {
        private readonly IProvidedServiceRepository _providedServiceRepository;
        public GetProvidedServiceQueryHandler(IProvidedServiceRepository providedServiceRepository)
        {
            _providedServiceRepository = providedServiceRepository;
        }

        public async Task<GetProvidedServiceViewModel> Handle(GetProvidedServiceQuery request, CancellationToken cancellationToken)
        {
            var providedService = await _providedServiceRepository.GetById(request.IdProvidedService);

            var messages = providedService
                .Messages
                .Select(m => new MessageViewModel(m.Content, m.CreatedAt))
                .ToList();

            var getProvidedServiceViewModel = new GetProvidedServiceViewModel(
                providedService.Id,
                providedService.Title,
                providedService.Description,
                providedService.IdClient,
                providedService.Client.Name,
                providedService.IdFreelancer,
                providedService.Freelancer.Name,
                providedService.TotalCost,
                providedService.StartedAt,
                providedService.FinishedAt,
                providedService.Status,
                messages
                );

            return getProvidedServiceViewModel;
        }
    }
}
