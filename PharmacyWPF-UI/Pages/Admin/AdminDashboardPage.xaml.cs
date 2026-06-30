using PharmacyClassLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;
using UserInfoClass;

namespace PharmacyWPF_UI.Pages.Admin
{
    public partial class AdminDashboardPage : Page
    {
        List<Medicine> medicines = new List<Medicine>();
        List<UserInfo> users = new List<UserInfo>();

        public AdminDashboardPage()
        {
            InitializeComponent();
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            LoadMedicines();
            users = UserInfo.LoadUserMG();
            LoadStats();
            LoadActivityLog();
        }

        private void LoadMedicines()
        {
            medicines.Clear();
            string path = Path.Combine(AppContext.BaseDirectory, "medicines.txt");
            if (!File.Exists(path)) return;

            string[] lines = File.ReadAllLines(path);
            for (int i = 1; i < lines.Length; i++)
            {
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
        }

        private void LoadStats()
        {

            int totalMedicines = medicines.Count;
            int expiredCount = 0;

            foreach (Medicine med in medicines)
            {
                if (med.Status == MedicineStatusKind.Expired)
                    expiredCount++;
            }

            TotalMedicineCard.Value = totalMedicines.ToString();
            ExpiredMedicineCard.Value = expiredCount.ToString();

            int monthlyCustomersCount = 0;
            double monthRevenue = 0;

            string transPath = Path.Combine(AppContext.BaseDirectory, "sales.txt");
            if (File.Exists(transPath))
            {
                string[] lines = File.ReadAllLines(transPath);
                for (int i = 1; i < lines.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(lines[i])) continue;
                    string[] col = lines[i].Split(',');
                    if (col.Length < 10) continue;

 
                    if (!DateTime.TryParse(col[9], out DateTime date)) continue;

                    if (date.Month == DateTime.Today.Month && date.Year == DateTime.Today.Year)
                    {
                        monthlyCustomersCount++;

                        if (double.TryParse(col[7], out double amount))
                            monthRevenue += amount;
                    }
                }
            }

            MonthlyCustomers.Value = monthlyCustomersCount.ToString();
            MonthTransactions.Value = monthRevenue.ToString("C");

            int onDutyCount = 0;
            foreach (UserInfo user in users)
            {
                if (user.Role == "Pharmacist" && user.IsActive)
                    onDutyCount++;
            }
            PharmacistonDuty.Value = onDutyCount.ToString();
        }


        private void LoadActivityLog()
        {
            List<ActivityLogItem> activityList = new List<ActivityLogItem>();

            foreach (UserInfo user in users)
            {
                activityList.Add(new ActivityLogItem
                {
                    User = user.Name,
                    Role = user.Role,
                    IsAdmin = user.IsAdmin,
                    Action = "Logged in",
                    Time = user.LastLoginDisplay
                });
            }

            activityList.Sort((a, b) => string.Compare(b.Time, a.Time));
            ActivityGrid.ItemsSource = activityList;
        }
    }

    public class ActivityLogItem
    {
        public string User { get; set; }
        public string Role { get; set; }
        public bool IsAdmin { get; set; }
        public string Action { get; set; }
        public string Time { get; set; }
    }
}