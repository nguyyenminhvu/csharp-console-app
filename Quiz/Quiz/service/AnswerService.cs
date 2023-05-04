using Quiz.model;
using Quiz.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.service
{
    public class AnswerService
    {
        private static Validations validations = new Validations();
        private static List<Question> questions = new List<Question>();
        private static string paths = "C:\\Users\\ACER\\Desktop\\General\\.NET Console App Lamboro\\Quiz\\Quiz\\data.txt";
        private static Repository repository = new QuestionRepository();
        public AnswerService() { }  
        public void playQuiz()
        {
            int points = 0;
            questions.Clear();
            questions=repository.readData(paths);
            for(int i = 0; i < questions.Count; i++)
            {
                Console.WriteLine("\n");
                questions[i].showQuestion(1,i+1);
                int ans = validations.inputInteger("Your answer: ",1, questions[i].Answers.Count());
                if (checkAns(questions[i].RealAnswer, questions[i].Answers[ans-1]))
                {
                    points += 10;
                    Console.WriteLine("Nice ! Correct Answer, + 10 point !!");
                    Console.WriteLine($"Point: {points}");
                }
                else
                {
                    questions[i].RealAnswer.showAllAnswer();
                }
            }
            Console.WriteLine($"You have {points} point, try next time. ");
            Console.WriteLine($"Point: {points}");
            Console.WriteLine("\n");
        }
        public Boolean checkAns(List<string> listAns, string ans)
        {
            Boolean check = false;
            for(int i = 0;i < listAns.Count; i++)
            {
                if (ans.Equals(listAns[i]))
                {
                    check = true;
                    return check;
                }
            }
            return check;
        }
    }
}
