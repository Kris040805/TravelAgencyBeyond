using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public void Input()
        {
            int operation = -1;
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
                    case 6://END 
                        break;
                    default:
                        Console.WriteLine("Option not available!");
                        break;
                }
            } while (operation != 6);
        }


        /* От исмет
        може да трябва да променим заглавията на всички менюта за да са симетрични
        защото при различните менюта ще се отпечатат на различна дължина тези 18 тирета и може да изглежда грозно
        най вероятно ще го оправим като от втория ню стринг с тиретата се извърши това---> 18 - (дължината на думата Бъс, например Бъс меню)
         */
        public void ShowMainMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string('-', 18) + "MENU" + new string('-', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. Bus menu");
            Console.WriteLine("2. City menu");
            Console.WriteLine("3. Client menu");
            Console.WriteLine("4. Driver menu");
            Console.WriteLine("5. Travel menu");
        }
    }
}
