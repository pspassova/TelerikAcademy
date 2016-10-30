using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Data.Models
{
    public class Courses
    {
        private ICollection<string> materials;
        private ICollection<Students> students;
        private ICollection<Homeworks> homeworks;

        public Courses()
        {
            this.materials = new HashSet<string>();
            this.students = new HashSet<Students>();
            this.homeworks = new HashSet<Homeworks>();
        }

        public int Id
        {
            get; set;
        }

        [Required]
        [MaxLength(200)]
        public string Name
        {
            get; set;
        }

        [MaxLength(3000)]
        public string Desctiption
        {
            get; set;
        }

        public ICollection<string> Materials
        {
            get
            {
                return this.materials;
            }

            set
            {
                this.materials = value;
            }
        }

        public virtual ICollection<Students> Students
        {
            get
            {
                return this.students;
            }

            set
            {
                this.students = value;
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