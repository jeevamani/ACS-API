using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Interview.Interface;
using Interview.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Interview.Controllers
{
    public class StudentController : Controller
    {
        IStudent _student;
        public StudentController(IStudent student)
        {
            _student = student;
        }

        [HttpGet]
        [Route("api/Student/GetStudent")]

        public IActionResult GetStudent()
        {
            try
            {
                var result = _student.GetStudentDetails();
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [Route("api/Student/upload")]
        [RequestFormLimits(MultipartBodyLengthLimit = 209715200)]
        public IActionResult UploadFiles([FromForm]IFormFile[] file, string foldername, string subfolder,Guid Id, string user)
        {
            Result objstatus = new Result();
            StudentIdupload studentIdupload = new StudentIdupload();
            StudentDetails studentDetails = new StudentDetails();
            CertificateUpload certificateUpload = new CertificateUpload();

            foreach (var item in file)
            {
                var filename = Path.GetFileName(item.FileName);
                var extention = Path.GetExtension(item.FileName);
                var path = "";
                if (!string.IsNullOrEmpty(item.FileName))
                {
                    
                    var filepath = Path.Combine(Directory.GetCurrentDirectory(), "UploadFiles", foldername, subfolder);
                    if (!Directory.Exists(filepath))
                        Directory.CreateDirectory(filepath);
                     path = Path.Combine(Directory.GetCurrentDirectory(), "UploadFiles", foldername, subfolder, item.FileName);
                    if (System.IO.File.Exists(path))
                        System.IO.File.Delete(path);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        item.CopyTo(stream);
                    }
                }
                using (DB_A3E3FF_scampus2020Context db = new DB_A3E3FF_scampus2020Context())
                {
                    if (subfolder == "UploadID")
                    {

                        studentIdupload.StudentId = Id;
                        studentIdupload.UploadFileType = extention;
                        studentIdupload.UploadFileTitile = subfolder;
                        studentIdupload.UploadPath = path;
                        studentIdupload.UploadFileName = filename;
                        studentIdupload.CreatedBy = user;
                        studentIdupload.CreatedDate = DateTime.Now;
                        db.StudentIdupload.Add(studentIdupload);
                        db.SaveChanges();
                    } else if (subfolder == "UploadPhoto")
                    {
                        var data = db.StudentDetails.Where(x => x.StudentId == Id).FirstOrDefault();
                        data.StudentPhoto = path;
                        db.SaveChanges();
                    } else
                    {
                        certificateUpload.StudentId = Id;
                        certificateUpload.UploadFileType = extention;
                        certificateUpload.UploadFileTitile = subfolder;
                        certificateUpload.UploadPath = path;
                        certificateUpload.UploadFileName = filename;
                        certificateUpload.CreatedBy = user;
                        certificateUpload.CreatedDate = DateTime.Now;
                        db.CertificateUpload.Add(certificateUpload);
                        db.SaveChanges();
                    }
                }
              

            }
            
            objstatus.StatusCode = 1;
            objstatus.Message = "Successfully Uploaded";


            return (ActionResult)Ok(objstatus);
        }

        [HttpGet]
        [Route("api/Student/GetCourse")]

        public IActionResult GetCourse()
        {
            try
            {
                var result = _student.GetMainCourses();
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpGet]
        [Route("api/Student/DeleteStudentFile")]

        public IActionResult DeleteStudentFIle(string Id, string type)
        {
            try
            {
                var result = _student.DeleteUploadedFile(Id, type);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpGet]
        [Route("api/Student/GetUploadedFile")]

        public IActionResult GetUploadedFile(string Id)
        {
            try
            {
                var result = _student.GetUploadedFile(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpGet]
        [Route("api/Student/GetStudentByID")]

        public IActionResult GetStudentByID(string Id)
        {
            try
            {
                var result = _student.GetStudentByID(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpGet]
        [Route("api/Student/DeleteStudent")]

        public IActionResult DeleteStudent(string Id)
        {
            try
            {
                var result = _student.DeleteStudent(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [Route("api/Student/AddStudent")]
        public IActionResult AddStudent([FromBody] PostModel inUsers)
        {
            Student obj = JsonConvert.DeserializeObject<Student>(inUsers.Key);
            try
            {
                var result = _student.AddStudent(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpPost]
        [Route("api/Student/UpdateStudent")]
        public IActionResult UpdateStudent([FromBody] PostModel inUsers)
        {
            Student obj = JsonConvert.DeserializeObject<Student>(inUsers.Key);
            try
            {
                var result = _student.UpdateStudent(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}