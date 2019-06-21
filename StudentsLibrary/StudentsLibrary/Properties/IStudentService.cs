using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace StudentsLibrary
{
    [ServiceContract]
    public interface IStudentService
    {
        [OperationContract]
        Student[] GetStudent();

        [OperationContract]
        Student GetStudentById(int id);

        [OperationContract]
        Student CreatStudent();

        [OperationContract]
        void UpdateStudent(int id);

        [OperationContract]
        void DeleteStudent(int id);
    }

}
