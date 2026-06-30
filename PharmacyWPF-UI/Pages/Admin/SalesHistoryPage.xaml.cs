using PharmacyClassLibrary;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace PharmacyWPF_UI.Pages.Admin
{
    public partial class SalesHistoryPage : Page
    {
        List<CartItem> allSales = new List<CartItem>();

        public SalesHistoryPage()
        {
            InitializeComponent();
            LoadSalesData();
        }

        private void LoadSalesData()
        {
            allSales = SaleTransaction.LoadFullTransactions();

            int monthlyCount = 0;
            double monthlyRevenue = 0;

            foreach (CartItem item in allSales)
            {
                if (DateTime.TryParse(item.Date, out DateTime date))
                {
                    if (date.Month == DateTime.Today.Month && date.Year == DateTime.Today.Year)
                    {
                        monthlyCount++;
                        monthlyRevenue += item.TotalPriceValue;
                    }
                }
            }

            MonthlyCustomers.Value = monthlyCount.ToString();
            MonthTransactions.Value = monthlyRevenue.ToString("0.00") + " EGP";
            SalesGrid.ItemsSource = allSales;
        }

        // ===================== Search =====================
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string query = SearchBox.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(query))
            {
                SalesGrid.ItemsSource = allSales;
                return;
            }

            List<CartItem> filtered = new List<CartItem>();
            foreach (CartItem item in allSales)
            {
                string customer = item.CustomerName?.ToLower() ?? "";
                string medicine = item.MedicineName?.ToLower() ?? "";
                string txId = item.TransactionId?.ToLower() ?? "";
                string pharmacist = item.PharmacistName?.ToLower() ?? "";

                if (customer.Contains(query) ||
                    medicine.Contains(query) ||
                    txId.Contains(query) ||
                    pharmacist.Contains(query))
                {
                    filtered.Add(item);
                }
            }

            SalesGrid.ItemsSource = filtered;
        }
    }
}