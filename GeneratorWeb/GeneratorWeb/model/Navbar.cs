using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorWeb.model
{
    internal class Navbar
    {
        public string NameLogo { get; set; }
        public string NameDropDown1 { get; set; }
        public string NameDropDown2 { get; set; }
        public string NameDropDown3 { get; set; }
        public string NameDropDown4 { get; set; }

        public Navbar()
        {
            NameLogo = "{Brighton}";
            NameDropDown1 = "{Home}";
            NameDropDown2 = "{About}";
            NameDropDown3 = "{Programs}";
            NameDropDown4 = "{Contact us}";
        }
    
    }
}
