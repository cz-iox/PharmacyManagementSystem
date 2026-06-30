using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyClassLibrary
{
    public class OTCMedicine : Medicine
    {
        public string MedicineType => "OTC";
        public override bool CanSellWithoutPrescription()
        {
            return true;
        }
    }
}
