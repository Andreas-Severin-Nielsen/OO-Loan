using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_Loan
{
    class Headset : IUnit
    {
        private string id;
        private int numberOfLendings;
        private State state;
        private User user;
        private DateTime lastServiced;

        public Headset(string id)
        {
            this.id = id ?? throw new ArgumentNullException(nameof(id));
        }

        public string GetDesignation()
        {
            return "Headset("+id + ") - " + state;
        }

        public string GetId()
        {
            return id;
        }

        public int GetNumberOfLendings()
        {
            return numberOfLendings;
        }

        public State GetState()
        {
            return state;
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

        public void RegisterService(DateTime date)
        {
            lastServiced = date;
            state = State.Free;
        }

        public void ReturnUnit()
        {
            this.user = null;
            if (numberOfLendings % 3 == 0)      // service every third time
                state = State.Reserved;
            else
                state = State.Free;
        }
    }
}
