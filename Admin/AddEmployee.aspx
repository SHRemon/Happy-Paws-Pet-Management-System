<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="HappyPaws.Admin.AddEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div style="background-image: url('../Images/bg.jpg'); width: 100%; height: 720px; background-repeat: no-repeat; background-size: cover; background-attachment: fixed;">
    <div class="container pt-4 pb-4">
        
        <dviv class="btn-toolbar justify-content-between mb-3">
            <div class="btn-group">
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>

            

            <div class="input-group h-25">
                <asp:HyperLink ID="linkBack" runat="server" NavigateUrl="~/Admin/EmployeeList.aspx" CssClass="btn btn-secondary"
                    Visible = "false">< Back</asp:HyperLink>
            </div>
        </dviv>

        <div class="row mr-lg-5 ml-lg-5 mb-3">
            <div class="col-md-6 pt-3">
                <label for="txtUsername" style="font-weight: 600">Username</label>
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Enter Unique Username" required>
                </asp:TextBox>
            </div>
            <div class="col-md-6 pt-3">
                <label for="txtName" style="font-weight: 600">Full Name</label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Enter Full Name" required>
                </asp:TextBox>
            </div>
        </div>

        <div class="row mr-lg-5 ml-lg-5 mb-3">
            <div class="col-md-6 pt-3">
                <label for="txtPassword" style="font-weight: 600">Password</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Enter Password" TextMode="Password" required></asp:TextBox>
            </div>
            <div class="col-md-6 pt-3">
                <label for="txtConfirmPassword" style="font-weight: 600">Confirm Password</label>
                <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Enter Confirm Password" required></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password & Confirm Password should be same." ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small"></asp:CompareValidator>
            </div>
        </div>

        
        <div class="row mr-lg-5 ml-lg-5 mb-3">
            <div class="col-md-6 pt-3">
                <label for="txtLocation" style="font-weight: 600">Location</label>
                <asp:DropDownList ID="Locationz" runat="server" DataSourceID="SqlDataSource1" CssClass="form-control w-100"
                    AppendDataBoundItems="true" DataTextField="LocationName" DataValueField="LocationName">
                    <asp:ListItem Value="0">Select Location</asp:ListItem>
                </asp:DropDownList>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Location is required"
                    ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0"
                    ControlToValidate="Locationz"></asp:RequiredFieldValidator>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cs %>"
                    SelectCommand="SELECT [LocationName] FROM [Location]"></asp:SqlDataSource>
            </div>
            <div class="col-md-6 pt-3">
                <label for="Gender" style="font-weight: 600">Gender</label>
                <asp:DropDownList ID="Gender" runat="server" CssClass="form-control">
                    <asp:ListItem Value="0">Select Gender</asp:ListItem>
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Gender is required" ForeColor="Red"
                    ControlToValidate="Gender" InitialValue="0" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row mr-lg-5 ml-lg-5 mb-3">
            <div class="col-md-12 pt-3">
                <label for="txtAddress" style="font-weight: 600">Address</label>
                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Enter Address"
                    TextMode="MultiLine" required>
                </asp:TextBox>
            </div>
        </div>


        <div class="row mr-lg-5 ml-lg-5 mb-3">

            <div class="col-md-6 pt-3">
                <label for="txtEmail" style="font-weight: 600">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter Email" required
                    TextMode="Email"></asp:TextBox>
            </div>
       
            <div class="col-md-6 pt-3">
                <label for="txtMobile" style="font-weight: 600">Mobile Number</label>
                  <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" placeholder="Enter Mobile Number" required></asp:TextBox>
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Mobile No. must have 11 digits" ForeColor="Red" 
                      Display="Dynamic" SetFocusOnError="true" Font-Size="Small" ValidationExpression="^[0-9]{11}$" ControlToValidate="txtMobile">
                  </asp:RegularExpressionValidator>
            </div>
        </div>

       

        <div class="row mr-lg-5 ml-lg-5 mb-3 pt-4">
            <div class="col-md-3 col-md-offset-2 mb-3">
                <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary btn-block" BackColor="#7200cf" Text="Add Employee" Onclick="btnAdd_Click"/>
            </div>
        </div>

    </div>

</div>


</asp:Content>
