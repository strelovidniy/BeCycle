using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackaton_test.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NickName { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string City { get; set; }

        public int Distance { get; set; }

        public List<Poster> Posters { get; set; } 

        //public List<Achievement> Achievements { get; set; }
    }
}