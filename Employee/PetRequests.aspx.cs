using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HappyPaws.Employee
{
    public partial class PetRequests : System.Web.UI.Page
    {

        SqlConnection con;
        SqlCommand cmd;
        DataTable dt;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["employee"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }

            if (!IsPostBack)
            {
                ShowRequestedPets();
            }
        }

        private void ShowRequestedPets()
        {
            string query = string.Empty;
            con = new SqlConnection(str);
            query = @"Select Row_Number() over(Order by (Select 1)) as [Sr.No],rp.RequestPetID,a.OwnerName,a.Gender,a.PetBreed,rp.AdoptId,a.Location,u.Mobile,
                            u.Name,u.Email from RequestPets rp
                            inner join [User] u on rp.UserID = u.UserId
                            inner join AdoptPet a on rp.AdoptId = a.AdoptId";
            cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowRequestedPets();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int RequestPetID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                con = new SqlConnection(str);
                cmd = new SqlCommand("Delete from RequestPets where RequestPetID = @id", con);
                cmd.Parameters.AddWithValue("@id", RequestPetID);
                con.Open();
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    lblMsg.Text = "Requested Pet deleted successfully!";
                    lblMsg.CssClass = "alert alert-success";
                }
                else
                {
                    lblMsg.Text = "Cannot delete this record!";
                    lblMsg.CssClass = "alert alert-danger";
                }
                GridView1.EditIndex = -1;
                ShowRequestedPets();
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

    }
}