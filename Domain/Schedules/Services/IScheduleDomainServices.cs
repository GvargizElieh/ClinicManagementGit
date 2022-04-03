namespace Domain.Schedules.Services
{
    public interface IScheduleDomainServices
    {
        Task<bool> IsTimeDuplicated(DateTime time);
    }
}
