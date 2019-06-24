using DataLayer;
using System;
using System.Collections.Generic;

namespace StudentsLibrary
{
    public class StudentService : IStudentService
    {
        private StudentDataService studentDataService;

        public Student CreatStudent()
        {
            return new Student();
        }

        public void DeleteStudent(int id)
        {
            List<Student> st = studentDataService.GetStudents();
            for(int i = 0; i < st.Count; i++)
            {
                if(st[i].StudentId == id)
                {
                    st[i] = null;
                    //write again...
                }
            }
        }

        public Student[] GetStudent()
        {
            this.studentDataService = new StudentDataService();
            return this.studentDataService.GetStudents().ToArray();
        }

        public Student GetStudentById(int id)
        {
            List<Student> st = studentDataService.GetStudents();
            foreach (var x in st)
            {
                if (x.StudentId == id)
                {
                    return x;
                }
            }
            return null;
        }

        public void UpdateStudent(int id)
        {
            throw new NotImplementedException();
        }
    }
}
