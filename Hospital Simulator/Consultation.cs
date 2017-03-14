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
  
        private DateTime _consultationDate;

        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string TreatmentRoomName { get; set; }

        //public Consultation(string name, string doctor, string treatmentRooms, DateTime registrationDate)
        //{
        //    new Patient() {Name = name};
        //    new Doctor() {Name = doctor};
        //    new TreatmentRoom() {Name = treatmentRooms};
        //    RegistrationDate = registrationDate;
        //}

        //public Patient Patient { get; set; }
        //public Doctor Doctor { get; set; }
        //public TreatmentRoom TreatmentRoom { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime ConsultationDate { get; set; }

    }
}
