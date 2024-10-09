using DockerLoadBalancing.Domain;
using DockerLoadBalancing.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DockerLoadBalancing.UI.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        IPeopleRepository _peopleRepository { get; set; }
        public PeopleController(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Person>> GetPeopleAsync()
        {
            return await _peopleRepository.GetPeopleAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddPerson([FromBody] Person person)
        {
            await _peopleRepository.AddPerson(person);
            return Ok();
        }
    }
}
