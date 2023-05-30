using CourseManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExtensionMethod_LinQ
{
    public static class ListExtension
    {
        // moi ham trong extension deu phai la static, no co the nhan bat ki tham so nao neu can nhung phai
        // cong them 1 tham so kieu du lieu cua ham duoc mo rong va duoc danh dau this o dau
        public static void Display(this List<Course> courses )
        {
            Console.WriteLine("List Of Course: ");
            foreach (var item in courses)
            {
                Console.WriteLine(item);
            }
        }
    }
}
