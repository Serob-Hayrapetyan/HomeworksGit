using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex4
{
    public partial class StudentCatalog
    {
        private class StudentComparer : IComparer<Student>
        {
            StudentCatalog students = new StudentCatalog();

            public int Compare(Student x, Student y)
            {
                if (students.GetAverageForStudent(x.ID) > students.GetAverageForStudent(y.ID))
                {
                    return -1;
                }

                if (students.GetAverageForStudent(x.ID) < students.GetAverageForStudent(y.ID))
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
