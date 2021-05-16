using MediatR;

namespace DevFreela.Application.Queries.GetProvidedService
{
    public class GetProvidedServiceQuery : IRequest<GetProvidedServiceViewModel>
    {
        public GetProvidedServiceQuery(int id)
        {
            IdProvidedService = id;
        }

        public int IdProvidedService { get; private set; }
    }
}
