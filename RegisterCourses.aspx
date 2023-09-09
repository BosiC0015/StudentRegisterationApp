<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCourses.aspx.cs" Inherits="Lab8.RegisterCourses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Lab 8 - Register Course</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" />
</head>
<body>
    <div class="container col-md-8 offset-2">
        <form id="form1" runat="server">
            <h1 class="h1">Registrations</h1>
            <div>
                <asp:DropDownList ID="ddlStudents" runat="server" CssClass="form-select mb-3" OnSelectedIndexChanged="Register_Courses" AutoPostBack="true">
                    <asp:ListItem Value="">Select...</asp:ListItem>
                </asp:DropDownList>
            </div>
            <asp:Label ID="lblRegistrationSummary" runat="server" CssClass="text-info h4" Text=""></asp:Label>
            <div class="mb-6">
                <label for="cblCourseList" class="h4 mb-3">Following courses are currently available for registration.</label>
                <div>
                    <asp:Label ID="lblError" runat="server" Text="" CssClass="text-danger h4"></asp:Label>
                </div>
                <asp:CheckBoxList ID="cblCourselist" runat="server" CssClass="mb-3"></asp:CheckBoxList>
                <asp:Button ID="save" runat="server" Text="Save" OnClick="Submit_Selection" CssClass="btn btn-primary mb-3" />
            </div>
            <a href="AddStudent.aspx">Add Student</a>
        </form>
    </div>
</body>
</html>
