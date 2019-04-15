using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Project.Models
{
    public class Users
    {        
            [Required(ErrorMessage = "Please enter your name")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "Please enter your name")]
            public string LastName { get; set; }

            [Required(ErrorMessage = "Please enter your name")]
            public string CompanuName { get; set; }

            [Required(ErrorMessage = "Please enter your name")]
            public string Position { get; set; }

            [Required(ErrorMessage = "Please enter your name")]
            public string Country { get; set; }

            [Required(ErrorMessage = "Please enter your email address")]
            [EmailAddress]
            public string Email { get; set; }        
    }
}
