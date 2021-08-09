using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_Loan
{
    /// <summary>
    /// Console user interface for managing loans
    /// </summary>
    class LoanScreen
    {
        private LoanManager loanManager;

        public LoanScreen(LoanManager loanManager)
        {
            this.loanManager = loanManager;
        }

        internal void CreateLoan()
        {
            List<User> users = loanManager.GetAvailableUsers();
            MenuSelection userSelection = new MenuSelection();
            userSelection.Headline = "Vælg låner";
            userSelection.SelectionMessage = "Vælg låneren fra følgende liste";
            userSelection.AddOption(users);
            int selectedUser = userSelection.RequestSelection();
            if (selectedUser == 0) return;
            selectedUser--; // zero index correction

            List<IUnit> units = loanManager.GetAvailableUnits();
            MenuSelection unitSelection = new MenuSelection();
            unitSelection.Headline = "Vælg enhed";
            unitSelection.SelectionMessage = "Vælg enheden fra følgende ledige enheder";
            unitSelection.AddOption(units);
            int selectedUnit = unitSelection.RequestSelection();
            if (selectedUnit == 0) return;
            selectedUnit--;  // zero index correction

            loanManager.CreateLoan(users[selectedUser], units[selectedUnit]);

            Console.Clear();
            Console.WriteLine(users[selectedUser].Name + " har nu lånt " + units[selectedUnit].GetDesignation());
            Console.ReadKey();
        }

        internal void EndLoan()
        {
            List<IUnit> units = loanManager.GetLoanedUnits();
            MenuSelection loanSelection = new MenuSelection();
            loanSelection.Headline = "Vælg lån";
            loanSelection.SelectionMessage = "Vælg returneret enhed fra listen";
            loanSelection.AddOption(units);
            int selection = loanSelection.RequestSelection();
            if (selection == 0) return;
            selection--;  // zero index correction
            loanManager.EndLoan(units[selection]);
        }
    }
}
