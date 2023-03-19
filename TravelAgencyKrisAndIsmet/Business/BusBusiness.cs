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

        public void Add(Bus bus)
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                travelAgencyContext.Buses.Add(bus);
                travelAgencyContext.SaveChanges();
            }
        }

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

        public Bus Get(int id)
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                return travelAgencyContext.Buses.Find(id);
            }
        }

        public List<Bus> GetAll()
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                return travelAgencyContext.Buses.ToList();
            }
        }

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
