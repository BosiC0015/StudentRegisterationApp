using Lab8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab8
{
    public partial class AddStudent : System.Web.UI.Page
    {
        private List<string> studentType = new List<string>()
        {
            "Full Time",
            "Part Time",
            "Coop"
        };

        private List<Student> students;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["students"] == null)
            {
                students = new List<Student>();
            }
            else
            {
                students = (List<Student>)Session["students"];
            }

            if (!IsPostBack)
            {
                foreach (string type in studentType)
                {
                    ddlStudentType.Items.Add(type);
                }
            }

            Display_Table();
        }

        protected void Add_New_Student(object sender, EventArgs e)
        {
            if (txtName.Text != "" && ddlStudentType.SelectedIndex != 0)
            {
                string name = txtName.Text;

                if (ddlStudentType.SelectedValue == "Full Time")
                {
                    Student newStudent = new FulltimeStudent(name);
                    students.Add(newStudent);
                }
                else if (ddlStudentType.SelectedValue == "Part Time")
                {
                    Student newStudent = new ParttimeStudent(name);
                    students.Add(newStudent);
                }
                else if (ddlStudentType.SelectedValue == "Coop")
                {
                    Student newStudent = new CoopStudent(name);
                    students.Add(newStudent);
                }

                Session["students"] = students;
                Display_Table();

                txtName.Text = "";
                ddlStudentType.SelectedIndex = 0;
            }
        }

        protected void Display_Table()
        {
            if (Session["students"] == null)
            {
                TableRow noStudent = new TableRow();

                TableCell noStudentCell = new TableCell();
                noStudentCell.Text = "No Student Yet!";
                noStudentCell.CssClass = "text-center text-danger";
                noStudentCell.ColumnSpan = 2;
                noStudent.Cells.Add(noStudentCell);

                tblStudents.Rows.Add(noStudent);
            }
            else
            {
                tblStudents.Rows.Clear();

                TableHeaderRow tblHead = new TableHeaderRow();
                tblHead.CssClass = "text-center";

                TableHeaderCell id = new TableHeaderCell();
                id.Text = "ID";
                tblHead.Cells.Add(id);

                TableHeaderCell name = new TableHeaderCell();
                name.Text = "Name";
                tblHead.Cells.Add(name);

                tblStudents.Rows.Add(tblHead);


                foreach (Student student in students)
                {
                    TableRow studentRow = new TableRow();

                    TableCell studentID = new TableCell();
                    studentID.Text = student.Id.ToString();
                    studentRow.Cells.Add(studentID);

                    TableCell studentName = new TableCell();
                    studentName.Text = student.Name;
                    studentRow.Cells.Add(studentName);

                    tblStudents.Rows.Add(studentRow);
                }
            }
        }
    }
}