using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Colour_World__T_Shirts__pvt___Ltd
{
    
    public partial class UpdateEmployeeForm : Form
    {
        connectionSql connectionManager = new connectionSql();
        public UpdateEmployeeForm()
        {
            InitializeComponent();
        }

        private void uploadSearchBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = connectionManager.connSql();
            string sql = "SELECT full_name,name_with_initial,address,gender,civil_status,nic,dob,nationality,mobile_no,resident_district,job_title,profile_pic FROM employee WHERE employee_id = @employeeId";
            SqlCommand cmd = new SqlCommand(sql, conn);

            try
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@employeeId", employeeIdTxt.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string full_name = reader["full_name"].ToString();
                    string name_with_initial = reader["name_with_initial"].ToString();
                    string address = reader["address"].ToString();
                    string gender = reader["gender"].ToString();
                    string civil_status = reader["civil_status"].ToString();
                    string nic = reader["nic"].ToString();
                    string dob = reader["dob"].ToString();
                    string nationality = reader["nationality"].ToString();
                    string mobile_no = reader["mobile_no"].ToString();
                    string resident_district = reader["resident_district"].ToString();
                    string job_title = reader["job_title"].ToString();

                    fullNameTxt.Text = full_name;
                    withInitialTxt.Text = name_with_initial;
                    addressTxt.Text = address;
                    if (gender == "Male")
                    {
                        maleRadioBtn.Checked = true;
                    }
                    else if (gender == "Female")
                    {
                        femaleRadioBtn.Checked = true;
                    }
                    civilStatusCombo.SelectedItem = civil_status;
                    nicTxt.Text = nic;
                    dobTxt.Text = dob;
                    nationalityTxt.Text = nationality;
                    mobileTxt.Text = mobile_no;
                    residentDistrictTxt.Text = resident_district;
                    jobTitleCombo.SelectedItem = job_title;
                    if (reader["profile_pic"] != DBNull.Value)
                    {
                        byte[] imageBytes = (byte[])reader["profile_pic"];
                        using (var ms = new System.IO.MemoryStream(imageBytes))
                        {
                            addImageBox.Image = Image.FromStream(ms);
                        }
                    }

                    //Shift next page
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        private void addProfileBtn_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                addImageBox.Image = new Bitmap(openFileDialog.FileName);
            }
        }
        private void uploadEmployeeBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = connectionManager.connSql();
            string sql = "UPDATE employee SET full_name = @fullName,name_with_initial = @initialName,address = @address,gender = @gender,civil_status = @civilStatus,nic = @nic,dob = @dob,nationality = @nationality,mobile_no = @mobileNo,resident_district = @residentDistrict,job_title = @jobTitle,profile_pic = @profilePic WHERE employee_id = @employeeId";
            SqlCommand cmd = new SqlCommand(sql,conn);

            try
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@fullName",fullNameTxt.Text);
                cmd.Parameters.AddWithValue("@initialName", withInitialTxt.Text);
                cmd.Parameters.AddWithValue("@address", addressTxt.Text);
                if (maleRadioBtn.Checked)
                {
                    cmd.Parameters.AddWithValue("@gender", maleRadioBtn.Text);
                }
                else if (femaleRadioBtn.Checked)
                {
                    cmd.Parameters.AddWithValue("@gender", femaleRadioBtn.Text);
                }
                cmd.Parameters.AddWithValue("@civilStatus", civilStatusCombo.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@nic", nicTxt.Text);
                cmd.Parameters.AddWithValue("@dob", dobTxt.Text);
                cmd.Parameters.AddWithValue("@nationality", nationalityTxt.Text);
                cmd.Parameters.AddWithValue("@mobileNo", mobileTxt.Text);
                cmd.Parameters.AddWithValue("@residentDistrict", residentDistrictTxt.Text);
                cmd.Parameters.AddWithValue("@jobTitle", jobTitleCombo.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@employeeId", employeeIdTxt.Text);
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

                int rowsOfAffected = cmd.ExecuteNonQuery();
                if(rowsOfAffected > 0)
                {
                    MessageBox.Show("Update Success!!!!!!!!!!");
                }
                else
                {
                    MessageBox.Show("Update Not Success, Please check!!!!!!!!!!");
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

        private void employeeIdTxt_Click(object sender, EventArgs e)
        {
            this.searchEmployeeNoLbl.Visible = false;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
