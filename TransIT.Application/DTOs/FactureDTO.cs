﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransIT.Application.DTOs
{
    public class FactureDTO
    {
        public DateTime DateCreated { get; set; }
        public decimal Amount { get; set; }
        public string Paying { get; set; }
        public int OrderId { get; set; }
    }
}
