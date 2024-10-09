using DockerLoadBalancing.Domain;

namespace DockerLoadBalancing.Infrastructure.Repositories
{
    public interface IPeopleRepository
    {
        Task AddPerson(Person person);
        Task<IEnumerable<Person>> GetPeopleAsync();
    }
}