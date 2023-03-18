using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Data
{
    public class Bus
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public int KilometersRun { get; set; }

        public Bus(int id, string model, int capacity, int kilometersRun)
        {
            Id = id;
            Model = model;
            Capacity = capacity;
            KilometersRun = kilometersRun;
        }

        public Bus()
        {

        }


    }
}
