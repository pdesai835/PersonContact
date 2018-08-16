using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactAPI.Models
{
    public class PersonContact
    {
        [Required]
        [Column(Order = 0)]
        public int Id { get; set; }
        [Required]
        [StringLength(50,ErrorMessage="First Name must not have more thn 50 characters.",MinimumLength=1)]
        [Index("IX_NameUnique", 1, IsUnique = true)]
        [Column(Order = 1)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Last Name must not have more thn 50 characters.", MinimumLength = 1)]
        [Index("IX_NameUnique", 2, IsUnique = true)]
        [Column(Order = 2)]
        public string LastName { get; set; }
        [EmailAddress]
        [Column(Order = 3)]
        public string Email { get; set; }
        [Phone]
        [Column(Order = 4)]
        public string PhoneNumber { get; set; }
        [Required]
        [Index("IX_NameUnique", 3, IsUnique = true)]
        [Column(Order = 5)]
        public bool Status { get; set; }

    }
}