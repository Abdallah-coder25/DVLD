namespace Driving_License_Issuanse_Project
{
    partial class SetADateVisionTest
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
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrScheduleTest1 = new Driving_License_Issuanse_Project.ctrScheduleTest();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnClose.Location = new System.Drawing.Point(219, 652);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 52);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrScheduleTest1
            // 
            this.ctrScheduleTest1.BackColor = System.Drawing.Color.White;
            this.ctrScheduleTest1.Location = new System.Drawing.Point(12, 2);
            this.ctrScheduleTest1.Name = "ctrScheduleTest1";
            this.ctrScheduleTest1.Size = new System.Drawing.Size(554, 644);
            this.ctrScheduleTest1.TabIndex = 1;
            // 
            // SetADateVisionTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 709);
            this.Controls.Add(this.ctrScheduleTest1);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SetADateVisionTest";
            this.Text = "SetADateVisionTest";
            this.Load += new System.EventHandler(this.SetADateVisionTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private ctrScheduleTest ctrScheduleTest1;
    }
}