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
        public void Add(Driver driver)
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                travelAgencyContext.Drivers.Add(driver);
                travelAgencyContext.SaveChanges();
            }

        }
        public void Delete(int id)
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                var item = travelAgencyContext.Drivers.Find(id);
                travelAgencyContext.Drivers.Remove(item);
                travelAgencyContext.SaveChanges();
            }
        }

        public Driver Get(int id)
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                return travelAgencyContext.Drivers.Find(id);
            }
        }

        public List<Driver> GetAll()
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                return travelAgencyContext.Drivers.ToList();
            }
        }
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
