using MediatR;

namespace DevFreela.Application.Commands.LoginUser
{
    /// <summary>
    /// Classe retorna o LoginUserViewModel
    /// </summary>
    public class LoginUserCommand
        : IRequest<LoginUserViewModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
