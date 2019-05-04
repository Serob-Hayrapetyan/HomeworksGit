using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex4
{
    partial class StudentCatalog
    {
        public List<Student> student;
        public Dictionary<int, Student> StudentsCatalog { get; set; }

        /// <summary>
        /// </summary>
        /// Add a single student to the catalog.
        public void AddStudent(Student aStudent)
        {
            student.Add(aStudent);
        }

        /// <summary>
        /// Given an id, return the student with that id.
        /// If no student exists with the given id, return null.
        /// </summary>
        public Student GetStudent(int id)
        {
            for (int i = 0; i < student.Count; i++)
            {
                if (student[i].ID == id)
                {
                    return student[i];
                }
            }
            return null;
        }

        /// <summary>
        /// Given an id,this method returns the score average for the student with that id.
        /// If no student exists with the given id, return -1.
        /// </summary>
        public int GetAverageForStudent(int id)
        {
            for (int i = 0; i < student.Count; i++)
            {
                if (StudentsCatalog.ContainsKey(id))
                {
                    int studentAverageScore = 0;
                    foreach (var student in StudentsCatalog)
                    {
                        if (student.Key == id)
                        {
                            int score;
                            score = student.Value.testScores.Sum(x => x.Value); //used some LINQ 
                            if (student.Value.testScores.Count() > 0)
                            {
                                studentAverageScore += score / student.Value.testScores.Count();
                            }
                        }
                    }
                    return studentAverageScore;
                }
                else
                {
                    return -1;
                }
            }
            return -1;
        }//ES METODY INQNURUYN CHEM GREL
        /// <summary>
        /// Returns the total test score average for ALL students in the catalog.
        /// Note that only students with a "real" score average (i.e. NOT -1) should
        /// be included in the calculation of the average.
        /// </summary>
        public int GetTotalAverage()
        {
            int totalAverageScoreForStudents = 0;
            int studentAverageScore;
            foreach (var student in this.StudentsCatalog)
            {
                studentAverageScore = GetAverageForStudent(student.Key);
                if (studentAverageScore != -1)
                {
                    totalAverageScoreForStudents += studentAverageScore;
                }
            }
            return totalAverageScoreForStudents / this.StudentsCatalog.Count();

        }

        public List<Student> GetTopThreeStudents()
        {
            var studentsList = new List<Student>(); //this logic is very bad, I don't like it, but it's the easiues way
            var topThreeStudentsList = new List<Student>();

            foreach (var student in this.StudentsCatalog)
            {
                studentsList.Add(student.Value);
            }

            studentsList.Sort(new StudentComparer());
            for (int i = 0; i < 3; i++)
            {
                topThreeStudentsList.Add(studentsList[i]);
            }

            return topThreeStudentsList;
        }
    }
}
