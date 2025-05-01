using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HappyPaws.User
{
    public partial class Petdetails : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt, dt1;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                showPetDetails();
                
            }
            else
            {
                Response.Redirect("Adopt.aspx");
            }
        }

        private void showPetDetails()
        {
            con = new SqlConnection(str);
            string query = @"Select * from AdoptPet where AdoptId = @id";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            DataList1.DataSource = dt;
            DataList1.DataBind();
            
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "RequestPet")
            {
                if (Session["user"] != null)
                {
                    try
                    {
                        con = new SqlConnection(str);
                        string query = @"Insert into RequestPets values(@UserID, @AdoptId)";
                        cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@AdoptId", Request.QueryString["id"]);
                        cmd.Parameters.AddWithValue("@UserID", Session["userId"]);
                        con.Open();
                        int r = cmd.ExecuteNonQuery();
                        if (r > 0)
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Pet Requested successfully!";
                            lblMsg.CssClass = "alert alert-success";
                            showPetDetails();
                        }
                        else
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Cannot Request the Pet, please try again!";
                            lblMsg.CssClass = "alert alert-danger";
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<scipt>alert('" + ex.Message + "');</scipt>");
                    }
                    finally
                    {
                        con.Close();
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (Session["user"] != null)
            {
                LinkButton btnRequestPet = e.Item.FindControl("lbRequestPet") as LinkButton;
                if (isRequested())
                {
                    btnRequestPet.Enabled = false;
                    btnRequestPet.Text = "Requested";
                }
                else
                {
                    btnRequestPet.Enabled = true;
                    btnRequestPet.Text = "Request Adoption";
                }
            }
        }

        bool isRequested()
        {
            con = new SqlConnection(str);
            string query = @"Select * from RequestPets where UserID = @UserId and AdoptId = @AdoptId";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@UserID", Session["userId"]);
            cmd.Parameters.AddWithValue("@AdoptId", Request.QueryString["id"]);
            sda = new SqlDataAdapter(cmd);
            dt1 = new DataTable();
            sda.Fill(dt1);
            if (dt1.Rows.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected string GetImageUrl(Object url)
        {
            string url1 = "";
            if (string.IsNullOrEmpty(url.ToString()) || url == DBNull.Value)
            {
                url1 = "~/Images/No_image.png";
            }
            else
            {
                url1 = string.Format("~/{0}", url);
            }
            return ResolveUrl(url1);
        }
    }
}