using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Simulator
{
    class Consultation
    {
        private Patient _name;
        private Doctor _doctor;
        private TreatmentRoom _treatmentRoom;
        private DateTime _registrationDate;
        private DateTime _consultationDate;

        public Consultation(Patient name, Doctor doctor, TreatmentRoom treatmentRooms, DateTime registrationDate)
        {
            this._name = name;
            this._doctor = doctor;
            this._treatmentRoom = treatmentRooms;
            this._registrationDate = DateTime.Now;
        }


    }
}
