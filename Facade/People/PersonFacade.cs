using Application.People.Create;
using Application.Utilities;
using MediatR;
using Query.People.DTOs;
using Query.People.GetAll;
using Query.People.GetById;

namespace Facade.People
{
    public class PersonFacade : IPersonFacade
    {
        private readonly IMediator mediator;

        public PersonFacade(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<OperationResult<long>> AddPersonAsync(CreatePersonCommand command)
        {
            return await mediator.Send(command);
        }

        public async Task<ICollection<PersonDto>> GetPeopleAsync()
        {
            return await mediator.Send(new GetAllPersonQuery());
        }

        public async Task<PersonDto> GetPersonAsync(long id)
        {
            return await mediator.Send(new GetByIdPersonQuery(id));
        }
    }
}
