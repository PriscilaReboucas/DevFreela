using DevFreela.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.StartProvidedService
{
    public class StartProvidedServiceCommandHandler
        : IRequestHandler<StartProvidedServiceCommand, Unit>
    {
        private readonly IProvidedServiceRepository _providedServiceRepository;
        public StartProvidedServiceCommandHandler(IProvidedServiceRepository providedServiceRepository)
        {
            _providedServiceRepository = providedServiceRepository;
        }

        public async Task<Unit> Handle(StartProvidedServiceCommand request, CancellationToken cancellationToken)
        {
            var providedService = await _providedServiceRepository.GetById(request.IdProvidedService);

            providedService.Start();

            await _providedServiceRepository.SaveChanges();

            return Unit.Value;
        }
    }
}
