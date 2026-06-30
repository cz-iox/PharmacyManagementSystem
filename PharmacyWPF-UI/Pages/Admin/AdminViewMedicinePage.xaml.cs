using PharmacyClassLibrary;
using System;
using System.IO;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace PharmacyWPF_UI.Pages.Admin
{
    public partial class ViewMedicinePage : Page
    {
        List<Medicine> medicines = new List<Medicine>();

        public ViewMedicinePage()
        {
            InitializeComponent();
            LoadMedicines();
        }

        private void LoadMedicines()
        {
            medicines.Clear();

            string[] MediList = File.ReadAllLines(Path.Combine(AppContext.BaseDirectory, "medicines.txt"));

            for (int i = 1; i < MediList.Length; i++)
            {
                string[] MediColmun = MediList[i].Split(',');
                bool requiresPrescription = bool.Parse(MediColmun[6]);

                Medicine medicine;
                if (requiresPrescription)
                {
                    medicine = new PrescriptionMedicine();
                }
                else
                {
                    medicine = new OTCMedicine();
                }

                medicine.MedicineID = MediColmun[0];
                medicine.Name = MediColmun[1];
                medicine.Price = double.Parse(MediColmun[2]);
                medicine.Manufacturer = MediColmun[3];
                medicine.QuantityInStock = int.Parse(MediColmun[4]);
                medicine.ExpiryDate = DateTime.Parse(MediColmun[5]);

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
                MedicineGrid.ItemsSource = medicines;
                return;
            }
            List<Medicine> filtered = new List<Medicine>();
            foreach (Medicine medicine in medicines)
            {
                string name = medicine.Name?.ToLower() ?? "";
                string id = medicine.MedicineID?.ToLower() ?? "";
                string manufacturer = medicine.Manufacturer?.ToLower() ?? "";
                if (name.Contains(query) || id.Contains(query) || manufacturer.Contains(query))
                {
                    filtered.Add(medicine);
                }
            }
            MedicineGrid.ItemsSource = filtered;
        }
        private void ExportBtn_Click(object sender, RoutedEventArgs e) { }
    }
}
