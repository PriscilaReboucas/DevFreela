namespace DevFreela.Application.Queries.GetUser
{
    public class UserSkillViewModel
    {
        public UserSkillViewModel(string description)
        {
            Description = description;
        }

        public string Description { get; private set; }
    }
}
