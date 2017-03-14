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
     
            // Get Patients using readme file
            Patient patientX = new Patient()
            {
                Name = "Hanna",
                Condition = Condition.HeadNeckCancer
            };

            // The Doctors
            List<Doctor> doctors = new List<Doctor>()
            {
                new Doctor()
                {
                    Name = "John",
                    _roles = new List<Roles>()
                    {
                        Roles.Oncologist
                    }
                },
                new Doctor()
                {
                    Name = "Anna",
                    _roles = new List<Roles>()
                    {
                        Roles.Oncologist,
                        Roles.GeneralPractitioner
                    }
                },
                new Doctor()
                {
                    Name = "Peter",
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
            IEnumerable<Consultation> consultations = new List<Consultation>()
            {
                new Consultation()
                {
                    PatientName = "Jonas",
                    DoctorName = "John",
                    TreatmentRoomName = "Three",
                    ConsultationDate = DateTime.Today.AddDays(1),
                    RegistrationDate = DateTime.Today
                }
            };
            var myDoctors = doctors[0].GetDoctorToPatient(patientX, doctors);
            var myTreatmentRoom = treatmentRooms[0].GetMyTreatmentRoom(patientX, treatmentRooms);
            Consultation busyDay;
            var NextDay = DateTime.Now.AddDays(1);
            if ((busyDay = consultations.FirstOrDefault(x => x.ConsultationDate == NextDay)) != null)
            {
                if (myDoctors.Contains(new Doctor() {Name = busyDay.DoctorName}))
                {
                    // && myTreatmentRoom.Contains(new TreatmentRoom() {Name = busyDay.TreatmentRoomName })
                }
            }
            else
            {
                var firstOrDefault = myDoctors.FirstOrDefault();
                var treatmentRoom = myTreatmentRoom.FirstOrDefault();
                if (firstOrDefault != null && treatmentRoom != null)
                {
                     Consultation patientConsultation = new Consultation()
                        {
                            PatientName = patientX.Name,
                            DoctorName = firstOrDefault.Name,
                            ConsultationDate = NextDay,
                            RegistrationDate = DateTime.Today,
                            TreatmentRoomName = treatmentRoom.Name
                        };                  
                }
            }
            /*
            IEnumerable<Consultation> consultations = new List<Consultation>()
            {
                new Consultation("Peter", "John","Four",DateTime.Today)
                {
                    ConsultationDate = DateTime.Today.AddDays(1)
                }
            };


            int index = 0;
            var NextDay = DateTime.Now.AddDays(1);
            Consultation busyDay;
            var myDoctors = doctors[0].GetDoctorToPatient(patientX, doctors);
            var myTreatmentRoom = treatmentRooms[0].GetMyTreatmentRoom(patientX, treatmentRooms);

        
                // kolla om det finns consultationreg idag               
             //  var gmm = consultations.FirstOrDefault(x => x.ConsultationDate == NextDay);
            if ((busyDay = consultations.FirstOrDefault(x => x.ConsultationDate == NextDay)) != null)
            {
                if (!myDoctors.Contains(busyDay.Doctor) && !myTreatmentRoom.Contains(busyDay.TreatmentRoom))
                {

                }
            }
            else
            {
               Consultation patientConsultation = new Consultation(patientX.Name,myDoctors.FirstOrDefault().Name,myTreatmentRoom.FirstOrDefault().Name,DateTime.Today)
               {
                   ConsultationDate = NextDay
               }; 
            }
                
            */

            //var enumarator = consultations.GetEnumerator();

            //while (enumarator.MoveNext())
            //{
            //    var obj = enumarator.Current;
            //}

            //foreach (var consultation in consultations)
            //{
            //    if (!myDoctors.Contains(consultation.Doctor) && !myTreatmentRoom.Contains(consultation.TreatmentRoom))
            //    {
            //        consultation.ConsultationDate
            //    }

            //}
        }

    }


}

