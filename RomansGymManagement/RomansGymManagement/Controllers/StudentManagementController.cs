using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
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

        // GET: api/Student/5
        [ResponseType(typeof(GetStudents_Result))]
        [Route("api/Student/GetAllStudents", Name = "GetAllStudents")]
        [HttpGet]
        public HttpResponseMessage GetAllStudents(string name ="")
        {
            var students = db.GetStudents().ToList();
            List<StudentManagementModel> StudentManagmentModelList = new List<StudentManagementModel>();
            if (students.Any())
            {
                foreach (var student in students)
                {
                    StudentManagementModel StudentManagementModel = new StudentManagementModel();
                    StudentManagementModel.Addres = student.Addres;
                    StudentManagementModel.Age = student.Age;
                    StudentManagementModel.MobileNumber = student.MobileNumber;
                    StudentManagementModel.Name = student.Name;
                    StudentManagementModel.ParentName = student.ParentName;
                    StudentManagementModel.RegistrationFees = student.RegistrationFees;
                    StudentManagementModel.Sex = student.Sex;
                    StudentManagementModel.StudentID = student.StudentID;
                    StudentManagementModel.TuitionFees = student.TuitionFees;
                    StudentManagmentModelList.Add(StudentManagementModel);
                }
                if (!string.IsNullOrEmpty(name))
                {
                    var result = StudentManagmentModelList.Where(x => x.Name.StartsWith(name, StringComparison.InvariantCultureIgnoreCase)).Select(x => x).ToList();
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, StudentManagmentModelList);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            
        }

        [Route("api/Student/PostUserImage/{id}")]
        public async Task<HttpResponseMessage> PostUserImage(int id)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            try
            {
                int userId = id;
                var httpRequest = HttpContext.Current.Request;

                foreach (string file in httpRequest.Files)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

                    var postedFile = httpRequest.Files[file];
                    if (postedFile != null && postedFile.ContentLength > 0)
                    {

                        int MaxContentLength = 1024 * 1024 * 5; //Size = 1 MB  

                        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png" };
                        var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                        var extension = ext.ToLower();
                        if (!AllowedFileExtensions.Contains(extension))
                        {

                            var message = string.Format("Please Upload image of type .jpg,.png.");

                            dict.Add("error", message);
                            return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                        }
                        else if (postedFile.ContentLength > MaxContentLength)
                        {

                            var message = string.Format("Please Upload a file upto 5 mb.");

                            dict.Add("error", message);
                            return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                        }
                        else
                        {



                            var filePath = HttpContext.Current.Server.MapPath("~/Userimage/" + id.ToString() + extension);

                            postedFile.SaveAs(filePath);

                        }
                    }

                    var message1 = string.Format("Image Updated Successfully.");
                    return Request.CreateErrorResponse(HttpStatusCode.Created, message1); ;
                }
                var res = string.Format("Please Upload a image.");
                dict.Add("error", res);
                return Request.CreateResponse(HttpStatusCode.NotFound, dict);
            }
            catch (Exception ex)
            {
                var res = string.Format("some Message");
                dict.Add("error", res);
                return Request.CreateResponse(HttpStatusCode.NotFound, dict);
            }
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