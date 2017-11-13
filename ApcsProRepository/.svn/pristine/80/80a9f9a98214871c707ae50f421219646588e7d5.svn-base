using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rohm.Common.Model;

namespace Rohm.DataAccess
{
    public class MachineRepository
    {
        private string c_ConnectionString;
        private string ConnectionString
        {
            get { return c_ConnectionString; }
            set { c_ConnectionString = value; }
        }

        public MachineRepository(string connectionString)
        {
            c_ConnectionString = connectionString;            
        }

        public Machine GetMachineById(int id)
        {
            return new Machine() { 
                MachineName = "M-001",
                State = "Running"
            };
        }

        public Machine[] GetMachineByCellControllerIp(string cellControllerIp)
        {
            Machine[] machineArray;

            machineArray = new Machine[3];

            machineArray[0] = new Machine() { MachineName = "M-002", State = "Stop" };
            machineArray[1] = new Machine() { MachineName = "M-003", State = "Alarm" };
            machineArray[2] = new Machine() { MachineName = "M-004", State = "Running" };

            return machineArray;
        }

    }
}
