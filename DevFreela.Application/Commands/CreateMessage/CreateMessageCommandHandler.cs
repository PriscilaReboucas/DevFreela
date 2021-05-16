using DevFreela.Core.Entities;
using DevFreela.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateMessage
{
    public class CreateMessageCommandHandler
        : IRequestHandler<CreateMessageCommand, Unit>
    {
        private readonly IProvidedServiceRepository _providedServiceRepository;
        public CreateMessageCommandHandler(IProvidedServiceRepository providedServiceRepository)
        {
            _providedServiceRepository = providedServiceRepository;
        }

        public async Task<Unit> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var message = new ProvidedServiceMessage(request.Content, request.IdProvidedService);

            await _providedServiceRepository.AddMessage(message);

            return Unit.Value;
        }
    }
}
