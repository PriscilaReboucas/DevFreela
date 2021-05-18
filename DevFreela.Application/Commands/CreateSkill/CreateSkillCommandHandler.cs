using DevFreela.Core.Entities;
using DevFreela.Core.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateSkill
{
    public class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommand, Unit>
    {
        private readonly ISkillRepository _skillRepository;
        public CreateSkillCommandHandler(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<Unit> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {
            var skill = new Skill(request.Description);

            await _skillRepository.Add(skill);

            return Unit.Value;
        }
    }
}
