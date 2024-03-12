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
        public int Capacity { get; set; }

        public ObservableCollection<Patient> patients = new ObservableCollection<Patient>();


        //constructors
        public Ward()
        {
            
        }
        public Ward(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
        }

    }
}
