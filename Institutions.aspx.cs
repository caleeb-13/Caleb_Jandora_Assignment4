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
           //connect to CitizenScienceDB
            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ConnectionString;
           //below, create the string that will contain the info from executing my getallinstitutions stored procedure
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "EXEC spGetAllInstitutions";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                   
                    //then, fill my datatable with the info from the stored procedure
                    
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
                //load the page with the data from the database
                Institution.DataSource = GetDataFromDatabase();
                Institution.DataBind();
            }
        }
        
    }
}