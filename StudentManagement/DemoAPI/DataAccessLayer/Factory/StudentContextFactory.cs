// using Microsoft.EntityFrameworkCore;
// namespace Student.DataAccessLayer
// {
//     public class StudentContextFactory
//     {
//         private  StudentContext? _studentContext;
//         public  StudentContext GetStudentContextObject()
//         {
//             var optionsBuilder = new DbContextOptionsBuilder<StudentContext>();
//             try
//             {
//                 IConfigurationRoot configuration = new ConfigurationBuilder()
//                 .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
//                 .AddJsonFile("appsettings.json")
//                 .Build();
//                 var connectionString = configuration.GetConnectionString("Default");
//                 optionsBuilder.UseSqlServer(connectionString
//                                          ?? throw new NullReferenceException(
//                                              $"Connection string is passed as null {nameof(connectionString)}"));
//                   _studentContext =  new StudentContext(optionsBuilder.Options);
//                   return _studentContext;
//             }
//             catch (Exception exception)
//             {
//                 Console.WriteLine(exception.Message);
//                 throw;
//             }
//         }
//     }
// }