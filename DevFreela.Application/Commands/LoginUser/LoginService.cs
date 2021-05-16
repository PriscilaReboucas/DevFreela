using System.Security.Cryptography;
using System.Text;

namespace DevFreela.Application.Commands.LoginUser
{
    public static class LoginService
    {
        public static string ComputeSha256Hash(string rawData)
        {
            // Cria um hash SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - retorna byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Converte byte array para string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2")); // x2 faz com que seja convertido (bytes) em representação hexadecimal
                }

                return builder.ToString();
            }
        }
    }
}