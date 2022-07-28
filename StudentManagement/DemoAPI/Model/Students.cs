using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace Student.Models

{
     [Index("EmailId",IsUnique =true)]
    public partial class Students
    {
       
        [Key]
        public int StudentId {get;set;}

        public string? Studentname {get;set;}

        public int StudentAge {get;set;}
        public string? EmailId {get;set;}

        public string? Password {get;set;}
        public String? Department{get;set;}=null;
        public int GenderId {get;set;}
      
        [ForeignKey("GenderId")]
        [InverseProperty("Students")]
        public virtual Gender? Gender { get; set; } = null!;


    }
}