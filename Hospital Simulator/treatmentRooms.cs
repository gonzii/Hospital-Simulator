using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Simulator
{
    class TreatmentRooms
    {
        private string _name;
        public TreatmentMachines _machines;
        // unique name
        public string Name {
            get { return _name; }
            set { _name = value; }
        }

        public TreatmentMachines Machines
        {
            get {return _machines;}
            set { _machines = value; }
        }
    }
}
