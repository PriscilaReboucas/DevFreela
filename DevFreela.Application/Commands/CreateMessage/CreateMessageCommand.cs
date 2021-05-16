using MediatR;

namespace DevFreela.Application.Commands.CreateMessage
{
    public class CreateMessageCommand : IRequest<Unit>
    {
        public CreateMessageCommand(int idProvidedService, string content)
        {
            IdProvidedService = idProvidedService;
            Content = content;
        }

        public int IdProvidedService { get; private set; }
        public string Content { get; private set; }
    }
}
