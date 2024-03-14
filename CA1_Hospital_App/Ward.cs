using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Pipes;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace CA1_Hospital_App
{
    public class Ward
    {
        public string Name { get; set; }
        public double Capacity { get; set; }

        public ObservableCollection<Patient> patients = new ObservableCollection<Patient>();

        //static field to track number of wards
        public static int NumberOfWards;

        //constructors
        public Ward()
        {
            //add to ward counter field
            NumberOfWards++;
        }
        public Ward(string name, double capacity)
        {
            Name = name;
            Capacity = capacity;
            patients = new ObservableCollection<Patient>();
            
            //add to ward counter field
            NumberOfWards++;
        }

        //methods
        public override string ToString()
        {
            return $"{Name}     Limit: {Capacity:F0}";
        }
    }
}
