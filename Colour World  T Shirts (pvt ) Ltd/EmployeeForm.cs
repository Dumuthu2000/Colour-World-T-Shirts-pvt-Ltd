using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Colour_World__T_Shirts__pvt___Ltd
{

    public partial class EmployeeForm : Form
    {
        AddEmployeeForm addEmployeeForm = new AddEmployeeForm();
        UpdateEmployeeForm updatEmployeeForm = new UpdateEmployeeForm();
        DeleteEmployeeeForm deleteEmployeeeForm = new DeleteEmployeeeForm();
        connectionSql connectionManager = new connectionSql();
        public EmployeeForm()
        {
            InitializeComponent();
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            SqlConnection conn = connectionManager.connSql();
            string sql = "SELECT employee_id,full_name,name_with_initial,address,gender,civil_status,nic,dob,nationality,mobile_no,resident_district,job_title FROM employee";
            SqlCommand cmd = new SqlCommand(sql, conn);

            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);

                this.employeeDataGridView.DataSource = dataSet.Tables[0];
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

        private void searchEmployeeBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = connectionManager.connSql();
            string sql = "SELECT * FROM employee WHERE employee_id LIKE @employeeId OR full_name LIKE @employeeName";
            SqlCommand cmd = new SqlCommand(sql,conn);

            try
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@employeeId", "%" + employeeSearchTxt.Text + "%");
                cmd.Parameters.AddWithValue("@employeeName","%"+employeeSearchTxt.Text+"%");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                
                employeeDataGridView.DataSource = dataSet.Tables[0];
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally 
            { 
                conn.Close(); 
            }
        }

        private void addEmployeeBtn_Click(object sender, EventArgs e)
        {
             addEmployeeForm = new AddEmployeeForm();
             addEmployeeForm.TopLevel = false;
             addEmployeeForm.FormBorderStyle = FormBorderStyle.None;
             addEmployeeForm.Dock = DockStyle.Fill;
             windowPanel.Controls.Add(addEmployeeForm);
             addEmployeeForm.Show();
             this.employeeDataGridView.Hide();
             this.panel9.Hide();
             this.panel8.Hide();



        }

        private void updateEmployeeBtn_Click(object sender, EventArgs e)
        {
            updatEmployeeForm = new UpdateEmployeeForm();
            updatEmployeeForm.TopLevel = false;
            updatEmployeeForm.FormBorderStyle = FormBorderStyle.None;
            updatEmployeeForm.Dock = DockStyle.Fill;
            windowPanel.Controls.Add(updatEmployeeForm);
            updatEmployeeForm.Show();
            this.employeeDataGridView.Hide();
            this.panel9.Hide();
            this.panel8.Hide();
        }

        private void deleteEmployeeBtn_Click(object sender, EventArgs e)
        {
            deleteEmployeeeForm = new DeleteEmployeeeForm();
            deleteEmployeeeForm.TopLevel = false;
            deleteEmployeeeForm.FormBorderStyle = FormBorderStyle.None;
            deleteEmployeeeForm.Dock = DockStyle.Fill;
            windowPanel.Controls.Add(deleteEmployeeeForm);
            deleteEmployeeeForm.Show();
            this.employeeDataGridView.Hide();
            this.panel9.Hide();
            this.panel8.Hide();
        }
        
    }
}
