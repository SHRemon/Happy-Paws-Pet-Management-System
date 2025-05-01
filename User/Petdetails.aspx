<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Petdetails.aspx.cs" Inherits="HappyPaws.User.Petdetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main>

        <!-- Hero Area Start-->
        <div class="slider-area ">
            <div class="single-slider section-overly slider-height2 d-flex align-items-center" data-background="../assets/img/hero/about.png">
                <div class="container">
                    <div class="row">
                        <div class="col-xl-12">
                            <div class="hero-cap text-center">
                                <h2>Pet Overview</h2>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Hero Area End -->

        <div>
            <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
        </div>

        <!-- pet post company Start -->
        <div class="job-post-company pt-120 pb-120">
            <div class="container col-xl-8 col-lg-8">
                <asp:DataList ID="DataList1" runat="server" OnItemCommand="DataList1_ItemCommand" OnItemDataBound="DataList1_ItemDataBound">

                    <ItemTemplate>

                        <div class="row ">
                            <!-- Left Content -->
                            <div class="col-xl-7 col-lg-7">
                                <!-- pet single -->
                                <div class="single-job-items mb-50">
                                    <div class="job-items">
                                        <div class="company-img company-img-details">
                                            <a href="#">
                                                <img width="80" src="<%# GetImageUrl(Eval("PetImage")) %>" alt=""></a>
                                        </div>
                                        <div class="job-tittle">
                                            <a href="#">
                                                <h4><%# Eval("PetBreed") %> </h4>
                                            </a>
                                            <ul>
                                                <li><%# Eval("Gender") %></li>
                                                <li><%# Eval("Age") %></li>
                                                <li><i class="fas fa-map-marker-alt"></i><%# Eval("Location") %></li>
                                                <li><%# Eval("Price") %></li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                                <!-- pet single End -->

                                <div class="job-post-details">
                                    <div class="post-details1 mb-50">
                                        <!-- Small Section Tittle -->
                                        <div class="small-section-tittle">
                                            <h4>Pet Description</h4>
                                        </div>
                                        <p><%# Eval("Description") %></p>
                                    </div>
                                </div>

                            </div>
                            <!-- Right Content -->
                            <div class="col-xl-5 col-lg-5">
                                <div class="post-details3  mb-50">
                                    <!-- Small Section Tittle -->
                                    <div class="small-section-tittle">
                                        <h4>Pet Overview</h4>
                                    </div>
                                    <ul>

                                        <li>Pet Type : <span><%# Eval("PetType") %></span></li>
                                        <li>Pet Breed : <span><%# Eval("PetBreed") %></span></li>
                                        <li>Available Pet : <span><%# Eval("NoOfPet") %></span></li>
                                        <li>Gender : <span><%# Eval("Gender") %></span></li>
                                        <li>Age : <span><%# Eval("Age") %></span></li>
                                        <li>Location : <span><%# Eval("Location") %></span></li>
                                        <li>Price :  <span><%# Eval("Price") %></span></li>
                                        <li>Posted date : <span><%# DataBinder.Eval(Container.DataItem, "CreateDate", "{0:dd MMMM yyyy}") %></span></li>

                                    </ul>
                                    <div class="apply-btn2">

                                        <asp:LinkButton ID="lbRequestPet" runat="server" CssClass="btn" Text="Request Pet" CommandName="RequestPet"></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </ItemTemplate>

                </asp:DataList>

            </div>
        </div>
        <!-- Pet post company End -->

    </main>

</asp:Content>
