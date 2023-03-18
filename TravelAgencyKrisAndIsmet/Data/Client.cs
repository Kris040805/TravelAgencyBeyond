using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Data
{
    public class Client
    {
        public int Id { get; set;  }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
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
