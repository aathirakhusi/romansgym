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
    
    public partial class GetFeesDues_Result
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
        public string ImageLocation { get; set; }
    }
}
