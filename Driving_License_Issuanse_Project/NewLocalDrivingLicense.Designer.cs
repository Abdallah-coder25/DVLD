namespace Driving_License_Issuanse_Project
{
    partial class NewLocalDrivingLicense
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ctrLocalDrivingLicense1 = new Driving_License_Issuanse_Project.ctrLocalDrivingLicense();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16F);
            this.label1.Location = new System.Drawing.Point(180, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(385, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "New Local Driving License";
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Driving_License_Issuanse_Project.Properties.Resources.cross_64;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(946, 701);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(57, 39);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ctrLocalDrivingLicense1
            // 
            this.ctrLocalDrivingLicense1.BackColor = System.Drawing.Color.White;
            this.ctrLocalDrivingLicense1.Location = new System.Drawing.Point(12, 51);
            this.ctrLocalDrivingLicense1.Name = "ctrLocalDrivingLicense1";
            this.ctrLocalDrivingLicense1.Size = new System.Drawing.Size(727, 630);
            this.ctrLocalDrivingLicense1.TabIndex = 4;
            // 
            // NewLocalDrivingLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(753, 698);
            this.Controls.Add(this.ctrLocalDrivingLicense1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "NewLocalDrivingLicense";
            this.Text = "ManageLocalDrivingLicense";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private ctrLocalDrivingLicense ctrLocalDrivingLicense1;
    }
}