using Quiz.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.controller
{
    public class QuizController
    {
        private static Validations validations = new Validations();
        private static QuestionService questionService = new QuestionService();
        private static AnswerService answerService = new AnswerService();   
        public QuizController() { }
        public void createQuestion()
        {
            int numAns = validations.inputInteger("How many question that you add?", 1, 99);
            questionService.addQuestion(numAns);
        }
        public void playQuiz()
        {
            answerService.playQuiz();
        }

    }
}
