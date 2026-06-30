using PharmacyClassLibrary;
using System;
using System.IO;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace PharmacyWPF_UI.Pages.Pharmacist
{
    public partial class ModifyMedicinePage : Page
    {
        private static string FilePath = Path.Combine(AppContext.BaseDirectory, "medicines.txt");

        List<Medicine> medicines = new List<Medicine>();
        Medicine selectedMedicine = null;

        public ModifyMedicinePage()
        {
            InitializeComponent();
            LoadMedicines();
        }

        private void LoadMedicines()
        {
            medicines.Clear();
            if (!File.Exists(FilePath)) return;

            string[] lines = File.ReadAllLines(FilePath);
            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i])) continue;

                string[] col = lines[i].Split(',');
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

            MedicineGrid.ItemsSource = null;
            MedicineGrid.ItemsSource = medicines;
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string query = SearchBox.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(query))
            {
                MedicineGrid.ItemsSource = null;
                MedicineGrid.ItemsSource = medicines;
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

            MedicineGrid.ItemsSource = null;
            MedicineGrid.ItemsSource = filtered;
        }

        private void EditRow_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button == null) return;

            selectedMedicine = button.Tag as Medicine;
            if (selectedMedicine != null)
            {
                EditStockBox.Text = selectedMedicine.QuantityInStock.ToString();
                EditPriceBox.Text = selectedMedicine.Price.ToString("0.00");
                EditExpiryPicker.SelectedDate = selectedMedicine.ExpiryDate;
                EditPanel.Visibility = Visibility.Visible;
            }
        }

        private void SaveEdit_Click(object sender, RoutedEventArgs e)
        {
            if (selectedMedicine == null) return;

            if (!int.TryParse(EditStockBox.Text, out int stock) || stock < 0)
            {
                MessageBox.Show("Invalid stock value.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!double.TryParse(EditPriceBox.Text, out double price) || price < 0)
            {
                MessageBox.Show("Invalid price value.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (EditExpiryPicker.SelectedDate == null)
            {
                MessageBox.Show("Please select an expiry date.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DateTime expiry = EditExpiryPicker.SelectedDate.Value;

            try
            {
                if (!File.Exists(FilePath)) return;

                string[] lines = File.ReadAllLines(FilePath);
                List<string> updatedLines = new List<string>();
                updatedLines.Add(lines[0]); 

                for (int i = 1; i < lines.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(lines[i])) continue;

                    string[] cols = lines[i].Split(',');
                    if (cols[0] == selectedMedicine.MedicineID)
                    {
                        cols[2] = price.ToString("0.00");
                        cols[4] = stock.ToString();
                        cols[5] = expiry.ToString("yyyy-MM-dd");
                    }
                    updatedLines.Add(string.Join(",", cols));
                }

                File.WriteAllLines(FilePath, updatedLines);

                EditPanel.Visibility = Visibility.Collapsed;
                selectedMedicine = null;
                LoadMedicines();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelEdit_Click(object sender, RoutedEventArgs e)
        {
            EditPanel.Visibility = Visibility.Collapsed;
            selectedMedicine = null;
        }

        private void DeleteRow_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button == null) return;

            Medicine med = button.Tag as Medicine;
            if (med == null) return;

            MessageBoxResult result = MessageBox.Show(
                "Are you sure you want to delete " + med.Name + "?",
                "Confirm Delete",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result != MessageBoxResult.Yes) return;

            try
            {
                if (!File.Exists(FilePath)) return;

                string[] lines = File.ReadAllLines(FilePath);
                List<string> remainingLines = new List<string>();

                foreach (string line in lines)
                {
                    if (!line.StartsWith(med.MedicineID + ","))
                        remainingLines.Add(line);
                }

                File.WriteAllLines(FilePath, remainingLines);
                LoadMedicines();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}