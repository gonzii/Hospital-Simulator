using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Simulator
{
  enum Condition
    {
        Flu,
        HeadNeckCancer,
        BreastCancer
    };
    //enum Topology
    //{
    //    HeadNeck,
    //    Breast
    //};
    class Patient
    {
        public string Name { get; internal set; }
        public Condition Condition { get; internal set; }

        //public Patient(string name, Condition condition)
        //{
        //    Name = name;
        //    if(condition == Condition.Cancer)
        //}
    }
}
