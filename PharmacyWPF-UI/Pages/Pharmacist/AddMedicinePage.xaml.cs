using System;
using System.IO;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace PharmacyWPF_UI.Pages.Pharmacist
{
    public partial class AddMedicinePage : Page
    {
       
        private static string FilePath = Path.Combine(AppContext.BaseDirectory, "medicines.txt");

        public AddMedicinePage()
        {
            InitializeComponent();
            CategoryCombo.Items.Add("OTC");
            CategoryCombo.Items.Add("Prescription");
            CategoryCombo.SelectedIndex = 0;
            GenerateNextId();
        }

      
        private void GenerateNextId()
        {
            int maxId = 0;

            if (File.Exists(FilePath))
            {
                string[] lines = File.ReadAllLines(FilePath);
                for (int i = 1; i < lines.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(lines[i])) continue;
                    string[] cols = lines[i].Split(',');
                    if (cols.Length > 0 && cols[0].StartsWith("MED") && cols[0].Length > 3)
                    {
                        if (int.TryParse(cols[0].Substring(3), out int idNum))
                        {
                            if (idNum > maxId)
                                maxId = idNum;
                        }
                    }
                }
            }

            IdBox.Text = "MED" + (maxId + 1).ToString("D3");
        }

  
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameBox.Text) ||
                string.IsNullOrWhiteSpace(ManufacturerBox.Text) ||
                string.IsNullOrWhiteSpace(PriceBox.Text) ||
                string.IsNullOrWhiteSpace(StockBox.Text) ||
                ExpiryDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Please fill all required fields.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!double.TryParse(PriceBox.Text, out double price))
            {
                MessageBox.Show("Invalid price format.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(StockBox.Text, out int stock))
            {
                MessageBox.Show("Invalid stock format.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (price < 0)
            {
                MessageBox.Show("Price cannot be negative.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (stock < 0)
            {
                MessageBox.Show("Stock cannot be negative.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DateTime expiry = ExpiryDatePicker.SelectedDate.Value;

            if (ProductionDatePicker.SelectedDate != null &&
                ProductionDatePicker.SelectedDate.Value > expiry)
            {
                MessageBox.Show("Expiry date cannot be before production date.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                bool requiresPrescription = CategoryCombo.Text == "Prescription";

                string newLine = IdBox.Text + "," +
                                 NameBox.Text.Trim() + "," +
                                 price.ToString("0.00") + "," +
                                 ManufacturerBox.Text.Trim() + "," +
                                 stock + "," +
                                 expiry.ToString("yyyy-MM-dd") + "," +
                                 requiresPrescription.ToString().ToLower();

                if (!File.Exists(FilePath))
                    File.WriteAllText(FilePath, "ID,Name,Price,Manufacturer,Quantity,ExpiryDate,RequiresPrescription\n");

                File.AppendAllText(FilePath, newLine + "\n");

                MessageBox.Show("Medicine added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearBtn_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            NameBox.Text = "";
            ManufacturerBox.Text = "";
            PriceBox.Text = "";
            StockBox.Text = "";
            CategoryCombo.SelectedIndex = 0;
            ProductionDatePicker.SelectedDate = null;
            ExpiryDatePicker.SelectedDate = null;
            GenerateNextId();
        }
    }
}