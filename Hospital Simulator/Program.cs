using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Consultation> consultation = new List<Consultation>();



            Doctor DrX = new Doctor()
            {
                Name = "Strange",
                Role = Roles.Oncologist
            };
        }
    }
}
