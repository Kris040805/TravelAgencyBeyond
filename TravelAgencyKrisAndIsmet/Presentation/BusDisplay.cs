using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Business;
using TravelAgency.Data;

namespace TravelAgencyKrisAndIsmet.Presentation
{
    public class BusDisplay
    {
        BusBusiness busBusiness;

        public BusDisplay()
        {
            busBusiness = new BusBusiness();
            BusMenuInput();
        }


        // МОЖЕМ ДА ДОБАВИМ ИНДИКАТОР НАПРИМЕР СЛЕД КАТО СЕ ДОБАВИ АВТОБУС В БАЗАТА ДАННИ СЕ ИЗПИСВА БЪС АДДЕД РЕТЪРНИН ТО МЕЙН МЕНЙУ...




        /// <summary>
        /// Print the menu and wait for input
        /// </summary>

        private void BusMenuInput()
        {
            ShowBusMenu();

            int operation = -1;

            operation = int.Parse(Console.ReadLine());
            switch (operation)
            {
                case 1:
                    BusAdd();
                    break;
                case 2:
                    BusDelete();
                    break;
                case 3:
                    BusGet();
                    break;
                case 4:
                    BusGetAll();
                    break;
                case 5:
                    BusUpdate();
                    break;
                default:
                    Console.WriteLine("Option not available!\nReturning to main menu...");
                    break;
            }

        }

        /// <summary>
        /// Manually add a new bus to the database
        /// </summary>
        private void BusAdd()
        {
            Bus bus = new Bus();
            Console.WriteLine("Enter model:");
            bus.Model = Console.ReadLine();
            Console.WriteLine("Enter capacity:");
            bus.Capacity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter kilometers runed:");
            bus.KilometersRun = int.Parse(Console.ReadLine());
            busBusiness.Add(bus);
        }

        /// <summary>
        /// Delete a bus by given id
        /// </summary>
        private void BusDelete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            Bus bus = busBusiness.Get(id);
            if (bus != null)
            {
                busBusiness.Delete(id);
                Console.WriteLine("Done.");
            }
            else
            {
                Console.WriteLine("Bus not found!");
            }
        }

        /// <summary>
        /// Displays information about the bus for the travel
        /// </summary>
        private void BusGet()
        {
            Console.WriteLine("Enter ID to get: ");
            int id = int.Parse(Console.ReadLine());
            Bus bus = busBusiness.Get(id);
            if (bus != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + bus.Id);
                Console.WriteLine("Model: " + bus.Model);
                Console.WriteLine("Capacity: " + bus.Capacity);
                Console.WriteLine("Kilometers ran: " + bus.KilometersRun);
                Console.WriteLine(new string('-', 40));
            }
        }

        /// <summary>
        /// Displays information about all busses in the database
        /// </summary>
        private void BusGetAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "BUSES" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var buses = busBusiness.GetAll();
            foreach (var bus in buses)
            {
                Console.WriteLine($"{bus.Id} {bus.Model} {bus.Capacity} {bus.KilometersRun}");
            }
        }

        /// <summary>
        /// Update a bus in the database
        /// </summary>
        private void BusUpdate()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Bus bus = busBusiness.Get(id);
            if (bus != null)
            {
                Console.WriteLine("Enter model: ");
                bus.Model = Console.ReadLine();
                Console.WriteLine("Enter capacity: ");
                bus.Capacity = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter kilometers runed: ");
                bus.KilometersRun = int.Parse(Console.ReadLine());
                busBusiness.Update(bus);
            }
            else
            {
                Console.WriteLine("Bus not found!");
            }
        }


        public void ShowBusMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string('-', 18) + "BUS MENU" + new string('-', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. Add new bus");
            Console.WriteLine("2. Delete a bus");
            Console.WriteLine("3. Get bus");
            Console.WriteLine("4. Get all buses");
            Console.WriteLine("5. Update a bus");
        }
    }
}
