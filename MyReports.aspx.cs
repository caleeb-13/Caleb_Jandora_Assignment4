using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4
{
    public partial class MyReports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          string UserID = HttpContext.Current.User.Identity.GetUserId();
            if (UserID != null) //basically, if there is a user show them the reports
            {
                ShowReports(); // call the method to show the reports
            }
            else
            {
                Response.Redirect("Login.aspx"); // if there is no user have them login 
            }
        }
        protected void ShowReports()
        {
            if (User.Identity.IsAuthenticated)
            {
                MyReportsPanel.Visible = true;
                string userID = HttpContext.Current.User.Identity.GetUserId(); //get the user id and assign it to the variable userID
                string query = "Select * from reports R inner join Projects P on P.ProjectID = R.ProjectID where VolunteerID = @UserID"; //query to get the reports
                DataTable dt = new DataTable();
                string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ToString(); // create connection string
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID); //add the userID to the query
                        cmd.ExecuteNonQuery();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd)) 
                        {
                            da.Fill(dt); // fill the table with the information
                        }
                    }
                }
                ReportsTable.DataSource = dt; // fill the tabke with the information
                ReportsTable.DataBind();

            }
            else
            {
                Response.Redirect("Login.aspx"); //again, if there is no user have them login
            }
            
        }
    }
}