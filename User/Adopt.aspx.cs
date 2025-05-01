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
    public partial class Adopt : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        public int jobCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showPetList();
                RBSelectedColorChange();
            }
        }

        private void showPetList()
        {
            if (dt == null)
            {
                con = new SqlConnection(str);
                string query = @"Select AdoptId,PetBreed,Price,PetType,Gender,Age,PetImage,Location,CreateDate from AdoptPet";
                cmd = new SqlCommand(query, con);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
            }
            DataList1.DataSource = dt;
            DataList1.DataBind();
            lblpetCount.Text = PetCount(dt.Rows.Count);
        }

        string PetCount(int count)
        {
            if (count > 1)
            {
                return "Total <b>" + count + "</b> Pets found";
            }
            else if (count == 1)
            {
                return "Total <b>" + count + "</b> Pet found";
            }
            else
            {
                return "No Pet found";
            }
        }

        protected void Location_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Location.SelectedValue != "0")
            {
                con = new SqlConnection(str);
                string query = @"Select AdoptId,PetBreed,Price,PetType,Gender,Age,PetImage,Location,CreateDate from AdoptPet 
                    where Location ='" + Location.SelectedValue + "' ";
                cmd = new SqlCommand(query, con);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                showPetList();
                RBSelectedColorChange();
            }
            else
            {
                showPetList();
                RBSelectedColorChange();
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

        public static string RelativeDate(DateTime theDate)
        {
            Dictionary<long, string> thresholds = new Dictionary<long, string>();
            int minute = 60;
            int hour = 60 * minute;
            int day = 24 * hour;
            thresholds.Add(60, "{0} seconds ago");
            thresholds.Add(minute * 2, "a minute ago");
            thresholds.Add(45 * minute, "{0} minutes ago");
            thresholds.Add(120 * minute, "an hour ago");
            thresholds.Add(day, "{0} hours ago");
            thresholds.Add(day * 2, "yesterday");
            thresholds.Add(day * 30, "{0} days ago");
            thresholds.Add(day * 365, "{0} months ago");
            thresholds.Add(long.MaxValue, "{0} years ago");
            long since = (DateTime.Now.Ticks - theDate.Ticks) / 10000000;
            foreach (long threshold in thresholds.Keys)
            {
                if (since < threshold)
                {
                    TimeSpan t = new TimeSpan((DateTime.Now.Ticks - theDate.Ticks));
                    return string.Format(thresholds[threshold], (t.Days > 365 ? t.Days / 365 : (t.Days > 0 ? t.Days : (t.Hours > 0 ? t.Hours : (t.Minutes > 0 ? t.Minutes : (t.Seconds > 0 ? t.Seconds : 0))))).ToString());
                }
            }
            return "";
        }

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string petType = string.Empty;
            petType = selectedCheckBox();
            if (petType != "")
            {
                con = new SqlConnection(str);
                string query = @"Select AdoptId,PetBreed,Price,PetType,Gender,Age,PetImage,Location,CreateDate from AdoptPet 
                    where PetType IN (" + petType + ")";
                cmd = new SqlCommand(query, con);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                showPetList();
                RBSelectedColorChange();
            }
            else
            {
                showPetList();
            }
        }
        string selectedCheckBox()
        {
            string petType = string.Empty;
            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected)
                {
                    petType += "'" + CheckBoxList1.Items[i].Text + "',"; //Full Time,Remote
                }
            }
            return petType = petType.TrimEnd(',');
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue != "0")
            {
                string postedDate = string.Empty;
                postedDate = selectedRadioButton();
                con = new SqlConnection(str);
                string query = @"Select AdoptId,PetBreed,Price,PetType,Gender,Age,PetImage,Location,CreateDate from AdoptPet 
                    where Convert(DATE,CreateDate) " + postedDate + " ";
                cmd = new SqlCommand(query, con);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                showPetList();
                RBSelectedColorChange();
            }
            else
            {
                showPetList();
                RBSelectedColorChange();
            }

        }

        string selectedRadioButton()
        {
            string postedDate = string.Empty;
            DateTime date = DateTime.Today;
            if (RadioButtonList1.SelectedValue == "1")
            {
                postedDate = "= Convert(DATE,'" + date.ToString("yyyy/MM/dd") + "') ";
            }
            else if (RadioButtonList1.SelectedValue == "2")
            {
                postedDate = " between Convert(DATE,'" + DateTime.Now.AddDays(-2).ToString("yyyy/MM/dd") + "') and Convert(DATE,'" + date.ToString("yyyy/MM/dd") + "') ";
            }
            else if (RadioButtonList1.SelectedValue == "3")
            {
                postedDate = " between Convert(DATE,'" + DateTime.Now.AddDays(-3).ToString("yyyy/MM/dd") + "') and Convert(DATE,'" + date.ToString("yyyy/MM/dd") + "') ";
            }
            else if (RadioButtonList1.SelectedValue == "4")
            {
                postedDate = " between Convert(DATE,'" + DateTime.Now.AddDays(-5).ToString("yyyy/MM/dd") + "') and Convert(DATE,'" + date.ToString("yyyy/MM/dd") + "') ";
            }
            else
            {
                postedDate = " between Convert(DATE,'" + DateTime.Now.AddDays(-10).ToString("yyyy/MM/dd") + "') and Convert(DATE,'" + date.ToString("yyyy/MM/dd") + "') ";
            }
            return postedDate;
        }

        protected void lbFilter_Click(object sender, EventArgs e)
        {
            try
            {
                bool isCondition = false;
                string subquery = string.Empty;
                string petType = string.Empty;
                string postedDate = string.Empty;
                string addAnd = string.Empty;
                string query = string.Empty;
                List<string> queryList = new List<string>();
                con = new SqlConnection(str);

                if (Location.SelectedValue != "0")
                {
                    queryList.Add(" Location ='" + Location.SelectedValue + "' ");
                    isCondition = true;
                }

                petType = selectedCheckBox();

                if (petType != "")
                {
                    queryList.Add(" PetType IN (" + petType + ")");
                    isCondition = true;
                }
                if (RadioButtonList1.SelectedValue != "0")
                {
                    postedDate = selectedRadioButton();
                    queryList.Add(" Convert(DATE, CreateDate) " + postedDate);
                    isCondition = true;
                }
                if (isCondition)
                {
                    foreach (string a in queryList)
                    {
                        subquery += a + " and "; // Location = 'Dhaka' and PetType IN (Dog, Cat) and
                    }
                    subquery = subquery.Remove(subquery.LastIndexOf("and"), 3);
                    query = @"Select AdoptId,PetBreed,Price,PetType,Gender,Age,PetImage,Location,CreateDate from AdoptPet where " + subquery + " ";
                }
                else
                {
                    query = @"Select AdoptId,PetBreed,Price,PetType,Gender,Age,PetImage,Location,CreateDate from AdoptPet";
                }
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                dt = new DataTable();
                sda.Fill(dt);
                showPetList();
                RBSelectedColorChange();
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


        protected void lbReset_Click(object sender, EventArgs e)
        {
            Location.ClearSelection();
            CheckBoxList1.ClearSelection();
            RadioButtonList1.SelectedValue = "0";
            RBSelectedColorChange();
            showPetList();
        }
        void RBSelectedColorChange()
        {
            if (RadioButtonList1.SelectedItem.Selected == true)
            {
                RadioButtonList1.SelectedItem.Attributes.Add("class", "selectedradio");
            }
        }


    }
}