using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_Loan
{
    class Laptop : Unit
    {
        private string id;
        private int numberOfLendings;
        private User user;
        private DateTime lastServiced;
        private State state;
        private string brand;

        public string Brand { get => brand; }


        /// <summary>
        /// Creating a new Laptop
        /// </summary>
        /// <param name="id">unique string ID</param>
        /// <param name="brand">Name of laptop</param>
        public Laptop(string id, string brand)
        {
            this.id = id ?? throw new ArgumentNullException(nameof(id));
            this.brand = brand ?? throw new ArgumentNullException(nameof(brand));
            numberOfLendings = 0;
            state = State.Free;
        }


        public void ReturnUnit()
        {
            this.user = null;
            if (numberOfLendings % 2 == 0)  // service every second time
                state = State.Reserved;
            else
                state = State.Free;
        }

        public void RegisterService(DateTime date)
        {
            lastServiced = date;
            state = State.Free;
        }

        public State GetState() { return this.state; }

        public string GetId()
        {
            return id;
        }

        public int GetNumberOfLendings()
        {
            return numberOfLendings;
        }

        public string GetDesignation()
        {
            return "Laptop "+brand + "("+id+") - " + state;
        }

        public User Getuser()
        {
            return this.user;
        }

        public void RegisterLoan(User selectedUser)
        {
            numberOfLendings++;
            this.user = selectedUser;
            state = State.Lended;
        }
    }


}
