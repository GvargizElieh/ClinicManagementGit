using Application.Reports.AddContent;
using Application.Reports.Create;
using Application.Reports.EditContent;
using ClinicManagementApi.Utilities;
using Facade.Reports;
using Microsoft.AspNetCore.Mvc;
using Query.Reports.DTOs;
using System.Net;

namespace ClinicManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ApiController
    {
        private readonly IReportFacade facade;

        public ReportController(IReportFacade facade)
        {
            this.facade = facade;
        }

        [HttpGet]
        public async Task<ApiResult<ICollection<ReportDto>>> GetReportsAsync()
        {
            var result = await facade.GetReportsAsync();
            return QueryResult(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<ReportDto>> GetReportAsync(long id)
        {
            var result = await facade.GetReportAsync(id);
            return QueryResult(result);
        }

        [HttpPost]
        public async Task<ApiResult<long>> AddReportAsync(CreateReportCommand command)
        {
            var result = await facade.AddRepotAsync(command);
            var url = Url.Action("GetReportAsync", "Report", new { id = result.Data }, Request.Scheme);
            return CommandResult(result, url, HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<ApiResult<long>> AddContentAsync(AddContentReportCommand command)
        {
            var result = await facade.AddContentToReportAsync(command);
            var url = Url.Action("GetReportAsync", "Report", new { id = result.Data }, Request.Scheme);
            return CommandResult(result, url, HttpStatusCode.Accepted);
        }

        [HttpPut("EdidContent")]
        public async Task<ApiResult<long>> EditContentAsync(EditContentReportCommand command)
        {
            var result = await facade.EditContentOfReportAsync(command);
            var url = Url.Action("GetReportAsync", "Report", new { id = result.Data }, Request.Scheme);
            return CommandResult(result, url, HttpStatusCode.Accepted);
        }
    }
}
