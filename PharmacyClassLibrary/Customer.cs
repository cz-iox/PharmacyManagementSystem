using System.Collections.Generic;
using System;

namespace PharmacyClassLibrary
{
    public class Customer
    {
        private long customer_ID;
        public long Customer_ID
        {
            set
            {
                if (value > 0 && value.ToString().Length == 14)
                    customer_ID = value;
                else
                    throw new ArgumentException("Customer ID must be a positive 14-digit number.");
            }
            get { return customer_ID; }
        }

        private string Customer_name;
        public string Customer_Name
        {
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    Customer_name = value;
            }
            get { return Customer_name; }
        }

        private int Customer_age;
        public int Customer_Age
        {
            set
            {
                if (value > 0)
                    Customer_age = value;
            }
            get { return Customer_age; }
        }

        public List<Medicine> PurchasedMedicines { get; set; } = new List<Medicine>();
        public bool HasValidPrescription { get; set; }

        public Customer()
        {
            Customer_Age = 0;
            Customer_Name = "";
            Customer_ID = 10000000000000;
        }
    }

    // ✅ نفس الـ namespace بدون تداخل
    public class CartItem
    {
        public string TransactionId { get; set; }
        public string MedicineName { get; set; }
        public string MedicineId { get; set; }
        public string ExpiryDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerId { get; set; }
        public string CustomerAge { get; set; }
        public int Quantity { get; set; }
        public string TotalPrice { get; set; }
        public double TotalPriceValue { get; set; }
        public string PharmacistName { get; set; }
        public string Date { get; set; }
    }
}