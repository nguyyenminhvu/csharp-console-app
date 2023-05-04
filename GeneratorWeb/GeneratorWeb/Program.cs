using System;
using GeneratorWeb.service;

namespace GeneratorWeb
{
    internal class Program
    {
        private static GenerateService service = new GenerateService();
        static void Main(string[] args)
        {
            Console.WriteLine("Let's Custom your Page.");
            string paths = Validations.Instance.inputString("Path file html?");
            service.changeNavbar(paths);
            //paths = Validations.Instance.inputString("Path file html?");
            //service.changeLayerIndex(paths);
            //paths = Validations.Instance.inputString("Path file html?");
            //service.changeFeature(paths);
            //paths = Validations.Instance.inputString("Path file html?");
            //service.changeFeedback(paths);
        }
    }
}
