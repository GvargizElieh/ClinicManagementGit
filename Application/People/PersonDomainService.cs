using Domain.People.Repository;
using Domain.People.Services;

namespace Application.People
{
    public class PersonDomainService : IPersonDomainService
    {
        private readonly IPersonRepository repository;

        public PersonDomainService(IPersonRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> IsNationalIdDuplicated(string nationalId)
        {
            return await repository.ExistsAsync(person => person.NationalId == nationalId);
        }
    }
}
