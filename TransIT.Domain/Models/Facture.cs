using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransIT.Domain.Models
{
    public class Facture
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }  = DateTime.Now;
        public decimal Amount { get; set; }
        public string Paying { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }

    }
}
