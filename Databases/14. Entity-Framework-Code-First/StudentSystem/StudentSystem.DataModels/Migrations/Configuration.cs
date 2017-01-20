namespace StudentSystem.DataModels.Migrations
{
    using Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemDbContext>
    {
        public Configuration()
        {
            // Set to true only for the sake of the homework.
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(StudentSystemDbContext context)
        {
            GenerateCourses(context);
            context.SaveChanges();
            GenerateStudents(context);
            context.SaveChanges();
            GenerateHomeworks(context);
            context.SaveChanges();
        }

        private static void GenerateCourses(StudentSystemDbContext dbContext)
        {
            var names = new string[] { "Archaeology and Anthropology", "Biochemistry (Molecular and Cellular)", "Sciences", "Biomedical Sciences", "Chemistry", "Classical Archaeology and Ancient History", "Classics", "Classics and English", "Classics and Modern Languages", "Classics and Oriental Studies", "Computer Science", "Computer Science and Philosophy", "Earth Sciences (Geology)", "Economics and Management", "Engineering Science", "English Language and Literature", "English and Modern Languages", "European and Middle Eastern Languages", "Fine Art", "Geography", "History", "History (Ancient and Modern)", "History and Economics", "History and English", "History and Modern Languages", "History and Politics", "History of Art", "Law (Jurisprudence)", "Materials Science", "Mathematics", "Mathematics and Computer Science", "Mathematics and Philosophy", "Mathematics and Statistics", "Medicine", "Modern Languages", "Modern Languages and Linguistics", "Music", "Oriental Studies", "Philosophy and Modern Languages", "Philosophy, Politics and Economics (PPE)", "Philosophy and Theology", "Physics", "Physics and Philosophy", "Psychology (Experimental)", "Psychology, Philosophy and Linguistics", "Theology and Religion", "Theology and Oriental Studies" };
            var desciption = "As an Oxford undergraduate you’ll be part of one or more departments, depending on the course you’re studying. You’ll also be a member of a college – a community of students and academics from many different subject areas.";
            var material = "Material N55309";

            for (int i = 1; i < names.Length; i++)
            {
                var course = new Courses
                {
                    Name = names[i],
                    Desctiption = desciption,
                    Materials = new HashSet<string>() { material + i }
                };

                dbContext.Courses.Add(course);
            }

            Console.WriteLine("Courses are successfully added!");
        }

        private static void GenerateStudents(StudentSystemDbContext dbContext)
        {
            var firstNames = new string[] { "MichelineManuela", "Kimber", "Brock", "Britteny", "Spencer", "Melisa", "Gregory", "Ariana", "Alpha", "Daria", "Carroll", "Graham", "Isis", "Jacklyn", "Cindie", "Maud", "Mireya", "Chandra", "Ignacio" };
            var lastNames = new string[] { "SMITH", "JOHNSON", "WILLIAMS", "BROWN", "JONES", "MILLER", "DAVIS", "GARCIA", "RODRIGUEZ", "LEWIS", "ROBINSON", "WALKER", "PEREZ", "HALL", "YOUNG", "ALLEN", "SANCHEZ", "WRIGHT", "KING", "BAKER", "ADAMS" };
            var number = 100;
            var info = "Every student at Oxford is a member of a college. They are sometimes compared to halls of residence at other universities, but they are so much more besides. Your college will be your home for much of your time at Oxford, providing accommodation, meals, a library and IT support. The relatively small number of students at each college allows for close and supportive personal attention to be given to your induction, academic development and welfare";
            var allCourses = dbContext.Courses.ToArray();

            for (int i = 1; i < firstNames.Length; i++)
            {

                var student = new Students
                {
                    FirstName = firstNames[i],
                    LastName = lastNames[i],
                    Number = number + i,
                    MoreInfo = info,
                    Courses = new List<Courses>() { allCourses[i], allCourses[i + 1] }
                };

                dbContext.Students.Add(student);
            }

            Console.WriteLine("Students are successfully added!");
        }

        private static void GenerateHomeworks(StudentSystemDbContext dbContext)
        {
            var content = "Task.";
            var allStudentsIds = dbContext.Students.Select(s => s.Id).ToArray();
            var allCoursesIds = dbContext.Courses.Select(s => s.Id).ToArray();

            for (int i = 1, j = 10; i <= 5; i++, j--)
            {
                var homework = new Homeworks
                {
                    Content = content + i,
                    StudentId = allStudentsIds[j],
                    CourseId = allCoursesIds[j]
                };

                dbContext.Homeworks.Add(homework);
            }

            Console.WriteLine("Homeworks are successfully added!");
        }
    }
}
