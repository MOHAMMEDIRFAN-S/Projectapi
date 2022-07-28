using System;
using System.ComponentModel.DataAnnotations;
using Student.Models;

namespace Student.Services.Validation
{
    public class validation
    {
        public static bool ValidateStudent(Students student)
        {
            if(student==null)throw new ValidationException("Student should not be null");
            if(student.Studentname?.Length<2)throw new ValidationException("Student Name should have the words greater than 2");
            if(student.StudentAge<18)throw new ValidationException("Age must be greater than 18");
            if(student.GenderId<=0 && student.GenderId<2)throw new ValidationException("GenderId must be 1 or 2");
            else return true;
        }
    }
}