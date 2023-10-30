namespace Colour_World__T_Shirts__pvt___Ltd
{
    partial class DeleteEmployeeeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.messageLabel = new System.Windows.Forms.Label();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.employeeIdTxt = new System.Windows.Forms.TextBox();
            this.employeeId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(-5, -10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1087, 423);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.messageLabel);
            this.panel2.Controls.Add(this.deleteBtn);
            this.panel2.Controls.Add(this.employeeIdTxt);
            this.panel2.Controls.Add(this.employeeId);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(124, 108);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(847, 181);
            this.panel2.TabIndex = 1;
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.ForeColor = System.Drawing.Color.Red;
            this.messageLabel.Location = new System.Drawing.Point(300, 124);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(317, 16);
            this.messageLabel.TabIndex = 153;
            this.messageLabel.Text = "Please enter you want to delete employee\'s EMP no";
            // 
            // deleteBtn
            // 
            this.deleteBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.deleteBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.deleteBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(56)))));
            this.deleteBtn.FlatAppearance.BorderSize = 0;
            this.deleteBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.deleteBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Magenta;
            this.deleteBtn.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.ForeColor = System.Drawing.Color.White;
            this.deleteBtn.Location = new System.Drawing.Point(587, 81);
            this.deleteBtn.Margin = new System.Windows.Forms.Padding(5, 15, 5, 5);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(100, 40);
            this.deleteBtn.TabIndex = 152;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.deleteBtn.UseVisualStyleBackColor = false;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // employeeIdTxt
            // 
            this.employeeIdTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.employeeIdTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.employeeIdTxt.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.employeeIdTxt.Font = new System.Drawing.Font("Bahnschrift", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeIdTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(56)))));
            this.employeeIdTxt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.employeeIdTxt.Location = new System.Drawing.Point(303, 89);
            this.employeeIdTxt.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.employeeIdTxt.Name = "employeeIdTxt";
            this.employeeIdTxt.Size = new System.Drawing.Size(276, 29);
            this.employeeIdTxt.TabIndex = 126;
            this.employeeIdTxt.Text = "EMP";
            this.employeeIdTxt.Click += new System.EventHandler(this.employeeIdTxt_Click_1);
            // 
            // employeeId
            // 
            this.employeeId.AutoSize = true;
            this.employeeId.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeId.Location = new System.Drawing.Point(139, 89);
            this.employeeId.Name = "employeeId";
            this.employeeId.Size = new System.Drawing.Size(132, 24);
            this.employeeId.TabIndex = 125;
            this.employeeId.Text = "Employee ID: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(270, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee Deletion ";
            // 
            // DeleteEmployeeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 410);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DeleteEmployeeeForm";
            this.Text = "DeleteEmployeeeForm";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox employeeIdTxt;
        private System.Windows.Forms.Label employeeId;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Label messageLabel;
    }
}