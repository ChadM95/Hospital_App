using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1_Hospital_App
{
    public class Patient
    {
        //properties
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public BloodType BloodType { get; set; }

        //constructors
        public Patient()
        {
            
        }

        public Patient(string name, DateTime dob, BloodType bloodType)
        {
            Name = name;
            DOB = dob;
            BloodType = bloodType;
        }

        //methods
        public override string ToString()
        {
            return $"{Name} ()";
        }

    }
   
}
