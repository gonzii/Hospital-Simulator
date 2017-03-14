using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Simulator
{
    class Program
    {


        //public static List<Doctor> doctors;


        public static void Main(string[] args)
        {
            IEnumerable<Consultation> consultations = new List<Consultation>();

            // Get Patients using readme file
            Patient patientX = new Patient()
            {
                Name = "Hanna",
                Condition = Condition.HeadNeckCancer
            };

            // The Doctors
            List<Doctor> doctors = new List<Doctor>()
            {
                new Doctor("John")
                {
                    _roles = new List<Roles>()
                    {
                        Roles.Oncologist
                    }
                },
                new Doctor("Anna")
                {
                    _roles = new List<Roles>()
                    {
                        Roles.Oncologist,
                        Roles.GeneralPractitioner
                    }
                },
                new Doctor("Peter")
                {
                    _roles = new List<Roles>()
                    {
                        Roles.GeneralPractitioner
                    }
                }

            };
            // Treatment Machine
            List<TreatmentMachine> treatmentMachines = new List<TreatmentMachine>()
            {
                new TreatmentMachine()
                {
                    Name = "Elekta",
                    Capability = Capability.Advanced
                },
                new TreatmentMachine()
                {
                    Name = "Varian",
                    Capability = Capability.Advanced
                },
                new TreatmentMachine()
                {
                    Name ="MM50",
                    Capability = Capability.Simple
                }
            };
            // Treatment Room
            List<TreatmentRoom> treatmentRooms = new List<TreatmentRoom>()
            {
                new TreatmentRoom()
                {
                    Name = "One",
                    TreatmentMachine = treatmentMachines.Single(x => x.Name == "Elekta")
                },
                new TreatmentRoom()
                {
                    Name = "Two",
                    TreatmentMachine = treatmentMachines.Single(x => x.Name == "Varian")
                },
                new TreatmentRoom()
                {
                    Name = "Three",
                    TreatmentMachine = treatmentMachines.Single(x => x.Name == "MM50")
                },
                new TreatmentRoom()
                {
                    Name = "Four"
                },
                new TreatmentRoom()
                {
                    Name = "Five"
                }

            };


            var myDoctors = doctors[0].GetDoctorToPatient(patientX, doctors);
            var myTreatmentRoom = treatmentRooms[0].GetMyTreatmentRoom(patientX, treatmentRooms);
            foreach (var consultation in consultations)
            {
                
            }
        }

    }


}

