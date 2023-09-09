<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="Lab8.AddStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Lab 8 - Add Student</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" />
</head>
<body>
    <div class="container col-md-8 offset-2">
        <h1 class="h1">Students</h1>
        <form id="form1" runat="server">
            <div class="form-group row mb-3 align-items-center">
                <label for="txtName" class="col-md-3 col-form-label">Student Name:</label>
                <div class="col-md-5">
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator 
                    ID="rfvName" 
                    ControlToValidate="txtName" 
                    runat="server" 
                    CssClass="col-md-3 text-danger" 
                    Display="Dynamic" 
                    EnableClientScript="true"
                >Name Required!</asp:RequiredFieldValidator>
            </div>
            <div class="form-group row mb-3x">
                <label for="ddlStudentType" class="col-md-3 col-form-label">Student Type:</label>
                <div class="col-md-5">
                    <asp:DropDownList ID="ddlStudentType" runat="server" CssClass="form-select mb-3">
                        <asp:ListItem Value="">Select...</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <asp:RequiredFieldValidator 
                    ID="rfvStudentType" 
                    ControlToValidate="ddlStudentType"
                    runat="server" 
                    CssClass="col-md-3 text-danger" 
                    Display="Dynamic" 
                    EnableClientScript="true"
                >Must Select One!</asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="Add_New_Student" />
            </div>
        </form>
        <asp:Table ID="tblStudents" runat="server" CssClass="table table-striped table-hover">
            <asp:TableHeaderRow CssClass="text-center">
                <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                <asp:TableHeaderCell>Name</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>

        <a href="RegisterCourses.aspx">Resgister Courses</a>
    </div>
</body>
</html>
