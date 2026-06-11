using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyClassLibrary
{
    public class PrescriptionMedicine : Medicine
    {
        public string MedicineType => "Prescription";
        public override bool CanSellWithoutPrescription()
        {
            return false; 
        }
    }
}
