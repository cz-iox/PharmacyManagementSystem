
using System;
using System.Collections.Generic;
using System.IO;

namespace PharmacyClassLibrary
{
    public class SaleTransaction
    {
        public static string FilePath = Path.Combine(AppContext.BaseDirectory, "sales.txt");

        private int transactionID;
        private Customer customerInfo;
        private List<Medicine> medicineList;
        private double totalPrice;
        private DateTime transactionDate;
        private string pharmacistName;

        public int TransactionID
        {
            get { return transactionID; }
            set
            {
                if (value <= 0) throw new ArgumentException("TransactionID must be greater than zero.");
                transactionID = value;
            }
        }
        public Customer CustomerInfo
        {
            get { return customerInfo; }
            set
            {
                if (value == null) throw new ArgumentNullException("CustomerInfo cannot be null.");
                customerInfo = value;
            }
        }
        public List<Medicine> MedicineList
        {
            get { return medicineList; }
            set
            {
                if (value == null) throw new ArgumentNullException("MedicineList cannot be null.");
                medicineList = value;
            }
        }
        public double TotalPrice
        {
            get { return totalPrice; }
            set
            {
                if (value < 0) throw new ArgumentException("TotalPrice cannot be negative.");
                totalPrice = value;
            }
        }
        public DateTime TransactionDate
        {
            get { return transactionDate; }
            set
            {
                if (value == DateTime.MinValue) throw new ArgumentException("TransactionDate must be a valid date.");
                transactionDate = value;
            }
        }
        public string PharmacistName
        {
            get { return pharmacistName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("PharmacistName cannot be empty.");
                pharmacistName = value;
            }
        }

        public SaleTransaction() { }

        public double CalculateTotal()
        {
            double total = 0;
            if (medicineList == null) return 0;
            foreach (Medicine med in medicineList)
                total += med.Price;
            totalPrice = total;
            return total;
        }

        public bool VerifyPrescriptionRequirements()
        {
            if (medicineList == null) return true;
            foreach (Medicine med in medicineList)
            {
                if (!med.CanSellWithoutPrescription())
                    return false;
            }
            return true;
        }

        public void UpdateInventory(List<CartItem> cartItems)
        {
            string medPath = Path.Combine(AppContext.BaseDirectory, "medicines.txt");
            if (!File.Exists(medPath)) return;

            string[] lines = File.ReadAllLines(medPath);
            List<string> updatedLines = new List<string>();
            updatedLines.Add(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] cols = lines[i].Split(',');
                foreach (CartItem item in cartItems)
                {
                    if (cols[0] == item.MedicineId)
                    {
                        if (int.TryParse(cols[4], out int currentStock))
                            cols[4] = Math.Max(0, currentStock - item.Quantity).ToString();
                    }
                }
                updatedLines.Add(string.Join(",", cols));
            }
            File.WriteAllLines(medPath, updatedLines);
        }

        public static Customer BuildCustomer(CartItem item, bool hasPrescription)
        {
            Customer customer = new Customer();

            if (!string.IsNullOrWhiteSpace(item.CustomerName))
                customer.Customer_Name = item.CustomerName;

            if (int.TryParse(item.CustomerAge, out int age) && age > 0)
                customer.Customer_Age = age;

            if (long.TryParse(item.CustomerId, out long cid))
            {
                try { customer.Customer_ID = cid; }
                catch {  }
            }

            customer.HasValidPrescription = hasPrescription;

            return customer;
        }

        public static void SaveTransaction(CartItem item, string pharmacistName)
        {
            bool fileExists = File.Exists(FilePath);

            using (FileStream fs = new FileStream(FilePath, FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                if (!fileExists)
                    sw.WriteLine("TransactionID,CustomerID,CustomerName,CustomerAge,MedicineName,MedicineId,Quantity,TotalPrice,PharmacistName,Date");

                sw.WriteLine(
                     item.TransactionId + "," + item.CustomerId + "," + item.CustomerName + "," + item.CustomerAge + "," + item.MedicineName + "," + item.MedicineId + "," + item.Quantity + "," + item.TotalPrice + "," + pharmacistName + "," + item.Date);
            }
        }

        public static List<CartItem> LoadTransactions()
        {
            List<CartItem> transactions = new List<CartItem>();
            if (!File.Exists(FilePath)) return transactions;

            string[] lines = File.ReadAllLines(FilePath);
            for (int i = 1; i < lines.Length; i++)
            {
                string[] col = lines[i].Split(',');
                if (col.Length < 10) continue;

                CartItem item = new CartItem
                {
                    TransactionId = col[0],
                    CustomerId = col[1],
                    CustomerName = col[2],
                    CustomerAge = col[3],
                    MedicineName = col[4],
                    MedicineId = col[5],
                    Date = col[9]
                };

                if (int.TryParse(col[6], out int qty)) item.Quantity = qty;
                if (double.TryParse(col[7], out double tp)) item.TotalPriceValue = tp;
                item.TotalPrice = tp.ToString("0.00");

                transactions.Add(item);
            }
            return transactions;
        }
        public static List<CartItem> LoadFullTransactions()
        {
            List<CartItem> transactions = new List<CartItem>();
            if (!File.Exists(FilePath)) return transactions;

            string[] lines = File.ReadAllLines(FilePath);
            for (int i = 1; i < lines.Length; i++)
            {
                string[] col = lines[i].Split(',');
                if (col.Length < 10) continue;

                CartItem item = new CartItem
                {
                    TransactionId = col[0],
                    CustomerId = col[1],
                    CustomerName = col[2],
                    CustomerAge = col[3],
                    MedicineName = col[4],
                    MedicineId = col[5],
                    PharmacistName = col[8],
                    Date = col[9]

                };

                if (int.TryParse(col[6], out int qty)) item.Quantity = qty;
                if (double.TryParse(col[7], out double tp)) item.TotalPriceValue = tp;
                item.TotalPrice = tp.ToString("0.00");

                transactions.Add(item);
            }
            return transactions;
        }
    }
}