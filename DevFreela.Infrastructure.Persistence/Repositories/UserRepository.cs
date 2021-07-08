using Dapper;
using DevFreela.Core.Entities;
using DevFreela.Core.Interfaces.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly string _connectionString;

        public UserRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
            _connectionString = _dbContext.Database.GetDbConnection().ConnectionString;
        }

        public async Task Add(User user)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                // definindo um script, utilizando o dapper, apos add do pacote.
                var sql = "INSERT INTO USERS (Name,Email,BirthDate, Active, Password, Role,CreatedAt) " +
                    "OUTPUT INSERTED.[Id] " +
                    "VALUES (@name,@email,@birthdate,@active,@password,@role,GETDATE())";

                // quando as propriedade nao possuirem o mesmo nome da entidade
                //var id = await sqlConnection.QuerySingleAsync<int>(sql,
                //    new
                //    {
                //        name = user.Name,
                //        email = user.Email,
                //        birthdate = user.BirthDate,
                //        active = user.Active,
                //        password = user.Password,
                //        role = user.Role
                //    });

                var id = await sqlConnection.QuerySingleAsync<int>(sql, user);


                // se a lista de skills tiver preenchida
                var insertSkills = @"INSERT INTO UsersSkills VALUES(@IdUser, @IdSkill)";

                foreach (var item in user.UserSkills)
                {
                    var totalRows = await sqlConnection.ExecuteAsync(insertSkills, new { IdUser = id, IdSkill = item.IdSkill });

                }

            }


            //utilizando entity framework
            //await _dbContext.Users.AddAsync(user);
            //await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetById(int id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Users WHERE Id = @id";
                return await sqlConnection.QuerySingleOrDefaultAsync<User>(sql, new { id });
            }
            //utilizando EF
            //return await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetUserByLogin(string email, string password)
        {

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                //usando o Dapper
                var sql = "SELECT * FROM Users WHERE email = @email and password = @password";
                return await sqlConnection.QueryFirstOrDefaultAsync<User>(sql, new { email, password });

            }

            // usando o entity framework
            // return await _dbContext.Users
            //.SingleOrDefaultAsync(
            //    u => u.Email == email &&
            //    u.Password == password
            //    );
        }
    }
}
