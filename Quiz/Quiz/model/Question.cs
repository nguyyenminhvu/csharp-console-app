using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.model
{
    public class Question
    {
        public Question() { }
        public string QuestionQuizz { get; set; }
        public List<string> Answers { get; set; }
        public List<string> RealAnswer { get; set; }

        public Question(string questionQuizz, List<string> answers, List<string> realAnswer)
        {
            QuestionQuizz = questionQuizz;
            Answers = answers;
            RealAnswer = realAnswer;
        }



    }

}
