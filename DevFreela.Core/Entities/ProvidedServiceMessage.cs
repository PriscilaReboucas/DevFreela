using System;

namespace DevFreela.Core.Entities
{
    public class ProvidedServiceMessage : BaseEntity
    {
        public ProvidedServiceMessage(string content, int idProvidedService)
        {
            Content = content;
            IdProvidedService = idProvidedService;
            CreatedAt = DateTime.Now;
        }

        public string Content { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public int IdProvidedService { get; private set; }
    }
}
