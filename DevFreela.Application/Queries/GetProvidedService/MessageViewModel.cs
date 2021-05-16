using System;

namespace DevFreela.Application.Queries.GetProvidedService
{
    public class MessageViewModel
    {
        public MessageViewModel(string content, DateTime createdAt)
        {
            Content = content;
            CreatedAt = createdAt;
        }

        public string Content { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
