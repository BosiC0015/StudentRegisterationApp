using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Models
{
    public class FulltimeStudent : Student
    {
        // property
        public static int MaxWeeklyHours { get; set; }

        // constructor
        public FulltimeStudent(string name) : base(name) { }

        // method
        public override void RegisterCourses(List<Course> selectedCourses)
        {
            if (TotalWeeklyHours() > MaxWeeklyHours)
            {
                throw new Exception("You cannot exceed __ hours a week.");
            }
            else
            {
                base.RegisterCourses(selectedCourses);
            }
        }
        public override string ToString()
        {
            return $"{Id} - {Name} (Full time)";
        }
    }
}