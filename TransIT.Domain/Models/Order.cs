using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransIT.Domain.Models.Users;

namespace TransIT.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeSend { get; set; }
        public IEnumerable<Package> Packages { get; set; }
        public IEnumerable<Item> Items { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public Facture? Facture { get; set; }
    }
}
