using MediatR;

namespace DevFreela.Application.Commands.StartProvidedService
{
    public class StartProvidedServiceCommand : IRequest<Unit>
    {
        public StartProvidedServiceCommand(int id)
        {
            IdProvidedService = id;
        }

        public int IdProvidedService { get; private set; }
    }
}
