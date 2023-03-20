using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Data;
using Microsoft.EntityFrameworkCore;

namespace TravelAgency.Business
{
    public class ClientBusiness
    {
        TravelAgencyContext travelAgencyContext;

        /// <summary>
        /// Adds a client to the database 
        /// </summary>
        public void Add(Client client)
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                travelAgencyContext.Clients.Add(client);
                travelAgencyContext.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes the client with this ID from the database
        /// </summary>
        public void Delete(int id)
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                var item = travelAgencyContext.Clients.Find(id);
                if (item != null)
                {
                    travelAgencyContext.Clients.Remove(item);
                    travelAgencyContext.SaveChanges();
                }
            }
        }

        /// <summary>
        /// When given the ID, returns the client
        /// </summary>
        public Client Get(int id)
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                return travelAgencyContext.Clients.Include(x=> x.Travel).ToList().Find(x=> x.Id==id);
            }
        }

        /// <summary>
        /// Returns all clients currently in the database
        /// </summary>
        public List<Client> GetAll()
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                return travelAgencyContext.Clients.ToList();
            }
        }
        /// <summary>
        /// Updates the old client with the new client
        /// </summary>
        public void Update(Client client)
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                var item = travelAgencyContext.Clients.Find(client.Id);
                if (item != null)
                {
                    travelAgencyContext.Entry(item).CurrentValues.SetValues(client);
                    travelAgencyContext.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Given the unique id of a client, returns the client's travel information
        /// </summary>
        public Travel GetTravel(int clientId)
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                var client = travelAgencyContext.Clients.Find(clientId);
                if (client != null)
                {
                    return client.Travel;
                }
            }
            return null;
        }
    }
}
