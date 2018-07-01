using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RomansGymManagement.Models
{
    public class StudentManagementModel
    {
        public int? StudentID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string ParentName { get; set; }
        public string MobileNumber { get; set; }
        public string Addres { get; set; }
        public Nullable<decimal> RegistrationFees { get; set; }
        public Nullable<decimal> TuitionFees { get; set; }
        public string ImageLocation { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime LastUpdatedDate { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public List<string> StudentCourse { get; set; }
    }
}