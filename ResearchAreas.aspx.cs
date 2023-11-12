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
    public partial class ResearchAreas : System.Web.UI.Page
    {
        public DataTable GetDataFromDatabase(string instID)
        {
            DataTable dt = new DataTable();

            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ToString();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "EXEC spGetAllResearchAreas @InstID";
                if (!string.IsNullOrEmpty(instID))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@InstID", instID);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }

                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("EXEC spSelectAllResearchAreas", conn))
                    {
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
                string InstitutionID = Request.QueryString["InstID"];
                if (!string.IsNullOrEmpty(InstitutionID))
                {
                    ResearchArea.DataSource = GetDataFromDatabase(InstitutionID);
                }
                else
                {
                    ResearchArea.DataSource = GetDataFromDatabase(null);
                }
                ResearchArea.DataBind();
            }
        }
    }
}