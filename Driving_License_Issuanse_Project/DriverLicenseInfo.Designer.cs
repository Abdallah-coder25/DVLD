namespace Driving_License_Issuanse_Project
{
    partial class DriverLicenseInfo
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
            this.ctrDriverLicenseInfo1 = new Driving_License_Issuanse_Project.ctrDriverLicenseInfo();
            this.SuspendLayout();
            // 
            // ctrDriverLicenseInfo1
            // 
            this.ctrDriverLicenseInfo1.Location = new System.Drawing.Point(2, 2);
            this.ctrDriverLicenseInfo1.Name = "ctrDriverLicenseInfo1";
            this.ctrDriverLicenseInfo1.Size = new System.Drawing.Size(789, 613);
            this.ctrDriverLicenseInfo1.TabIndex = 0;
            // 
            // DriverLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 626);
            this.Controls.Add(this.ctrDriverLicenseInfo1);
            this.Name = "DriverLicenseInfo";
            this.Text = "DriverLicenseInfo";
            this.Load += new System.EventHandler(this.DriverLicenseInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrDriverLicenseInfo ctrDriverLicenseInfo1;
    }
}