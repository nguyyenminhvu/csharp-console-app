using CourseManagement;
using System;

namespace Delegate
{
    //Delegate trong C# là một cách để tạo ra một đối tượng chứa một hoặc nhiều phương thức,
    //cho phép ta truyền các phương thức này như là một đối tượng và thực hiện các thao tác bất đồng bộ (asynchronous) và sự kiện (event) trong C#.

   // Để giải thích cụ thể hơn, ta có thể sử dụng ví dụ về việc xử lý sự kiện trong C#.
   // Khi ta tạo ra một sự kiện (event) trong C#, ta cần phải tạo ra một delegate tương ứng với sự kiện đó.
   // Sau đó, các phương thức (handlers) có thể được thêm vào danh sách các phương thức được gọi khi sự kiện đó xảy ra.
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            demoBasicDelegate();    
        }
        public static void demoBasicDelegate()
        {
            Calculation calculation = new Calculation(add); // delegate ko phai object, khong phai cap phat bo nho gi ca, same same con tro
            Calculation calculation1 = sub;  // cach viet ngan gon thay co ben tren
          //  Calculation calculation1 = (x,y)=>x-y;// hoac viet nhu z theo lamda expression
            Calculation calculation2 = calculation + calculation1;
            //  calculation2(4, 5);
            //  caculator(4, 5, calculation1);

            testSort();

        }
        public static int add(int x, int y)
        {
            Console.WriteLine(x + y);
            return x + y;
        }   
        public static int sub(int x, int y)
        {
            Console.WriteLine(x - y);
            return x - y;
        }
        public static void caculator(int x, int y, Calculation calculation)
        {
            // ham nay minh truyen cho no 2 tham so va 1 cong thuc nao do chua biet, truyen roi moi biet
            calculation(x, y);

        }

        public static void testSort()
        {
            CourseService courseService = new CourseService();  
            courseService.init();
            Console.WriteLine("Sort by id: ");
            courseService.sortComparionId();
            courseService.printfAll();  
        }
    }
}
