using Domain.People;
using Domain.People.Repository;
using Infrastructure.Utilities;

namespace Infrastructure.Persistent.EF.People
{
    public class PersonRepository : BaseRepository<Person> , IPersonRepository
    {
        public PersonRepository(ClinicContext context) : base(context)
        {
        }
    }
}
