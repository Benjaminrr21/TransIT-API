using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransIT.Domain.Models
{
    public class Package
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public string Status { get; set; }
        public decimal Weight { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
        
        public int OrderId { get; set; }
        public Order Order { get; set; }


    }
}
