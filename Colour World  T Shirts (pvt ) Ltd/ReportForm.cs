using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

namespace Colour_World__T_Shirts__pvt___Ltd
{
    public partial class ReportForm : Form
    {
        ReportDocument crypt = new ReportDocument();
        connectionSql connectionManager = new connectionSql();
        public ReportForm()
        {
            InitializeComponent();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            SqlConnection conn = connectionManager.connSql();
            string sql = "SELECT * FROM salary";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "salary");

            SalaryCrystalReport salaryReport = new SalaryCrystalReport();
            salaryReport.SetDataSource(dataset);
            crystalReportViewer3.ReportSource = salaryReport;
        }
    }
}
