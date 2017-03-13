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
        private Patient name;
        private Doctor doctor;
        private TreatmentRooms treatmentRoom;
        private DateTime registrationDate;
        private DateTime consultationDate;

        public Consultation(Patient name, Doctor doctor, TreatmentRooms treatmentRooms, DateTime registrationDate)
        {
            this.name = name;
            this.doctor = doctor;
            this.treatmentRoom = treatmentRooms;
            this.registrationDate = DateTime.Now;
        }


    }
}
