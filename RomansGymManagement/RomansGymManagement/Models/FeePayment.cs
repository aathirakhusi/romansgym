//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RomansGymManagement.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FeePayment
    {
        public int ID { get; set; }
        public int StudentId { get; set; }
        public int PaidAmount { get; set; }
        public System.DateTime PaymentDate { get; set; }
        public string Month { get; set; }
    }
}
