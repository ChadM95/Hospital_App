using System.Collections.ObjectModel;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CA1_Hospital_App
{
    //Create Blood Type Enum 
    public enum BloodType
    {
        A, B, AB, O
    }
    public partial class MainWindow : Window
    {
        //create collection of ward objects
        public ObservableCollection<Ward> wards = new ObservableCollection<Ward>();
        public MainWindow()
        {
            InitializeComponent();

        }

        //window loaded event - populates program with sample ward and patient objects
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //create sample wards
            Ward w1 = new Ward("The Bee Gees Ward", 3);
            Ward w2 = new Ward("The Simpsons Ward", 5);

            //add to wards collection
            wards.Add(w1);
            wards.Add(w2);

            //update wards listbox
            lbxWards.ItemsSource = wards;

            //create patients for ward 1
            Patient p1 = new Patient("Barry", new DateTime(1946, 9, 1), BloodType.A);
            Patient p2 = new Patient("Robin", new DateTime(1949, 12, 22), BloodType.O);
            Patient p3 = new Patient("Maurice", new DateTime(1949, 12, 22), BloodType.AB);

            //create patients for ward 2
            Patient p4 = new Patient("Homer", new DateTime(1982, 1, 1), BloodType.AB);
            Patient p5 = new Patient("Marge", new DateTime(1984, 2, 2), BloodType.O);
            Patient p6 = new Patient("Bart", new DateTime(2014, 3, 3), BloodType.A);
            Patient p7 = new Patient("Lisa", new DateTime(2016, 4, 4), BloodType.B);
            Patient p8 = new Patient("Maggie", new DateTime(2023, 5, 5), BloodType.AB);

            //Add patients to ward 1
            w1.patients.Add(p1);
            w1.patients.Add(p2);
            w1.patients.Add(p3);

            //Add patients to ward 2
            w2.patients.Add(p4);
            w2.patients.Add(p5);
            w2.patients.Add(p6);
            w2.patients.Add(p7);
            w2.patients.Add(p8);

            //update ward header
            tblkWardHeader.Text = $"Ward List ({Ward.NumberOfWards})";
        }

        //update listboxes when ward is selected
        private void lbxWards_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbxWards.SelectedItem is Ward SelectedWard)
            {
                lbxPatients.ItemsSource = SelectedWard.patients;
            }

        }

        //update patient details display
        private void lbxPatients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SelectedPatient = lbxPatients.SelectedItem as Patient;

            if (SelectedPatient != null)
            {
                //display patient name
                tblkName.Text = SelectedPatient.Name;

                //display patient blood type image
                switch (SelectedPatient.BloodType)
                {
                    case BloodType.A:
                        bloodImg.Source = new BitmapImage(new Uri("/CA1_Hospital_App;component/Images/a.png", UriKind.Relative));
                        break;

                    case BloodType.B:
                        bloodImg.Source = new BitmapImage(new Uri("/CA1_Hospital_App;component/Images/b.png", UriKind.Relative));
                        break;

                    case BloodType.AB:
                        bloodImg.Source = new BitmapImage(new Uri("/CA1_Hospital_App;component/Images/ab.png", UriKind.Relative));
                        break;

                    case BloodType.O:
                        bloodImg.Source = new BitmapImage(new Uri("/CA1_Hospital_App;component/Images/o.png", UriKind.Relative));
                        break;

                }

            }
        }

        //display slider number in textblock
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tblkCapacity.Text = String.Format("{0:F0}", sliderCapacity.Value);
        }

        //add new ward
        private void btnAddWard_Click(object sender, RoutedEventArgs e)
        {
            if (tbWardName.Text != null && sliderCapacity.Value > 0)
            {
                //read in name and capacity
                string name = tbWardName.Text;
                double capacity = sliderCapacity.Value;
                
                //create new ward object
                Ward newWard = new Ward(name,capacity);
                
                //add to ward collection
                wards.Add(newWard);

                //update ward header
                tblkWardHeader.Text = $"Ward List ({Ward.NumberOfWards})";
            }
        }

        //add new patient
        private void btnAddPatient_Click(object sender, RoutedEventArgs e)
        {
            //create object reference for selected ward 
            var SelectedWard = lbxWards.SelectedItem as Ward;

            //check ward capacity first
            if (SelectedWard.patients.Count == SelectedWard.Capacity)
                MessageBox.Show($"Ward capacity ({SelectedWard.Capacity:F0}) reached. Cannot add any more wards");

            else if (tbPatientName.Text != null && datePickerDOB.SelectedDate != null )
            {
                //read in data
                string name = tbPatientName.Text;
                DateTime dob = (DateTime)datePickerDOB.SelectedDate;

                BloodType bloodType = BloodType.A; //default value to prevent compiler error

                //radio buttons
                if (rdBtnA.IsChecked.Equals(true))
                {
                    bloodType = BloodType.A;
                }

                else if (rdBtnB.IsChecked == true)
                {
                    bloodType = BloodType.B;
                }

                else if (rdBtnAB.IsChecked == true)
                {
                    bloodType = BloodType.AB;
                }

                else if (rdBtnO.IsChecked == true)
                {
                    bloodType = BloodType.O;
                }

                //create new object
                Patient p1 = new Patient
                {
                    Name = name,
                    DOB = dob,
                    BloodType = bloodType                     
                };

                //add patient to selected ward
                SelectedWard.patients.Add(p1);
            }
        }
    }
}