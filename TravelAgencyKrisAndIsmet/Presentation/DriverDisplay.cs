﻿using System;
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

        /// <summary>
        /// Print the menu and wait for input
        /// </summary>
        public void DriverMenuInput()
        {
            ShowDriverMenu();

            int operation = -1;
            try
            {
                operation = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
            }

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

        /// <summary>
        /// Manually add a new driver to the database
        /// </summary>
        private void DriverAdd()
        {
            Driver driver = new Driver();
            Console.WriteLine("Enter first name:");
            driver.FirstName = Console.ReadLine();
            Console.WriteLine("Enter last name:");
            driver.LastName = Console.ReadLine();
            Console.WriteLine("Enter age:");
            driver.Age = int.Parse(Console.ReadLine());
            driverBusiness.Add(driver);
        }

        /// <summary>
        /// Delete a driver which matches the entered ID
        /// </summary>
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

        /// <summary>
        /// Displays information about the driver for the travel
        /// </summary>
        private void DriverGet()
        {
            Console.WriteLine("Enter ID to get: ");
            int id = int.Parse(Console.ReadLine());
            Driver driver = driverBusiness.Get(id);
            if (driver != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + driver.Id);
                Console.WriteLine("First name: " + driver.FirstName);
                Console.WriteLine("Last name: " + driver.LastName);
                Console.WriteLine("Age : " + driver.Age);
                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("No driver found");
            }
        }

        /// <summary>
        /// Displays information about all drivers in the database
        /// </summary>
        private void DriverGetAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "DRIVERS" + new string(' ', 16));

            var drivers = driverBusiness.GetAll();
            if (drivers.Count == 0)
            {
                Console.WriteLine("No drivers found!");
                return;
            }
            foreach (var driver in drivers)
            {
                Console.WriteLine($"{driver.Id} {driver.FirstName} {driver.LastName} Age{driver.Age}");
            }
        }

        /// <summary>
        /// Update a driver in the database
        /// </summary>
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


        /// <summary>
        /// Prints out the driver menu
        /// </summary>
        public void ShowDriverMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string('-', 15) + "DRIVER MENU" + new string('-', 14));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. Add new driver");
            Console.WriteLine("2. Delete a driver");
            Console.WriteLine("3. Get driver");
            Console.WriteLine("4. Get all drivers");
            Console.WriteLine("5. Update a driver");
        }
    }
}
