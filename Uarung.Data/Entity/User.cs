using System;
using System.ComponentModel.DataAnnotations;
using Uarung.Data.Contract;

namespace Uarung.Data.Entity
{
    public class User : IEntityBase
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public char Gender { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
