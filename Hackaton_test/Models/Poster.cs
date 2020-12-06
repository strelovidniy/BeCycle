using System;

namespace Hackaton_test.Models
{
    public class Poster
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description {  get; set; }
        public User User { get; set; }
        public uint UserId { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}