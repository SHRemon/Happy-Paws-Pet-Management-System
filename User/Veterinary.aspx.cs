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
    public partial class Veterinary : System.Web.UI.Page
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

        protected void btnRequestVet_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime time = DateTime.Now;
                con = new SqlConnection(str);
                string query = @"Insert into VetAppointment(PetBreed,NoOfPet,Age,Description,Location,OwnerName,Mobile,CreateDate) values 
                                (@PetBreed,@NoOfPet,@Age,@Description,@Location,@OwnerName,@Mobile,@CreateDate)";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PetBreed", txtPetBreed.Text.Trim());
                cmd.Parameters.AddWithValue("@NoOfPet", txtNoOfPet.Text.Trim());
                cmd.Parameters.AddWithValue("@Age", txtAge.Text.Trim());
                cmd.Parameters.AddWithValue("@Description", txtReason.Text.Trim());
                cmd.Parameters.AddWithValue("@Location", Location.SelectedValue);
                cmd.Parameters.AddWithValue("@OwnerName", txtFullName.Text.Trim());
                cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text.Trim());             
                cmd.Parameters.AddWithValue("@CreateDate", time.ToString("yyyy-MM-dd HH:mm:ss"));
                con.Open();
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Veterinary Requested Successfully!";
                    lblMsg.CssClass = "alert alert-success";
                    clear();
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Request Failed! Please try again.";
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
            txtReason.Text = string.Empty;
            txtFullName.Text = string.Empty;
            txtMobile.Text = string.Empty;
            Location.ClearSelection();
        }
    }
}