using CourseManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExtensionMethod_LinQ
{
    public static class CourseExtension
    {
        public static void Display(this Course course, int count=1)
        {
            Console.WriteLine($"Course info {count} time: ");
            for(int i = 0; i < count; i++)
            {
                Console.WriteLine(course);
            }
        }
    }
}
