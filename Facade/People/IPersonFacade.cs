using Application.People.Create;
using Application.Utilities;
using Query.People.DTOs;

namespace Facade.People
{
    public interface IPersonFacade
    {
        Task<OperationResult<long>> AddPersonAsync(CreatePersonCommand command);

        Task<ICollection<PersonDto>> GetPeopleAsync();
        Task<PersonDto> GetPersonAsync(long id);
    }
}
