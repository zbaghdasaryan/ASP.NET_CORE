﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter а valid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your phone number")]
        public int Phone { get; set; }
        [Required(ErrorMessage = "Please specify whether you'll attend")]
        public bool? WillAttend { get; set; }

    }
}
