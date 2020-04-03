using BlazorBoilerplate.Shared.DataModels;
using BlazorBoilerplate.Shared.Dto.Sample;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Shared.DataInterfaces
{
    public interface IContactStore
    {
        Task<List<ContactDto>> GetAll();

        Task<ContactDto> GetById(long id);

        Task<List<ContactDto>> GetAllByUserId(Guid userId);

        Task<Contact> Create(ContactDto contactDto);

        Task<Contact> Update(ContactDto contactDto);

        Task DeleteById(long id);
    }
}