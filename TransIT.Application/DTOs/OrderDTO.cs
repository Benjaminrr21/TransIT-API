using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransIT.Domain.Models;

namespace TransIT.Application.DTOs
{
    public class OrderDTO
    {
        public DateTime TimeCreated { get; set; } = DateTime.Now;
        public string Address { get; set; }
        public string Status { get; set; }
        public int ClientId { get; set; }
       //public IEnumerable<PackageDTO> Packages { get; set; }
       
    }
}
