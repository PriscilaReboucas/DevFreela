using MediatR;
using System;

namespace DevFreela.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<CreateUserViewModel>
    {
        public CreateUserCommand(string name, string email, DateTime birthDate, string password, string role)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Password = password;
            Role = role;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
