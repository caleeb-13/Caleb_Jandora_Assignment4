using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4
{
    public partial class Projects : System.Web.UI.Page
    {


        public DataTable GetDataFromDatabase(string RA)
        {
            DataTable dt = new DataTable();

            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ToString();
            if (!string.IsNullOrEmpty(RA))
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = "EXEC spGetProjects @ResearchID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ResearchID", RA);
                        cmd.ExecuteNonQuery();

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }

                }
            }

            return dt;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string ResearchID = Request.QueryString["ResearchID"];
                if (string.IsNullOrEmpty(ResearchID))
                {
                    Response.Redirect("ResearchAreas.aspx");

                }

                else
                {
                    ProjectPage.DataSource = GetDataFromDatabase(ResearchID);
                    ProjectPage.DataBind();
                }
            }
        
         }
              
            
    }
}