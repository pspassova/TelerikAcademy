using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Data.Models
{
    public class Students
    {
        private ICollection<Courses> courses;
        private ICollection<Homeworks> homeworks;

        public Students()
        {
            this.courses = new HashSet<Courses>();
            this.homeworks = new HashSet<Homeworks>();
        }

        public int Id
        {
            get; set;
        }

        [MinLength(2)]
        [MaxLength(100)]
        public string FirstName
        {
            get; set;
        }

        [MinLength(2)]
        [MaxLength(100)]
        public string LastName
        {
            get; set;
        }

        [Required]
        [Range(100,999)]
        public int Number
        {
            get; set;
        }

        [MaxLength(3000)]
        public string MoreInfo
        {
            get; set;
        }

        public virtual ICollection<Courses> Courses
        {
            get
            {
                return this.courses;
            }

            set
            {
                this.courses = value;
            }
        }

        public virtual ICollection<Homeworks> Homeworks
        {
            get
            {
                return this.homeworks;
            }

            set
            {
                this.homeworks = value;
            }
        }
    }
}
