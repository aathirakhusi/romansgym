using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RomansGymManagement.Models
{
    public class FeesPaymentModel
    {
        public int StudentId { get; set; }
        public List<System.DateTime> AmountPaidForDate { get; set; }
        public Nullable<bool> IsAttented { get; set; }
    }
}