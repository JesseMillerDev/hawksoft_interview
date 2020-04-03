using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorBoilerplate.Shared.Dto.Sample
{
    public class ContactDto
    {
        [Key]
        public long Id { get; set; }
        public Guid UserId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Email { get; set; }

        public AddressDto Address { get; set; }

        public ContactDto()
        {
            Address = new AddressDto();
        }
    }
}