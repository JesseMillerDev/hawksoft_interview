using System;
using System.ComponentModel.DataAnnotations;
using BlazorBoilerplate.Shared.DataInterfaces;

namespace BlazorBoilerplate.Shared.DataModels
{
    public class Contact : IAuditable, ISoftDelete
    {
        [Key]
        public long Id { get; set; }
        
        public Guid UserId { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        public string Email { get; set; }
        public Address Address { get; set; }
    }
}