using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_Loan
{
    /// <summary>
    /// Console user interface for IUnit management
    /// </summary>
    class UnitScreen
    {
        private UnitManager unitManager;


        public UnitScreen(UnitManager unitManager)
        {
            this.unitManager = unitManager;
        }

        internal void Service()
        {
            List<IUnit> units = unitManager.GetUnitsForService();
            MenuSelection unitSelection = new MenuSelection();
            unitSelection.Headline = "Vælg Enhed";
            unitSelection.SelectionMessage = "Vælg den enhed der udføres vedligeholdelse på";
            unitSelection.AddOption(units);
            int selection = unitSelection.RequestSelection();
            if (selection == 0) return;
            selection--; // zero index correction

            Console.WriteLine("Der registreres nu udført vedligehold på " + units[selection].GetDesignation());
            unitManager.RegisterService(units[selection]);
            Console.WriteLine("Der er nu registreret vedligehold på enheden.");
            Console.ReadKey();
        }

        internal void ManageUnits()
        {
            MenuSelection menuSelection = new MenuSelection();
            menuSelection.Headline = "Vælg administration af enheder";
            menuSelection.SelectionMessage = "Vælg en af nedenstående handlinger";
            menuSelection.AddOption("Tilføj ny enhed");
            menuSelection.AddOption("Slet eksisterende enhed");
            int selection = menuSelection.RequestSelection();
            switch (selection)
            {
                case 0:
                    return;
                case 1:
                    RegisterNewUnit();
                    break;
                case 2:
                    RemoveUnit();
                    break;
            }
        }


        private void RemoveUnit()
        {
            // NOT THREAD SAFE!!!
            MenuSelection menuSelection = new MenuSelection();
            menuSelection.Headline = "Vælg Enhed";
            menuSelection.SelectionMessage = "Vælg den enhed der skal fjernes fra systemet";
            List<IUnit> units = unitManager.GetAllunits();
            menuSelection.AddOption(units);
            int selection = menuSelection.RequestSelection();
            if (selection == 0) return;
            selection--;  // zero index correction
            Console.WriteLine("Er du sikker på at du vil slette følgende enhed fra systemet?");
            Console.WriteLine(units[selection].GetDesignation());
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Y) unitManager.RemoveUnit(selection);
        }

        private void RegisterNewUnit()
        {
            MenuSelection menuSelection = new MenuSelection();
            menuSelection.Headline = "Vælg Type";
            menuSelection.SelectionMessage = "Vælg typen af enheder";
            menuSelection.AddOption("Laptop");
            menuSelection.AddOption("Headset");
            int selection = menuSelection.RequestSelection();
            switch (selection)
            {
                case 0:
                    return;
                case 1:
                    RegisterNewLaptop();
                    break;
                case 2:
                    RegisterNewHeadset();
                    break;
            }
        }

        private void RegisterNewHeadset()
        {
            Console.Clear();
            Console.WriteLine("Registrering af en ny enhed");
            string response = unitManager.CreateNewHeadset();
            Console.WriteLine("Der er nu oprettet nyt headset: " + response);
            Console.ReadLine();
            return;
        }

        private void RegisterNewLaptop()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Registrering af en ny enhed");
                Console.WriteLine("Indtast mærke:");
                string brand = Console.ReadLine();
                Console.WriteLine("Mærket registreres som " + brand + ". Er dette korrekt? (y/n)");
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.Y:
                        string response = unitManager.CreateNewLaptop(brand);
                        Console.WriteLine("Der er nu oprettet ny enhed: " + response);
                        Console.ReadKey();
                        return;
                    case ConsoleKey.N:
                        continue;
                    default:
                        return;
                }
            }
        }
    }
}
