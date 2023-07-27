﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Client
    {
        [Key]
        public int Id {get; set; }
        [Required]
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? CEP {get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
    }
}
