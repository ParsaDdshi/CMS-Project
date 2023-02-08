﻿using System.ComponentModel.DataAnnotations;

namespace CMS.Models
{
    public class UserProfileViewModel
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public DateTime RegisterDate { get; set; }
    }
}
