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

namespace Colour_World__T_Shirts__pvt___Ltd
{
    public partial class LoginForm : Form
    {
        connectionSql connectionManager = new connectionSql();
        public LoginForm()
        {
            InitializeComponent();
            passwordTxt.PasswordChar = '*';
        }

        private void loginBtn_Click_1(object sender, EventArgs e)
        {
            string userName = usernameTxt.Text;
            string password = passwordTxt.Text;

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return; // Stop further execution
            }

            SqlConnection conn = connectionManager.connSql();
            string sql = "SELECT username,password FROM user_tbl";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string enteredUsername = reader["username"].ToString();
                    string enteredPassword = reader["password"].ToString();

                    if (enteredUsername == userName && enteredPassword == password)
                    {
                        MainForm mainForm = new MainForm();
                        mainForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect username or password.try again!!!!!");
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

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
