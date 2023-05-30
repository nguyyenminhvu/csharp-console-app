using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    internal class ProccessDTO
    {
        public ProccessDTO() { }
        public string Name { get; set; }    
        public string Id { get; set; }
        public ProccessDTO(string name, string id)
        {
            Name = name;
            Id = id;
        }
    }
}
