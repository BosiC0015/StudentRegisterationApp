using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Models
{
    public class ParttimeStudent : Student
    {
        // property
        public static int MaxNumOfCourses { get; set; }

        // constructor
        public ParttimeStudent(string name) : base(name) { }

        // method
        public override void RegisterCourses(List<Course> selectedCourses)
        {
            int totCourses = selectedCourses.Count();

            if (totCourses >  MaxNumOfCourses)
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
            return $"{Id} - {Name} (Part time)";
        }
    }
}