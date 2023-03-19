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
        public void Add(City city)
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                travelAgencyContext.Cities.Add(city);
                travelAgencyContext.SaveChanges();
            }


        }
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

        public City Get(int id)
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                return travelAgencyContext.Cities.Find(id);
            }
        }

        public List<City> GetAll()
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                return travelAgencyContext.Cities.ToList();
            }
        }

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
