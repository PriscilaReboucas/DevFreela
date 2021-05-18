using Dapper;
using DevFreela.Core.Entities;
using DevFreela.Core.Interfaces.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly string _connectionString;

        public SkillRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
            _connectionString = _dbContext.Database.GetDbConnection().ConnectionString;
        }

        public async Task Add(Skill skill)

        {
            //utilizando o entityFramwork
            //_dbContext.Skills.Add(skill);
            //_dbContext.SaveChanges();


            //recebendo como parâmetro a connection string
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                // definindo um script, utilizando o dapper, apos add do pacote.
                var sql = "INSERT INTO Skills (Description, CreatedAt) VALUES (@description, GETDATE())";

                // executando o comando passando o parametro description.
                await sqlConnection.ExecuteAsync(sql, new { description = skill.Description });
            }
        }

        // utilizando o Dapper
        public async Task<List<Skill>> GetAll()
        {
            
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                //utilizando o dapper
                var sql = "SELECT Id, Description, CreatedAt FROM Skills";              
                var result = await sqlConnection.QueryAsync<Skill>(sql);               
                return result.ToList();
            }

            //return await _dbContext.Skills.ToListAsync();
        }
    }
}
