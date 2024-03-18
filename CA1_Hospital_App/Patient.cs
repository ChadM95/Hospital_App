using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public Patient(string name)
        {
            Name = name;
        }

        public Patient(string name, DateTime dob)
        {
            Name = name;
            DOB = dob;
        }

        public Patient(string name, BloodType bloodType)
        {
            Name = name;
            BloodType = bloodType;
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
            return $"{Name} ({GetAge()}) Blood Type: {BloodType}";
        }

        public int GetAge()
        {
            int age;
            DateTime today = DateTime.Today;
            age = today.Year - this.DOB.Year;
            return age;
        }

    }
   
}
