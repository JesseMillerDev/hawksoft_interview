using BlazorBoilerplate.Server.Managers;
using BlazorBoilerplate.Server.Middleware.Wrappers;
using BlazorBoilerplate.Shared.Dto.Sample;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace BlazorBoilerplate.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactManager _contactManager;

        public ContactsController(IContactManager contactManager)
        {
            _contactManager = contactManager;
        }

        // GET: api/Contact
        [HttpGet]
        [AllowAnonymous]
        public async Task<ApiResponse> Get()
            => await _contactManager.Get();

        // GET: api/Contact/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ApiResponse> Get(int id)
            => ModelState.IsValid ?
                await _contactManager.Get(id) :
                new ApiResponse(Status400BadRequest, "Contact Model is Invalid");

        // GET: api/Contact/5
        [HttpGet("user/{userId}")]
        [AllowAnonymous]
        public async Task<ApiResponse> GetContactsForUser(Guid userId)
        {
            return ModelState.IsValid ? await _contactManager.GetAllByUserId(userId) : new ApiResponse(Status400BadRequest, "User Id is Invalid");
        }
            

        // POST: api/Contact
        [HttpPost]
        [AllowAnonymous]
        public async Task<ApiResponse> Post([FromBody] ContactDto contact)
            => ModelState.IsValid ?
                await _contactManager.Create(contact) :
                new ApiResponse(Status400BadRequest, "Contact Model is Invalid");

        // Put: api/Contact
        [HttpPut]
        [AllowAnonymous]
        public async Task<ApiResponse> Put([FromBody] ContactDto contact)
            => ModelState.IsValid ?
                await _contactManager.Update(contact) :
                new ApiResponse(Status400BadRequest, "Contact Model is Invalid");

        // DELETE: api/Contact/5
        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<ApiResponse> Delete(long id)
            => await _contactManager.Delete(id);
    }
}
