using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_Loan
{
    /// <summary>
    /// Control class maanaging all business logic concerning units
    /// </summary>
    class UnitManager
    {
        private int count;  // global counter for units
        private List<IUnit> units;

        /// <summary>
        /// Creating object of the class UnitManager, using a list of units attached by Dependency Injection
        /// </summary>
        /// <param name="units">List of units</param>
        public UnitManager(List<IUnit> units)
        {
            this.units = units;
            count = 0;
        }

        /// <summary>
        /// Updates the global unit counter, then returning the number as a string
        /// </summary>
        /// <returns>Updated global unit counter</returns>
        private string NewID()
        {
            count++;
            return count.ToString("D4");
        }

        /// <summary>
        /// Creating a new laptop, and attaching it to the list of units
        /// </summary>
        /// <param name="brand">Name of laptop brand</param>
        /// <returns>Readable laptop designation</returns>
        public string CreateNewLaptop(string brand)
        {
            string id = "L" + NewID();
            IUnit unit = new Laptop(id, brand);
            units.Add(unit);
            return unit.GetDesignation();
        }

        /// <summary>
        /// Creating a new headset, and attaching it to the list of units
        /// </summary>
        /// <returns>Readable headset designation</returns>
        public string CreateNewHeadset()
        {
            string id = "H" + NewID();
            IUnit unit = new Headset(id);
            units.Add(unit);
            return unit.GetDesignation();
        }

        /// <summary>
        /// Gets a list of all units reserved for service
        /// </summary>
        /// <returns>List of units to maintain</returns>
        internal List<IUnit> GetUnitsForService()
        {
            List<IUnit> reserved = new List<IUnit>();
            foreach(IUnit u in units)
            {
                if (u.GetState() == State.Reserved) reserved.Add(u);
            }
            return reserved;
        }

        /// <summary>
        /// Registering that a unit has been maintained
        /// </summary>
        /// <param name="unit">IUnit that has been maintained</param>
        internal void RegisterService(IUnit unit)
        {
            unit.RegisterService(DateTime.Now);
        }

        /// <summary>
        /// Gets a list of all the units regardless of state
        /// </summary>
        /// <returns>List of units</returns>
        internal List<IUnit> GetAllunits()
        {
            return units;
        }

        /// <summary>
        /// Removing a unit from the system. If a user is registered as a loaner, the loan will be cleared.
        /// </summary>
        /// <param name="selection">Index of the unit to be removed from the list of units</param>
        internal void RemoveUnit(int selection)
        {
            IUnit unit = units[selection];
            if (unit.Getuser() != null) unit.Getuser().Unit = null;
            units.Remove(unit);
        }
    }
}
