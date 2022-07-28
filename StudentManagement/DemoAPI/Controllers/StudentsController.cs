using System;
using Student.Models;
using Microsoft.AspNetCore.Mvc;
using Student.Services.Interfaces;
using System.Collections.Generic;
using Student.Services;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;



namespace Student.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StudentController : ControllerBase
    {
     
      
       public readonly IStudentService _studentService;
        public readonly ILogger<StudentController> _logger;
        public StudentController(IStudentService studentService,ILogger<StudentController> logger)
        {
            _studentService=studentService;
            
            _logger=logger;
        
        }

        
        [HttpPost]
        public async Task<ActionResult> CreateStudent(Students student)
        {
            if(student==null) return BadRequest("Null value cannot used");

        try
        {
            return _studentService.CreateStudent(student)?await Task.FromResult(Ok("Created successfully")):BadRequest("Error occured while creating student details");
        }
        catch(ValidationException exception)
            {
                _logger.LogError(HelperService.LoggerMessage("StudentController","CreateStudent(Students student",exception,student));
                return BadRequest("validation error occured");
            }
            catch(Exception exception)
            {
                _logger.LogError(HelperService.LoggerMessage("StudentController","CreateStudent(Students student)",exception,student));
                return Problem("Error Occured While creating student");
            }
      

        }

        [HttpGet]
        public async Task<ActionResult> GetStudent(int StudentId)
        {
            if(StudentId<=0)return BadRequest("StudentId must be greater than 0");
             try{
                var Student=_studentService.GetStudent(StudentId);
                return await Task.FromResult(Ok(Student));
             }
             catch(Exception exception)
            {
                _logger.LogError(HelperService.LoggerMessage("EmployeeController","GetEmployee(int EmployeeId)",exception,StudentId));
                return Problem("Error Occured While creating employee");
            }

            
        }

         [HttpDelete]
        public async Task<ActionResult> DeleteStudent(int StudentId)
        {
            if(StudentId<=0)return BadRequest("StudentId must be greater than 0");
            try{
                return _studentService.DeleteStudent(StudentId)? await Task.FromResult(Ok("Successfully Deleted")):BadRequest("Error Occured While Deleting the record");
            }
           
            catch(Exception exception)
            {
                _logger.LogError(HelperService.LoggerMessage("StudentController","DeleteStudent(int StudentId)",exception,StudentId));
                return Problem("Error Occured While creating Student");
            }
        }

          [HttpPut]
        public async Task<ActionResult> UpdateStudent(Students Student)
        {
            try{
                var student=_studentService.UpdateStudent(Student);
                return await Task.FromResult(Ok(student));
            }
            
            catch(Exception exception)
            {
                _logger.LogError(HelperService.LoggerMessage("StudentController","UpdateStudent(Students Student)",exception,Student));
                return Problem("Error Occured While creating Student");
            }

            
        }
        [HttpPatch]
        public async Task<ActionResult> UpdateStudentAge(int StudentId,int StudentAge)
        {
            try
            {
                var student = _studentService.UpdateStudentAge(StudentId,StudentAge);
                return await Task.FromResult(Ok(student));
            }
            catch(Exception exception)
            {
                _logger.LogError(HelperService.LoggerMessage("StudentController","UpdateStudentAge(int StudentId,int StudentAge)",exception,StudentId,StudentAge));
                return Problem("Erroe occured while update age");
            }
        }
        
    }
}