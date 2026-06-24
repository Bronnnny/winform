using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 投简历.models
{
    public class Sqlsever
    {
        string Sqlstr = "Data Source=RTX-8090;initial catalog=winfrom; Integrated Security=true";

        public void Sqladd(double temps,string status,DateTime data)
        {
            using (SqlConnection conn=new SqlConnection(Sqlstr))
            {
                conn.Open();

                string sql = "INSERT INTO dbo.Templog(temp,status,times)values(@temp,@status,@times)";
                using (SqlCommand cmd = new SqlCommand(sql, conn)) 
                {
                    cmd.Parameters.AddWithValue("temp",temps);
                    cmd.Parameters.AddWithValue("status",status);
                    cmd.Parameters.AddWithValue("times",data);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
