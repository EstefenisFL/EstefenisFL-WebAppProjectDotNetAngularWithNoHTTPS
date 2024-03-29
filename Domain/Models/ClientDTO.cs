﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ClientDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }        
        [EmailAddress]
        [Required]
        public string? Email { get; set; }
        public string? RegistrationNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public string? CEP { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public int? Option { get; set; }
    }
}
