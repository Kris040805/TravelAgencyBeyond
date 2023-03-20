using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.Business;
using TravelAgency.Data;
using TravelAgencyKrisAndIsmet.Presentation;

namespace TravelAgency.Presentation
{
    public class Display
    {
        public Display()
        {
            Input();
        }

        /// <summary>
        /// Prints the menu and waits for user input
        /// </summary>
        public void Input()
        {
            int operation = -1;
            PrintLogo();
            do
            {
                ShowMainMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        BusDisplay busDisplay = new BusDisplay();
                        break;
                    case 2:
                        CityDisplay cityDisplay = new CityDisplay();
                        break;
                    case 3:
                        ClientDisplay clientDisplay = new ClientDisplay();
                        break;
                    case 4:
                        DriverDisplay driverDisplay = new DriverDisplay();
                        break;
                    case 5:
                        TravelDisplay travelDisplay = new TravelDisplay();
                        break;
                    case 6:
                        Console.Clear();
                        PrintLogo();
                        break;
                    case 7:
                        Console.WriteLine("Closing...");
                        Thread.Sleep(1000);
                        break;
                    default:
                        Console.WriteLine("Option not available!");
                        break;
                }
            } while (operation != 7);
        }


        /// <summary>
        /// Prints out the main menu
        /// </summary>
        public void ShowMainMenu()
        {
            Thread.Sleep(1000);
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string('-', 18) + "MENU" + new string('-', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. Bus menu");
            Console.WriteLine("2. City menu");
            Console.WriteLine("3. Client menu");
            Console.WriteLine("4. Driver menu");
            Console.WriteLine("5. Travel menu");
            Console.WriteLine("6. Clear console");
            Console.WriteLine("7. Close program");
        }

        /// <summary>
        /// Prints the agency's logo
        /// </summary>
        public void PrintLogo()
        {
            Console.WriteLine(@"
  ______                            _ 
  | ___ \                          | |
  | |_/ / ___ _   _  ___  _ __   __| |
  | ___ \/ _ \ | | |/ _ \| '_ \ / _` |
  | |_/ /  __/ |_| | (_) | | | | (_| |
  \____/ \___|\__, |\___/|_| |_|\__,_|
               __/ |                  
              |___/                   
");
        }
    }
}
