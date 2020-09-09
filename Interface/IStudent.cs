using Interview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interview.Interface
{
   public interface IStudent
    {
        public   List<MainCourse> GetMainCourses();
        public List<Student> GetStudentDetails();

        public Result AddStudent(Student postModel);
        public Result UpdateStudent(Student postModel);
        public Result DeleteStudent(string ID);
        public Student GetStudentByID(string Id);
        public List<studentfile> GetUploadedFile(string Id);

        public Result DeleteUploadedFile(string Id, string Type);

    }
}
