using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransIT.Domain.Models;

namespace TransIT.Application.DTOs
{
    public class ClientViewDTO
    {
        public int Id { get; set; } 
        public string PIB { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ContactPerson { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public IEnumerable<ViewOrderDTO> Orders { get; set; }
    }
}
