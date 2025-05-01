<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="RequestBooking.aspx.cs" Inherits="HappyPaws.User.RequestBooking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <section>
    <div class="container pt-50 pb-40">
        <div class="row">
                <div class="col-12 pb-20">
                    <asp:Label ID="lblMsg" runat="server" Visible ="false"></asp:Label>
                </div>
                <div class="col-12">
                    <h2 class="contact-title text-center">Request Booking</h2>
                </div>
                <div class="col-lg-6 mx-auto">
                    <div class="form-contact contact_form">
                        <div class="row">
                            <div class="col-12">
                                <h6></h6>
                            </div>
                            <div class="col-12">
                                <div class="form-group">
                                    <label>Pet Breed</label>
                                    <asp:TextBox ID="txtPetBreed" runat="server" CssClass="form-control" placeholder="Enter Pet Breed" required></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <label>No of Pet</label>
                                    <asp:TextBox ID="txtNoOfPet" runat="server" CssClass="form-control" placeholder="Enter Number of Pet" required></asp:TextBox>
                               </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <label>Pet Age</label>
                                    <asp:TextBox ID="txtAge" runat="server" CssClass="form-control" placeholder="Enter Pet Age" required></asp:TextBox>
                                     </div>
                            </div>
                            <div class="col-12">
                                <div class="form-group">
                                    <label>Pet Type</label>
                                    <asp:TextBox ID="txtPetType" runat="server" CssClass="form-control" placeholder="Enter Pet Type(Cat, Dog)" required></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-12">
                                <h6>More Information</h6>
                            </div>
                            <div class="col-12">
                                <div class="form-group">
                                    <label>Owner Name</label>
                                    <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" placeholder="Enter Owner Name" required></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Name must be in characters" ForeColor="Red" 
                                         Display="Dynamic" SetFocusOnError="true" Font-Size="Small" ValidationExpression="^[a-zA-Z\s]+$" ControlToValidate="txtFullName">
                                    </asp:RegularExpressionValidator>
                                </div>
                            </div>
                           
                               <div class="col-12">
                                   <div class="form-group">
                                       <label>Mobile Number</label>
                                       <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" placeholder="Enter Mobile Number" required></asp:TextBox>
                                       <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Mobile No. must have 11 digits" ForeColor="Red" 
                                           Display="Dynamic" SetFocusOnError="true" Font-Size="Small" ValidationExpression="^[0-9]{11}$" ControlToValidate="txtMobile">
                                       </asp:RegularExpressionValidator>
                                   </div>
                               </div>
                               <div class="col-12">
                                   <div class="form-group">
                                       <label>Location</label>
                                        <asp:DropDownList ID="Location" runat="server" DataSourceID="SqlDataSource1" CssClass="form-control w-100"
                                            AppendDataBoundItems="true" DataTextField="LocationName" DataValueField="LocationName">
                                             <asp:ListItem Value="0">Select Location</asp:ListItem>
                                        </asp:DropDownList>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Location is required"
                                             ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0" 
                                             ControlToValidate="Location"></asp:RequiredFieldValidator>
                                       <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cs %>" ProviderName="<%$ ConnectionStrings:cs.ProviderName %>" SelectCommand="SELECT [LocationName] FROM [Location]"></asp:SqlDataSource>
                                       
                                   </div>
                               </div>
                        </div>
                        <div class="form-group mt-3">
                            <asp:Button ID="btnRequestBooking" runat="server" Text="Request Booking" CssClass="button button-contactForm boxed-btn mr-4" OnClick="btnRequestBooking_Click"/>
                            
                        </div>
                        
                       </div>
                    </div>
                </div>
            </div>
 
</section>




</asp:Content>
