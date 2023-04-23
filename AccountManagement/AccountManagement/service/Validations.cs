using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.service
{
    public class Validations
    {

        public Validations()
        {
        }
        private static Validations instance;
        public static Validations Instance { get { if (instance == null) { instance = new Validations(); } return instance; } private set => instance = value; }
        public int inputInteger(string msg, int min, int max)
        {
            bool check = true;
            int rs = 0;
            string s1 = "";
            while (check)
            {
                Console.WriteLine(msg);
                s1 = Console.ReadLine();
                try
                {
                    rs = Convert.ToInt32(s1);
                    if (rs >= min && rs <= max)
                    {
                        check = false;
                    }
                    else
                    {
                        Console.WriteLine($"Option [{min}-{max}]");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Please input integer !! ");
                    check = true;
                }
            }
            return rs;
        }
        private bool checkIntegerDay(int msg)
        {
            bool check = false;
            if (msg >= 1 && msg <= 31)
            {
                check = true;
            }
            return check;
        }
        private bool checkIntegerMonth(int msg)
        {
            bool check = false;
            if (msg >= 1 && msg <= 12)
            {
                check = true;
            }
            return check;
        }
        private bool checkIntegerYear(int msg)
        {
            bool check = false;
            if (msg > 0)
            {
                check = true;
            }
            return check;
        }
        public int inputIntegerNoCondition(string msg)
        {
            bool check = true;
            int rs = 0;
            string s1 = "";
            while (check)
            {
                Console.WriteLine(msg);
                s1 = Console.ReadLine();
                try
                {
                    rs = Convert.ToInt32(s1);
                    check = false;

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Please input integer !! ");
                    check = true;
                }
            }
            return rs;
        }
        public string inputString(string msg)
        {
            bool check = true;
            string rs = "";
            while (check)
            {
                Console.WriteLine(msg);
                rs = Console.ReadLine();
                if (rs.Trim().Length > 0)
                {
                    check = false;
                }
                else
                {
                    Console.WriteLine("Please input some thing !! ");
                    check = true;
                }
            }
            return rs;
        }
        public int checkIsInteger(string s)
        {
            int rs = 0;
            try
            {
                rs = Convert.ToInt32(s);
            }
            catch
            {
                rs = -1;
            }
            return rs;
        }
        public int[] inputStringDate(string msg)
        {
            bool check = true, checkDay = false, checkMonth = false, checkYear = false;
            string[] aString = null;
            int[] iTime = new int[3];
            string rs = "";
            int day = 0, month = 0, year = 0;
            while (check)
            {
                rs = inputString(msg);
                if (rs.Trim().Length > 0)
                {
                    aString = rs.Split("/");
                    if (aString.Length == 3)
                    {
                        day = checkIsInteger(aString[0]);
                        month = checkIsInteger(aString[1]);
                        year = checkIsInteger(aString[2]);
                        if (day > 0 && month > 0 && year > 0)
                        {
                            checkDay = checkIntegerDay(day);
                            checkMonth = checkIntegerMonth(month);
                            checkYear = checkIntegerYear(year);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Please input some thing !! ");
                    check = true;
                }
                if (checkDay && checkMonth && checkYear)
                {
                    check = false;
                    iTime[0] = day;
                    iTime[1] = month;
                    iTime[2] = year;
                }
            }
            return iTime;
        }
    }
}
