using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PharmacyClassLibrary;

namespace PharmacyWPF
{
    /// <summary>
    /// Interaction logic for SellMedicine.xaml
    /// </summary>
    public partial class SellMedicine : Page
    {

        private ObservableCollection<Medicine> _cartItems;

        public SellMedicine()
        {
            InitializeComponent();
            _cartItems = new ObservableCollection<Medicine>();
            TransactionDetails.ItemsSource = _cartItems;
        }


        public void AddToCartBtn_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(MedicineIDTxt.Text, out int parsedMedicineId) == false || MedicineIDTxt.Text == MedicineIDTxt.Placeholder || parsedMedicineId <= 0)
            {
                MessageBox.Show("Invalid Medicine Id", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (long.TryParse(CustomerIDTxt.Text, out long parsedCustomerId) == false || CustomerIDTxt.Text == CustomerIDTxt.Placeholder || parsedCustomerId <= 0 )
            {
                MessageBox.Show("Invalid Customer Id", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (int.TryParse(CustomerAgeTxt.Text, out int parsedCustomerAge) == false || CustomerAgeTxt.Text == CustomerAgeTxt.Placeholder || parsedCustomerAge <0)
            {
                MessageBox.Show("Invalid Customer Age", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (MedicineNameTxt.Text == MedicineNameTxt.Placeholder || int.TryParse(MedicineNameTxt.Text, out int parsedMedicineName) == true)
            {
                MessageBox.Show(" You Must Enter Correct Medicine Name", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (CustomerNameTxt.Text == CustomerNameTxt.Placeholder || int.TryParse(CustomerNameTxt.Text, out int parsedCustomerName) == true)
            {
                MessageBox.Show(" You Must Enter Correct Customer Name", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (int.TryParse(NumofUnitTxt.Text, out int parsedNumUnits) == false || NumofUnitTxt.Text == NumofUnitTxt.Placeholder || parsedNumUnits <= 0)
            {
                MessageBox.Show("Please enter a valid quantity (greater than 0)." , "Input Error" , MessageBoxButton.OK, MessageBoxImage.Error);
                return;


                //_cartItems.Add(soldItem);
            }




        }










        public void MedicineSearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //string searchText = MedicineSearchTextBox.Text.ToLower();

            //var filteredMedicine = allMedicines.Where
            //    (m => m.ToLower().Contains(searchText)).ToList();

            //ResultsListBox.ItemsSource = filteredMedicine;
        }


        public void ResultsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ResultsListBox.SelectedItem != null)
            {
                string selectedMedicine = ResultsListBox.SelectedItem.ToString();
            }
        }
    
    }
}
