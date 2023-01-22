using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using Microsoft.Win32;

namespace Exercise2
{
    public class StudentAdministration : IStudentAdministration
    {
        private readonly IList<Student> allStudents = new List<Student>();
        public int StudentTotal => allStudents.Count;

        public event NewStudentEventHandler? NewStudentEvent;

        public void RegisterStudent(Student student)
        {
            allStudents.Add(student);
            OnNewStudentEvent(student);
        }

        private void OnNewStudentEvent(Student student)
        {
            NewStudentEvent?.Invoke(this, new StudentEventArgs(student));
        }
    }
}
