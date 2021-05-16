using DevFreela.Core.Enums;
using DevFreela.Core.Exceptions;
using System;
using System.Collections.Generic;

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
            Messages = new List<ProvidedServiceMessage>();
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public int IdClient { get; private set; }
        public User Client { get; private set; }
        public int IdFreelancer { get; private set; }
        public User Freelancer { get; private set; }
        public decimal TotalCost { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public void Start()
        {
            if (Status != StatusProvidedServiceEnum.Pending)
            {
                throw new InvalidStatusException(nameof(ProvidedService));
            }

            Status = StatusProvidedServiceEnum.Started;
            StartedAt = DateTime.Now;
        }

        public DateTime? StartedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
        public StatusProvidedServiceEnum Status { get; private set; }
        public List<ProvidedServiceMessage> Messages { get; private set; }
    }
}
