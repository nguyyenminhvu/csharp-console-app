using System;
using Quiz.controller;
using Quiz.service;

namespace Quiz
{
    internal class Program
    {
        private static Validations validations = new Validations();
        private static QuizController controller = new QuizController();
        static void Main(string[] args)
        {
            int choice = 0;
            Boolean check = true;
            while (check)
            {
                Console.WriteLine("-----------------QUIZ-----------------");
                Console.WriteLine("1. Play Quiz");
                Console.WriteLine("2. Create Question");
                Console.WriteLine("3. Quit");
                choice = validations.inputInteger("Choice?", 1, 3);
                switch(choice)
                {
                    case 1: controller.playQuiz(); break;
                    case 2: controller.createQuestion(); break;
                    case 3: check = false; break;
                }

            }
        }
    }
}
