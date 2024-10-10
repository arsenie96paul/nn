using backend.Models; 
using backend.Database;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class AddressService
    {
        private readonly IDbContextFactory<BackendDbContext> _contextFactory;

        public AddressService(IDbContextFactory<BackendDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public List<Address> GetAddressesByPersonId(int personId)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return context.Addresses
                    .Where(a => a.PersonId == personId)
                    .ToList(); 
            }
        }
    }
}
