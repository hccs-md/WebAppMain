using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace WebAppMain.DAL
{
    public class MyDbContext : DbContext
    {

        public MyDbContext() : base("DefaultConnection")
        {
            Database.SetInitializer<MyDbContext>(new MyDbInitializer());
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Textbook> Textbooks { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<HccsRole> HccsRoles { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }


    public class MyDbInitializer : CreateDatabaseIfNotExists<MyDbContext>
    {
        protected override void Seed(MyDbContext context)
        {
            // create 3 students to seed the database
            //context.Students.Add(new Student { ID = 1, FirstName = "Mark", LastName = "Richards", EnrollmentDate = DateTime.Now });
            //context.Students.Add(new Student { ID = 2, FirstName = "Paula", LastName = "Allen", EnrollmentDate = DateTime.Now });
            //context.Students.Add(new Student { ID = 3, FirstName = "Tom", LastName = "Hoover", EnrollmentDate = DateTime.Now });
            //base.Seed(context);
        }
    }
}