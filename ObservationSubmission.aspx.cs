using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Printing;
using System.EnterpriseServices;
using Microsoft.AspNet.Identity;

namespace Assignment4
{
    public partial class ObservationSubmission : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ReportID = Session["ReportID"] as string; // this is the reportID that is stored in the session
            if (ReportID != null) // if there is a report id, make the submission visible
            {
                ObservationSubmissionID.Visible = true;
            }
            else
            {
                CreateReport(); // if not, create a report

            }
        }
        protected void ShowObservation() // this is for the observation submission
        {
            if (User.Identity.IsAuthenticated) // if the user is logged in, show the submission 
            {
                ObservationSubmissionID.Visible = true;
            }
            else

            {
                Response.Redirect("Login.aspx"); // if they are not, redirect them to the login page
            }
        }
        private void CreateReport() {
            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ToString();
            string userID = HttpContext.Current.User.Identity.GetUserId(); // this is the userID that is stored in the session
            string projectID = Session["ProjectID"] as string; // this is the projectID that is stored in the session
            if (projectID != null & userID != null) // if there is both a projectID and a userID, create a report
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("spCreateReport", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@VolunteerID", userID); // this is the userID that is stored in the session
                        cmd.Parameters.AddWithValue("@ProjectID", projectID); // this is the projectID that is stored in the session
                        cmd.Parameters.Add("@ReportID", SqlDbType.Int); // 
                        cmd.Parameters["@ReportID"].Direction = ParameterDirection.Output; 
                        cmd.ExecuteNonQuery();
                        Session["ReportID"] = cmd.Parameters["@ReportID"].Value.ToString(); 
                    }
                }
                ObservationSubmissionID.Visible = true;
            }
              
        }
        private void InsertIntoObservation()
        {
         string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ToString();
            string ReportID = Session["ReportID"] as string;
            string Notes = NotesBox.Text; // this is the notes that the user enters
            string Value = ValueBox.Text; // this is the value that the user enters
            //i will add the rest of the parts of observation later, I just wanted to get it working for now
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("spAddObservation", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ReportID", ReportID);
                    cmd.Parameters.Add("@ObservationID", SqlDbType.Int);
                    cmd.Parameters["@ObservationID"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Notes", Notes); // take what the user inputs and add it to the database
                    cmd.Parameters.AddWithValue("@Value", Value); // take what the user inputs and add it to the database
                    cmd.ExecuteNonQuery();
                    ObservationSubmissionID.Visible = true;

                   

                }

            }

        }
        public void Submit_Click(object sender, EventArgs e) // when they click submit, insert the observation into the database
        {
            if (Page.IsValid)
            {
                InsertIntoObservation();
                ObservationSubmissionID.Visible = false;
                 
                Response.Redirect("ReportDetails.aspx?ID=" + Session["ReportID"]); // take them back to the report details page with their report id
            }
        }
    }
}