using CourseManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExtensionMethod_LinQ
{
    internal class DemoMethodExtensionLinQ
    {
        List<Course> courses;
        public DemoMethodExtensionLinQ()
        {
            courses = new List<Course>();
            courses.Add(new Course("1", "DBI202", new DateTime(2021, 10, 10)));
            courses.Add(new Course("2", "CSD201", new DateTime(2020, 10, 10)));
            courses.Add(new Course("3", "Summer", new DateTime(2026, 10, 10)));
            courses.Add(new Course("4", "SWR302", new DateTime(2024, 10, 10)));
            courses.Add(new Course("5", "PRJ301", new DateTime(2021, 10, 10)));
            courses.Add(new Course("6", "MAS291", new DateTime(2019, 10, 10)));
            courses.Add(new Course("7", "JPS113", new DateTime(2020, 10, 10)));
            courses.Add(new Course("8", "JPD123", new DateTime(2015, 10, 10))); 
            courses.Add(new Course("9", "MAE101", new DateTime(2012, 10, 10)));
            courses.Add(new Course("10", "PRN211", new DateTime(2018, 10, 10)));
            courses.Add(new Course("11", "SSG104", new DateTime(2019, 10, 10)));
            courses.Add(new Course("12", "SWT301", new DateTime(2017, 10, 10)));
 
        }   
        public List<Course> GetCourses() {  return courses; }
        public Course getCourseByIdUsingMethod(string id)
        {
            return courses.First(x=> x.Id.Equals(id));
        }
        public List<Course> getCourseByName(string name)
        {
            return courses.Where(x=>x.Name.Contains(name)).ToList();
            // neu toi co x thi toi return ra kieu du lieu cua x (dieu kien name cua x contain voi nam tham so). x o day la course
        }
        public void getCourseWithDataCondition(DateTime startDate, DateTime endDate)
        {
            var rs= courses.Where(x => x.startCourse >= startDate && x.startCourse <= endDate).Select(x => (x.Name, x.startCourse)).ToList();
            foreach (var item in rs)
            {
                Console.WriteLine($"Name: {item.Name}, Start Course: {item.startCourse.ToString("dd/MM/yyyy")}");
            }
        }






        public Course getCourseByIdUsingQuery(string id)
        {
            return (from c in courses where c.Id == id select c).First();
        }
        public List<Course> getCourseByNameUsingQuery(string name)
        {
            return (from c in courses where c.Name.Contains(name) select c).ToList();
        }
        public void getCourseDuringDateUsingQuery(DateTime start, DateTime end)
        {
            var c = (from co in courses where co.startCourse >= start && co.startCourse <= end select new
            {
                Tilte=co.Name,
                Date=co.startCourse.ToString("dd/MM/yyyy")
            } );
            foreach (var item in c)
            {
                Console.WriteLine($"{item.Tilte} - {item.Date}");
            }
            // thay doi ten bang de hien thi ra. Tao object json moi roi thay vao thoi
        }
    }
}
