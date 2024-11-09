using Microsoft.Data.SqlClient;
using System.Data;

namespace SKbooks.Data
{
    public class DBhelper
    {
        SqlConnection con = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=Thebook;Trusted_connection=True;TrustServerCertificate=true;");
        SqlCommand cmd ;
        SqlDataAdapter adp;
        string sql;

        public int Exexecutenonquery(string query)
        {
            int val=0;
            try
            {
                cmd=new SqlCommand(query,con);
                con.Open();
                val=cmd.ExecuteNonQuery();
                con.Close();
              
            }
            catch (Exception ex)
            {
                
                
            }
            return val;
        }

        public DataSet ExecuteDataSet(string query)
        {
            SqlConnection con = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=Thebook;Trusted_connection=True;TrustServerCertificate=true;");

            DataSet ds = new DataSet();
            try
            {
                adp = new SqlDataAdapter(query, con);
                adp.Fill(ds);
            }
            catch (Exception ex) 
            { 

            }

            return ds;

        }


        public int Exexecutenonquery(string query,SqlParameter[] parameters_value)
        {
            SqlConnection con = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=Thebook;Trusted_connection=True;TrustServerCertificate=true;");

            SqlCommand command = new SqlCommand(query, con);
            int retVal = -1;
            try
            {
                if ((query.StartsWith("INSERT") | query.StartsWith("insert") | query.StartsWith("UPDATE") | query.StartsWith("update") | query.StartsWith("DELETE") | query.StartsWith("delete")))
                    command.CommandType = CommandType.Text;
                else
                    command.CommandType = CommandType.StoredProcedure;
                int i;
                for (i = 0; i <= parameters_value.Length - 1; i++)
                    command.Parameters.Add(parameters_value[i]);
                con.Open();
                retVal = command.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
            }

            finally
            {
                if ((con.State == ConnectionState.Open))
                    con.Close();
                command.Dispose();
                con.Dispose();
            }
            return retVal;




        }


    }
}
