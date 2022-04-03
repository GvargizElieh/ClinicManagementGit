using Application.Utilities;
using Domain.People.Enums;

namespace Application.People.Create
{
    public record CreatePersonCommand(string Name, string Family, string NationalId, Gender Gender, DateTime BirthDate) : IBaseCommand<long>;
}
