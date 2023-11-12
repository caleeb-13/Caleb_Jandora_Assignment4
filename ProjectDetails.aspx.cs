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

namespace Assignment4
{
    public partial class ProjectDetails : System.Web.UI.Page
    {
        public DataTable GetDataFromDatabase()
        {
            DataTable dt = new DataTable();

            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "EXEC spGetProjectDetails";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }

            }
            return dt;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string projectID = Request.QueryString["ID"];
            if (string.IsNullOrEmpty(projectID))
            {
                Response.Redirect("default.aspx");
            }
            else
            {
                LoadProjectDetails(projectID);
            }
            
        }
        private void LoadProjectDetails(string projectID)
        {
            string connStr = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ToString();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "EXEC spGetSpecificProject @ProjectID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProjectID", projectID);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.Read())
                {
                    lblName.Text = reader["ProjectName"].ToString();
                    lblDescription.Text = reader["Description"].ToString();
                    lblProjectID.Text = reader["ProjectID"].ToString();
                    lblStartDate.Text = reader["StartDate"].ToString();
                    lblEndDate.Text = reader["EndDate"].ToString();
                    lblCoordinator.Text = reader["Coordinator"].ToString();
                    lblResearchID.Text = reader["ResearchID"].ToString();
                    lblObsCount.Text = reader["ObsCount"].ToString();


                }
                reader.Close();
            }
        }
    }
}