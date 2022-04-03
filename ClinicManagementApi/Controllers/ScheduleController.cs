using Application.Schedules.Create;
using ClinicManagementApi.Utilities;
using Facade.Schedules;
using Microsoft.AspNetCore.Mvc;
using Query.Schedules.DTOs;
using System.Net;

namespace ClinicManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ApiController
    {
        private readonly IScheduleFacade facade;

        public ScheduleController(IScheduleFacade facade)
        {
            this.facade = facade;
        }

        [HttpGet]
        public async Task<ApiResult<ICollection<ScheduleDto>>> GetSchedulesAsync()
        {
            var result = await facade.GetSchedules();
            return QueryResult(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<ScheduleDto>> GetScheduleAsync(long id)
        {
            var result = await facade.GetSchedule(id);
            return QueryResult(result);
        }

        [HttpPost]
        public async Task<ApiResult<long>> AddScheduleAsync(CreateScheduleCommand command)
        {
            var result = await facade.AddSchedule(command);
            var url = Url.Action("GetScheduleAsync", "Schedule", new { id = result.Data }, Request.Scheme);
            return CommandResult(result, url, HttpStatusCode.Created);
        }
    }
}
