using StudentSystem.Data.Models;
using StudentSystem.DataModels;
using StudentSystem.DataModels.Migrations;
using System;
using System.Data.Entity;
using System.Linq;

namespace StudentSystem.App
{
    public class StartUp
    {
        // Build to restore the packages and change the connection-strings in all projects if you're not using SSMS 2014.
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemDbContext, Configuration>());

            var dbContext = new StudentSystemDbContext();
            var student = new Students
            {
                Number = 404,
                LastName = "Oxfordion"
            };

            dbContext.Students.Add(student);
            dbContext.SaveChanges();

            var allCourses = dbContext.Courses.ToList();
            for (int i = 0; i < 5; i++)
            {
                student.Courses.Add(allCourses[i]);
            }

            dbContext.SaveChanges();

            var studentCoursesNames = student.Courses.Select(c => c.Name);
            Console.WriteLine($"\nStudent 404's list of courses:\n-- {string.Join("\n-- ", studentCoursesNames)}");
            Console.WriteLine("\nData was inserted through the Seed method and can be checked in SSMS. :)");
        }
    }
}
