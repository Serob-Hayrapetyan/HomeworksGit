using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex4
{
    public class Student
    {
        public int ID;
        public string name;
        public Dictionary<string, int> testScores;

        public Student(int id, string name, Dictionary<string, int> testscores)
        {
            ID = id;
            this.name = name;
            testScores = testscores;
        }
    }
}
