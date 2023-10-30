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

namespace Colour_World__T_Shirts__pvt___Ltd
{
    public partial class DeleteEmployeeeForm : Form
    {
        connectionSql connectionManager = new connectionSql();
        public DeleteEmployeeeForm()
        {
            InitializeComponent();
        }

        private void employeeIdTxt_Click_1(object sender, EventArgs e)
        {
            this.messageLabel.Visible = false;
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = connectionManager.connSql();
            string sql = "DELETE FROM employee WHERE employee_id = @employeeId";
            SqlCommand cmd = new SqlCommand(sql, conn);

            try
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@employeeId", employeeIdTxt.Text);

                int rowsOfAffected = cmd.ExecuteNonQuery();
                if (rowsOfAffected > 0)
                {
                    MessageBox.Show("Delete Employee Successfully!!!!!!!!!!");
                }
                else
                {
                    MessageBox.Show("Deleted Not Success, Please check!!!!!!!!!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
