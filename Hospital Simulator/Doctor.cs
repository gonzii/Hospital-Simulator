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
        General_Practitioner
    };
    class Doctor
    {
        private string name;

        public string Name { get; internal set; }
        public Roles Role { get; set; }

    }
}
