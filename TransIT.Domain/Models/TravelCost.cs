using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransIT.Domain.Models
{
    public class TravelCost
    {
        public int Id { get; set; }
        public decimal FuelCost { get; set; }
        public decimal CustomsCost {  get; set; } 
        public decimal RepairCost { get; set; }
    }
}
