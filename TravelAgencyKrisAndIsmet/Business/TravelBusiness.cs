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

        /// <summary>
        /// Adds a trave; to the database 
        /// </summary>
        public void Add(Travel travel)
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                travelAgencyContext.Travels.Add(travel);
                travelAgencyContext.SaveChanges();
               
            }
        }

        /// <summary>
        /// Deletes the travel with this ID from the database
        /// </summary>
        public void Delete(int id)
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                var item = travelAgencyContext.Travels.Find(id);
                travelAgencyContext.Travels.Remove(item);
                travelAgencyContext.SaveChanges();
            }
        }

        /// <summary>
        /// When given the ID, returns the travel
        /// </summary>
        public Travel Get(int id)
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                return travelAgencyContext.Travels.Find(id);
            }
        }

        /// <summary>
        /// Returns all travels currently in the database
        /// </summary>
        public List<Travel> GetAll()
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                return travelAgencyContext.Travels.ToList();
            }
        }
        /// <summary>
        /// Updates the travel bus with the new travel
        /// </summary>
        public void Update(Travel travel)
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                var item = travelAgencyContext.Travels.Find(travel.Id);
                travelAgencyContext.Entry(item).CurrentValues.SetValues(travel);
                travelAgencyContext.SaveChanges();
            }
        }

        /// <summary>
        /// Returns the bus which is used in the travel with the ID
        /// </summary>
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

        /// <summary>
        /// Returns the city from which the bus departs used in the travel with the entered ID
        /// </summary>
        public City GetFromCity(int travelId)
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                Travel travel = travelAgencyContext.Travels.Find(travelId);
                travelAgencyContext.Entry(travel).Reference(x => x.FromCity).Load();
                return travel.FromCity;
            }
        }

        /// <summary>
        /// Returns the destination of the travel with the entered ID
        /// </summary>
        public City GetToCity(int travelId)
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                Travel travel = travelAgencyContext.Travels.Find(travelId);
                travelAgencyContext.Entry(travel).Reference(x => x.ToCity).Load();
                return travel.ToCity;
            }
        }

        /// <summary>
        /// Returns all clients which are registered to the travel with the entered ID
        /// </summary>
        /// <param name="travelId"></param>
        /// <returns></returns>
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
