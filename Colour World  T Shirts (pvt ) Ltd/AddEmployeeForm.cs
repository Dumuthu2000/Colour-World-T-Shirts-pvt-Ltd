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
    public partial class AddEmployeeForm : Form
    {
        connectionSql connectionManager = new connectionSql();
        
        public AddEmployeeForm()
        {
            InitializeComponent();
        }
        private void addProfileBtn_Click(object sender, EventArgs e)
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
                    cmd.Parameters.AddWithValue("@gender", femaleRadioBtn.Text);
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
                cmd.Parameters.AddWithValue("@jobTitle", jobTitleCombo.SelectedItem.ToString());

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

       
    }
}
