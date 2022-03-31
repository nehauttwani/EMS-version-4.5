using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EMS
{
    public class SqlConnectionMethod
    {

        public List<object> Command(string StoredProcedure)
        {
            List<object> list = new List<object>();
            string strConn = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(strConn);
            SqlCommand sqlCommand = new SqlCommand
            {


                // Settings.  
                CommandText = StoredProcedure,
                CommandType = CommandType.StoredProcedure,
                Connection = sqlConnection,
                CommandTimeout = 108 //// Setting timeeout for longer queries to 12 hours.  
            };
            list.Add(sqlCommand);
            list.Add(sqlConnection);
            return list;
        }
    }
}
