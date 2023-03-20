using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Data;
using Microsoft.EntityFrameworkCore;

namespace TravelAgency.Business
{
    public class DriverBusiness
    {
        TravelAgencyContext travelAgencyContext;

        /// <summary>
        /// Adds a driver to the database 
        /// </summary>
        public void Add(Driver driver)
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                travelAgencyContext.Drivers.Add(driver);
                travelAgencyContext.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes the driver with this ID from the database
        /// </summary>
        public void Delete(int id)
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                var item = travelAgencyContext.Drivers.Find(id);
                travelAgencyContext.Drivers.Remove(item);
                travelAgencyContext.SaveChanges();
            }
        }

        /// <summary>
        /// When given the ID, returns the driver
        /// </summary>
        public Driver Get(int id)
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                return travelAgencyContext.Drivers.Find(id);
            }
        }

        /// <summary>
        /// Returns all drivers currently in the database
        /// </summary>
        public List<Driver> GetAll()
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                return travelAgencyContext.Drivers.ToList();
            }
        }
        /// <summary>
        /// Updates the old driver with the new driver
        /// </summary>
        public void Update(Driver driver)
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                var item = travelAgencyContext.Drivers.Find(driver.Id);
                travelAgencyContext.Entry(item).CurrentValues.SetValues(driver);
                travelAgencyContext.SaveChanges();
            }
        }
    }
}
