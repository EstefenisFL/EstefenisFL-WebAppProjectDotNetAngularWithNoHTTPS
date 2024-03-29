﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Domain.Models
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public string? BarCode { get; set; }
        public string? Description { get; set; }
        public decimal Value { get; set; }
        public ProductType ProductType { get; set; }
        public bool Status { get; set; }
    }
}
