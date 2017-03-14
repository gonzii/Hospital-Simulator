using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Simulator
{
    class Program
    {
        /// <summary>
        /// Method reetrieving a list of possible treatment rooms for the patient
        /// </summary>
        /// <param name="patient">the patient</param>
        /// <param name="treatmentRoomList">List of all treament rooms</param>
        /// <returns>List of possible treatment rooms</returns>
        static List<TreatmentRoom> GetMyTreatmentRoom(Patient patient, List<TreatmentRoom> treatmentRoomList)
        {
            if (patient.Condition == Condition.HeadNeckCancer)
            {
                var mytreatmentRooms =
                    treatmentRoomList.Where(x => x.TreatmentMachine != null && x.TreatmentMachine.Capability == Capability.Advanced).ToList();
                return mytreatmentRooms;
            }
            else if (patient.Condition == Condition.BreastCancer)
            {
                var mytreatmentRooms =
                    treatmentRoomList.Where(x => x.TreatmentMachine != null && x.TreatmentMachine.Capability == Capability.Simple).ToList();
                return mytreatmentRooms;
            }
            else
            {
                var mytreatmentRooms = treatmentRoomList.Where(x => x.TreatmentMachine == null).ToList();
                return mytreatmentRooms;
            }
        }
        /// <summary>
        /// Method retrieving a list of possible doctors for the patient
        /// </summary>
        /// <param name="patient">the patient</param>
        /// <param name="doctorList">List of all doctors</param>
        /// <returns>List of possible doctors </returns>
        static List<Doctor> GetDoctorToPatient(Patient patient, List<Doctor> doctorList)
        {
            if (patient.Condition == Condition.HeadNeckCancer || patient.Condition == Condition.BreastCancer)
            {
                var mydoctors = doctorList.Where(x => x._roles.Any(m => m == Roles.Oncologist)).ToList();
                return mydoctors;
            }
            else
            {
                var mydoctors = doctorList.Where(x => x._roles.Any(m => m == Roles.GeneralPractitioner)).ToList();
                return mydoctors;
            }
        }
      
        public static void Main(string[] args)
        {
            // Reading text file with entry 
            // PatientName|Condition
            StringBuilder sb = new StringBuilder();
            List<Patient> patients = new List<Patient>();
            List<string> patientlist = new List<string>();
            using (StreamReader sr = new StreamReader(@"D:\test.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    patientlist.Add(sr.ReadLine());
                }
            }
            for (int i = 0; i <patientlist.Count; i++)
            {
                string[] str = patientlist[i].Split('|');
                switch (str[1])
                {
                    case "HeadNeckCancer":
                        patients.Add(new Patient() { Name = str[0] , Condition = Condition.HeadNeckCancer});          
                        break;
                    case "BreastCancer":
                        patients.Add(new Patient() { Name = str[0], Condition = Condition.BreastCancer });
                        break;
                    case "Flu":
                        patients.Add(new Patient() { Name = str[0], Condition = Condition.Flu });
                        break;
                }
                
            }
            // Initializing a list of available doctors
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
            // Initializing a list of available Treatment Machines
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
            // Initializing a list of available Treatment Rooms
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

            // Use for testing, adding a consultation to list of consultations
            List<Consultation> consultations = new List<Consultation>()
            {
                new Consultation()
                {
                    Patient = new Patient(){Condition = Condition.HeadNeckCancer, Name = "Per"},
                    Doctor = doctors[1],
                    TreatmentRoom = treatmentRooms[1],
                    ConsultationDate = DateTime.Today.AddDays(1),
                    RegistrationDate = DateTime.Today
                }
            };
            // Preparing for consultation on the next day
            var nextDay = DateTime.Today.AddDays(1);

            // Looping thru patients
            foreach (var patient in patients)
            {
                // retrieving possible doctors and treatmentroom for the patient
                var myDoctors = GetDoctorToPatient(patient, doctors);
                var myTreatmentRoom = GetMyTreatmentRoom(patient, treatmentRooms);
                

                while (true)
                {
                    // adding the cosultations for a day
                    var consultationListForTheDay = consultations.Where(x => x.ConsultationDate == nextDay).ToList();
                    // if consultation found for the specific day, check available doctors and treatmentrooms
                    if (consultationListForTheDay.Count > 0)
                    {
                        var doctorAvailable =
                        myDoctors.Where(p => !consultationListForTheDay.Any(p2 => p2.Doctor.Name == p.Name)).ToList();
                        if (doctorAvailable.Count > 0)
                        {
                            var roomAvailable =
                             myTreatmentRoom.Where(r => !consultationListForTheDay.Any(r2 => r2.TreatmentRoom.Name == r.Name))
                                .ToList();
                            // if room and doctor available then add consultation for the day
                            if (roomAvailable.Count > 0)
                            {
                                consultations.Add(
                                new Consultation()
                                {
                                Patient = patient,
                                Doctor = doctorAvailable.FirstOrDefault(),
                                TreatmentRoom = roomAvailable.FirstOrDefault(),
                                RegistrationDate = DateTime.Today,
                                ConsultationDate = nextDay
                                });
                                break;
                            }
                            // if no available treatmentroom the check for next day
                            else
                            {
                                nextDay = nextDay.AddDays(1);
                            }
                        }
                        else
                        {
                            nextDay = nextDay.AddDays(1);
                        }
                    }
                    // if no consultation found on the day then add random possible doctor and treatment room
                    else
                    {
                        Random random = new Random();
                        consultations.Add(new Consultation()
                        {
                            Patient = patient,
                            Doctor = myDoctors[random.Next(myDoctors.Count)],
                            TreatmentRoom = myTreatmentRoom[random.Next(myTreatmentRoom.Count)],
                            RegistrationDate = DateTime.Today,
                            ConsultationDate = nextDay
                        });
                        break;
                    }
                }
            }
            foreach (var consultation in consultations)
            {
                Console.WriteLine(consultation.Patient.Name);
                Console.WriteLine(consultation.Doctor.Name);
                Console.WriteLine(consultation.TreatmentRoom.Name);
                Console.WriteLine(consultation.ConsultationDate);
                Console.WriteLine(consultation.RegistrationDate);
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}