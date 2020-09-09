using Interview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interview.Interface
{
   public interface ICourse
    {
        public List<CourseModule> GetCourseModules();
        public Result AddCourse(CourseModule courseModule);
        public Result UpdateCourse(CourseModule courseModule);
        public Result DeleteCourse(string Id);
    }
}
