namespace DevFreela.Application.Commands.CreateProvidedService
{
    public class CreateProvidedServiceViewModel
    {
        public CreateProvidedServiceViewModel(int id, string title, string description, int idClient, int idFreelancer, decimal totalCost)
        {
            Id = id;
            Title = title;
            Description = description;
            IdClient = idClient;
            IdFreelancer = idFreelancer;
            TotalCost = totalCost;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int IdClient { get; private set; }
        public int IdFreelancer { get; private set; }
        public decimal TotalCost { get; private set; }
    }
}
