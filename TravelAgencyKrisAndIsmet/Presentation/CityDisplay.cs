using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Business;
using TravelAgency.Data;

namespace TravelAgencyKrisAndIsmet.Presentation
{
    public class CityDisplay
    {
        CityBusiness cityBusiness;

        public CityDisplay()
        {
            cityBusiness = new CityBusiness();
            CityMenuInput();
        }

        public void CityMenuInput()
        {
            ShowCityMenu();

            int operation = int.Parse(Console.ReadLine());

            switch (operation)
            {
                case 1: CityAdd(); break;
                case 2: CityDelete(); break;
                case 3: CityGet(); break;
                case 4: CityGetAll(); break;
                case 5: CityUpdate(); break;
                default: Console.WriteLine("Option not available!"); break;
            }
        }

        private void CityAdd()
        {
            City city = new City();
            Console.WriteLine("Enter name of city: ");
            city.Name = Console.ReadLine();
            Console.WriteLine("Enter population: ");
            city.Population = int.Parse(Console.ReadLine());
            cityBusiness.Add(city);
        }

        private void CityDelete()
        {
            Console.WriteLine("Enter the ID of the city you want to delete:");
            int id = int.Parse(Console.ReadLine());
            var city = cityBusiness.Get(id);
            if (city != null)
            {
                /*cityBusiness.Delete(id);
                Console.WriteLine("Done");*/
                //
                try
                {
                    cityBusiness.Delete(id);
                    Console.WriteLine("Done");
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                {
                    Console.WriteLine("You cannot delete this city.");

                }
            }
            else
            {
                Console.WriteLine("City not found!");
            }
        }

        private void CityGet()
        {
            Console.WriteLine("Enter ID to get: ");
            int id = int.Parse(Console.ReadLine());
            City city = cityBusiness.Get(id);
            if (city != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + city.Id);
                Console.WriteLine("Name: " + city.Name);
                Console.WriteLine("Population: " + city.Population);
            }
        }

        private void CityGetAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "CITIES" + new string(' ', 16));
            var cities = cityBusiness.GetAll();
            if (cities.Count == 0)
            {
                Console.WriteLine("No cities found!");
                return;
            }
            foreach (var city in cities)
            {
                Console.WriteLine($"{city.Id} {city.Name} Population: {city.Population}");
            }
        }

        private void CityUpdate()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            City city = cityBusiness.Get(id);
            if (city != null)
            {
                Console.WriteLine("Enter name: ");
                city.Name = Console.ReadLine();
                Console.WriteLine("Enter population: ");
                city.Population = int.Parse(Console.ReadLine());
                cityBusiness.Update(city);
            }
            else
            {
                Console.WriteLine("City not found!");
            }
        }

        public void ShowCityMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string('-', 16) + "CITY MENU" + new string('-', 15));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. Add new city");
            Console.WriteLine("2. Delete a city");
            Console.WriteLine("3. Get city");
            Console.WriteLine("4. Get all cities");
            Console.WriteLine("5. Update a city");
        }
    }
}
