using DevFreela.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevFreela.Core.Interfaces.Repositories
{
    public interface ISkillRepository
    {
        Task<List<Skill>> GetAll();
        Task Add(Skill skill);
    }
}
