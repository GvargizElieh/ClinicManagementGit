using Application.Utilities;

namespace Application.People.AssignFinancial
{
    public record AssingnFinancialPersonCommand(long PersonId, long FinancialId) : IBaseCommand;
}
