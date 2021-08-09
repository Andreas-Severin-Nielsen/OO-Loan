using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_Loan
{
    interface IUnit
    {
        /// <summary>
        /// Returns the units ID
        /// </summary>
        /// <returns>string unique identification</returns>
        string GetId();

        /// <summary>
        /// Gets the number of times a unit has been loaned
        /// </summary>
        /// <returns>int loan count of the unit</returns>
        int GetNumberOfLendings();

        /// <summary>
        /// Registers the return of a unit and the end of a loan
        /// </summary>
        void ReturnUnit();

        /// <summary>
        /// gets the state of the unit, which can either be loaned, available or reserved for service
        /// </summary>
        /// <returns>Enum state</returns>
        State GetState();

        /// <summary>
        /// Gets readable information about the unit
        /// </summary>
        /// <returns>string unit information</returns>
        string GetDesignation();

        /// <summary>
        /// Registers that service has been performed on the unit on the given date
        /// </summary>
        /// <param name="date">Datetime date of service performed</param>
        void RegisterService(DateTime date);

        /// <summary>
        /// Gets the user, if a user is loaning the unit. Returns null if no loan is active
        /// </summary>
        /// <returns>user who is loaning the unit, or null</returns>
        User Getuser();

        /// <summary>
        /// Registers that the unit is being loaned, and attaching a user who is loaning the unit
        /// </summary>
        /// <param name="selectedUser">User who is loaning the unit</param>
        void RegisterLoan(User selectedUser);
    }
}
