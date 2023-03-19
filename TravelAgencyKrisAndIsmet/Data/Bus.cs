using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Data
{
    public class Bus
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Model { get; set; }
        
        [Required]
        public int Capacity { get; set; }
        public int? KilometersRun { get; set; }

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
