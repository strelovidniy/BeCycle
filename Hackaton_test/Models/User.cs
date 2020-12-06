using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackaton_test.Models
{
    [Table("User")]
    public class User
    {
        [Column("UserId")] public uint Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public uint Age { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string PhoneNumber { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string City { get; set; }
        

        public uint Distance { get; set; }
        

        public List<Poster> Posters { get; set; }

        //public List<Achievement> Achievements { get; set; }
        
    }
}
