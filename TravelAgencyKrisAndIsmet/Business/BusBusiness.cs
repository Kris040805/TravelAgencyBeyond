using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Data;
using Microsoft.EntityFrameworkCore;


namespace TravelAgency.Business
{
    public class BusBusiness
    {
        private TravelAgencyContext travelAgencyContext;

        /// <summary>
        /// Adds a bus to the database 
        /// </summary>
        public void Add(Bus bus)
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                travelAgencyContext.Buses.Add(bus);
                travelAgencyContext.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes the bus with this ID from the database
        /// </summary>
        public void Delete(int id)
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                var item = travelAgencyContext.Buses.Find(id);
                if (item != null)
                {
                    travelAgencyContext.Buses.Remove(item);
                    travelAgencyContext.SaveChanges();
                }
            }
        }

        /// <summary>
        /// When given the ID, returns the bus
        /// </summary>
        public Bus Get(int id)
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                return travelAgencyContext.Buses.Find(id);
            }
        }

        /// <summary>
        /// Returns all busses currently in the database
        /// </summary>
        public List<Bus> GetAll()
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                return travelAgencyContext.Buses.ToList();
            }
        }

        /// <summary>
        /// Updates the old bus with the new bus
        /// </summary>
        public void Update(Bus bus)
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                var item = travelAgencyContext.Buses.Find(bus.Id);
                if (item != null)
                {
                    travelAgencyContext.Entry(item).CurrentValues.SetValues(bus);
                    travelAgencyContext.SaveChanges();
                }
            }
        }
    }
}
