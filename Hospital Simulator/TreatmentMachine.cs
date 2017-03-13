using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Simulator
{
    enum Capability
    {
        Simple,
        Advanced
    };
    class TreatmentMachine
    {
        public string Name { get; internal set; }

        public Capability Capability { get; set; }
    }
}
