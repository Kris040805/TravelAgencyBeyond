using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Data;

namespace TravelAgency.Business
{
    public class TravelBusiness
    {
        TravelAgencyContext travelAgencyContext;

        public void Add(Travel travel)
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                travelAgencyContext.Travels.Add(travel);
                travelAgencyContext.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                var item = travelAgencyContext.Travels.Find(id);
                travelAgencyContext.Travels.Remove(item);
                travelAgencyContext.SaveChanges();
            }
        }

        public Travel Get(int id)
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                return travelAgencyContext.Travels.Find(id);
            }
        }
        public List<Travel> GetAll()
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                return travelAgencyContext.Travels.ToList();
            }
        }
        public void Update(Travel travel)
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                var item = travelAgencyContext.Travels.Find(travel.Id);
                travelAgencyContext.Entry(item).CurrentValues.SetValues(travel);
                travelAgencyContext.SaveChanges();
            }
        }
        public Bus GetBusByTravelId(int travelId)
        {

            using (travelAgencyContext = new TravelAgencyContext())
            {
                //Include(x=> x.Travel).ToList().Find(x=> x.Id==id)
                //travelAgencyContext.Clients.Include(x=> x.Travel).ToList().Find(x=> x.Id==id)
                //travelAgencyContext.Buses.Find(travel.BusId)
                
                Travel travel = travelAgencyContext.Travels.Find(travelId);
                travelAgencyContext.Entry(travel).Reference(x => x.Bus).Load();
                return travel.Bus;
            }
        }

        public City GetFromCity(int travelId)
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                Travel travel = travelAgencyContext.Travels.Find(travelId);
                travelAgencyContext.Entry(travel).Reference(x => x.FromCity).Load();
                return travel.FromCity;
            }
        }

        public City GetToCity(int travelId)
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                Travel travel = travelAgencyContext.Travels.Find(travelId);
                travelAgencyContext.Entry(travel).Reference(x => x.ToCity).Load();
                return travel.ToCity;
            }
        }

        public List<Client> ShowClients(int travelId)
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                Travel travel = travelAgencyContext.Travels.Find(travelId);
                travelAgencyContext.Entry(travel).Collection(x => x.Clients).Load();
                return travel.Clients.ToList();
            }
        }
    }
}
