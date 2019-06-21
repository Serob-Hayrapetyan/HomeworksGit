using System;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    [DataContract]
    public class Student
    {
        [DataMember]
        public int StudentId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Age { get; set; } 
    }
}
