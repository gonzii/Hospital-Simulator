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

        public Doctor(string name)
        {
            Name = name;
            _roles = new List<Roles>();
        }

        public string Name { get; internal set; }      
        
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


    }
}
