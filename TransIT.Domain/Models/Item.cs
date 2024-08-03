using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransIT.Domain.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public int Amount { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
