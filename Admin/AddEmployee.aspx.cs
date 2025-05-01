using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HappyPaws.Admin
{
    public partial class AddEmployee : System.Web.UI.Page
    {

        SqlConnection con;
        SqlCommand cmd;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        string query;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }

            if (!IsPostBack)
            {
                fillData();
            }

        }

        private void fillData()
        {
            if (Request.QueryString["id"] != null)
            {
                con = new SqlConnection(str);
                query = "Select * from Employee where EmployeeID = '" + Request.QueryString["id"] + "' ";
                cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        txtUsername.Text = sdr["Username"].ToString();
                        txtName.Text = sdr["Name"].ToString();  
                        txtEmail.Text = sdr["Email"].ToString();
                        Gender.SelectedValue = sdr["Gender"].ToString();
                        Locationz.SelectedValue = sdr["Location"].ToString();
                        txtMobile.Text = sdr["Mobile"].ToString();
                        txtAddress.Text = sdr["Address"].ToString();
                        btnAdd.Text = "Update";
                        linkBack.Visible = true;
                    }
                }
                else
                {
                    lblMsg.Text = "Employee not found!";
                    lblMsg.CssClass = "alert alert-danger";
                }
                sdr.Close();
                con.Close();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string type;
               
                con = new SqlConnection(str);

                if (Request.QueryString["id"] != null)
                {
                    query = @"Update Employee set Username=@Username,Name=@Name,Gender=@Gender,Email=@Email,
                            Mobile=@Mobile,Location=@Location,Address=@Address where EmployeeID=@id";
                    type = "updated";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Gender", Gender.SelectedValue);
                    cmd.Parameters.AddWithValue("@@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text.Trim());
                    cmd.Parameters.AddWithValue("@Location", Locationz.SelectedValue);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@id", Request.QueryString["id"].ToString());
                }


                else
                {
                    query = @"Insert into Employee values(@Username,@Password,@Name,@Gender,@Email,
                            @Mobile,@Location, @Address,@CreateDate)";
                    type = "saved";
                    DateTime time = DateTime.Now;
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());                         
                    cmd.Parameters.AddWithValue("@Gender", Gender.SelectedValue);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text.Trim());
                    cmd.Parameters.AddWithValue("@Location", Locationz.SelectedValue);    
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@CreateDate", time.ToString("yyyy-MM-dd HH:mm:ss")); 

                }
                    con.Open();
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        lblMsg.Text = "Employee " + type + " successfully!";
                        lblMsg.CssClass = "alert alert-success";
                        clear();
                    }
                    else
                    {
                        lblMsg.Text = "Something Wrong! Please try Again.";
                        lblMsg.CssClass = "alert alert-danger";
                    }
                
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("Violation of UNIQUE KEY constraint"))
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "<b>" + "(" + txtUsername.Text.Trim() + ")" + "</b> username already exist, try new one.";
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

        private void clear()
        {
            txtUsername.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
            txtEmail.Text = string.Empty;
            Gender.ClearSelection();
            txtMobile.Text = string.Empty;
            txtAddress.Text = string.Empty;
            Locationz.ClearSelection();
        }
    }
}