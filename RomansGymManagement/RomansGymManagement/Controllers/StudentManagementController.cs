using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RomansGymManagement.Models;

namespace RomansGymManagement.Controllers
{
    [Route("api/Student")]
    public class StudentManagementController : ApiController
    {
        private romansgy_gymEntities db = new romansgy_gymEntities();
        // POST: api/IncomeDetails
        [ResponseType(typeof(StudentManagementModel))]
        [Route("api/Student", Name = "UpsertStudentDetails")]
        public IHttpActionResult PostStudentDetails(StudentManagementModel StudentDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IHttpActionResult response;
            StudentManagementModel modo = new StudentManagementModel();
            var studentId = db.UpsertStudentCourse(StudentDetails.StudentID, StudentDetails.Name, StudentDetails.Age, StudentDetails.Sex, StudentDetails.ParentName, StudentDetails.MobileNumber, StudentDetails.Addres, StudentDetails.RegistrationFees, StudentDetails.TuitionFees, StudentDetails.ImageLocation, StudentDetails.CreatedDate, StudentDetails.LastUpdatedDate, StudentDetails.DeletedDate, this.ConstructCourseXML(StudentDetails.StudentCourse)).ToList();
            StudentDetails.StudentID = studentId.Select(i => i.Value).First();
            return CreatedAtRoute("UpsertStudentDetails", new { id = modo.StudentID }, StudentDetails);
        }

        private string ConstructCourseXML(List<string> StudentCousrses)
        {
            string courseString = "<Course>";
            foreach (string StudentCousrse in StudentCousrses)
            {
                courseString += string.Format("<CourseName>{0}</CourseName>", StudentCousrse);
            }

            courseString += "</Course>";
            return courseString;
        }
    }
            
}