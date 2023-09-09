using Lab8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Lab8
{
    public partial class RegisterCourses : System.Web.UI.Page
    {
        private List<Student> students = new List<Student>();
        private List<string> studentsList = new List<string>();
        private List<Course> courseList = Helper.GetAvailableCourses();
        private string errorMsg;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["students"] != null)
            {
                students = (List<Student>) Session["students"];

                foreach (Student student in students)
                {
                    studentsList.Add(student.ToString());
                }
            }

            if (!IsPostBack)
            {
                foreach (string student in studentsList)
                {
                    ddlStudents.Items.Add(student);
                }

                foreach (Course course in courseList)
                {
                    string courseInfo = $"{course.Title} - {course.WeeklyHours} hours/week";
                    cblCourselist.Items.Add(new ListItem(courseInfo, course.Code));
                }
            }
        }

        protected void Register_Courses(object sender, EventArgs e)
        {
            // clear
            errorMsg = string.Empty;
            lblError.Text = string.Empty;

            foreach (ListItem item in cblCourselist.Items)
            {
                item.Selected = false;
            }

            // pre-select
            if (ddlStudents.SelectedIndex != 0)
            {
                Student selectedStudent = students[ddlStudents.SelectedIndex - 1];
                lblRegistrationSummary.Text = $"Selected student has registered {selectedStudent.RegisteredCourses.Count()} course(s), {selectedStudent.TotalWeeklyHours()} hours weekly.";

                List<Course> selectedCourses = selectedStudent.RegisteredCourses;

                foreach (ListItem item in cblCourselist.Items)
                {
                    foreach (Course course in selectedCourses)
                    {
                        if (item.Value == course.Code)
                        {
                            item.Selected = true;
                        }
                    }
                }

            }
        }

        protected void Submit_Selection(object sender, EventArgs e)
        {
            if (!Validate_Input())
            {
                lblError.Text = errorMsg;
            }
            else
            {
                lblError.Text = string.Empty;
                Student selectedStudent = students[ddlStudents.SelectedIndex - 1];

                // get selected courses
                List<Course> newRegisterdCourses = new List<Course>();
                foreach (ListItem item in cblCourselist.Items)
                {
                    if (item.Selected)
                    {
                        Course c = Helper.GetCourseByCode(item.Value);
                        newRegisterdCourses.Add(c);
                    }
                }
                selectedStudent.RegisterCourses(newRegisterdCourses);

                Session["students"] = students;

                lblRegistrationSummary.Text = $"Selected student has registered {selectedStudent.RegisteredCourses.Count()} course(s), {selectedStudent.TotalWeeklyHours()} hours weekly.";
            }
        }

        protected bool Validate_Input()
        {
            // check the courses
            // get total weekly hours and course numbers
            int totHours = 0;
            int courseNum = 0;

            foreach (ListItem item in cblCourselist.Items)
            {
                if (item.Selected)
                {
                    int i = item.Text.IndexOf('-');
                    totHours += int.Parse(item.Text.Substring(i + 2, 1));
                    courseNum += 1;
                }
            }

            if (courseNum == 0)
            {
                errorMsg = "You need to select at least one course.";
            }

            // check by student type
            Student selectedStudent = students[ddlStudents.SelectedIndex - 1];
            int startInt = selectedStudent.ToString().IndexOf('(');
            int endInt = selectedStudent.ToString().IndexOf(')');
            int len = endInt - startInt - 1;
            string type = selectedStudent.ToString().Substring(startInt + 1, len);

            if (type == "Full time")
            {
                if (totHours > 16)
                {
                    errorMsg = "Your selection exceeds the maximum weekly hours: 16";
                    return false;
                }
            }
            else if (type == "Part time")
            {
                if (courseNum > 3)
                {
                    errorMsg = "Your selection exceeds the maximum number of courses: 3";
                    return false;
                }
            }
            else if (type == "Coop")
            {
                if (courseNum > 2)
                {
                    errorMsg = "Your selection exceeds the maximum number of courses: 2";
                    return false;
                }
                else if (totHours > 4)
                {
                    errorMsg = "Your selection exceeds the maximum weekly hours: 4";
                    return false;
                }
            }

            return true;
        }
    }
}