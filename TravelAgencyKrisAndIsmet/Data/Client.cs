using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Data
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public int? Age { get; set; }
        [Required]
        public int TravelId { get; set; }
        public Travel Travel { get; set; }

        public Client(int id, string firstName, string lastName, int age, int travelId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            TravelId = travelId;
        }

        public Client()
        {

        }
    }
}
