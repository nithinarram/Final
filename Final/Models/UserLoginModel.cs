﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final.Models
{
    public class UserLoginModel
    {
       
            [Required]
            public string UserId { get; set; }
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        
    }
}