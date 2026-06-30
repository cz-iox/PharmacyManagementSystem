using PharmacyClassLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace PharmacyWPF_UI.Pages.Pharmacist
{
    public partial class ViewMedicinePage : Page
    {

        List<Medicine> medicines = new List<Medicine>();

        public ViewMedicinePage()
        {
            InitializeComponent();
            LoadMedicines();
        }

        public void LoadMedicines()
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

        private void ExportBtn_Click(object sender, RoutedEventArgs e) { }
    }
}
