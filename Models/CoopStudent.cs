using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Models
{
    public class CoopStudent:Student
    {
        // properties
        public static int MaxWeeklyHours { get; set; }
        public static int MaxNumOfCourses { get; set; }

        // constructor
        public CoopStudent(string name):base(name) { }

        // methods
        public override void RegisterCourses(List<Course> selectedCourses)
        {
            int totCourses = selectedCourses.Count();

            if (TotalWeeklyHours() > MaxWeeklyHours)
            {
                throw new Exception("You cannot exceed __ hours a week.");
            }
            else if (totCourses > MaxNumOfCourses)
            {
                throw new Exception("You cannot exceed __ courses a week.");
            }
            else
            {
                base.RegisterCourses(selectedCourses);
            }
        }
        public override string ToString()
        {
            return $"{Id} - {Name} (Coop)";
        }
    }
}