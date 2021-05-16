namespace DevFreela.Application.Commands.LoginUser
{
    /// <summary>
    /// Classe retorna as informações para o usuário que logou
    /// </summary>
    public class LoginUserViewModel
    {
        public LoginUserViewModel(string email, string token)
        {
            Email = email;
            Token = token;
        }

        public string Email { get; private set; }
        public string Token { get; private set; }
    }
}
