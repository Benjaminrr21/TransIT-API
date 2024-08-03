using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransIT.Application.DTOs
{
    public class PackageDTO
    {
        public string Category { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public string Status { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; }
    }
}
