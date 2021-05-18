using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_Loan
{
    class School
    {
        /// <summary>
        /// String name of the school
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// List of units registered in the school
        /// </summary>
        public List<Unit> Units { get; set; }

        /// <summary>
        /// List of users (loaners) registered in the school
        /// </summary>
        public List<User> Users { get; set; }

        /// <summary>
        /// Constructing object of the school class
        /// </summary>
        /// <param name="name">string name of the school</param>
        public School(string name)
        {
            Name = name;
            Units = new List<Unit>();
            Users = new List<User>();
        }
    }
}
