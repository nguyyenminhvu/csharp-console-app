using Quiz.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.repository
{
    public interface Repository
    {
        public List<Question> readData(string path);
        public void writeData(List<Question> listQuestion, string path);
    }
}
