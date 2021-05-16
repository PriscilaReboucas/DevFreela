using MediatR;

namespace DevFreela.Application.Commands.CreateProvidedService
{
    public class CreateProvidedServiceCommand : IRequest<CreateProvidedServiceViewModel>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int IdClient { get; set; }
        public int IdFreelancer { get; set; }
        public decimal TotalCost { get; set; }
    }
}
