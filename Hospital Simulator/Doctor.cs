using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Simulator
{
    enum Roles
    {
        Oncologist,
        GeneralPractitioner
    };
    class Doctor
    {
        public List<Roles> _roles;
        /// <summary>
        /// Properties for Doctor class
        /// </summary>
        public string Name { get; internal set; }
        public Roles Roles { get; set; }

        /// <summary>
        /// Method retrieving a list of possible doctors for the patient
        /// </summary>
        /*
        public List<Doctor> GetDoctorToPatient(Patient patient, List<Doctor> doctorList)
        {
            if (patient.Condition == Condition.HeadNeckCancer || patient.Condition == Condition.BreastCancer)
            {
                var doctors = doctorList.Where(x => x._roles.Any(m => m == Roles.Oncologist)).ToList();
                //doctorList.Select(x => x._roles.Contains(Roles.Oncologist));
                //doctorList.Any(x => x._roles.Contains(Roles.Oncologist));
                return doctors;
            }
            else
            {
                var doctors = doctorList.Where(x => x._roles.Any(m => m == Roles.GeneralPractitioner)).ToList();
                return doctors;
            }
        }
        */


    }
}
