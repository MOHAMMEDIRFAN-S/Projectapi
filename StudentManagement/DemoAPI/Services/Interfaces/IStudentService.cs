using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student.Models;

namespace Student.Services.Interfaces
{
    public interface IStudentService
    {
        bool CreateStudent(Students student);
        bool DeleteStudent(int StudentId);
         Students GetStudent(int StudentId);
         bool UpdateStudent(Students student);
         bool UpdateStudentAge(int StudentId,int StudentAge);
        
    }
}