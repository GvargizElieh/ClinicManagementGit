using Application.Financials.Cancel;
using Application.Financials.Create;
using Application.Financials.Pay;
using ClinicManagementApi.Utilities;
using Facade.Financials;
using Microsoft.AspNetCore.Mvc;
using Query.Financials.DTOs;
using System.Net;

namespace ClinicManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialController : ApiController
    {
        private readonly IFinancialFacade facade;

        public FinancialController(IFinancialFacade facade)
        {
            this.facade = facade;
        }

        [HttpGet]
        public async Task<ApiResult<ICollection<FinancialDto>>> GetFinancialsAsync()
        {
            var result = await facade.GetFinancials();
            return QueryResult(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<FinancialDto>> GetFinancialAsync(long id)
        {
            var result = await facade.GetFinancial(id);
            return QueryResult(result);
        }

        [HttpPost]
        public async Task<ApiResult<long>> AddFinancialAsync(CreateFinancialCommand command)
        {
            var result = await  facade.AddFinancial(command);
            var url = Url.Action("GetFinancialAsync", "Financial", new { id = result.Data }, Request.Scheme);
            return CommandResult(result, url, HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<ApiResult<long>> PayAsync(PayFinancialCommand command)
        {
            var result = await facade.Pay(command);
            var url = Url.Action("GetFinancialAsync", "Financial", new { id = result.Data }, Request.Scheme);
            return CommandResult(result, url, HttpStatusCode.Accepted);
        }

        [HttpPut("Cancel")]
        public async Task<ApiResult<long>> CancelAsync(CancelFinancialCommand command)
        {
            var result = await facade.Cancel(command);
            var url = Url.Action("GetFinancialAsync", "Financial", new { id = result.Data }, Request.Scheme);
            return CommandResult(result, url, HttpStatusCode.Accepted);
        }
    }
}
