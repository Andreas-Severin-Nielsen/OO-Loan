using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_Loan
{
    /// <summary>
    /// Console user interface for managing users
    /// </summary>
    class UserScreen
    {
        private UserManager userManager;

        public UserScreen(UserManager userManager)
        {
            this.userManager = userManager;
        }


        internal void ManageUsers()
        {
            MenuSelection menuSelection = new MenuSelection();
            menuSelection.Headline = "Vælg administration af brugere";
            menuSelection.SelectionMessage = "Vælg en af nedenstående handlinger";
            menuSelection.AddOption("Tilføj ny bruger");
            menuSelection.AddOption("Slet eksisterende bruger");
            int selection = menuSelection.RequestSelection();
            switch (selection)
            {
                case 0:
                    return;
                case 1:
                    RegisterNewUser();
                    break;
                case 2:
                    RemoveUser();
                    break;
            }
        }

        private void RemoveUser()
        {
            List<User> users = new List<User>();
            users = userManager.GetAllUsers();
            MenuSelection menuSelection = new MenuSelection();
            menuSelection.Headline = "Vælg bruger";
            menuSelection.SelectionMessage = "Vælg den bruger der skal fjernes fra systemet";
            menuSelection.AddOption(users);
            int selection = menuSelection.RequestSelection();
            if (selection == 0) return;
            selection--;    // correcting to zero index
            User user = users[selection];
            Console.WriteLine("Er du sikker på at du ønsker at fjerne følgende bruger fra systemet?");
            Console.WriteLine(user.Name);
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Y) userManager.Remove(user);

        }

        private void RegisterNewUser()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Registrering af en ny bruger");
                Console.WriteLine("Indtast navnet på brugeren:");
                string name = Console.ReadLine();
                Console.WriteLine("Bruger registreres som " + name + ". Er dette korrekt? (y/n)");
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.Y:
                        string response = userManager.CreateNewUser(name);
                        Console.WriteLine("Der er nu oprettet ny bruger: " + response);
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
