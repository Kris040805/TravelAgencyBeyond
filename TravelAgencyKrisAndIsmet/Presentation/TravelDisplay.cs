using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Business;
using TravelAgency.Data;

namespace TravelAgencyKrisAndIsmet.Presentation
{
    public class TravelDisplay
    {
        TravelBusiness travelBusiness;

        public TravelDisplay()
        {
            travelBusiness = new TravelBusiness();
            TravelMenuInput();
        }

        private void TravelMenuInput()
        {
            ShowTravelMenu();

            int operation = -1;

            operation = int.Parse(Console.ReadLine());
            switch (operation)
            {
                case 1:
                    TravelAdd();
                    break;
                case 2:
                    TravelDelete();
                    break;
                case 3:
                    TravelGet();
                    break;
                case 4:
                    TravelGetAll();
                    break;
                case 5:
                    TravelUpdate();
                    break;
                case 6:
                    TravelGetBus();
                    break;
                case 7:
                    TravelGetFromCity();
                    break;
                case 8:
                    TravelGetToCity();
                    break;
                case 9:
                    ShowClients();
                    break;
                default:
                    Console.WriteLine("Option not available!\nReturning to main menu...");
                    break;
            }
        }

        private void TravelAdd()
        {
            Travel travel = new Travel();
            Console.WriteLine("Enter from-city ID:");
            travel.FromCityId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter to-city ID:");
            travel.ToCityId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter bus ID:");
            travel.BusId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter driver ID:");
            travel.DriverId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter date of travel: ");
            travel.DateOfTravel = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            travelBusiness.Add(travel);
        }
        private void TravelGet()
        {
            Console.WriteLine("Enter ID to get: ");
            int id = int.Parse(Console.ReadLine());
            Travel travel = travelBusiness.Get(id);
            if (travel != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + travel.Id);
                Console.WriteLine("From-city id: " + travel.FromCityId);
                Console.WriteLine("To-city id: " + travel.ToCityId);
                Console.WriteLine("Bus id: " + travel.BusId);
                Console.WriteLine("Driver id: " + travel.DriverId);
                Console.WriteLine("Date of travel: " + travel.DateOfTravel.ToShortDateString());
                Console.WriteLine(new string('-', 40));
            }
        }

        private void TravelDelete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            Travel travel = travelBusiness.Get(id);
            if (travel != null)
            {
                try
                {
                    travelBusiness.Delete(id);
                    Console.WriteLine("Done.");

                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                {
                    Console.WriteLine("You cannot delete this travel");
                }
            }
            else
            {
                Console.WriteLine("Travel not found!");
            }
        }
        private void TravelGetAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 14) + "TRAVELS" + new string(' ', 14));
            var travels = travelBusiness.GetAll();
            if (travels.Count == 0)
            {
                Console.WriteLine("No buses found!");
                return;
            }
            foreach (var travel in travels)
            {
                Console.WriteLine($"{travel.Id}, From City ID: {travel.FromCityId}, To City ID: {travel.ToCityId}, Bus ID: {travel.BusId}, Driver ID: {travel.DriverId}, Date: {travel.DateOfTravel.ToShortDateString()}");
            }
        }
        private void TravelUpdate()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Travel travel = travelBusiness.Get(id);
            if (travel != null)
            {
                Console.WriteLine("Enter from-city ID: ");
                travel.FromCityId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter to-city ID: ");
                travel.ToCityId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter bus ID: ");
                travel.BusId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter date of travel: ");
                travel.DateOfTravel = DateTime.Parse(Console.ReadLine());
                travelBusiness.Update(travel);
            }
            else
            {
                Console.WriteLine("Travel not found!");
            }
        }

        private void TravelGetBus()
        {
            Console.WriteLine("Enter ID of travel to see its bus: ");
            int id = int.Parse(Console.ReadLine());
            //Travel travel = travelBusiness.Get(id);
            Bus bus = travelBusiness.GetBusByTravelId(id);
            if (bus != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + bus.Id);
                Console.WriteLine("Model: " + bus.Model);
                Console.WriteLine("Capacity: " + bus.Capacity);
                Console.WriteLine("Kilometers runed: " + bus.KilometersRun);
                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("Travel not found!");
            }
        }

        private void TravelGetFromCity()
        {
            Console.WriteLine("Enter ID of travel to get from-city");
            int id = int.Parse(Console.ReadLine());
            City fromCity = travelBusiness.GetFromCity(id);

            if (fromCity != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + fromCity.Id);
                Console.WriteLine("Name: " + fromCity.Name);
                Console.WriteLine("Population: " + fromCity.Population);
                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("Travel not found!");
            }
        }

        private void TravelGetToCity()
        {
            Console.WriteLine("Enter ID of travel to get to-city id");
            int id = int.Parse(Console.ReadLine());
            City toCity = travelBusiness.GetToCity(id);
            if (toCity != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + toCity.Id);
                Console.WriteLine("Name: " + toCity.Name);
                Console.WriteLine("Population: " + toCity.Population);
                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("Travel not found!");
            }
        }

        private void ShowClients()
        {
            Console.WriteLine("Enter ID of travel to get its clients");
            int id = int.Parse(Console.ReadLine());
            Travel travel = travelBusiness.Get(id);
            if (travel != null)
            {
                List<Client> clients = travelBusiness.ShowClients(id);
                Console.WriteLine(new string('-', 40));
                if (clients.Count != 0)
                {
                    foreach (var client in clients)
                    {
                        Console.WriteLine($"{client.Id} {client.FirstName} {client.LastName} {client.Age}");
                    }
                }
                else
                {
                    Console.WriteLine("No clients in this travel!");
                }
                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("Travel not found!");
            }
        }

        public void ShowTravelMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string('-', 18) + "TRAVEL MENU" + new string('-', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. Add new travel");
            Console.WriteLine("2. Delete a travel");
            Console.WriteLine("3. Get travel");
            Console.WriteLine("4. Get all travels");
            Console.WriteLine("5. Update a travel");
            Console.WriteLine("6. Get bus by travel id");
            Console.WriteLine("7. Get from-city");
            Console.WriteLine("8. Get to-city");
            Console.WriteLine("9. Show clients in travel");
        }
    }
}
