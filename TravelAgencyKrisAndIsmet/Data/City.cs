using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Data
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int? Population { get; set; }

        public City() { }

        public City(int id, string name, int population)
        {
            Id  =  id;
            Name   = name;
            Population = population;
        }
    }
}
