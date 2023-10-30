using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;

namespace Colour_World__T_Shirts__pvt___Ltd
{
    internal class PaymentDetails
    {
        PaymentComponent paymentManager = new PaymentComponent();
        connectionSql connectionManager = new connectionSql();
        public PaymentComponent getPaymentDetailsForEmployee(string employeeId)
        {
            SqlConnection conn = connectionManager.connSql();
            string sql = "SELECT e.employee_id, e.full_name, e.profile_pic, s.basic_salary, s.worked_dates, s.ot_rate, s.ot_hours, s.attendance_allowance, s.production_allowance, s.advance_amount, s.net_salary, e.profile_pic FROM salary AS s INNER JOIN employee AS e ON s.employee_id = e.employee_id WHERE s.employee_id = @employeeId";
            SqlCommand cmd = new SqlCommand(sql,conn);

            try
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@employeeId",employeeId);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    paymentManager.EmployeeId = reader["e.employee_id"].ToString();
                    paymentManager.FullName = reader["e.full_name"].ToString();
                    paymentManager.ProfilePic = reader["e.profile_pic"].ToString();
                    paymentManager.BasicSalary = reader[" s.basic_salary"].ToString();
                    paymentManager.WorkedDates = reader["s.worked_dates"].ToString();
                    paymentManager.OtRate = reader["s.ot_rate"].ToString();
                    paymentManager.OtHours = reader["s.ot_hours"].ToString();
                    paymentManager.AttendanceAllowance = reader["s.attendance_allowance"].ToString();
                    paymentManager.ProductionAllowance = reader["s.production_allowance"].ToString();
                    paymentManager.AdvanceAmount = reader["s.advance_amount"].ToString();
                    paymentManager.NetSalary = reader["s.net_salary"].ToString();

                    //string EmployeeId = reader["s.employee_id"].ToString();
                    //string FullName = reader["e.full_name"].ToString();
                    //string BasicSalary = reader[" s.basic_salary"].ToString();
                    //string WorkedDates = reader["s.worked_dates"].ToString();
                    //string OtRate = reader["s.ot_rate"].ToString();
                    //string OtHours = reader["s.ot_hours"].ToString();
                    //string AttendanceAllowance = reader["s.attendance_allowance"].ToString();
                    //string ProductionAllowance = reader["s.production_allowance"].ToString();
                    //string AdvanceAmount = reader["s.advance_amount"].ToString();
                    //string NetSalary = reader["s.net_salary"].ToString();

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
            return paymentManager;
        }
    }
}
