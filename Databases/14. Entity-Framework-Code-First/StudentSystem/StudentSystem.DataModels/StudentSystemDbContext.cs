using StudentSystem.Data.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace StudentSystem.DataModels
{
    public class StudentSystemDbContext : DbContext
    {
        public StudentSystemDbContext() 
            : base("StudentSystem")
        {
        }

        public IDbSet<Students> Students
        {
            get; set;
        }

        public IDbSet<Courses> Courses
        {
            get; set;
        }
        public IDbSet<Homeworks> Homeworks
        {
            get; set;
        }
    }
}
