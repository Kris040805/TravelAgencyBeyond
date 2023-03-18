using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Data
{
    public class Driver
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Driver()
        {
            
        }
        public Driver(int id, string firstName, string lastName, int age)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        

    }
}
