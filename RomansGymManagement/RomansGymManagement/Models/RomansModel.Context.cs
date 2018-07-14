﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class romansgy_gymEntities : DbContext
    {
        public romansgy_gymEntities()
            : base("name=romansgy_gymEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ExpenseHeadDetail> ExpenseHeadDetails { get; set; }
        public virtual DbSet<IncomeDetail> IncomeDetails { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentCourse> StudentCourses { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<RegistrationFee> RegistrationFees { get; set; }
        public virtual DbSet<DeviceNotification> DeviceNotifications { get; set; }
        public virtual DbSet<FeesPaidDetail> FeesPaidDetails { get; set; }
    
        public virtual ObjectResult<Nullable<int>> UpsertStudentCourse(Nullable<int> studentID, string name, Nullable<int> age, string sex, string parentName, string mobileNumber, string addres, Nullable<decimal> registrationFees, Nullable<decimal> tuitionFees, string imageLocation, Nullable<System.DateTime> createdDate, Nullable<System.DateTime> lastUpdatedDate, Nullable<System.DateTime> deletedDate, string courseXML)
        {
            var studentIDParameter = studentID.HasValue ?
                new ObjectParameter("StudentID", studentID) :
                new ObjectParameter("StudentID", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var ageParameter = age.HasValue ?
                new ObjectParameter("Age", age) :
                new ObjectParameter("Age", typeof(int));
    
            var sexParameter = sex != null ?
                new ObjectParameter("Sex", sex) :
                new ObjectParameter("Sex", typeof(string));
    
            var parentNameParameter = parentName != null ?
                new ObjectParameter("ParentName", parentName) :
                new ObjectParameter("ParentName", typeof(string));
    
            var mobileNumberParameter = mobileNumber != null ?
                new ObjectParameter("MobileNumber", mobileNumber) :
                new ObjectParameter("MobileNumber", typeof(string));
    
            var addresParameter = addres != null ?
                new ObjectParameter("Addres", addres) :
                new ObjectParameter("Addres", typeof(string));
    
            var registrationFeesParameter = registrationFees.HasValue ?
                new ObjectParameter("RegistrationFees", registrationFees) :
                new ObjectParameter("RegistrationFees", typeof(decimal));
    
            var tuitionFeesParameter = tuitionFees.HasValue ?
                new ObjectParameter("TuitionFees", tuitionFees) :
                new ObjectParameter("TuitionFees", typeof(decimal));
    
            var imageLocationParameter = imageLocation != null ?
                new ObjectParameter("ImageLocation", imageLocation) :
                new ObjectParameter("ImageLocation", typeof(string));
    
            var createdDateParameter = createdDate.HasValue ?
                new ObjectParameter("CreatedDate", createdDate) :
                new ObjectParameter("CreatedDate", typeof(System.DateTime));
    
            var lastUpdatedDateParameter = lastUpdatedDate.HasValue ?
                new ObjectParameter("LastUpdatedDate", lastUpdatedDate) :
                new ObjectParameter("LastUpdatedDate", typeof(System.DateTime));
    
            var deletedDateParameter = deletedDate.HasValue ?
                new ObjectParameter("DeletedDate", deletedDate) :
                new ObjectParameter("DeletedDate", typeof(System.DateTime));
    
            var courseXMLParameter = courseXML != null ?
                new ObjectParameter("CourseXML", courseXML) :
                new ObjectParameter("CourseXML", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("UpsertStudentCourse", studentIDParameter, nameParameter, ageParameter, sexParameter, parentNameParameter, mobileNumberParameter, addresParameter, registrationFeesParameter, tuitionFeesParameter, imageLocationParameter, createdDateParameter, lastUpdatedDateParameter, deletedDateParameter, courseXMLParameter);
        }
    
        public virtual ObjectResult<GetStudentCourse_Result1> GetStudentCourse(Nullable<int> studentID)
        {
            var studentIDParameter = studentID.HasValue ?
                new ObjectParameter("StudentID", studentID) :
                new ObjectParameter("StudentID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetStudentCourse_Result1>("GetStudentCourse", studentIDParameter);
        }
    
        public virtual int UpsertRegistrationFees(Nullable<decimal> registrationAmount)
        {
            var registrationAmountParameter = registrationAmount.HasValue ?
                new ObjectParameter("RegistrationAmount", registrationAmount) :
                new ObjectParameter("RegistrationAmount", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpsertRegistrationFees", registrationAmountParameter);
        }
    
        public virtual ObjectResult<GetUserLogin_Result> GetUserLogin(string userName, string password)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("userName", userName) :
                new ObjectParameter("userName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetUserLogin_Result>("GetUserLogin", userNameParameter, passwordParameter);
        }
    
        public virtual ObjectResult<GetStudents_Result> GetStudents()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetStudents_Result>("GetStudents");
        }
    
        public virtual ObjectResult<Nullable<int>> UpsertStudentCoursevOne(Nullable<int> studentID, string name, Nullable<int> age, string sex, string parentName, string mobileNumber, string addres, Nullable<decimal> registrationFees, Nullable<decimal> tuitionFees, string imageLocation, Nullable<System.DateTime> createdDate, Nullable<System.DateTime> lastUpdatedDate, Nullable<System.DateTime> deletedDate, string admissionNumber, string courses, string courseXML)
        {
            var studentIDParameter = studentID.HasValue ?
                new ObjectParameter("StudentID", studentID) :
                new ObjectParameter("StudentID", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var ageParameter = age.HasValue ?
                new ObjectParameter("Age", age) :
                new ObjectParameter("Age", typeof(int));
    
            var sexParameter = sex != null ?
                new ObjectParameter("Sex", sex) :
                new ObjectParameter("Sex", typeof(string));
    
            var parentNameParameter = parentName != null ?
                new ObjectParameter("ParentName", parentName) :
                new ObjectParameter("ParentName", typeof(string));
    
            var mobileNumberParameter = mobileNumber != null ?
                new ObjectParameter("MobileNumber", mobileNumber) :
                new ObjectParameter("MobileNumber", typeof(string));
    
            var addresParameter = addres != null ?
                new ObjectParameter("Addres", addres) :
                new ObjectParameter("Addres", typeof(string));
    
            var registrationFeesParameter = registrationFees.HasValue ?
                new ObjectParameter("RegistrationFees", registrationFees) :
                new ObjectParameter("RegistrationFees", typeof(decimal));
    
            var tuitionFeesParameter = tuitionFees.HasValue ?
                new ObjectParameter("TuitionFees", tuitionFees) :
                new ObjectParameter("TuitionFees", typeof(decimal));
    
            var imageLocationParameter = imageLocation != null ?
                new ObjectParameter("ImageLocation", imageLocation) :
                new ObjectParameter("ImageLocation", typeof(string));
    
            var createdDateParameter = createdDate.HasValue ?
                new ObjectParameter("CreatedDate", createdDate) :
                new ObjectParameter("CreatedDate", typeof(System.DateTime));
    
            var lastUpdatedDateParameter = lastUpdatedDate.HasValue ?
                new ObjectParameter("LastUpdatedDate", lastUpdatedDate) :
                new ObjectParameter("LastUpdatedDate", typeof(System.DateTime));
    
            var deletedDateParameter = deletedDate.HasValue ?
                new ObjectParameter("DeletedDate", deletedDate) :
                new ObjectParameter("DeletedDate", typeof(System.DateTime));
    
            var admissionNumberParameter = admissionNumber != null ?
                new ObjectParameter("AdmissionNumber", admissionNumber) :
                new ObjectParameter("AdmissionNumber", typeof(string));
    
            var coursesParameter = courses != null ?
                new ObjectParameter("Courses", courses) :
                new ObjectParameter("Courses", typeof(string));
    
            var courseXMLParameter = courseXML != null ?
                new ObjectParameter("CourseXML", courseXML) :
                new ObjectParameter("CourseXML", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("UpsertStudentCoursevOne", studentIDParameter, nameParameter, ageParameter, sexParameter, parentNameParameter, mobileNumberParameter, addresParameter, registrationFeesParameter, tuitionFeesParameter, imageLocationParameter, createdDateParameter, lastUpdatedDateParameter, deletedDateParameter, admissionNumberParameter, coursesParameter, courseXMLParameter);
        }
    
        public virtual ObjectResult<GetStudentCoursevOne_Result> GetStudentCoursevOne(Nullable<int> studentID)
        {
            var studentIDParameter = studentID.HasValue ?
                new ObjectParameter("StudentID", studentID) :
                new ObjectParameter("StudentID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetStudentCoursevOne_Result>("GetStudentCoursevOne", studentIDParameter);
        }
    
        public virtual ObjectResult<GetStudentsvOne_Result> GetStudentsvOne()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetStudentsvOne_Result>("GetStudentsvOne");
        }
    
        public virtual int UpdateImageLocation(Nullable<int> studentId, string imageLocation)
        {
            var studentIdParameter = studentId.HasValue ?
                new ObjectParameter("StudentId", studentId) :
                new ObjectParameter("StudentId", typeof(int));
    
            var imageLocationParameter = imageLocation != null ?
                new ObjectParameter("ImageLocation", imageLocation) :
                new ObjectParameter("ImageLocation", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateImageLocation", studentIdParameter, imageLocationParameter);
        }
    
        public virtual int UpsertDeviceNotification(string deviceId, string fCMRegistrationID)
        {
            var deviceIdParameter = deviceId != null ?
                new ObjectParameter("DeviceId", deviceId) :
                new ObjectParameter("DeviceId", typeof(string));
    
            var fCMRegistrationIDParameter = fCMRegistrationID != null ?
                new ObjectParameter("FCMRegistrationID", fCMRegistrationID) :
                new ObjectParameter("FCMRegistrationID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpsertDeviceNotification", deviceIdParameter, fCMRegistrationIDParameter);
        }
    
        public virtual ObjectResult<string> GetFCMIds()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetFCMIds");
        }
    
        public virtual int DeleteDeviceNotification(string deviceId)
        {
            var deviceIdParameter = deviceId != null ?
                new ObjectParameter("DeviceId", deviceId) :
                new ObjectParameter("DeviceId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteDeviceNotification", deviceIdParameter);
        }
    
        public virtual ObjectResult<GetFeesDues_Result> GetFeesDues()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetFeesDues_Result>("GetFeesDues");
        }
    }
}
