using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Data;
using Microsoft.EntityFrameworkCore;
namespace TravelAgency.Business
{
    public class CityBusiness
    {
        TravelAgencyContext travelAgencyContext;
        /// <summary>
        /// Adds a city to the database 
        /// </summary>
        public void Add(City city)
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                travelAgencyContext.Cities.Add(city);
                travelAgencyContext.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes the city with this ID from the database
        /// </summary>
        public void Delete(int id)
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                var item = travelAgencyContext.Cities.Find(id);
                if (item != null)
                {
                    travelAgencyContext.Cities.Remove(item);
                    travelAgencyContext.SaveChanges();
                }
            }
        }

        /// <summary>
        /// When given the ID, returns the city
        /// </summary>
        public City Get(int id)
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                return travelAgencyContext.Cities.Find(id);
            }
        }
        /// <summary>
        /// Returns all cities currently in the database
        /// </summary>
        public List<City> GetAll()
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                return travelAgencyContext.Cities.ToList();
            }
        }

        /// <summary>
        /// Updates the old city with the new city
        /// </summary>
        public void Update(City city)
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                var item = travelAgencyContext.Cities.Find(city.Id);
                if (item != null)
                {
                    travelAgencyContext.Entry(item).CurrentValues.SetValues(city);
                    travelAgencyContext.SaveChanges();
                }
            }
        }
    }
}
