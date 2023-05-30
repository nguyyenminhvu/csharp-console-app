using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement
{
    public class Course
    {
        public string Id { get; set; }
        public string Name { get; set;}
        public DateTime startCourse { get; set; }

        public Course(string id, string name, DateTime startCourse)
        {
            Id = id;
            Name = name;
            this.startCourse = startCourse;
        }
        public Course()
        {
        }

        public override string ToString()
        {
            return $"Course Id: {this.Id}, Name: {this.Name}, Start Course: {this.startCourse.ToString("MM/dd/yyyy")}";
        }


    }
    public class OnlineCourse : Course
    {
        public string url { get; set; }

        public OnlineCourse(string id, string name, DateTime startCourse, string url):base( id, name, startCourse)
        {
            this.url = url;
        }

        public OnlineCourse()
        {
        }

        public override string ToString()
        {
            return base.ToString()+$", Url Meet: {this.url}";
        }
    }
}
