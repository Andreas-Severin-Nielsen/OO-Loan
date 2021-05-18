using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_Loan
{
    class User
    {
        private string id;

        /// <summary>
        /// String: User ID
        /// </summary>
        public string Id { get => id; }

        /// <summary>
        /// String: The name of the user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Unit the user is loaning. Null if no loan is active for user
        /// </summary>
        public Unit Unit { get; set; }

        /// <summary>
        /// Constructing object of a user
        /// </summary>
        /// <param name="id">string: unique ID of user</param>
        /// <param name="name">string: name of user</param>
        public User(string id, string name)
        {
            this.id = id ?? throw new ArgumentNullException(nameof(id));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Unit = null;
        }

        /// <summary>
        /// Registering the unit a user is loaning
        /// </summary>
        /// <param name="selectedUnit">Unit the user is loaning</param>
        internal void RegisterLoan(Unit selectedUnit)
        {
            Unit = selectedUnit;
        }

        /// <summary>
        /// Readable information about user (name and ID)
        /// </summary>
        /// <returns>string readable user information</returns>
        public string GetDesignation()
        {
            return Name + "(" + id + ")";
        }
    }
}
