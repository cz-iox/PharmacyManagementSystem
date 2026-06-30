using PharmacyClassLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PharmacyWPF_UI.Pages.Pharmacist
{
    public partial class ValidityCheckPage : Page
    {
        List<Medicine> medicines = new List<Medicine>();
        public ValidityCheckPage()
        {
            InitializeComponent();
            LoadMedicines();
        }
        private void LoadMedicines()
        {
            medicines.Clear();

            string[] MediList = File.ReadAllLines(Path.Combine(AppContext.BaseDirectory, "medicines.txt"));

            //loop 3shan n5zn el data of medicines
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

            UpdateCards();
            UpdateFlaggedGrid();

        }
        private void UpdateCards()
        {
            int validCount = 0;
            int expiringSoonCount = 0;
            int expiredCount = 0;

            foreach (Medicine med in medicines)
            {
                if (med.Status == MedicineStatusKind.Valid)
                    validCount++;
                else if (med.Status == MedicineStatusKind.ExpiringSoon)
                    expiringSoonCount++;
                else if (med.Status == MedicineStatusKind.Expired)
                    expiredCount++;
            }

            ValidCard.Value = validCount.ToString();
            ExpiringCard.Value = expiringSoonCount.ToString();
            ExpiredCard.Value = expiredCount.ToString();

        }


            private void UpdateFlaggedGrid()
        {
            List<Medicine> flaggedMedi = new List<Medicine>();

            foreach (Medicine med in medicines) 
            {
                if (med.Status == MedicineStatusKind.ExpiringSoon ||
                    med.Status == MedicineStatusKind.Expired)
                {
                    flaggedMedi.Add(med); 
                }
            }

            FlaggedGrid.ItemsSource = flaggedMedi;
        }

    }

    }
