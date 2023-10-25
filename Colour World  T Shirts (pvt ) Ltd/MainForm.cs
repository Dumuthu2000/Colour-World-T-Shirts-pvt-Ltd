using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Colour_World__T_Shirts__pvt___Ltd
{
    public partial class MainForm : Form
    {
        Dashboard dashboard = new Dashboard();
        EmployeeForm employeeForm = new EmployeeForm();
        SalaryForm salaryForm = new SalaryForm();
        LoginForm loginForm = new LoginForm();
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            dashboard = new Dashboard();
            dashboard.TopLevel = false;
            dashboard.FormBorderStyle = FormBorderStyle.None;
            dashboard.Dock = DockStyle.Fill;
            formPanel.Controls.Add(dashboard);
            dashboard.Show();
        }
        private void closeBtn_Click(object sender, EventArgs e)
        {
            loginForm.Show();
            this.Close();
        }

        private void dashboardBtm_Click(object sender, EventArgs e)
        {
            dashboard = new Dashboard();
            dashboard.TopLevel = false;
            dashboard.FormBorderStyle = FormBorderStyle.None;
            dashboard.Dock = DockStyle.Fill;
            formPanel.Controls.Add(dashboard);
            dashboard.Show();
            salaryForm.Hide();
            employeeForm.Hide();

        }

        private void employeesBtn_Click(object sender, EventArgs e)
        {
            employeeForm = new EmployeeForm();
            employeeForm.TopLevel = false;
            employeeForm.FormBorderStyle = FormBorderStyle.None;
            employeeForm.Dock = DockStyle.Fill;
            formPanel.Controls.Add(employeeForm);
            employeeForm.Show();
            dashboard.Hide();
            salaryForm.Hide();
        }

        private void salaryBtn_Click(object sender, EventArgs e)
        {
            salaryForm = new SalaryForm();
            salaryForm.TopLevel = false;
            salaryForm.FormBorderStyle = FormBorderStyle.None;
            salaryForm.Dock = DockStyle.Fill;
            formPanel.Controls.Add(salaryForm);
            salaryForm.Show();
            dashboard.Hide();
            employeeForm.Hide();
        }

        private void signOutBtn_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }
    }
}
