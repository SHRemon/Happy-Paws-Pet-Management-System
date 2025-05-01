using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HappyPaws.Employee
{
    public partial class EmployeeMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            if (Session["employee"] != null)
            {
                Session.Abandon();
                Response.Redirect("../User/Login.aspx");
            }
        }
    }
}