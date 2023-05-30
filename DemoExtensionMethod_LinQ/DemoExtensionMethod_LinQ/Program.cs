using CourseManagement;
using System;
using System.Collections.Generic;

namespace DemoExtensionMethod_LinQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //demoCourseExtension();
            //demoListExtension();
            demoUsingLinQ();
        }
        public static void demoListExtension()
        {
            List<Course> courses = new List<Course>();
            courses.Add(new Course("1", "Spring", new DateTime(2021, 10, 10)));
            courses.Add(new Course("2", "Fall", new DateTime(2020, 10, 10)));
            courses.Add(new Course("3", "Summer", new DateTime(2026, 10, 10)));
            courses.Add(new Course("4", "Winter", new DateTime(2024, 10, 10)));
            courses.Display();
        }
        public static void demoCourseExtension()
        {
            Course course = new Course("1", "Spring", new DateTime(2024, 10, 10));
            course.Display(2);
        }
        public static void demoUsingLinQ()
        {
            DemoMethodExtensionLinQ demoMethodExtensionLinQ = new DemoMethodExtensionLinQ();
            //  demoMethodExtensionLinQ.getCourseByIdUsingMethod("2").Display();
            //    demoMethodExtensionLinQ.getCourseByName("J").Display() ;
            demoMethodExtensionLinQ.getCourseDuringDateUsingQuery(new DateTime(2015, 12, 30), new DateTime(2025, 12, 30));
        }
    }
}
