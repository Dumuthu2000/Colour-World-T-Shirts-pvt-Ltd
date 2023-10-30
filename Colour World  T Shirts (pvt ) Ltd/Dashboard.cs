using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Colour_World__T_Shirts__pvt___Ltd
{
    public partial class Dashboard : Form
    {
        connectionSql connectionManager = new connectionSql();
        public Dashboard()
        {
            InitializeComponent();

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            SqlConnection conn = connectionManager.connSql();
            string sql = "SELECT COUNT(*) AS nuOfEmployees FROM employee";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                   string nuOfEmployees = reader["nuOfEmployees"].ToString();
                   totalEmployeeLbl.Text = nuOfEmployees;
                    activeEmployeeLbl.Text = nuOfEmployees; 
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
    }
}
