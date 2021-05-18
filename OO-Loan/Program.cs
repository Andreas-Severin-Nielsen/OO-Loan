using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_Loan
{
    class Program
    {
        static void Main(string[] args)
        {
            School school = new School("ZBC");
            LoanManager loanManager = new LoanManager(school);
            UnitManager unitManager = new UnitManager(school.Units);
            UserManager userManager = new UserManager(school.Users);
            CreateSomeTestDate(unitManager, userManager); // Random data put into the system for test purposes
            MainScreen mainScreen = new MainScreen(
                school,
                loanManager,
                unitManager,
                userManager);
            mainScreen.RunMain();

        }

        private static void CreateSomeTestDate(UnitManager unitManager, UserManager userManager)
        {
            unitManager.CreateNewHeadset();
            unitManager.CreateNewLaptop("Lenovo");
            unitManager.CreateNewHeadset();
            unitManager.CreateNewLaptop("Dell");
            unitManager.CreateNewHeadset();
            unitManager.CreateNewLaptop("Apple");
            userManager.CreateNewUser("Pelle Pokerface");
            userManager.CreateNewUser("King Kjeld");
            userManager.CreateNewUser("Bossmann Bent");
            userManager.CreateNewUser("Doris Deltaforce");
            userManager.CreateNewUser("Frode Frontrunner");
            userManager.CreateNewUser("Gitte Goldfinger");
            userManager.CreateNewUser("Lise Lightbringer");
            userManager.CreateNewUser("Otto Overpower");
            userManager.CreateNewUser("Vera Vantage");
            userManager.CreateNewUser("Ralf Rampage");
            unitManager.CreateNewHeadset();
            unitManager.CreateNewHeadset();
            unitManager.CreateNewHeadset();
            unitManager.CreateNewHeadset();
            unitManager.CreateNewHeadset();
            unitManager.CreateNewHeadset();
            unitManager.CreateNewHeadset();
            unitManager.CreateNewHeadset();
            unitManager.CreateNewHeadset();
            unitManager.CreateNewHeadset();

        }
    }
}
