using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Simulator
{
    class TreatmentRoom
    {
        private string _name;

        // unique name
        public string Name {
            get { return _name; }
            set { _name = value; }
        }
        public TreatmentMachine TreatmentMachine { get; internal set; }

        public List<TreatmentRoom> GetMyTreatmentRoom(Patient patient, List<TreatmentRoom> treatmentRoomList)
        {
            if (patient.Condition == Condition.HeadNeckCancer)
            {
                var treatmentRooms = 
                    treatmentRoomList.Where(x => x.TreatmentMachine.Capability == Capability.Advanced).ToList();
                return treatmentRooms;
                //var doctors = doctorList.Where(x => x._roles.Any(m => m == Roles.Oncologist)).ToList();
            }
            else if (patient.Condition == Condition.BreastCancer)
            {
                var treatmentRooms =
                    treatmentRoomList.Where(x => x.TreatmentMachine.Capability == Capability.Simple).ToList();
                return treatmentRooms;
            }
            else
            {
                var treatmentRooms = treatmentRoomList.Where(x => x.TreatmentMachine == null).ToList();
                return treatmentRooms;
            }
        }
    }
}
