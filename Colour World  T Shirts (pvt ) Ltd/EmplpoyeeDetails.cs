using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;

namespace Colour_World__T_Shirts__pvt___Ltd
{
    internal class EmplpoyeeDetails
    {
        connectionSql connectioManager = new connectionSql();
        public string jobTitle;

        public string getJobTitleForEmployee(string employee_id)
        {   
            
            SqlConnection conn = connectioManager.connSql();
            string sql = "SELECT job_title FROM employee WHERE employee_id = @employeeId";
            SqlCommand cmd = new SqlCommand(sql,conn);

            try
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@employeeId",employee_id);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    jobTitle = reader["job_title"].ToString();  
                }           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                
            }
            return jobTitle;
        }
    }
}
