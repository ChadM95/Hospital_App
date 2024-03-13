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
            //create new ward
            Ward w1 = new Ward("The Bee Gees Ward", 3);
            
            //add to wards collection
            wards.Add(w1);

            //update wards listbox
            lbxWards.ItemsSource = wards;

            //create patients
            Patient p1 = new Patient("Barry",new DateTime(1946,9,1),BloodType.A);
            Patient p2 = new Patient("Robin",new DateTime(1949,12,22),BloodType.O);
            Patient p3 = new Patient("Maurice",new DateTime(1949,12,22),BloodType.AB);

            //Add patients to ward
            w1.patients.Add(p1);
            w1.patients.Add(p2);
            w1.patients.Add(p3);
            
        }

        //update listboxes upon selection
        private void lbxWards_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbxWards.SelectedItem is Ward SelectedWard)
            { 
                lbxPatients.ItemsSource = SelectedWard.patients;
            }

        }
    }

}