using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransIT.Domain.Models.Users
{
    public class Client 
    {
        public int Id { get; set; }
        public string PIB {  get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Phone {  get; set; }
        public string ContactPerson { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
