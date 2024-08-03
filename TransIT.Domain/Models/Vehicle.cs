using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransIT.Domain.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string RegNumber { get; set; }
        public string Type { get; set; }
        public string Dimensions { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Capacity { get; set; }
        public string Fuel {  get; set; }
        public decimal Power { get; set; }

    }
}
