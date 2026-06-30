using PharmacyClassLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using UserInfoClass;
using static MaterialDesignThemes.Wpf.Theme.ToolBar;

namespace PharmacyWPF_UI.Pages.Pharmacist
{
    public partial class SellMedicinePage : Page
    {
        List<Medicine> medicines = new List<Medicine>();
        List<CartItem> cartItems = new List<CartItem>();
        private bool isSyncingCombos = false;
        private UserInfo _currentUser;

        public SellMedicinePage(UserInfo currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            LoadMedicines();
        }

        private void LoadMedicines()
        {
            medicines.Clear();
            string path = Path.Combine(AppContext.BaseDirectory, "medicines.txt");
            if (!File.Exists(path)) return;

            string[] MediList = File.ReadAllLines(path);
            for (int i = 1; i < MediList.Length; i++)
            {
                string[] col = MediList[i].Split(',');
                if (col.Length < 7) continue;
                if (!bool.TryParse(col[6], out bool requiresPrescription)) continue;

                Medicine medicine;
                if (requiresPrescription)
                    medicine = new PrescriptionMedicine();
                else
                    medicine = new OTCMedicine();

                medicine.MedicineID = col[0];
                medicine.Name = col[1];
                if (double.TryParse(col[2], out double price)) medicine.Price = price;
                medicine.Manufacturer = col[3];
                if (int.TryParse(col[4], out int qty)) medicine.QuantityInStock = qty;
                if (DateTime.TryParse(col[5], out DateTime exp)) medicine.ExpiryDate = exp;

                medicines.Add(medicine);
            }

            isSyncingCombos = true;
            MedicineIdCombo.ItemsSource = null;
            MedicineIdCombo.ItemsSource = medicines;
            MedicineNameCombo.ItemsSource = null;
            MedicineNameCombo.ItemsSource = medicines;
            ExpiryCombo.ItemsSource = null;
            ExpiryCombo.ItemsSource = medicines;
            isSyncingCombos = false;
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string query = SearchBox.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(query))
            {
                SearchResultsList.ItemsSource = null;
                return;
            }

            List<Medicine> filtered = new List<Medicine>();
            foreach (Medicine med in medicines)
            {
                string name = med.Name?.ToLower() ?? "";
                string id = med.MedicineID?.ToLower() ?? "";
                if (name.Contains(query) || id.Contains(query))
                    filtered.Add(med);
            }

            SearchResultsList.ItemsSource = null;
            SearchResultsList.ItemsSource = filtered;
        }

        private void SearchResultsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SearchResultsList.SelectedItem is Medicine selected)
            {
                SyncCombos(selected);
                UpdateTotalPrice();
            }
        }

        private void MedicineCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isSyncingCombos) return;
            ComboBox combo = sender as ComboBox;
            if (combo != null && combo.SelectedItem is Medicine selected)
            {
                SyncCombos(selected);
                UpdateTotalPrice();
            }
        }

        private void SyncCombos(Medicine selected)
        {
            isSyncingCombos = true;
            MedicineIdCombo.SelectedItem = selected;
            MedicineNameCombo.SelectedItem = selected;
            ExpiryCombo.SelectedItem = selected;
            isSyncingCombos = false;
        }

        private void UnitsBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateTotalPrice();
        }

        private void UpdateTotalPrice()
        {
            if (MedicineNameCombo.SelectedItem is Medicine selected &&
                int.TryParse(UnitsBox.Text, out int units) && units > 0)
            {
                TotalPriceBox.Text = (selected.Price * units).ToString("0.00");
            }
            else
            {
                TotalPriceBox.Text = "0.00";
            }
        }

        private void AddToCartBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!(MedicineNameCombo.SelectedItem is Medicine selected))
            {
                MessageBox.Show("Please select a medicine first.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(UnitsBox.Text, out int units) || units <= 0)
            {
                MessageBox.Show("Please enter a valid number of units.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (units > selected.QuantityInStock)
            {
                MessageBox.Show("Not enough stock. Only " + selected.QuantityInStock + " units available.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!selected.CanSellWithoutPrescription() && PrescriptionCheck.IsChecked != true)
            {
                MessageBox.Show("This medicine requires a valid prescription.", "Prescription Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            double totalValue = selected.Price * units;

            CartItem item = new CartItem
            {
                TransactionId = "TX" + new Random().Next(10000, 99999).ToString(),
                MedicineName = selected.Name,
                MedicineId = selected.MedicineID,
                ExpiryDate = selected.ExpiryDate.ToString("yyyy-MM-dd"),
                CustomerName = string.IsNullOrWhiteSpace(CustomerNameBox.Text) ? "Unknown" : CustomerNameBox.Text,
                CustomerId = CustomerIdBox.Text,
                CustomerAge = CustomerAgeBox.Text,
                Quantity = units,
                TotalPrice = totalValue.ToString("0.00"),
                TotalPriceValue = totalValue,
                Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm")

            };

            cartItems.Add(item);
            TransactionGrid.ItemsSource = null;
            TransactionGrid.ItemsSource = cartItems;
        }

        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            CustomerIdBox.Text = "";
            CustomerNameBox.Text = "";
            CustomerAgeBox.Text = "";
            UnitsBox.Text = "";
            TotalPriceBox.Text = "0.00";
            PrescriptionCheck.IsChecked = false;

            isSyncingCombos = true;
            MedicineIdCombo.SelectedItem = null;
            MedicineNameCombo.SelectedItem = null;
            ExpiryCombo.SelectedItem = null;
            isSyncingCombos = false;
        }

        private void PurchaseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (cartItems.Count == 0)
            {
                MessageBox.Show("Cart is empty.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                SaleTransaction transaction = new SaleTransaction();

                transaction.UpdateInventory(cartItems);

                foreach (CartItem item in cartItems)
                {
                    item.PharmacistName = _currentUser?.Name ?? "Unknown";
                    Customer customer = SaleTransaction.BuildCustomer(item, PrescriptionCheck.IsChecked == true);
                    transaction.CustomerInfo = customer;
                    SaleTransaction.SaveTransaction(item, item.PharmacistName);
                }

                MessageBox.Show("Transaction completed successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                cartItems.Clear();
                TransactionGrid.ItemsSource = null;
                ResetBtn_Click(null, null);
                LoadMedicines();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

    }
}