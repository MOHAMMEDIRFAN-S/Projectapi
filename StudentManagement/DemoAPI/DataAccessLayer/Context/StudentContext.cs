using System;
using System.Collections.Generic;
using Student.Models;
using Microsoft.EntityFrameworkCore;

namespace Student.DataAccessLayer
{
    public class StudentContext:DbContext
    {

         public StudentContext(DbContextOptions<StudentContext> options):base(options)
        {
            
        }
        
      
        public DbSet<Gender> Gender{get;set;}=null!;
        public DbSet<Students> Students{get;set;}=null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>(entity =>
            {
                entity.HasData(new Gender { GenderId = 1, GenderName = "Male" });
                entity.HasData(new Gender { GenderId = 2, GenderName= "Female" });
                entity.HasKey("GenderId");
            });
        }

    }
}
