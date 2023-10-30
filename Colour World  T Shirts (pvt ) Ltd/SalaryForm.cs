using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;

namespace Colour_World__T_Shirts__pvt___Ltd
{
    public partial class SalaryForm : Form
    {
        connectionSql connectioManager = new connectionSql();
        //EmplpoyeeDetails employeeDetails = new EmplpoyeeDetails();
        public string empId;
        double amoutPerWorkDay = 0;
        string jobTitle;
        public SalaryForm()
        {
            InitializeComponent();
        }

        private void generateBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = connectioManager.connSql();
            string sql = "SELECT full_name from employee WHERE employee_id = @employeeId";
            SqlCommand cmd = new SqlCommand(sql,conn);

            try
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@employeeId", employeeIdTxt.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string fullName = reader["full_name"].ToString();
                    this.fullNameTxt.Text = fullName;
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
        }

        private void salaryCalBtn_Click(object sender, EventArgs e)
        {
            // Initialize a connection to the database
            using (SqlConnection conn = connectioManager.connSql())
            {
                conn.Open();
                try
                {
                    string employeeId = employeeIdTxt.Text;
                    double epf = Convert.ToDouble(epftxt.Text);
                    double attendanceAllowance = Convert.ToDouble(attendenceAllowanceTxt.Text);
                    double productionAllowance = Convert.ToDouble(productionAllowanceTxt.Text);
                    double advanceAmount = Convert.ToDouble(advanceAmountTxt.Text);
                    int workedDates = Convert.ToInt32(workDatesTxt.Text);
                    double otRate = Convert.ToDouble(rateOtTxt.Text);
                    double otHours = Convert.ToDouble(otHoursTxt.Text);

                    // Get job title from the database
                    string jobTitle = GetJobTitleForEmployee(conn, employeeId);

                    if (jobTitle == "Manager")
                    {
                        amoutPerWorkDay = 1500.00;
                    }
                    else if (jobTitle == "Staff")
                    {
                        amoutPerWorkDay = 1200.00;
                    }
                    else if (jobTitle == "Machine Operator")
                    {
                        amoutPerWorkDay = 1000.00;
                    }
                    else if (jobTitle == "Supervisor")
                    {
                        amoutPerWorkDay = 950.00;
                    }
                    else
                    {
                        MessageBox.Show("Invalid Job title");
                        return; // Exit the method if the job title is invalid
                    }

                    // Salary Calculation
                    double basicSalary = amoutPerWorkDay * workedDates;
                    double otAmount = otRate * otHours;
                    double allowanceAmount = attendanceAllowance + productionAllowance;

                    // Deductions
                    double epfAmount = basicSalary * (epf / 100);
                    double deductionAmount = epfAmount + advanceAmount;

                    // Net Salary
                    double netSalary = (basicSalary + otAmount + allowanceAmount) - (epfAmount + deductionAmount);

                    // Insert data into the 'salary' table
                    InsertSalaryData(conn, employeeId, basicSalary, epf, attendanceAllowance, productionAllowance, advanceAmount, workedDates, otRate, otHours, netSalary);

                    // Retrieve and display payment details
                    DisplayPaymentDetails(conn, employeeId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private string GetJobTitleForEmployee(SqlConnection conn, string employeeId)
        {
            string jobTitle = "";
            string sql = "SELECT job_title FROM employee WHERE employee_id = @employeeId";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@employeeId", employeeId);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    jobTitle = reader["job_title"].ToString();
                }
            }

            return jobTitle;
        }

        private void InsertSalaryData(SqlConnection conn, string employeeId, double basicSalary, double epf, double attendanceAllowance, double productionAllowance, double advanceAmount, int workedDates, double otRate, double otHours, double netSalary)
        {
            string sql = "INSERT INTO salary (employee_id, basic_salary, epf, attendance_allowance, production_allowance, advance_amount, worked_dates, ot_rate, ot_hours, net_salary) VALUES (@empId, @basicSalary, @epf, @attAllowance, @proAllowance, @advance, @workedDates, @otRate, @otHours, @netSalary)";
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@empId", employeeId);
            cmd.Parameters.AddWithValue("@basicSalary", basicSalary);
            cmd.Parameters.AddWithValue("@epf", epf);
            cmd.Parameters.AddWithValue("@attAllowance", attendanceAllowance);
            cmd.Parameters.AddWithValue("@proAllowance", productionAllowance);
            cmd.Parameters.AddWithValue("@advance", advanceAmount);
            cmd.Parameters.AddWithValue("@workedDates", workedDates);
            cmd.Parameters.AddWithValue("@otRate", otRate);
            cmd.Parameters.AddWithValue("@otHours", otHours);
            cmd.Parameters.AddWithValue("@netSalary", netSalary);

            cmd.ExecuteNonQuery();
        }

        private void DisplayPaymentDetails(SqlConnection conn, string employeeId)
        {
            string paymentSql = "SELECT e.employee_id, e.full_name, s.basic_salary, s.worked_dates, s.ot_rate, s.ot_hours, s.attendance_allowance, s.production_allowance, s.advance_amount, s.net_salary, e.profile_pic FROM salary AS s INNER JOIN employee AS e ON s.employee_id = e.employee_id WHERE e.employee_id = @employeesId";
            SqlCommand command = new SqlCommand(paymentSql, conn);
            command.Parameters.AddWithValue("@employeesId", employeeId);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    sheetEmployeeIdTxt.Text = reader["employee_id"].ToString();
                    sheetFullNameTxt.Text = reader["full_name"].ToString();
                    sheetBasicSalaryTxt.Text = reader["basic_salary"].ToString();
                    sheetWorkedDatesTxt.Text = reader["worked_dates"].ToString();
                    sheetOtRateTxt.Text = reader["ot_rate"].ToString();
                    sheetOtHoursTxt.Text = reader["ot_hours"].ToString();
                    sheetAttendanceAllowanceTxt.Text = reader["attendance_allowance"].ToString();
                    sheetProductionAllowanceTxt.Text = reader["production_allowance"].ToString();
                    sheetAdvanceAmountTxt.Text = reader["advance_amount"].ToString();
                    sheetNetSalaryTxt.Text = reader["net_salary"].ToString();
                    if (reader["profile_pic"] != DBNull.Value)
                    {
                        byte[] imageBytes = (byte[])reader["profile_pic"];
                        using (var ms = new System.IO.MemoryStream(imageBytes))
                        {
                            sheetProfileImageBox.Image = Image.FromStream(ms);
                        }
                    }

                    paymentSheetPanel.Visible = true;
                }
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void viewPaymentBtn_Click(object sender, EventArgs e)
        {
            this.paymentSheetPanel.Visible = true;
        }

        private void sheetEmployeeIdTxt_Click(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(242,44);
        }
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void viewBtn_Click_1(object sender, EventArgs e)
        {
            SqlConnection conn = connectioManager.connSql();
            string paymentSql = "SELECT e.full_name, s.basic_salary, s.worked_dates, s.ot_rate, s.ot_hours, s.attendance_allowance, s.production_allowance, s.advance_amount, s.net_salary, e.profile_pic FROM salary AS s INNER JOIN employee AS e ON s.employee_id = e.employee_id WHERE e.employee_id = @employeesId";
            SqlCommand command = new SqlCommand(paymentSql, conn);

            try
            {
                conn.Open();
                command.Parameters.AddWithValue("@employeesId", sheetEmployeeIdTxt.Text);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string FullName = reader["full_name"].ToString();
                    string BasicSalary = reader["basic_salary"].ToString();
                    string WorkedDates = reader["worked_dates"].ToString();
                    string OtRate = reader["ot_rate"].ToString();
                    string OtHours = reader["ot_hours"].ToString();
                    string AttendanceAllowance = reader["attendance_allowance"].ToString();
                    string ProductionAllowance = reader["production_allowance"].ToString();
                    string AdvanceAmount = reader["advance_amount"].ToString();
                    string NetSalary = reader["net_salary"].ToString();

                    this.sheetFullNameTxt.Text = FullName;
                    this.sheetBasicSalaryTxt.Text = BasicSalary;
                    this.sheetWorkedDatesTxt.Text = WorkedDates;
                    this.sheetOtRateTxt.Text = OtRate;
                    this.sheetOtHoursTxt.Text = OtHours;
                    this.sheetAttendanceAllowanceTxt.Text = AttendanceAllowance;
                    this.sheetProductionAllowanceTxt.Text = ProductionAllowance;
                    this.sheetAdvanceAmountTxt.Text = AdvanceAmount;
                    this.sheetNetSalaryTxt.Text = NetSalary;
                    if (reader["profile_pic"] != DBNull.Value)
                    {
                        byte[] imageBytes = (byte[])reader["profile_pic"];
                        using (var ms = new System.IO.MemoryStream(imageBytes))
                        {
                            sheetProfileImageBox.Image = Image.FromStream(ms);
                        }
                    }
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
        }

        private void printReportBtn_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm();
            reportForm.Show();
            MainForm mainForm = new MainForm();
            mainForm.Hide();



        }

    }

}
