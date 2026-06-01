namespace Driving_License_Issuanse_Project
{
    partial class ShowDetailsApplication
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
            this.ctrApplicationDetails1 = new Driving_License_Issuanse_Project.ctrApplicationDetails();
            this.SuspendLayout();
            // 
            // ctrApplicationDetails1
            // 
            this.ctrApplicationDetails1.BackColor = System.Drawing.Color.White;
            this.ctrApplicationDetails1.DetailsID = 0;
            this.ctrApplicationDetails1.Location = new System.Drawing.Point(1, 2);
            this.ctrApplicationDetails1.Name = "ctrApplicationDetails1";
            this.ctrApplicationDetails1.Size = new System.Drawing.Size(605, 413);
            this.ctrApplicationDetails1.TabIndex = 0;
            // 
            // ShowDetailsApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 433);
            this.Controls.Add(this.ctrApplicationDetails1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ShowDetailsApplication";
            this.Text = "ShowDetailsApplication";
            this.Load += new System.EventHandler(this.ShowDetailsApplication_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrApplicationDetails ctrApplicationDetails1;
    }
}