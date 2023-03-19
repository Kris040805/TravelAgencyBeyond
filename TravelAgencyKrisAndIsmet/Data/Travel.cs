using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Data
{
    public class Travel
    {
        [Key]
        public int Id { get; set; }
        public int? FromCityId { get; set; }
        public int? ToCityId { get; set; }
        public int? BusId { get; set; }
        public int? DriverId { get; set; }
        [Required]
        public DateTime DateOfTravel { get; set; }
        public ICollection<Client> Clients { get; set; }
        public City FromCity { get; set; }
        public City ToCity { get; set; }
        public Bus Bus { get; set; }

        public Travel(int id, int fromCityId, int toCityId, int busId, DateTime dateOfTravel):base()
        {
            Id = id;
            FromCityId = fromCityId;
            ToCityId = toCityId;
            BusId = busId;
            DateOfTravel = dateOfTravel;
        }

        public Travel()
        {
            Clients = new List<Client>();
        }

    }
}
