using AutoMapper;
using BlazorBoilerplate.Shared.DataInterfaces;
using BlazorBoilerplate.Shared.DataModels;
using BlazorBoilerplate.Shared.Dto.Sample;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Storage.Stores
{
    public class ContactStore : IContactStore
    {
        private readonly IApplicationDbContext _db;
        private readonly IMapper _autoMapper;

        public ContactStore(IApplicationDbContext db, IMapper autoMapper)
        {
            _db = db;
            _autoMapper = autoMapper;
        }       

        public async Task<List<ContactDto>> GetAll()
        {
            return await _autoMapper.ProjectTo<ContactDto>(_db.Contacts).ToListAsync();
        }

        public async Task<ContactDto> GetById(long id)
        {
            var contact = await _db.Contacts.SingleOrDefaultAsync(t => t.Id == id);

            if (contact == null)
                throw new InvalidDataException($"Unable to find Todo with ID: {id}");

            return _autoMapper.Map<ContactDto>(contact);
        }

        public async Task<List<ContactDto>> GetAllByUserId(Guid userId)
        {
            var userContacts = await _autoMapper.ProjectTo<ContactDto>(_db.Contacts.Where(c => c.UserId == userId)).ToListAsync();

            if (userContacts == null)
                throw new InvalidDataException($"Unable to find Contacts for User with ID: {userId}");

            return userContacts;
        }

        public async Task<Contact> Create(ContactDto contactDto)
        {
            var contact = _autoMapper.Map<ContactDto, Contact>(contactDto);
            await _db.Contacts.AddAsync(contact);
            await _db.SaveChangesAsync(CancellationToken.None);
            return contact;
        }

        public async Task<Contact> Update(ContactDto contactDto)
        {
            var contact = await _db.Contacts.SingleOrDefaultAsync(t => t.Id == contactDto.Id);
            if (contact == null)
                throw new InvalidDataException($"Unable to find Todo with ID: {contactDto.Id}");

            contact = _autoMapper.Map(contactDto, contact);
            _db.Contacts.Update(contact);
            await _db.SaveChangesAsync(CancellationToken.None);

            return contact;
        }

        public async Task DeleteById(long id)
        {
            var contact = _db.Contacts.SingleOrDefault(t => t.Id == id);

            if (contact == null)
                throw new InvalidDataException($"Unable to find Todo with ID: {id}");

            _db.Contacts.Remove(contact);
            await _db.SaveChangesAsync(CancellationToken.None);
        }
    }
}
