using DevFreela.Core.Enums;
using System;

namespace DevFreela.Core.Entities
{
    public class ProvidedService : BaseEntity
    {
        public ProvidedService(string title, string description, int idClient, int idFreelancer, decimal totalCost)
        {
            Title = title;
            Description = description;
            IdClient = idClient;
            IdFreelancer = idFreelancer;
            CreatedAt = DateTime.Now;
            TotalCost = totalCost;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public int IdClient { get; private set; }
        /// <summary>
        /// Propriedade de Navegação Client
        /// </summary>
        public User Client { get; private set; }
        public int IdFreelancer { get; private set; }
        /// <summary>
        /// Propriedade de Navegação Freelancer
        /// </summary>
        public User Freelancer { get; private set; }
        public decimal TotalCost { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
        public StatusProvidedServiceEnum Status { get; private set; }
    }
}
