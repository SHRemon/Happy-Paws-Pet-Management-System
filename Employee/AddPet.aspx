<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/EmployeeMaster.Master" AutoEventWireup="true" CodeBehind="AddPet.aspx.cs" Inherits="HappyPaws.Employee.AddPet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
     <div style="background-image: url('../Images/bg.jpg'); width: 100%; height: 720px; background-repeat: no-repeat; background-size: cover; background-attachment: fixed;">
     <div class="container pt-4 pb-4">
         
         <div class="btn-toolbar justify-content-between mb-3">
             <div class="btn-group">
                 <asp:Label ID="lblMsg" runat="server"></asp:Label>
             </div>

             <h3 class="text-center">Add New Pet</h3>

             <div class="input-group h-25">
                 <asp:HyperLink ID="linkBack" runat="server" NavigateUrl="~/Admin/PetList.aspx" CssClass="btn btn-secondary"
                     Visible = "false">< Back</asp:HyperLink>
             </div>
         </div>

         <div class="row mr-lg-5 ml-lg-5 mb-3">
             <div class="col-md-6 pt-3">
                 <label for="txtPetTitle" style="font-weight: 600">Pet Breed</label>
                 <asp:TextBox ID="txtPetTitle" runat="server" CssClass="form-control" placeholder="Persian, German Shepherd.." required>
                 </asp:TextBox>
             </div>
             <div class="col-md-6 pt-3">
                 <label for="txtNoOfPet" style="font-weight: 600">Number Of Pet</label>
                 <asp:TextBox ID="txtNoOfPet" runat="server" CssClass="form-control" placeholder="Enter Number Of Pet"
                     TextMode="Number" required>
                 </asp:TextBox>
             </div>
         </div>

         <div class="row mr-lg-5 ml-lg-5 mb-3">
             <div class="col-md-12 pt-3">
                 <label for="txtDescription" style="font-weight: 600">Description</label>
                 <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" placeholder="Enter Pet Description"
                     TextMode="MultiLine" required>
                 </asp:TextBox>
             </div>
         </div>

            <div class="row mr-lg-5 ml-lg-5 mb-3">
                 <div class="col-md-6 pt-3">
                     <label for="txtGender" style="font-weight: 600">Gender</label>
                     <asp:TextBox ID="txtGender" runat="server" CssClass="form-control" placeholder="Enter Gender" required>
                     </asp:TextBox>
                 </div>

                 <div class="col-md-6 pt-3">
                     <label for="txtAge" style="font-weight: 600">Age</label>
                     <asp:TextBox ID="txtAge" runat="server" CssClass="form-control" placeholder="Enter Age" required>
                     </asp:TextBox>
                 </div>
             </div>
 

         <div class="row mr-lg-5 ml-lg-5 mb-3">
             <div class="col-md-6 pt-3">
                 <label for="txtPrice" style="font-weight: 600">Price</label>
                 <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" placeholder="500, 700." required>
                 </asp:TextBox>
             </div>
             <div class="col-md-6 pt-3">
                 <label for="PetType" style="font-weight: 600">Pet Type</label>
                 <asp:DropDownList ID="PetType" runat="server" CssClass="form-control">
                     <asp:ListItem Value="0">Select Pet Type</asp:ListItem>
                     <asp:ListItem>Cat</asp:ListItem>
                     <asp:ListItem>Dog</asp:ListItem>
                 </asp:DropDownList>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="PetType is required" ForeColor="Red"
                     ControlToValidate="PetType" InitialValue="0" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
             </div>
         </div>

         <div class="row mr-lg-5 ml-lg-5 mb-3">
             <div class="col-md-6 pt-3">
                 <label for="txtOwner" style="font-weight: 600">Owner Name</label>
                 <asp:TextBox ID="txtOwner" runat="server" CssClass="form-control" placeholder="Enter Owner Name" required>
                 </asp:TextBox>
             </div>
             <div class="col-md-6 pt-3">
                 <label for="PetType" style="font-weight: 600">Pet Image</label>
                 <asp:FileUpload ID="PetImage" runat="server" CssClass="form-control" ToolTip=".jpg, .jpeg, .png extension only" />
             </div>
         </div>

         <div class="row mr-lg-5 ml-lg-5 mb-3">
              <div class="col-md-6 pt-3">
                 <label for="txtLocation" style="font-weight: 600">Location</label>
                 <asp:DropDownList ID="Locationz" runat="server" DataSourceID="SqlDataSource1" CssClass="form-control w-100"
                     AppendDataBoundItems="true" DataTextField="LocationName" DataValueField="LocationName">
                     <asp:ListItem Value="0">Select Location</asp:ListItem>
                 </asp:DropDownList>

                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Location is required"
                     ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0"
                     ControlToValidate="Locationz"></asp:RequiredFieldValidator>
                 <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cs %>"
                     SelectCommand="SELECT [LocationName] FROM [Location]"></asp:SqlDataSource>
             </div>

             <div class="col-md-6 pt-3">
                 <label for="txtMobile" style="font-weight: 600">Mobile Number</label>
                   <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" placeholder="Enter Mobile Number" required></asp:TextBox>
                   <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Mobile No. must have 11 digits" ForeColor="Red" 
                       Display="Dynamic" SetFocusOnError="true" Font-Size="Small" ValidationExpression="^[0-9]{11}$" ControlToValidate="txtMobile">
                   </asp:RegularExpressionValidator>
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

         <div class="row mr-lg-5 ml-lg-5 mb-3 pt-4">
             <div class="col-md-3 col-md-offset-2 mb-3">
                 <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary btn-block" BackColor="#7200cf" Text="Add Pet" Onclick="btnAdd_Click"/>
             </div>
         </div>

     </div>

 </div>

</asp:Content>
