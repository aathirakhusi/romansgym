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
        // POST: api/Student
        [ResponseType(typeof(StudentManagementModel))]
        [Route("api/Student", Name = "UpsertStudentDetails")]
        [HttpPost]
        public IHttpActionResult PostStudentDetails(StudentManagementModel StudentDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            StudentManagementModel StudentManagmentModel = new StudentManagementModel();
            if(StudentDetails.StudentID == null)
            {
                var dateAndTime = DateTime.Now;
                StudentDetails.CreatedDate = dateAndTime.Date;
                StudentDetails.LastUpdatedDate = dateAndTime.Date;
            }
            else
            {
                var dateAndTime = DateTime.Now;
                StudentDetails.LastUpdatedDate = dateAndTime.Date;
            }
            var studentId = db.UpsertStudentCourse(StudentDetails.StudentID, StudentDetails.Name, StudentDetails.Age, StudentDetails.Sex, StudentDetails.ParentName, StudentDetails.MobileNumber, StudentDetails.Addres, StudentDetails.RegistrationFees, StudentDetails.TuitionFees, StudentDetails.ImageLocation, StudentDetails.CreatedDate, StudentDetails.LastUpdatedDate, StudentDetails.DeletedDate, this.ConstructCourseXML(StudentDetails.StudentCourse)).ToList();
            StudentDetails.StudentID = studentId.Select(i => i.Value).First();
            return CreatedAtRoute("UpsertStudentDetails", new { id = StudentManagmentModel.StudentID }, StudentDetails);
        }

        // GET: api/Student/5
        [ResponseType(typeof(GetStudentCourse_Result))]
        [Route("api/Student/{id}",Name = "GetStudentDetails")]
        [HttpGet]
        public HttpResponseMessage GetStudentDetails(int id)
        {
            StudentManagementModel StudentManagmentModel = new StudentManagementModel();
            var studentDetails = db.GetStudentCourse(id).ToList();
            if (studentDetails.Count != 0)
            {
                var deletedDate = studentDetails.Select(x => x.DeletedDate).First();
                if (deletedDate == null)
                {
                    StudentManagmentModel.StudentID = studentDetails.Select(x => x.StudentID).First();
                    StudentManagmentModel.Name = studentDetails.Select(x => x.Name).First();
                    StudentManagmentModel.Age = studentDetails.Select(x => x.Age).First();
                    StudentManagmentModel.Sex = studentDetails.Select(x => x.Sex).First();
                    StudentManagmentModel.ParentName = studentDetails.Select(x => x.ParentName).First();
                    StudentManagmentModel.MobileNumber = studentDetails.Select(x => x.MobileNumber).First();
                    StudentManagmentModel.Addres = studentDetails.Select(x => x.Addres).First();
                    StudentManagmentModel.RegistrationFees = studentDetails.Select(x => x.RegistrationFees).First();
                    StudentManagmentModel.TuitionFees = studentDetails.Select(x => x.TuitionFees).First();
                    StudentManagmentModel.ImageLocation = studentDetails.Select(x => x.ImageLocation).First();
                    StudentManagmentModel.ImageLocation = studentDetails.Select(x => x.ImageLocation).First();
                    StudentManagmentModel.CreatedDate = studentDetails.Select(x => x.CreatedDate).First();
                    StudentManagmentModel.LastUpdatedDate = studentDetails.Select(x => x.LastUpdatedDate).First();
                    StudentManagmentModel.DeletedDate = studentDetails.Select(x => x.DeletedDate).First();

                    List<string> studentCourses = new List<string>();
                    foreach (var studItem in studentDetails)
                    {
                        studentCourses.Add(studItem.CourseName);
                    }
                    StudentManagmentModel.StudentCourse = studentCourses;
                    return Request.CreateResponse(HttpStatusCode.OK, StudentManagmentModel);
                }
            }
            return Request.CreateResponse(HttpStatusCode.NoContent, StudentManagmentModel);
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