using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RomansGymManagement.Models
{
    public class FeesDuesModel
    {
        public int StudentId { get; set; }
        public Nullable<System.DateTime> FeesLastPaidDate { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string ParentName { get; set; }
        public string MobileNumber { get; set; }
        public string Addres { get; set; }
        public Nullable<decimal> TuitionFees { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public List<string> PendingMonths { get; set; }
    }
}