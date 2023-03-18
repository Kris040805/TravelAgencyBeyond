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
            Console.WriteLine("Enter first driver ID:");
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
                Console.WriteLine("Date of travel: " + travel.DateOfTravel);
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
                travelBusiness.Delete(id);
                Console.WriteLine("Done.");
            }
            else
            {
                Console.WriteLine("Travel not found!");
            }
        }
        private void TravelGetAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "BUSES" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var travels = travelBusiness.GetAll();
            foreach (var travel in travels)
            {// Warning toString метода за dateTime
                Console.WriteLine($"{travel.Id} {travel.FromCityId} {travel.ToCityId} {travel.BusId} {travel.DriverId} {travel.DateOfTravel.ToString()}");
            }
        }
        private void TravelUpdate()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Travel travel = travelBusiness.Get(id);
            if (travel != null)
            {
                Console.WriteLine("Enter from-city id: ");
                travel.FromCityId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter to-city id: ");
                travel.ToCityId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter bus id: ");
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
            Travel travel = travelBusiness.Get(id);

            // Така ли е май-добре да го оставим или нещо по-добро да измислим
            Bus bus = travel.Bus;

            Console.WriteLine(new string('-', 40));
            Console.WriteLine("ID: " + bus.Id);
            Console.WriteLine("Model: " + bus.Model);
            Console.WriteLine("Capacity: " + bus.Capacity);
            Console.WriteLine("Kilometers runed: " + bus.KilometersRun);
            Console.WriteLine(new string('-', 40));
        }
        private void TravelGetFromCity()
        {
            Console.WriteLine("Enter ID of travel to get from-city id");
            int id = int.Parse(Console.ReadLine());
            Travel travel = travelBusiness.Get(id);
            if (travel != null)
            {
                City city = travel.FromCity;
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + city.Id);
                Console.WriteLine("Name: " + city.Name);
                Console.WriteLine("Population: " + city.Population);
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
            Travel travel = travelBusiness.Get(id);
            if (travel != null)
            {
                City city = travel.ToCity;
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + city.Id);
                Console.WriteLine("Name: " + city.Name);
                Console.WriteLine("Population: " + city.Population);
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
            Console.WriteLine(new string('-', 18) + "BUS MENU" + new string('-', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. Add new travel");
            Console.WriteLine("2. Delete a travel");
            Console.WriteLine("3. Get travel");
            Console.WriteLine("4. Get all travels");
            Console.WriteLine("5. Update a travel");
            Console.WriteLine("6. Get bus by travel id");
            Console.WriteLine("7. Get from-city");
            Console.WriteLine("8. Get to-city");
        }
    }
}
