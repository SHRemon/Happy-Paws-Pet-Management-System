using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HappyPaws.Admin
{
    public partial class EmployeeList : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        DataTable dt;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }

            if (!IsPostBack)
            {
                ShowEmployee();
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowEmployee();

        }

        private void ShowEmployee()
        {
            string query = string.Empty;
            con = new SqlConnection(str);
            query = @"Select Row_Number() over(Order by (Select 1)) as [Sr.No], EmployeeID, Username, Name, Gender, Email,
                   Mobile,Location,Address, CreateDate from Employee";
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
            ShowEmployee();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex]; //Which index is selected.
                int EmployeeId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                con = new SqlConnection(str);
                cmd = new SqlCommand("Delete from Employee where EmployeeID = @id", con);
                cmd.Parameters.AddWithValue("@id", EmployeeId);
                con.Open();
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    lblMsg.Text = "Employee Details deleted successfully!";
                    lblMsg.CssClass = "alert alert-success";
                }
                else
                {
                    lblMsg.Text = "Cannot delete this record!";
                    lblMsg.CssClass = "alert alert-danger";
                }
                GridView1.EditIndex = -1;
                ShowEmployee();
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditEmployee")
            {
                Response.Redirect("AddEmployee.aspx?id=" + e.CommandArgument.ToString());
            }
        }
    }
}