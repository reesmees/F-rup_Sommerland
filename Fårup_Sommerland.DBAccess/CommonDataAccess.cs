using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fårup_Sommerland.DBAccess
{
    public abstract class CommonDataAccess
    {
        private string conString;

        protected CommonDataAccess(string conString)
        {
            ConString = conString;
        }

        public string ConString
        {
            get { return conString; }
            set { conString = value; }
        }

        public bool ExecuteNonQuery(string query)
        {
            bool success = true;
            using (SqlConnection con = new SqlConnection(conString))
            using (SqlCommand com = new SqlCommand(query, con))
            {
                con.Open();
                com.ExecuteNonQuery();
            }
            return success;
        }

        public DataSet ExecuteQuery(string query)
        {
            DataSet data = new DataSet();
            using (SqlConnection con = new SqlConnection(conString))
            using (SqlCommand com = new SqlCommand(query, con))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(com);
                adapter.Fill(data);
            }
            return data;
        }
    }
}
