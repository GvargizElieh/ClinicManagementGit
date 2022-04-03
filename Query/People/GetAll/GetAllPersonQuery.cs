using Query.People.DTOs;
using Query.Utilities;

namespace Query.People.GetAll
{
    public record GetAllPersonQuery : IBaseQuery<ICollection<PersonDto>>;
}
