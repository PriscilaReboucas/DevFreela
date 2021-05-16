using DevFreela.Core.Entities;
using DevFreela.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateProvidedService
{
    public class CreateProvidedServiceCommandHandler
        : IRequestHandler<CreateProvidedServiceCommand, CreateProvidedServiceViewModel>
    {
        private readonly IProvidedServiceRepository _providedServiceRepository;
        public CreateProvidedServiceCommandHandler(IProvidedServiceRepository providedServiceRepository)
        {
            _providedServiceRepository = providedServiceRepository;
        }

        public async Task<CreateProvidedServiceViewModel> Handle(CreateProvidedServiceCommand request, CancellationToken cancellationToken)
        {
            var providedService = new ProvidedService(request.Title, request.Description, request.IdClient, request.IdFreelancer, request.TotalCost);

            await _providedServiceRepository.Add(providedService);

            return new CreateProvidedServiceViewModel(providedService.Id, providedService.Title, providedService.Description, providedService.IdClient, providedService.IdFreelancer, providedService.TotalCost);
        }
    }
}
