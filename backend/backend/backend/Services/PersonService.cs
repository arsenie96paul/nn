using backend.Models; 
using backend.Database; 
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class PersonService
    {
        private readonly IDbContextFactory<BackendDbContext> _contextFactory;

        public PersonService(IDbContextFactory<BackendDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public virtual List<Person> GetAllPeople()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.People.ToList();
            }
        }

        public int AddPerson(string name)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var person = new Person { Name = name }; 
                context.People.Add(person); 
                context.SaveChanges(); 
                return person.PersonId;
            }
        }

        public Person GetPerson(int personId)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.People.FirstOrDefault(p => p.PersonId == personId); 
            }
        }
    }
}
