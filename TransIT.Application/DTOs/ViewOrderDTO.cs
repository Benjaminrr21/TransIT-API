using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransIT.Application.DTOs
{
    public class ViewOrderDTO
    {
        public int Id { get; set; }
        public DateTime TimeCreated { get; set; } = DateTime.Now;
        public string Address { get; set; }
        public string Status { get; set; }
        //public int ClientId { get; set; }
        public IEnumerable<PackageInOrderDTO> Packages { get; set; }
    }
}
