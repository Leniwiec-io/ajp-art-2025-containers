using DockerLoadBalancing.Domain;
using DockerLoadBalancing.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockerLoadBalancing.Infrastructure.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        PeopleContext _context;
        public PeopleRepository(PeopleContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }
        public async Task<IEnumerable<Person>> GetPeopleAsync()
        {
            var output = await _context.People.ToListAsync();
            return output;
        }

        public async Task AddPerson(Person person)
        {
            await _context.People.AddAsync(person);
            await _context.SaveChangesAsync();
        }
    }
}
