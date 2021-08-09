using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_Loan
{
    /// <summary>
    /// Controll class, managing all business logic concerning loans
    /// </summary>
    class LoanManager
    {
        private School school;

        /// <summary>
        /// Creating the manager object and attaching a school object by Dependency Injection
        /// </summary>
        /// <param name="school">School containing users and units</param>
        public LoanManager(School school)
        {
            this.school = school;
        }

        /// <summary>
        /// Gets all users that are able to make a loan
        /// </summary>
        /// <returns>List ofavailable Users</returns>
        internal List<User> GetAvailableUsers()
        {
            List<User> users = new List<User>();
            foreach(User u in school.Users)
            {
                if (u.Unit == null) users.Add(u);
            }
            return users;
        }

        /// <summary>
        /// Gets all units that can be loaned
        /// </summary>
        /// <returns>List of units</returns>
        internal List<IUnit> GetAvailableUnits()
        {
            List<IUnit> units = new List<IUnit>();
            foreach (IUnit u in school.Units)
            {
                if (u.GetState() == State.Free) units.Add(u);
            }
            return units;
        }

        /// <summary>
        /// Creating a loan by registering connection within one user and one unit
        /// </summary>
        /// <param name="selectedUser">User loaning the unit</param>
        /// <param name="selectedUnit">IUnit the user is loaning</param>
        internal void CreateLoan(User selectedUser, IUnit selectedUnit)
        {
            selectedUser.RegisterLoan(selectedUnit);
            selectedUnit.RegisterLoan(selectedUser);
        }

        /// <summary>
        /// Gets all units that are loaned by users
        /// </summary>
        /// <returns>List of loaned units</returns>
        internal List<IUnit> GetLoanedUnits()
        {
            List<IUnit> units = new List<IUnit>();
            foreach(IUnit u in school.Units)
            {
                if (u.GetState() == State.Lended) units.Add(u);
            }
            return units;
        }

        /// <summary>
        /// Ending a loan by removing the connections within a user and a unit
        /// </summary>
        /// <param name="unit">IUnit that is returned by the user</param>
        internal void EndLoan(IUnit unit)
        {
            unit.Getuser().Unit = null;
            unit.ReturnUnit();
        }
    }
}
