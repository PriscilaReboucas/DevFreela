using DevFreela.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreela.Application.Queries.GetProvidedService
{
    public class GetProvidedServiceViewModel
    {
        public GetProvidedServiceViewModel(
            int id, 
            string title, 
            string description, 
            int idClient, 
            string client, 
            int idFreelancer, 
            string freelancer, 
            decimal totalCost, 
            DateTime? startedAt,
            DateTime? finishedAt,
            StatusProvidedServiceEnum status,
            List<MessageViewModel> messages)
        {
            Id = id;
            Title = title;
            Description = description;
            IdClient = idClient;
            Client = client;
            IdFreelancer = idFreelancer;
            Freelancer = freelancer;
            TotalCost = totalCost;
            StartedAt = startedAt;
            FinishedAt = finishedAt;
            Status = status;
            Messages = messages;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int IdClient { get; private set; }
        public string Client { get; private set; }
        public int IdFreelancer { get; private set; }
        public string Freelancer { get; private set; }
        public decimal TotalCost { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
        public StatusProvidedServiceEnum Status { get; private set; }
        public List<MessageViewModel> Messages { get; private set; }
    }
}
