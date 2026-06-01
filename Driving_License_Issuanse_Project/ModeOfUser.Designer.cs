namespace Driving_License_Issuanse_Project
{
    partial class ModeOfUser
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
            this.ctrUser1 = new Driving_License_Issuanse_Project.ctrUser();
            this.SuspendLayout();
            // 
            // ctrUser1
            // 
            this.ctrUser1.BackColor = System.Drawing.Color.White;
            this.ctrUser1.Location = new System.Drawing.Point(11, -2);
            this.ctrUser1.Name = "ctrUser1";
            this.ctrUser1.Size = new System.Drawing.Size(725, 647);
            this.ctrUser1.TabIndex = 0;
            this.ctrUser1.UserID = -1;
            // 
            // ModeOfUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 657);
            this.Controls.Add(this.ctrUser1);
            this.Name = "ModeOfUser";
            this.Text = "ModeOfUser";
            this.Load += new System.EventHandler(this.ModeOfUser_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrUser ctrUser1;
    }
}