using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HappyPaws.User
{
    public partial class RequestBooking : System.Web.UI.Page
    {

        SqlConnection con;
        SqlCommand cmd;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }
        }

        protected void btnRequestBooking_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime time = DateTime.Now;
                con = new SqlConnection(str);
                string query = @"Insert into Bookings(PetBreed,NoOfPet,Age,PetType,OwnerName,Mobile,Location,CreateDate) values 
                                (@PetBreed,@NoOfPet,@Age,@PetType,@OwnerName,@Mobile,@Location,@CreateDate)";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PetBreed", txtPetBreed.Text.Trim());
                cmd.Parameters.AddWithValue("@NoOfPet", txtNoOfPet.Text.Trim());
                cmd.Parameters.AddWithValue("@Age", txtAge.Text.Trim());
                cmd.Parameters.AddWithValue("@PetType", txtPetType.Text.Trim());
                cmd.Parameters.AddWithValue("@OwnerName", txtFullName.Text.Trim());
                cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text.Trim());               
                cmd.Parameters.AddWithValue("@Location", Location.SelectedValue);
                cmd.Parameters.AddWithValue("@CreateDate", time.ToString("yyyy-MM-dd HH:mm:ss"));
                con.Open();
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Booking Requested Successfully!";
                    lblMsg.CssClass = "alert alert-success";
                    clear();
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Booking Failed! Please try again.";
                    lblMsg.CssClass = "alert alert-danger";
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            finally
            {
                con.Close();
            }
        }

        private void clear()
        {
            txtPetBreed.Text = string.Empty;
            txtNoOfPet.Text = string.Empty;
            txtAge.Text = string.Empty;
            txtPetType.Text = string.Empty;
            txtFullName.Text = string.Empty;
            txtMobile.Text = string.Empty;  
            Location.ClearSelection();
        }
    }
}