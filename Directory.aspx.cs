using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.EnterpriseServices;
//this is my extra functionality. I wanted to provide users with the ability to see volunteer's name and id that way users can see who is associated with each ID
// i considered making it a contact info page, but felt it was probably not the best idea to have people's personal names, phone #'s and email addresses publicly available online
namespace Assignment4
{
    public partial class Directory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) //load the page
        {
            if (!IsPostBack) // only run for initial request
            {
                GetVolunteerData(); 
            }
        }

        private void GetVolunteerData() //method to get volunteers data from the database
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ToString();
            using (SqlConnection conn = new SqlConnection(connectionString)) // use the connection string we just created
            {
                using (SqlCommand cmd = new SqlCommand("spGetAllVolunteers", conn)) // execute the stored procedure
                {
                    cmd.CommandType = CommandType.StoredProcedure; //say what kind of commandtype we are using
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    conn.Open();
                    da.Fill(dt); // put the data from the stored procedure into the data table
                    conn.Close();

                    GridViewVolunteers.DataSource = dt;
                    GridViewVolunteers.DataBind(); //bind the data to the gridview
                }
            }
        }
    }
}