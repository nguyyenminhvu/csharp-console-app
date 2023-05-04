using Newtonsoft.Json;
using Quiz.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.repository
{
    public class QuestionRepository : Repository
    {
        public  List<Question> readData(string path)
        {
            List<Question> listQuestion = new List<Question>();
            string json =  File.ReadAllText(path);
            listQuestion=JsonConvert.DeserializeObject<List<Question>>(json);
            return listQuestion;
        }

        public void writeData(List<Question> listQuestion, string path)
        {
            string json = JsonConvert.SerializeObject(listQuestion);
            File.WriteAllText(path, json); 
            Console.WriteLine("Add successful !!");
        }
    }
}
