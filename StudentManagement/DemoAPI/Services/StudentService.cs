using System;
using Student.Models;
using System.Threading.Tasks;
using Student.Services.Interfaces;
using Student.Services.Validation;
using Student.DataAccessLayer.Interface;
using Student.Services;



namespace Student.Services
{
    public class StudentService:IStudentService
    {

         public readonly IStudentRepository _studentRepository;

         public readonly ILogger<StudentService> _logger;
        public StudentService(IStudentRepository studentRepository,ILogger<StudentService> logger)
        {
              _studentRepository=studentRepository;

              _logger=logger;
        }
    
    public bool CreateStudent(Students Student)
        {
               validation.ValidateStudent(Student);

              
            try{
               return _studentRepository.CreateStudent(Student);
            }
            
            catch (Exception exception)
            {
                _logger.LogError(HelperService.LoggerMessage("StudentService", "CreateStudent(Students Student)", exception, Student));
                return false;
            }

        }
          public Students GetStudent(int StudentId)
        {
            try{
                return _studentRepository.GetStudent(StudentId);
            }
            
            catch (Exception exception)
            {
                _logger.LogError(HelperService.LoggerMessage("StudentService","GetStudent(int Student)",exception,StudentId));
                throw exception;
            }
        }
         public bool DeleteStudent(int StudentId)
         
        {
            try{
            return _studentRepository.DeleteStudent(StudentId);
            }
            
            catch (Exception exception)
            {
                _logger.LogError(HelperService.LoggerMessage("StudentService","DeleteStudent(int StudentId)",exception,StudentId));
                return false;
            }
        }

        public bool UpdateStudent(Students student)
        {
            try
            {
                var ExistingStudent=_studentRepository.GetStudent(student.StudentId);
                ExistingStudent.Studentname=student.Studentname;
                ExistingStudent.StudentAge=student.StudentAge;
                ExistingStudent.EmailId=student.EmailId;
                ExistingStudent.Password=student.Password;
                ExistingStudent.GenderId=student.GenderId;
                ExistingStudent.Department=student.Department;
    
                return _studentRepository.UpdateStudent(ExistingStudent);
            }
            catch (Exception exception)
            {
                
                _logger.LogError(HelperService.LoggerMessage("StudentService","UpdateStudent(Students student)",exception,student));
                return false;
            }
        }   
           public bool UpdateStudentAge(int StudentId,int StudentAge)
           {
            try{
                return _studentRepository.UpdateStudentAge(StudentId,StudentAge);
            }
            catch(Exception exception)
            {
                _logger.LogError(HelperService.LoggerMessage("StudentService","UpdateStudentAge(int StudentId,int StudentAge)",exception,StudentId,StudentAge));
                return false;
            }
           }
         
    }
    
}