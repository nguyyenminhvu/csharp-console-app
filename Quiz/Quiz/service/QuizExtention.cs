using Quiz.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.service
{
    public static class QuizExtention
    {
        public static void showQuestion(this Question question, int count = 1, int numQ=1)
        {
           Console.WriteLine($"Question {numQ}: "+question.QuestionQuizz);
           question.Answers.showAllAnswer();
        }
        public static void showAllAnswer(this List<string> answers)
        {
            if (answers.Count == 1) {
                for (int i = 0; i < answers.Count; i++)
                {
                    Console.WriteLine($"Incorrect !! The Answer is {answers[i]}");
                }
            }
            else
            {
                for (int i = 0; i < answers.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {answers[i]}");
                }
            }
          
        }

    }
}
