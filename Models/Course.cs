using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Models
{
    public class Course
    {
        // properties
        public string Code { get; }
        public string Title { get; }
        public int WeeklyHours { get; set; }

        // constructor
        public Course(string code, string title)
        {
            Code = code;
            Title = title;
        }
    }
}