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
        public void Add(Client client)
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                travelAgencyContext.Clients.Add(client);
                travelAgencyContext.SaveChanges();
            }


        }
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

        public Client Get(int id)
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                return travelAgencyContext.Clients.Find(id);
            }
        }

        public List<Client> GetAll()
        {
            using (travelAgencyContext = new TravelAgencyContext())
            {
                return travelAgencyContext.Clients.ToList();
            }
        }

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

        //Given the unique id of a client returns the client's travel information
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
