using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Business;
using TravelAgency.Data;
using Microsoft.EntityFrameworkCore;

namespace TravelAgencyKrisAndIsmet.Presentation
{
    public class ClientDisplay
    {
        ClientBusiness clientBusiness;
        public ClientDisplay()
        {
            clientBusiness = new ClientBusiness();
            ClientMenuInput();
        }


        /// <summary>
        /// Принтира менюто и иска вход
        /// </summary>
        private void ClientMenuInput()
        {

            ShowClientMenu();

            int operation = int.Parse(Console.ReadLine());

            switch (operation)
            {
                case 1:
                    ClientAdd();
                    break;
                case 2:
                    ClientDelete();
                    break;
                case 3:
                    ClientGet();
                    break;
                case 4:
                    ClientGetAll();
                    break;
                case 5:
                    ClientUpdate();
                    break;
                case 6:
                    ClientGetTravelByClientId();
                    break;
                default:
                    Console.WriteLine("Option not available!\nReturning to main menu...");
                    break;
            }
        }

        /// <summary>
        /// Manually add a new client to the database
        /// </summary>
        public void ClientAdd()
        {
            Client client = new Client();
            Console.WriteLine("Enter first name:");
            client.FirstName = Console.ReadLine();
            Console.WriteLine("Enter last name:");
            client.LastName = Console.ReadLine();
            Console.WriteLine("Enter age :");
            client.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter id of travel");
            client.TravelId = int.Parse(Console.ReadLine());
            clientBusiness.Add(client);


        }


        /// <summary>
        /// Given the id the method deletes a client from the database 
        /// </summary>
        public void ClientDelete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            Client client = clientBusiness.Get(id);
            if (client != null)
            {
                clientBusiness.Delete(id);
                Console.WriteLine("Done.");
            }
            else
            {
                Console.WriteLine("Client not found!");
            }
        }

        /// <summary>
        /// The method returns information about a client given the id
        /// </summary>
        public void ClientGet()
        {
            Console.WriteLine("Enter ID to get: ");
            int id = int.Parse(Console.ReadLine());
            Client client = clientBusiness.Get(id);
            if (client != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + client.Id);
                Console.WriteLine("First name: " + client.FirstName);
                Console.WriteLine("Last name: " + client.LastName);
                Console.WriteLine("Age : " + client.Age);
                Console.WriteLine("Travel id: " + client.TravelId);
                Console.WriteLine(new string('-', 40));
            }
        }

        /// <summary>
        /// The following method returns all clients currently in the database
        /// </summary>
        public void ClientGetAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "CLIENTS" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var clients = clientBusiness.GetAll();
            foreach (var client in clients)
            {
                Console.WriteLine($"{client.Id} {client.FirstName} {client.LastName} {client.Age}, Travel ID -{client.TravelId}");
            }
        }

        /// <summary>
        /// актуализира информацията за клиента на когото ID-то е въведено
        /// </summary>
        public void ClientUpdate()
        {

            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Client client = clientBusiness.Get(id);
            if (client != null)
            {
                Console.WriteLine("Enter first name: ");
                client.FirstName = Console.ReadLine();
                Console.WriteLine("Enter last name: ");
                client.LastName = Console.ReadLine();
                Console.WriteLine("Enter age:");
                client.Age = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter travel id");
                client.TravelId = int.Parse(Console.ReadLine());
                clientBusiness.Update(client);
            }
            else
            {
                Console.WriteLine("Client not found!");
            }



        }

        /// <summary>
        /// При дадено ID на клиент се връща информацията за неговото пътуване 
        /// </summary>
        public void ClientGetTravelByClientId()
        {
            Console.WriteLine("Enter the ID of a client and his travel information will be shown");
            int idClient = int.Parse(Console.ReadLine());
            var client = clientBusiness.Get(idClient);
            
            Console.WriteLine("Travel ID: " + client.Travel.Id);
            Console.WriteLine("From city ID: " + client.Travel.FromCityId);
            Console.WriteLine("To city ID: " + client.Travel.ToCityId);
            Console.WriteLine("Bus ID: " + client.Travel.BusId);
            Console.WriteLine("Date of travel - " + client.Travel.DateOfTravel.ToString());
        }


        public void ShowClientMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string('-', 18) + "BUS MENU" + new string('-', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. Add new client");
            Console.WriteLine("2. Delete a client");
            Console.WriteLine("3. Get client");
            Console.WriteLine("4. Get all clients");
            Console.WriteLine("5. Update a client");
            Console.WriteLine("6. Get client's travel");
        }
    }
}
