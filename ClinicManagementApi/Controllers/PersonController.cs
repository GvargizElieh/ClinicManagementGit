using Application.People.Create;
using ClinicManagementApi.Utilities;
using Facade.People;
using Microsoft.AspNetCore.Mvc;
using Query.People.DTOs;
using System.Net;

namespace ClinicManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ApiController
    {
        private readonly IPersonFacade facade;

        public PersonController(IPersonFacade facade)
        {
            this.facade = facade;
        }

        [HttpGet]
        public async Task<ApiResult<ICollection<PersonDto>>> GetPeopleAsync()
        {
            var result = await facade.GetPeopleAsync();
            return QueryResult(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<PersonDto>> GetPersonAsync(long id)
        {
            var result = await facade.GetPersonAsync(id);
            return QueryResult(result);
        }

        [HttpPost]
        public async Task<ApiResult<long>> AddPersonAsync(CreatePersonCommand command)
        {
            var result = await facade.AddPersonAsync(command);
            var url = Url.Action("GetPersonAsync", "Person", new { id = result.Data }, Request.Scheme);
            return CommandResult(result, url, HttpStatusCode.Created);
        }
    }
}
