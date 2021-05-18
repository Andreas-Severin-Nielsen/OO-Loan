using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_Loan
{
    /// <summary>
    /// Main console user interface for the loan program
    /// </summary>
    class MainScreen
    {
        private School school;
        private LoanScreen loanScreen;
        private UnitScreen unitScreen;
        private UserScreen userScreen;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="school">School to be administrated by the loan system</param>
        /// <param name="loanManager">Loan controller</param>
        /// <param name="unitManager">Unit Controller</param>
        /// <param name="userManager">User controller</param>
        public MainScreen(School school, LoanManager loanManager, UnitManager unitManager, UserManager userManager)
        {
            this.school = school;
            loanScreen = new LoanScreen(loanManager);
            unitScreen = new UnitScreen(unitManager);
            userScreen = new UserScreen(userManager);
        }

        /// <summary>
        /// Showing the console user interface
        /// </summary>
        public void RunMain()
        {
            MenuSelection ms = new MenuSelection();
            ms.Headline = "Hovedmenu - " + school.Name + " Udlånssystem";
            ms.SelectionMessage = "Vælg handling";
            ms.AddOption("Udlån udstyr");
            ms.AddOption("Modtag udstyr retur");
            ms.AddOption("Vedligehold udstyr");
            ms.AddOption("Administrer udstyr");
            ms.AddOption("Administrer lånere");
            ms.AddOption("Afslut program");
            int svar;
            while (true)
            {
                svar = ms.RequestSelection();
                switch (svar)
                {
                    case 0:
                        return;
                    case 1:
                        loanScreen.CreateLoan();
                        break;
                    case 2:
                        loanScreen.EndLoan();
                        break;
                    case 3:
                        unitScreen.Service();
                        break;
                    case 4:
                        unitScreen.ManageUnits();
                        break;
                    case 5:
                        userScreen.ManageUsers();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        continue;
                } 
            }

        }


    }
}
