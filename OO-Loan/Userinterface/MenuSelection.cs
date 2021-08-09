using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_Loan
{
    /// <summary>
    /// Generic menu selection class for console user interface. Use:
    /// <br></br>1: Set Headline property (headline of menu selection)
    /// <br></br>2: Set SelectionMessage property (deeper explanation of the menu)
    /// <br></br>3: use AddOption to add options to the menu
    /// <br></br>4: use RequestSelection to show the options and get the user input
    /// </summary>
    class MenuSelection
    {
        public string Headline { get; set; }
        public string SelectionMessage { get; set; }
        private List<string> options;
        private int optionCounter;
        private int selector;
        private string numberInput;

        public MenuSelection()
        {
            Headline = "Menu Selection";
            SelectionMessage = "Select an option below:";
            options = new List<string>();
            selector = 0;
            optionCounter = 0;
        }

        /// <summary>
        /// Adds one option to the menu selection
        /// </summary>
        /// <param name="option">string: name of option</param>
        public void AddOption(string option)
        {
            optionCounter++;
            options.Add(" " + optionCounter + " - " + option);
        }

        /// <summary>
        /// Adds a list of users, where each user is an option
        /// </summary>
        /// <param name="users">List of users</param>
        internal void AddOption(List<User> users)
        {
            foreach (User u in users)
                AddOption(u.Id + " - " + u.Name);
        }

        /// <summary>
        /// Returns users selection as integer value.
        /// <br></br>Option 0 is always stated as return
        /// <br></br>Option index starts with 1.
        /// <br></br>Headline, SelectionMessage and options should be added before this is used.
        /// </summary>
        /// <returns>int user selection</returns>
        public int RequestSelection()
        {
            string returnOption = " 0 - tilbage";
            if (options.Count == 0 || !options[0].Equals(returnOption)) options.Insert(0, returnOption);
            selector = 1;
            return GetSelection();
        }

        /// <summary>
        /// Adds a list of units, where each unit is an option in the menu
        /// </summary>
        /// <param name="units">List of units</param>
        internal void AddOption(List<IUnit> units)
        {
            foreach (IUnit u in units)
                AddOption(u.GetDesignation());
        }

        private void DrawRequest()
        {
            Console.Clear();
            Console.WriteLine(" - " + Headline.ToUpper() + " - \r\n");
            Console.WriteLine(SelectionMessage);
            int writecounter = 0;
            foreach (string s in options)
            {
                if (writecounter == selector)
                {
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                }
                Console.WriteLine(s);
                Console.BackgroundColor = default;
                writecounter++;
            }
            Console.WriteLine(numberInput);
        }


        private int GetSelection()
        {
            while (true)
            {
                DrawRequest();
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.Escape:
                        return 0;
                    case ConsoleKey.Enter:
                        return selector;
                    case ConsoleKey.D0:
                    case ConsoleKey.NumPad0:
                        if (optionCounter < 10) return 0;
                        else AddNumberInput("0");
                        break;
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        if (optionCounter < 10 && optionCounter >= 1) return 1;
                        else AddNumberInput("1");
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        if (optionCounter < 10 && optionCounter >= 2) return 2;
                        else AddNumberInput("2");
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        if (optionCounter < 10 && optionCounter >= 3) return 3;
                        else AddNumberInput("3");
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        if (optionCounter < 10 && optionCounter >= 4) return 4;
                        else AddNumberInput("4");
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        if (optionCounter < 10 && optionCounter >= 5) return 5;
                        else AddNumberInput("5");
                        break;
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        if (optionCounter < 10 && optionCounter >= 6) return 6;
                        else AddNumberInput("6");
                        break;
                    case ConsoleKey.D7:
                    case ConsoleKey.NumPad7:
                        if (optionCounter < 10 && optionCounter >= 7) return 7;
                        else AddNumberInput("7");
                        break;
                    case ConsoleKey.D8:
                    case ConsoleKey.NumPad8:
                        if (optionCounter < 10 && optionCounter >= 8) return 8;
                        else AddNumberInput("8");
                        break;
                    case ConsoleKey.D9:
                    case ConsoleKey.NumPad9:
                        if (optionCounter < 10 && optionCounter >= 9) return 9;
                        else AddNumberInput("9");
                        break;
                    case ConsoleKey.UpArrow:
                        if (selector > 0) selector--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (selector < optionCounter) selector++;
                        break;
                    case ConsoleKey.Backspace:
                        RemoveNumberInput();
                        break;
                    default:
                        continue;
                }
                numberInput = selector.ToString();
            }
        }

        private void RemoveNumberInput()
        {
            numberInput = numberInput.Remove(numberInput.Length-1);
        }

        private void AddNumberInput(string userInput)
        {
            numberInput += userInput;
            int newNumber = int.Parse(numberInput);
            while (newNumber > optionCounter)
            {
                numberInput = numberInput.Remove(0, 1);
                if (numberInput == "")
                {
                    selector = 0;
                    return;
                }
                newNumber = int.Parse(numberInput);
            }
            selector = newNumber;
        }
    }
}
