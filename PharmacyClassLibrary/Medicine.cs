using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyClassLibrary
{
    public enum MedicineStatusKind
    {
        Valid,
        ExpiringSoon,
        Expired
    }

    public abstract class Medicine
    {
        public string MedicineID { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public double Price { get; set; }
        public int QuantityInStock { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool RequiresPrescription { get; set; }
        public abstract bool CanSellWithoutPrescription();

        public Medicine()
        {
            MedicineID = "Medi000";
            Name = "";
            Manufacturer = "";
            Price = 0.0;
            QuantityInStock = 0;
            ExpiryDate = DateTime.Now;
        }


        public Medicine(string id , string name , double price , string manufact , int quantity , DateTime expirydate)
        {
            MedicineID = id;
            Name = name;
            Manufacturer = manufact;
            Price = price;
            QuantityInStock = quantity;
            ExpiryDate = expirydate;
        }

        public MedicineStatusKind Status
        {
            get
            {
                DateTime today = DateTime.Today;

                if (ExpiryDate < today)
                    return MedicineStatusKind.Expired;

                else if (ExpiryDate <= today.AddDays(30))
                    return MedicineStatusKind.ExpiringSoon;

                else
                    return MedicineStatusKind.Valid;
            }
        }

    }
}
