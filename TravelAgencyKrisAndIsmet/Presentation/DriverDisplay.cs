using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Business;
using TravelAgency.Data;

namespace TravelAgencyKrisAndIsmet.Presentation
{
    public class DriverDisplay
    {
        DriverBusiness driverBusiness;

        public DriverDisplay()
        {
            driverBusiness = new DriverBusiness();
            DriverMenuInput();
        }


        public void DriverMenuInput()
        {
            ShowDriverMenu();

            int operation = int.Parse(Console.ReadLine());
            switch (operation)
            {
                case 1: DriverAdd(); break;
                case 2: DriverDelete(); break;
                case 3: DriverGet(); break;
                case 4: DriverGetAll(); break;
                case 5: DriverUpdate(); break;
                default: Console.WriteLine("Option not available!\nReturning to main menu..."); break;
            }
        }

        private void DriverAdd()
        {
            Driver driver = new Driver();
            Console.WriteLine("Enter first name:");
            driver.FirstName = Console.ReadLine();
            Console.WriteLine("Enter last name:");
            driver.LastName = Console.ReadLine();
            Console.WriteLine("Enter age");
            driver.Age = int.Parse(Console.ReadLine());
            driverBusiness.Add(driver);
        }

        private void DriverDelete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            Driver driver = driverBusiness.Get(id);
            if (driver != null)
            {
                try
                {
                    driverBusiness.Delete(id);
                    Console.WriteLine("Done.");
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                {
                    Console.WriteLine("You cannot delete this driver.");
                }
                }
            else
            {
                Console.WriteLine("Driver not found!");
            }
        }

        private void DriverGet()
        {
            Console.WriteLine("Enter the ID of the driver you want to delete:");
            int id = int.Parse(Console.ReadLine());
            var driver = driverBusiness.Get(id);
            if (driver != null)
            {
                driverBusiness.Delete(id);
                Console.WriteLine("Done.");
            }
            else
            {
                Console.WriteLine("Driver not found!");
            }
        }

        private void DriverGetAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "DRIVERS" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var drivers = driverBusiness.GetAll();
            foreach (var driver in drivers)
            {
                Console.WriteLine($"{driver.Id} {driver.FirstName} {driver.LastName} Age{driver.Age}");
            }
        }

        private void DriverUpdate()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Driver driver = driverBusiness.Get(id);
            if (driver != null)
            {
                Console.WriteLine("Enter first name: ");
                driver.FirstName = Console.ReadLine();
                Console.WriteLine("Enter last name: ");
                driver.LastName = Console.ReadLine();
                Console.WriteLine("Enter age:");
                driver.Age = int.Parse(Console.ReadLine());
                driverBusiness.Update(driver);
            }
            else
            {
                Console.WriteLine("Driver not found!");
            }
        }


        public void ShowDriverMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string('-', 18) + "DRIVER MENU" + new string('-', 11));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. Add new driver");
            Console.WriteLine("2. Delete a driver");
            Console.WriteLine("3. Get driver");
            Console.WriteLine("4. Get all drivers");
            Console.WriteLine("5. Update a driver");
        }
    }
}
