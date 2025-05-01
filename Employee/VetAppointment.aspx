<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/EmployeeMaster.Master" AutoEventWireup="true" CodeBehind="VetAppointment.aspx.cs" Inherits="HappyPaws.Employee.VetAppointment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div style="background-image: url('../Images/bg.jpg'); width: 100%; height: 720px; background-repeat: no-repeat; background-size: cover; background-attachment: fixed;">
     <div class="container-fluid pt-4 pb-4">
         <div>
             <asp:Label ID="lblMsg" runat="server"></asp:Label>
         </div>

         <h3 class="text-center">Vet Appointment List</h3>

         <div class="row mb-3 pt-sm-3">
             <div class="col-md-12">
                 <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered" HeaderStyle-HorizontalAlign="Center"
                     EmptyDataText="No record to display..!" AutoGenerateColumns="False" AllowPaging="True" PageSize="5"
                     OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="AppointmentID" OnRowDeleting="GridView1_RowDeleting">
                     <Columns>

                         <asp:BoundField DataField="Sr.No" HeaderText="Sr.No">
                             <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>

                         <asp:BoundField DataField="PetBreed" HeaderText="Pet Breed">
                             <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>

                         <asp:BoundField DataField="NoOfPet" HeaderText="No Of Pet">
                             <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>

                         <asp:BoundField DataField="Age" HeaderText="Age">
                             <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>

                         <asp:BoundField DataField="Description" HeaderText="Reason for Visit">
                             <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>

                         <asp:BoundField DataField="Location" HeaderText="Location">
                             <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>

                         <asp:BoundField DataField="OwnerName" HeaderText="Owner Name">
                             <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>

                         <asp:BoundField DataField="Mobile" HeaderText="Mobile">
                             <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>                           

                         <asp:BoundField DataField="CreateDate" HeaderText="Requested Date" DataFormatString="{0:dd MMMM yyyy}">
                             <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>

                         <asp:CommandField CausesValidation="false" HeaderText="Delete" ShowDeleteButton="true"
                             DeleteImageUrl="../assets/img/icon/delete.png" ButtonType="Image">
                             <ControlStyle Height="25px" Width="25px" />
                             <ItemStyle HorizontalAlign="Center" />
                         </asp:CommandField>

                     </Columns>
                     <HeaderStyle BackColor="#7200cf" ForeColor="White" />
                 </asp:GridView>
             </div>
         </div>

     </div>
 </div>




</asp:Content>
