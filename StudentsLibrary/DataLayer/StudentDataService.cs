using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataLayer
{
    public class StudentDataService
    {
        private List<Student> students;

        public StudentDataService()
        {
            this.students = new List<Student>();
            SeedData();
        }

        /// <summary>
        /// Get students data from file, db, or other source
        /// </summary>
        private void SeedData()
        {
            Univercity univerDb = new Univercity();
            var stud = univerDb.Students;

            this.students = stud.ToList();
        }

        public List<Student> GetStudents()
        {
            return this.students;
        }
    }

    /// <summary>
    /// Database class
    /// </summary>
    public class Univercity : DbContext
    {
        public DbSet<Student> Students { get; set; }   
    }
}
