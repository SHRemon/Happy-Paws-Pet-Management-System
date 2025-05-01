using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HappyPaws.Employee
{
    public partial class AddPet : System.Web.UI.Page
    {

        SqlConnection con;
        SqlCommand cmd;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        string query;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["employee"] == null)
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
                query = "Select * from AdoptPet where AdoptId = '" + Request.QueryString["id"] + "' ";
                cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        txtPetTitle.Text = sdr["PetBreed"].ToString();
                        txtNoOfPet.Text = sdr["NoOfPet"].ToString();
                        txtDescription.Text = sdr["Description"].ToString();
                        txtGender.Text = sdr["Gender"].ToString();
                        txtAge.Text = sdr["Age"].ToString();
                        txtPrice.Text = sdr["Price"].ToString();
                        PetType.SelectedValue = sdr["PetType"].ToString();
                        txtOwner.Text = sdr["OwnerName"].ToString();
                        Locationz.SelectedValue = sdr["Location"].ToString();
                        txtMobile.Text = sdr["Mobile"].ToString();
                        txtAddress.Text = sdr["Address"].ToString();
                        btnAdd.Text = "Update";
                        linkBack.Visible = true;
                    }
                }
                else
                {
                    lblMsg.Text = "Pet not found!";
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
                string type, concatQuery, imagePath = string.Empty;
                bool isValidToExecute = false;
                con = new SqlConnection(str);

                if (Request.QueryString["id"] != null)
                {
                    if (PetImage.HasFile)
                    {
                        if (IsValidExtension(PetImage.FileName))
                        {
                            concatQuery = "PetImage = @PetImage,";
                        }
                        else
                        {
                            concatQuery = string.Empty;
                        }
                    }
                    else
                    {
                        concatQuery = string.Empty;
                    }
                    query = @"Update AdoptPet set PetBreed=@PetBreed,NoOfPet=@NoOfPet,Description=@Description,Gender=@Gender,
                            Age=@Age,Price=@Price,PetType=@PetType,
                            OwnerName=@OwnerName," + concatQuery + @"Location=@Location,Mobile=@Mobile,
                            Address=@Address where AdoptId=@id";
                    type = "updated";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@PetBreed", txtPetTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@NoOfPet", txtNoOfPet.Text.Trim());
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@Gender", txtGender.Text.Trim());
                    cmd.Parameters.AddWithValue("@Age", txtAge.Text.Trim());
                    cmd.Parameters.AddWithValue("@Price", txtPrice.Text.Trim());
                    cmd.Parameters.AddWithValue("@PetType", PetType.SelectedValue);
                    cmd.Parameters.AddWithValue("@OwnerName", txtOwner.Text.Trim());
                    cmd.Parameters.AddWithValue("@Location", Locationz.SelectedValue);
                    cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@id", Request.QueryString["id"].ToString());
                    if (PetImage.HasFile)
                    {
                        if (IsValidExtension(PetImage.FileName))
                        {
                            Guid obj = Guid.NewGuid();
                            imagePath = "Images/" + obj.ToString() + PetImage.FileName;
                            PetImage.PostedFile.SaveAs(Server.MapPath("~/Images/") + obj.ToString() + PetImage.FileName);

                            cmd.Parameters.AddWithValue("@PetImage", imagePath);
                            isValidToExecute = true;
                        }
                        else
                        {
                            lblMsg.Text = "Please select .jpg, .jpeg, .png file for Logo";
                            lblMsg.CssClass = "alert alert-danger";
                        }
                    }
                    else
                    {
                        isValidToExecute = true;
                    }
                }


                else
                {
                    query = @"Insert into AdoptPet values(@PetBreed,@NoOfPet,@Description,@Gender,@Age,
                        @Price,@PetType,@OwnerName,@PetImage,@Location,@Mobile,@Address,@CreateDate)";
                    type = "saved";
                    DateTime time = DateTime.Now;
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@PetBreed", txtPetTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@NoOfPet", txtNoOfPet.Text.Trim());
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@Gender", txtGender.Text.Trim());
                    cmd.Parameters.AddWithValue("@Age", txtAge.Text.Trim());
                    cmd.Parameters.AddWithValue("@Price", txtPrice.Text.Trim());
                    cmd.Parameters.AddWithValue("@PetType", PetType.SelectedValue);
                    cmd.Parameters.AddWithValue("@OwnerName", txtOwner.Text.Trim());
                    cmd.Parameters.AddWithValue("@Location", Locationz.SelectedValue);
                    cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@CreateDate", time.ToString("yyyy-MM-dd HH:mm:ss"));
                    if (PetImage.HasFile)
                    {
                        if (IsValidExtension(PetImage.FileName))
                        {
                            Guid obj = Guid.NewGuid();
                            imagePath = "Images/" + obj.ToString() + PetImage.FileName;
                            PetImage.PostedFile.SaveAs(Server.MapPath("~/Images/") + obj.ToString() + PetImage.FileName);

                            cmd.Parameters.AddWithValue("@PetImage", imagePath);

                            isValidToExecute = true;
                        }
                        else
                        {
                            lblMsg.Text = "Please select .jpg, .jpeg, .png file for Image";
                            lblMsg.CssClass = "alert alert-danger";
                        }
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@PetImage", imagePath);
                        isValidToExecute = true;
                    }

                }

                if (isValidToExecute)
                {
                    con.Open();
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        lblMsg.Text = "Pet " + type + " successfully!";
                        lblMsg.CssClass = "alert alert-success";
                        clear();
                    }
                    else
                    {
                        lblMsg.Text = "Something Wrong! Please try Again.";
                        lblMsg.CssClass = "alert alert-danger";
                    }
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
            txtPetTitle.Text = string.Empty;
            txtNoOfPet.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtGender.Text = string.Empty;
            txtAge.Text = string.Empty;
            txtPrice.Text = string.Empty;
            PetType.ClearSelection();
            txtOwner.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtAddress.Text = string.Empty;
            Locationz.ClearSelection();
        }

        private bool IsValidExtension(string fileName)
        {
            bool isValid = false;
            string[] fileExtension = { ".jpg", ".png", ".jpeg" };
            for (int i = 0; i <= fileExtension.Length - 1; i++)
            {
                if (fileName.Contains(fileExtension[i]))
                {
                    isValid = true;
                    break;
                }
            }
            return isValid;
        }
    }
}