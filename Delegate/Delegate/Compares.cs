using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement
{
    public class IdCompares : IComparer<Course>
    {
        public int Compare(Course x, Course y)
        {
            return x.Id.CompareTo(y.Id);    
        }
    }   
    public class NameCompares : IComparer<Course>
    {
        public int Compare(Course x, Course y)
        {
            return x.Name.CompareTo(y.Name);    
        }
    } 
    public class StartDateCompares : IComparer<Course>
    {
        public int Compare(Course x, Course y)
        {
            return x.startCourse.CompareTo(y.startCourse);    
        }
    }
}
