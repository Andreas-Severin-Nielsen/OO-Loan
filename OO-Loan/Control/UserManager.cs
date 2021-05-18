using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_Loan
{
    /// <summary>
    /// Control class managing all business logic concerning users
    /// </summary>
    class UserManager
    {
        private int count; // Global user counter
        private List<User> users;

        /// <summary>
        /// Creating object of the class UserManager, attaching a list of users through Dependency Injection
        /// </summary>
        /// <param name="users"></param>
        public UserManager(List<User> users)
        {
            this.users = users;
            count = 0;
        }

        /// <summary>
        /// Creating a new user, and attaching it to the list of users
        /// </summary>
        /// <param name="name">Name of the user</param>
        /// <returns>Readable user designation (name and ID)</returns>
        public string CreateNewUser(string name)
        {
            count++;
            string id = "U" + count.ToString("D4");
            User user = new User(id, name);
            users.Add(user);
            return user.GetDesignation();
        }

        /// <summary>
        /// Gets all users regardless of loans
        /// </summary>
        /// <returns>list of users</returns>
        internal List<User> GetAllUsers()
        {
            return users;
        }

        /// <summary>
        /// Removing a user from the list of users
        /// </summary>
        /// <param name="user">The user object to be removed from the list of users</param>
        internal void Remove(User user)
        {
            users.Remove(user);
        }

    }
}
