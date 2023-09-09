using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Models
{
    public class Student
    {
        // properties
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Course> RegisteredCourses { get; set; } = new List<Course>();


        // constructor
        public Student(string name)
        {
            Random random = new Random();
            Id = random.Next(100000, 999999);

            Name = name;
        }
        public virtual void RegisterCourses(List<Course> selectedCourses)
        {
            RegisteredCourses.Clear();

            foreach (Course course in selectedCourses)
            {
                RegisteredCourses.Add(course);
            }
        }

        // method
        public int TotalWeeklyHours()
        {
            int tot = 0;

            foreach (Course course in RegisteredCourses)
            {
                tot += course.WeeklyHours;
            }

            return tot;
        }
    }
}