using System;
using System.Collections.Generic;

namespace DevFreela.Core.Entities
{
    public class User : BaseEntity
    {
        protected User() { }
        public User(string name, string email, DateTime birthDate, string password, string role)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            CreatedAt = DateTime.Now;
            UserSkills = new List<UserSkill>();
            ProvidedServices = new List<ProvidedService>();
            OwningProvidedServices = new List<ProvidedService>();
            Active = true;
            Password = password;
            Role = role;

        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public List<UserSkill> UserSkills { get; private set; }
        public List<ProvidedService> ProvidedServices { get; private set; } // serviços que oferece
        public List<ProvidedService> OwningProvidedServices { get; private set; } // lista de servidos que ele é o dono/cliente.
        public bool Active { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
    }
}
