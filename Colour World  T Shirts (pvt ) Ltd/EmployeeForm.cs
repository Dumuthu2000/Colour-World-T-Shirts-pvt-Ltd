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
using System.IO;

namespace Colour_World__T_Shirts__pvt___Ltd
{

    public partial class EmployeeForm : Form
    {
        string connectionString = "Data Source=DESKTOP-BCB35Q8\\SQLEXPRESS;Initial Catalog=colourWorldTshirts;Integrated Security=True";

        public EmployeeForm()
        {
            InitializeComponent();
        }

        private void addProfileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                addImageBox.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionString);
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
            SqlConnection conn = new SqlConnection(connectionString);
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
            SqlConnection conn = new SqlConnection(connectionString);
            string sql = "INSERT INTO employee VALUES (@employeeId,@fullName,@initialName,@address,@gender,@civilStatus,@nic,@dob,@nationality,@mobileNo,@residenceDistrict,@jobTitle,@profilePic)";
            SqlCommand cmd = new SqlCommand(sql, conn);

            try
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@employeeId", employeeIdTxt.Text);
                cmd.Parameters.AddWithValue("@fullName", fullNameTxt.Text);
                cmd.Parameters.AddWithValue("@initialName", withInitialTxt.Text);
                cmd.Parameters.AddWithValue("@address", addressTxt.Text);
                if (maleRadioBtn.Checked)
                {
                    cmd.Parameters.AddWithValue("@gender", maleRadioBtn.Text);
                }
                else if (femaleRadioBtn.Checked)
                {
                    cmd.Parameters.AddWithValue("@gender",femaleRadioBtn.Text);
                }
                else
                {
                    MessageBox.Show("Radio buttons error");
                }
                cmd.Parameters.AddWithValue("@civilStatus", civilStatusCombo.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@nic", nicTxt.Text);
                cmd.Parameters.AddWithValue("@dob", dobTxt.Value);
                cmd.Parameters.AddWithValue("@nationality", nationalityTxt.Text);
                cmd.Parameters.AddWithValue("@mobileNo", mobileTxt.Text);
                cmd.Parameters.AddWithValue("@residenceDistrict", residentDistrictTxt.Text);
                cmd.Parameters.AddWithValue("@civilStatus", jobTitleCombo.SelectedItem.ToString());

                byte[] imageBytes = null;

                // Check if there is an image in the addImageBox control
                Image image = addImageBox.Image;
                if (image != null)
                {
                    using (MemoryStream stream = new MemoryStream())
                    {
                        image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg); // You can change the format as needed
                        imageBytes = stream.ToArray();
                    }
                }
                // Now, add the image byte array to your SQL parameter
                cmd.Parameters.Add("@profilePic", SqlDbType.VarBinary, -1).Value = imageBytes;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Employee added successfully");
           
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

        private void deleteEmployeeBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string sql = "DELETE FROM employee WHERE employee_id = @employeeId";
            SqlCommand cmd = new SqlCommand(sql,conn);

            try
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@employeeId", employeeIdTxt.Text);

                int affectedRow = cmd.ExecuteNonQuery();
                if (affectedRow > 0)
                {
                    MessageBox.Show("Employee Deleted Suceess");
                }
                else
                {
                    MessageBox.Show("Employee not deleted, please check!!!!!!");
                }
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

        private void editEmployeeBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string sql = "SELECT full_name FROM employee WHERE employee_id = @employeeId";
            SqlCommand cmd = new SqlCommand(sql, conn);

            try
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@employeeId", employeeIdTxt.Text);
                string fullName = (string)cmd.ExecuteScalar();
                this.fullNameTxt.Text = fullName;

                this.editEmployeeBtn.Text = "Upload";
                this.editEmployeeBtn.BackColor = Color.Red;
                this.editEmployeeBtn.Name = "uploadBtn";
                this.editEmployeeBtn.Click += uploadBtn_Click;

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

        private void uploadBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string sql = "UPDATE employee SET full_name = @fullName WHERE employee_id = @employeeId";
            SqlCommand cmd = new SqlCommand(sql,conn);

            try
            {
                conn.Open();               
                cmd.Parameters.AddWithValue("@fullName", fullNameTxt.Text);
                cmd.Parameters.AddWithValue("@employeeId", employeeIdTxt.Text);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Update succcessfull");
                }
                else
                {
                    MessageBox.Show("Update Unsucccessfull");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close() ;
            }
        }
    }
}
