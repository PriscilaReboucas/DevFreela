using DevFreela.Core.Interfaces.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.LoginUser
{
    /// <summary>
    /// Classe que realiza as operações de login recebe LoginUserCommand e o tipo de retorno LoginUserViewModel
    /// </summary>
    public class LoginUserCommandHandler
        : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public LoginUserCommandHandler(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        /// <summary>
        /// Handler vem do mediator e vai ser chamado quando invocer o send, executando a lógica da aplicação
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            //encriptar a senha recebida na requisição.
            var encryptedPassword = LoginService.ComputeSha256Hash(request.Password);

            //buscando no banco de dados o usuário que possua o email e o password.         
            var user = await _userRepository.GetUserByLogin(request.Email, encryptedPassword);

            if (user == null)
            {
                return null;
            }

            return new LoginUserViewModel(user.Email, GenerateJwtToken(user.Email, user.Role));
        }

        /// <summary>
        /// Obtem os parametros do JWT Retorna uma string 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        private string GenerateJwtToken(string email, string role)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            // gera encriptação para o key "MinhaChaveSecreta"
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //criando os claims, informação que estará no token.
            var claims = new List<Claim>
            {
                new Claim("userName", email),
                new Claim(ClaimTypes.Role, role)
            };

            var token = new JwtSecurityToken(issuer: issuer, audience: audience,
expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials, claims: claims);

            var tokenHandler = new JwtSecurityTokenHandler();

            var stringToken = tokenHandler.WriteToken(token);

            // retorna todas as informações transformadas em token.
            return stringToken;
        }

    }
}
