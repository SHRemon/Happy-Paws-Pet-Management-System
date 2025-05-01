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
    public partial class Dashboard : System.Web.UI.Page
    {
        SqlConnection con;
        SqlDataAdapter sda;
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
                Users();
                Pets();
                RequestedPets();
                ContactCount();
                Bookingz();
                VetAppointmentz();
            }

        }

        private void VetAppointmentz()
        {
            con = new SqlConnection(str);
            sda = new SqlDataAdapter("Select Count(*) from VetAppointment", con);
            dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["VetAppointment"] = dt.Rows[0][0];
            }
            else
            {
                Session["VetAppointment"] = 0;
            }
        }

        private void Users()
        {
            con = new SqlConnection(str);
            sda = new SqlDataAdapter("Select Count(*) from [User]", con);
            dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["Users"] = dt.Rows[0][0];
            }
            else
            {
                Session["Users"] = 0;
            }
        }

        private void Pets()
        {
            con = new SqlConnection(str);
            sda = new SqlDataAdapter("Select Count(*) from AdoptPet", con);
            dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["Pets"] = dt.Rows[0][0];
            }
            else
            {
                Session["Pets"] = 0;
            }
        }

        private void RequestedPets()
        {
            con = new SqlConnection(str);
            sda = new SqlDataAdapter("Select Count(*) from RequestPets", con);
            dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["RequestPets"] = dt.Rows[0][0];
            }
            else
            {
                Session["RequestPets"] = 0;
            }
        }

        private void ContactCount()
        {
            con = new SqlConnection(str);
            sda = new SqlDataAdapter("Select Count(*) from Bookings", con);
            dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["Bookings"] = dt.Rows[0][0];
            }
            else
            {
                Session["Bookings"] = 0;
            }
        }

        private void Bookingz()
        {
            con = new SqlConnection(str);
            sda = new SqlDataAdapter("Select Count(*) from Contact", con);
            dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["Contact"] = dt.Rows[0][0];
            }
            else
            {
                Session["Contact"] = 0;
            }
        }
    }
}