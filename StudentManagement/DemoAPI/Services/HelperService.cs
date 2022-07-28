using System.Text;
using Student.Models;

namespace Student.Services
{
     public static class HelperService
     {
        public static string LoggerMessage(string RepositoryName, string MethodName, Exception exception, object? Data = null)
        {
            return  $"{RepositoryName}:{MethodName}-Exception:{exception.ToString()}";
         }

         public static string LoggerMessage(string RepositoryName, string MethodName, Exception exception, int FirstId, int? secondId)
        {
            return secondId != null ? $"{RepositoryName}:{MethodName}-Exception:{exception.ToString()} DataPassed:{{ {FirstId}, {secondId} }}" :
             $"{RepositoryName}:{MethodName}-Exception:{exception.ToString()} DataPassed:{{  {FirstId} }}"; 
        }
     }
}