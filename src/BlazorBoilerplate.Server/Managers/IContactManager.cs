using System;
using System.Threading.Tasks;
using BlazorBoilerplate.Server.Middleware.Wrappers;
using BlazorBoilerplate.Shared.Dto.Sample;

namespace BlazorBoilerplate.Server.Managers
{
    public interface IContactManager
    {
        Task<ApiResponse> Get();
        Task<ApiResponse> Get(long id);
        Task<ApiResponse> GetAllByUserId(Guid userId);
        Task<ApiResponse> Create(ContactDto todo);
        Task<ApiResponse> Update(ContactDto todo);
        Task<ApiResponse> Delete(long id);
    }
}