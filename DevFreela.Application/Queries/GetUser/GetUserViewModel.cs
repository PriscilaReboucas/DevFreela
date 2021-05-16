using System.Collections.Generic;

namespace DevFreela.Application.Queries.GetUser
{
    public class GetUserViewModel // modelo de dados retornado para api para cliente, informações que serão retornadas do usuário
    {
        public GetUserViewModel(int id, string name, List<UserSkillViewModel> userSkills)
        {
            Id = id;
            Name = name;
            UserSkills = userSkills;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public List<UserSkillViewModel> UserSkills { get; private set; }
    }
}
