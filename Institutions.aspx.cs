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
    public partial class Institutions : System.Web.UI.Page
    {
        public DataTable GetDataFromDatabase()
        {
            DataTable dt = new DataTable();
           
            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ConnectionString;
           
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "EXEC spGetAllInstitutions";
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
            if (!IsPostBack)
            {

                Institution.DataSource = GetDataFromDatabase();
                Institution.DataBind();
            }
        }
        
    }
}