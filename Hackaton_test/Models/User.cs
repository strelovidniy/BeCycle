using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackaton_test.Models
{
    public class User
    {
        public uint Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public uint Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
