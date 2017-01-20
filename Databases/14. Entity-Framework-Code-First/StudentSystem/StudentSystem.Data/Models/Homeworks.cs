using System;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Data.Models
{
    public class Homeworks
    {
        public int Id
        {
            get; set;
        }

        [Required]
        public string Content
        {
            get; set;
        }

        public DateTime? TimeSent
        {
            get; set;
        }

        public virtual Students Student
        {
            get; set;
        }

        [Required]
        public int StudentId
        {
            get; set;
        }

        public virtual Courses Course
        {
            get; set;
        }

        [Required]
        public int CourseId
        {
            get; set;
        }
    }
}