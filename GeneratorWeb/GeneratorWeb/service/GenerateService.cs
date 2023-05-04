using GeneratorWeb.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorWeb.service
{
    internal class GenerateService
    {

        public void changeNavbar(string paths)
        {   Navbar navbar = new Navbar();   

            string nameLogo = Validations.Instance.inputString("Name Logo?");
            string nameDropDown1 = Validations.Instance.inputString("Name DropDown 1?");
            string nameDropDown2 = Validations.Instance.inputString("Name DropDown 2?");
            string nameDropDown3 = Validations.Instance.inputString("Name DropDown 3?");
            string nameDropDown4 = Validations.Instance.inputString("Name DropDown 4?");

            string stringFile = File.ReadAllText(paths);

            stringFile = stringFile.Replace($"{navbar.NameLogo}", nameLogo);
            stringFile = stringFile.Replace($"{navbar.NameDropDown1}", nameDropDown1);
            stringFile = stringFile.Replace($"{navbar.NameDropDown2}", nameDropDown2);
            stringFile = stringFile.Replace($"{navbar.NameDropDown3}", nameDropDown3);
            stringFile = stringFile.Replace($"{navbar.NameDropDown4}", nameDropDown4);

            File.WriteAllText("C:\\Users\\ACER\\Desktop\\General\\.NET Console App Lamboro\\demoGeneratorWeb\\brighton-html\\generateNavbar.html", stringFile);
            changeLayerIndex("C:\\Users\\ACER\\Desktop\\General\\.NET Console App Lamboro\\demoGeneratorWeb\\generateNavbar.html");
        }
        public void changeLayerIndex(string paths)
        {
            string indexTitle1P1 = Validations.Instance.inputString("Title 1.1 ?");
            string indexTitle1P2 = Validations.Instance.inputString("Title 1.2 ?");
            string title1Description = Validations.Instance.inputString("Title 1 Description?");

            string indexTitle2P1 = Validations.Instance.inputString("Title 2.1 ?");
            string indexTitle2P2 = Validations.Instance.inputString("Title 2.2 ?");
            string title2Description = Validations.Instance.inputString("Title 2 Description?");

            string stringFile = File.ReadAllText(paths);

            stringFile = stringFile.Replace("{indexTitle1p1}", indexTitle1P1);
            stringFile = stringFile.Replace("{indexTitle1p2}", indexTitle1P2);
            stringFile = stringFile.Replace("{indexTitle1Des}", title1Description);

            stringFile = stringFile.Replace("{indexTitle2p1}", indexTitle2P1);
            stringFile = stringFile.Replace("{indexTitle2p2}", indexTitle2P2);
            stringFile = stringFile.Replace("{indexTitle2Des}", title2Description);

            File.WriteAllText("C:\\Users\\ACER\\Desktop\\General\\.NET Console App Lamboro\\demoGeneratorWeb\\brighton-html\\generateLayerIndex.html", stringFile);
            changeFeature("C:\\Users\\ACER\\Desktop\\General\\.NET Console App Lamboro\\demoGeneratorWeb\\brighton-html\\generateLayerIndex.html");
        }
        public void changeFeature(string paths)
        {
            string titleFeature = Validations.Instance.inputString("Name Title Feature?");
            string DescriptionFeature = Validations.Instance.inputString("Description Title Feature?");

            string nameFeature1 = Validations.Instance.inputString("Name Feature 1?");
            string desFeature1 = Validations.Instance.inputString("Description Feature 1?");

            string nameFeature2 = Validations.Instance.inputString("Name Feature 2?");
            string desFeature2 = Validations.Instance.inputString("Description Feature 2?");

            string nameFeature3 = Validations.Instance.inputString("Name Feature 3?");
            string desFeature3 = Validations.Instance.inputString("Description Feature 3?");

            string nameFeature4 = Validations.Instance.inputString("Name Feature 4?");
            string desFeature4 = Validations.Instance.inputString("Description Feature 4?");

            string nameFeature5 = Validations.Instance.inputString("Name Feature 5?");
            string desFeature5 = Validations.Instance.inputString("Description Feature 5?");

            string nameFeature6= Validations.Instance.inputString("Name Feature 6?");
            string desFeature6 = Validations.Instance.inputString("Description Feature 6?");

            string readMoreTitle= Validations.Instance.inputString("Title Read More?");
            string readMoreDes = Validations.Instance.inputString("Description Read More?");

            string stringFile = File.ReadAllText(paths);

            stringFile= stringFile.Replace("{tilteFeature1}", titleFeature);
            stringFile = stringFile.Replace("{descriptionFeature1}", DescriptionFeature);

            stringFile = stringFile.Replace("{feature1}", nameFeature1);
            stringFile = stringFile.Replace("{feature1Des}", desFeature1);

            stringFile = stringFile.Replace("{feature2}", desFeature2);
            stringFile = stringFile.Replace("{feature2Des}", desFeature2);

            stringFile = stringFile.Replace("{feature3}", desFeature3);
            stringFile = stringFile.Replace("{feature3Des}", desFeature3);

            stringFile = stringFile.Replace("{feature4}", desFeature4);
            stringFile = stringFile.Replace("{feature4Des}", desFeature4);

            stringFile = stringFile.Replace("{feature5}", desFeature5);
            stringFile = stringFile.Replace("{feature5Des}", desFeature5);

            stringFile = stringFile.Replace("{feature6}", desFeature6);
            stringFile = stringFile.Replace("{feature6Des}", desFeature6);

            stringFile = stringFile.Replace("{titleReadMore}", desFeature6);
            stringFile = stringFile.Replace("{titleReadMoreDes}", desFeature6);


            File.WriteAllText("C:\\Users\\ACER\\Desktop\\General\\.NET Console App Lamboro\\demoGeneratorWeb\\brighton-html\\generateFeature.html", stringFile);
            changeFeedback("C:\\Users\\ACER\\Desktop\\General\\.NET Console App Lamboro\\demoGeneratorWeb\\brighton-html\\generateFeature.html");
        }
        public void changeFeedback(string paths)
        {
       
            string nameParent1 = Validations.Instance.inputString("Name Parent 1?");
            string jobParent1 = Validations.Instance.inputString("Job Parent 1?");
            string desParent1 = Validations.Instance.inputString("Feedback Parent 1?");

            string nameParent2 = Validations.Instance.inputString("Name Parent 2?");
            string jobParent2 = Validations.Instance.inputString("Job Parent 2?");
            string desParent2 = Validations.Instance.inputString("Feedback Parent 2?");

            string stringFile = File.ReadAllText(paths);
          
            stringFile = stringFile.Replace("{parent1}", nameParent1);
            stringFile = stringFile.Replace("{parent1Job}", jobParent1);
            stringFile = stringFile.Replace("{parent1Des}", desParent1);

            stringFile = stringFile.Replace("{parent2}", nameParent2);
            stringFile = stringFile.Replace("{parent2Job}", jobParent2);
            stringFile = stringFile.Replace("{parent2Des}", desParent2);

            File.WriteAllText("C:\\Users\\ACER\\Desktop\\General\\.NET Console App Lamboro\\demoGeneratorWeb\\brighton-html\\generateFeature.html", stringFile);
        }
    }
}
