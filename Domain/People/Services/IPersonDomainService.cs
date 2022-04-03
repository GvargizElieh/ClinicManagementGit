namespace Domain.People.Services
{
    public interface IPersonDomainService
    {
        Task<bool> IsNationalIdDuplicated(string nationalId);
    }
}
