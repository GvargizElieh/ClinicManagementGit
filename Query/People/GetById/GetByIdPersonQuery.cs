using Query.People.DTOs;
using Query.Utilities;

namespace Query.People.GetById
{
    public record GetByIdPersonQuery(long PersonId) : IBaseQuery<PersonDto>;
}
