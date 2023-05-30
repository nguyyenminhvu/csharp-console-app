using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement
{
    public class CourseService 
    {
        private static List<Course> courses= new List<Course>();
        private static Validations validations = new Validations();  
        public void addCourse()
        {
            Boolean check = true;
            int choice = 0;
                Console.WriteLine("1.Course Offline.");
                Console.WriteLine("2.Course Online.");
                choice = validations.inputInteger("Your choice: ",1,2);
                switch(choice)
                {
                    case 1: courseOfline();
                        break;
                    case 2: courseOnline();
                        break;
                }
        }
        public DateTime inputTime(string msg)
        {
            int[] sTime = validations.inputStringDate(msg);
            DateTime date = new DateTime(sTime[2], sTime[1], sTime[0]);
            return date;
        }
        public Course courseOfline()
        {
            Course course = new Course();
            string id = validations.inputString("Input Id: ");
            string name = validations.inputString("Input Name: ");
            DateTime date = inputTime("Star Course (dd/MM/yyyy): ");
            course.Id= id;
            course.Name= name;  
            course.startCourse= date;
            courses.Add(course);    
            return course;
        }
        public Course courseOnline()
        {
            OnlineCourse course = new OnlineCourse();
            string id = validations.inputString("Input Id: ");
            string name = validations.inputString("Input Name: ");
            string urlMeet = validations.inputString("Url Meet: ");
            DateTime date = inputTime("Star Course (dd/MM/yyyy): ");
            course.Id= id;
            course.Name= name;  
            course.startCourse= date;
            course.url=urlMeet;
            courses.Add(course);    
            return course;
        }
        public void printfAll()
        {
            for(int i=0; i<courses.Count; i++)
            {
                Console.WriteLine(courses[i].ToString());
            }
        }
        public void searchCourse()
        {
            DateTime startDate = inputTime("Star Course (dd/MM/yyyy): ");
            DateTime endDate = inputTime("End Course (dd/MM/yyyy): ");
            foreach (var item in courses)
            {
                if(item.startCourse>= startDate && item.startCourse <= endDate)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
        public void sortById()
        {
            courses.Sort(new IdCompares());
            printfAll();
        }   
        public void sortByName()
        {
            courses.Sort(new NameCompares());
            printfAll();
        }  
        public void sortByTime()
        {
            courses.Sort(new StartDateCompares());
            printfAll();
        }
        public void menuSort()
        {
            Console.WriteLine("1. Sort By Id.");
            Console.WriteLine("2. Sort By Name.");
            Console.WriteLine("3. Sort By Start Course.");
            Console.WriteLine("4. Back.");
            int choice = validations.inputInteger("Choose sort: ",1,3);
            switch (choice) {
                case 1: sortById(); 
                    break;
                case 2: sortByName();
                    break;
                case 3: sortByTime(); 
                    break;
                case 4: break;
            }
        }
        public  void readListCourseFromFile(string fileName)
        {
            courses.Clear();
            StreamReader streamReader = new StreamReader(fileName);
            string line ;
            while ((line = streamReader.ReadLine()) != null)
            {
                string[] aCourse = line.Split(',');
                if (aCourse.Length == 4)
                {
                    OnlineCourse course = new OnlineCourse(aCourse[0], aCourse[1], Convert.ToDateTime(aCourse[2]), aCourse[3]);
                    courses.Add(course);
                }
                else if (aCourse.Length == 3)
                {
                    Course course = new Course(aCourse[0], aCourse[1], Convert.ToDateTime(aCourse[2]));
                    courses.Add(course);
                }
            }
            streamReader.Close();
        }
     
        public int sortDelegateComparison(Course x, Course y)
        {
            return x.Id.CompareTo(y.Id);    
        }
        public void sortComparionId()
        {
            courses.Sort(sortDelegateComparison);  // trong tinh huong nay thi Sort la delegate cua c# dinh nghia
        }
        public void sortComparionName()
        { // anonymous. ko quan tam den ten ham la gi chi quan tam den cong viec
            courses.Sort(
                delegate (Course x, Course y)
                {
                    return x.Name.CompareTo(y.Name);    
                }
                );
        }
        public void sortComparionDate()
        { // van la anonymous function nhung ngan gon hon bang lamda expression
            courses.Sort((x, y) => x.startCourse.CompareTo(y.startCourse));  
        }
        public void init()
        {
            courses.Clear();
            courses.Add(new Course("1", "Spring", new DateTime(2020 / 11 / 10)));
            courses.Add(new Course("4", "Summer", new DateTime(2020 / 11 / 10)));
            courses.Add(new Course("3", "Fall", new DateTime(2020 / 11 / 10))); 
            courses.Add(new Course("2", "Winter", new DateTime(2020 / 11 / 10)));
        }

    }
}
