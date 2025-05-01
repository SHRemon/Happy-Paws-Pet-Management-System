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
    public partial class EditProfile : System.Web.UI.Page
    {


        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader sdr;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        string query;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    showUserInfo();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        private void showUserInfo()
        {
            try
            {
                con = new SqlConnection(str);
                string query = "Select *  from [User] where UserId=@userId";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userId", Request.QueryString["id"]);
                con.Open();
                sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    if (sdr.Read())
                    {
                        txtUserName.Text = sdr["Username"].ToString();
                        txtFullName.Text = sdr["Name"].ToString();
                        txtEmail.Text = sdr["Email"].ToString();
                        txtMobile.Text = sdr["Mobile"].ToString();
                        txtAddress.Text = sdr["Address"].ToString();
                        Location.SelectedValue = sdr["Location"].ToString();
                    }
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "User not found!";
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    string concatQuery = string.Empty;
                    string filePath = string.Empty;
                    con = new SqlConnection(str);

                    query = @"Update [User] set Username=@Username,Name=@Name,Email=@Email,Mobile=@Mobile,Address=@Address,Location=@Location where UserId=@UserId";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Username", txtUserName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Name", txtFullName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@Location", Location.SelectedValue);
                    cmd.Parameters.AddWithValue("@UserId", Request.QueryString["id"]);

                    con.Open();
                    int r = cmd.ExecuteNonQuery();
                    if (r > 0)
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Profile details updated successfully!";
                        lblMsg.CssClass = "alert alert-success";
                    }
                    else
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Cannot update the records, please try after sometime..!";
                        lblMsg.CssClass = "alert alert-danger";
                    }

                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Couldn't Update! please try Again!";
                    lblMsg.CssClass = "alert alert-danger";
                }
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("Violation of UNIQUE KEY constraint"))
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "<b>" + txtUserName.Text.Trim() + "</b> username already exist, try new one..!";
                    lblMsg.CssClass = "alert alert-danger";
                }
                else
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
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
    }
}