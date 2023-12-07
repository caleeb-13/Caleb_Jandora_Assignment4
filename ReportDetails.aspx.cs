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
    public partial class ReportDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ReportID = Request.QueryString["ID"]; //pass the id through 
            if (ReportID != null)
            {
                Session["ReportID"] = ReportID; //set the session variable to the id
            }
            else
            {
                CreateReport(); //create a new report
            }
            ShowObservation(); //show the observations for that report
        }
        protected void ShowObservation()
        {
            if (User.Identity.IsAuthenticated)
            {
                DataTable dt = new DataTable();
                string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ToString(); //connect to my database
                string ReportID = Session["ReportID"] as string; //get the session variable, assign it to reportID
                string query = "SELECT * FROM Observations WHERE ReportID = @ReportID"; //query the database for the observations with that reportID
                 
                using (SqlConnection conn = new SqlConnection()) // 
                {
                    conn.ConnectionString = connString; // set the connection string
                    conn.Open(); 
                    using (SqlCommand cmd = new SqlCommand(query, conn)) // create a new sql command
                    {
                        cmd.Parameters.AddWithValue("@ReportID", ReportID); // add the reportID as a parameter
                        cmd.ExecuteNonQuery(); 
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd)) // create a new data adapter
                        {
                            da.Fill(dt);
                        }
                    }
                }
                ObservationTable.DataSource = dt; //set the datasource of the table to the datatable
                ObservationTable.DataBind(); // bind the data to the table
                ObservationTablePanel.Visible = true; //show the table
            }
            else
            {
                 
                Response.Redirect("Login.aspx"); // if the user is not logged in, redirect them to the login page
            }
        }
        private void CreateReport() // create a new report
        {
            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ToString(); // connect to the database
            string userID = HttpContext.Current.User.Identity.GetUserId(); // get the user's id
            string projectID = Session["projectID"] as string; // get the project id from the session variable
            if (projectID != null & userID != null) // if the project id and user id are not null
            {
                using (SqlConnection conn = new SqlConnection(connString)) // connect to the database
                {
                    conn.Open(); 
                    using (SqlCommand cmd = new SqlCommand("spCreateReport", conn)) // call the stored procedure
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure; 
                        cmd.Parameters.AddWithValue("@ProjectID", projectID); // add the project id as a parameter
                        cmd.Parameters.AddWithValue("@VolunteerID", userID); // add the user id as a parameter
                        cmd.Parameters.Add("@ReportID", SqlDbType.Int); // add the report id as a parameter
                        cmd.Parameters["@ReportID"].Direction = ParameterDirection.Output; 
                        cmd.ExecuteNonQuery(); 
                        Session["ReportID"] = cmd.Parameters["@ReportID"].Value.ToString(); // set the session variable to the report id
                    }
                }
            }
        }

    }
}