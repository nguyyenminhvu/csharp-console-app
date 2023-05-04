using Newtonsoft.Json;
using Quiz.model;
using Quiz.repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Quiz.service
{
    internal class QuestionService
    {
        private static Validations validations = new Validations();
        private static List<Question> questions = new List<Question>();
        private static string paths = "C:\\Users\\ACER\\Desktop\\General\\.NET Console App Lamboro\\Quiz\\Quiz\\data.txt";
        private static Repository repository= new QuestionRepository();
        public void addQuestion(int numAns)
        {       
            for(int ii = 0;ii<numAns; ii++) { 
                List<string> listAnswer = new List<string>();
                List<string> realAnswer = new List<string>();
                string question = validations.inputString("Question: ");
                int num = validations.inputInteger("How many answer?", 2, 6);
                for (int i = 0; i < num; i++)
                {
                    string ans = validations.inputString($"Answer {i + 1}: ");
                    listAnswer.Add(ans);
                }
                int numRealAnswer = validations.inputInteger("Input answer correct: ", 1, listAnswer.Count());
                realAnswer.Add(listAnswer[numRealAnswer - 1]);
                questions.Clear();
                questions=repository.readData(paths);
                questions.Add(new Question(question, listAnswer, realAnswer));
                repository.writeData(questions, paths);
            
            }
        }
    }
}
