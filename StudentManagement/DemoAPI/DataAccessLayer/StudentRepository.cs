using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Student.Services;
using Student.Models;
using Microsoft.EntityFrameworkCore;


namespace Student.DataAccessLayer.Interface 
{
       public class StudentRepository:IStudentRepository
       {

         private readonly StudentContext _Context;

          private readonly ILogger<StudentRepository> _logger;

         public StudentRepository(StudentContext context,ILogger<StudentRepository> logger)
        {
            _Context=context;
            _logger=logger;
            
        }
         public bool CreateStudent(Students student)
        {
             try{
                _Context.Students.Add(student);
                _Context.SaveChanges();
                return true;
            }
            catch (ValidationException exception)
            {
                _logger.LogError("StudentRepository","CreateStudent(Students student)",exception,student);
                throw;
            }
            catch (Exception exception)
            {
                _logger.LogError("StudentRepository","CreateStudent(Students student)",exception,student);
                throw exception;
            }
        }

         public Students GetStudent(int StudentId)
        {
            if(StudentId <= 0)
            throw new ArgumentException("StudentId must be creater than 0");
            try{
                var Student=_Context.Students.Include(e => e.Gender).FirstOrDefault(item => item.StudentId ==StudentId);
                return Student;
            
            }
            catch (Exception exception)
            {
                 _logger.LogError(HelperService.LoggerMessage("StudentRepository", "GetStudent(int StudentId)", exception, StudentId));
                throw exception;
            }
           
        }

         public bool DeleteStudent(int StudentId)
        {
             if(StudentId<=0)throw new ArgumentException("StudentId must be creater than 0");
            try{
                var ExistingStudent=_Context.Students.FirstOrDefault(item => item.StudentId==StudentId);
                _Context.Students.Remove(ExistingStudent);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                _logger.LogError(HelperService.LoggerMessage("StudentRepository", "DeleteStudent(int StudentId)", exception, StudentId));
                return false;
            }
        }

         public bool UpdateStudent(Students student)
        {
            try{
                var Student=_Context.Students.Update(student);
                _Context.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
              _logger.LogError(HelperService.LoggerMessage("StudentRepository", "UpdateStudent(Students student)", exception, student));
              return false;
            }
        }

        public bool UpdateStudentAge(int StudentId,int StudentAge)
        {
            try{
               var ExistingStudent = GetStudent(StudentId);
               ExistingStudent.StudentAge = StudentAge;
               _Context.Students.Update(ExistingStudent);
               return true;
            }
            catch (Exception exception)
            {
            _logger.LogError(HelperService.LoggerMessage("StudentRepository", "UpdateStudentAge(int StudentId,int StudentAge)", exception, StudentId,StudentAge));
              return false;
            }
        }
       }
}
