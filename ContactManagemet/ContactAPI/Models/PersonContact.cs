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
        [StringLength(50, ErrorMessage = "First Name must be between 1 to 50 characters.", MinimumLength = 1)]
        [Index("IX_NameUnique", 1, IsUnique = true)]
        [Column(Order = 1)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last Name must be between 1 to 50 characters.", MinimumLength = 1)]
        [Index("IX_NameUnique", 2, IsUnique = true)]
        [Column(Order = 2)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage="Wrong emailId format specified.")]
        [StringLength(50, ErrorMessage = "Email must be between 10 to 50 characters.", MinimumLength = 10)]
        [Index("IX_EmailUnique", 1, IsUnique = true)]
        [Column(Order = 3)]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Wrong Phone Number format specified.")]
        [StringLength(20, ErrorMessage = "Phone Number must be between 10 to 20 characters.", MinimumLength = 10)]
        [Index("IX_PhoneUnique", 1, IsUnique = true)]
        [Column(Order = 4)]
        public string PhoneNumber { get; set; }

        [Required]
        [Index("IX_NameUnique", 3, IsUnique = true)]
        [Index("IX_EmailUnique", 2, IsUnique = true)]
        [Index("IX_PhoneUnique", 2, IsUnique = true)]
        [Column(Order = 5)]
        public bool Status { get; set; }

    }
}