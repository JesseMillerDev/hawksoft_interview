using BlazorBoilerplate.Server.Middleware.Wrappers;
using BlazorBoilerplate.Shared.DataInterfaces;
using BlazorBoilerplate.Shared.Dto.Sample;
using static Microsoft.AspNetCore.Http.StatusCodes;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Server.Managers
{
    public class ContactManager : IContactManager
    {
        private readonly IContactStore _contactStore;

        public ContactManager(IContactStore contactStore)
        {
            _contactStore = contactStore;
        }

        public async Task<ApiResponse> Get()
        {
            try
            {
                return new ApiResponse(Status200OK, "Retrieved Contacts", await _contactStore.GetAll());
            }
            catch (Exception ex)
            {
                return new ApiResponse(Status400BadRequest, ex.Message);
            }
        }

        public async Task<ApiResponse> Get(long id)
        {
            try
            {
                return new ApiResponse(Status200OK, "Retrieved Contact", await _contactStore.GetById(id));
            }
            catch (Exception e)
            {
                return new ApiResponse(Status400BadRequest, "Failed to Retrieve Contact");
            }
        }

        public async Task<ApiResponse> GetAllByUserId(Guid userId)
        {
            try
            {
                return new ApiResponse(Status200OK, "Retrieved Contacts for User", await _contactStore.GetAllByUserId(userId));
            }
            catch (Exception ex)
            {
                return new ApiResponse(Status400BadRequest, "Failed to Retrieve Contacts for User", ex.Message);
            }
        }

        public async Task<ApiResponse> Create(ContactDto contactDto)
        {
            var contact = await _contactStore.Create(contactDto);
            return new ApiResponse(Status200OK, "Created Contact", contact);
        }

        public async Task<ApiResponse> Update(ContactDto contactDto)
        {
            try
            {
                return new ApiResponse(Status200OK, "Updated Contact", await _contactStore.Update(contactDto));
            }
            catch (InvalidDataException dataException)
            {
                return new ApiResponse(Status400BadRequest, "Failed to update Contact");
            }
        }

        public async Task<ApiResponse> Delete(long id)
        {
            try
            {
                await _contactStore.DeleteById(id);
                return new ApiResponse(Status200OK, "Soft Delete Contact");
            }
            catch (InvalidDataException dataException)
            {
                return new ApiResponse(Status400BadRequest, "Failed to update Contact");
            }
        }
    }
}
