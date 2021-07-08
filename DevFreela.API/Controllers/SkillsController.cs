using DevFreela.Application.Commands.CreateSkill;
using DevFreela.Application.Queries.GetAllSkills;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    public class SkillsController : ControllerBase
    {
        private readonly IMediator _mediator;
        //private readonly IMemoryCache _memoryCache;
        private const string GET_SKILLS_CACHE = "GET_SKILLS";

        public SkillsController(IMediator mediator/*, /*IMemoryCache memoryCache**/)
        {
            _mediator = mediator;
            //_memoryCache = memoryCache;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //if (_memoryCache.TryGetValue(GET_SKILLS_CACHE, out List<SkillViewModel> skills))
            //{
            //    return Ok(skills);
            //}

            var query = new GetAllSkillsQuery();

            var result = await _mediator.Send(query);

            //var memoryCacheOptions = new MemoryCacheEntryOptions
            //{
            //    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(3600),
            //    SlidingExpiration = TimeSpan.FromSeconds(1200)
            //};

            //_memoryCache.Set(GET_SKILLS_CACHE, result, memoryCacheOptions);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateSkillCommand createSkillCommand)
        {
            await _mediator.Send(createSkillCommand);

            return Ok();
        }
    }
}
