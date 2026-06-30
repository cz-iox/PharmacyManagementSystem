using PharmacyClassLibrary;
using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Controls;

namespace PharmacyWPF_UI.Pages.Pharmacist
{
    public partial class DashboardPage : Page
    {
        public DashboardPage()
        {
            InitializeComponent();
            LoadDashboardData();
        }

        List<Medicine> medicines = new List<Medicine>();

        private void LoadDashboardData()
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

            int inStockCount = 0;
            int expiredCount = 0;
            int expiringSoonCount = 0;
            int lowStockCount = 0;

            List<Medicine> expiringSoonList = new List<Medicine>();

            foreach (Medicine med in medicines)
            {
                if (med.QuantityInStock > 0)
                {
                    inStockCount++;
                }

                if (med.QuantityInStock <= 20)
                {
                    lowStockCount++;
                }

                if (med.Status == MedicineStatusKind.Expired)
                {
                    expiredCount++;
                }
                else if (med.Status == MedicineStatusKind.ExpiringSoon)
                {
                    expiringSoonCount++;
                    expiringSoonList.Add(med);
                }
            }

            InStockCard.Value = inStockCount.ToString();
            ExpiredCard.Value = expiredCount.ToString();
            ExpiringSoonCard.Value = expiringSoonCount.ToString();
            LowStockCard.Value = lowStockCount.ToString();

            ExpiringGrid.ItemsSource = expiringSoonList;
        }
    }
}
