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
        // Properties for Consultation
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public TreatmentRoom TreatmentRoom { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime ConsultationDate { get; set; }
    }
}
