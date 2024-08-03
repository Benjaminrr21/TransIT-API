using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransIT.Domain.Models;

namespace TransIT.Application.DTOs
{
    public class OrderOfClientDTO
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeSend { get; set; }
        public IEnumerable<Package> Packages { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}
