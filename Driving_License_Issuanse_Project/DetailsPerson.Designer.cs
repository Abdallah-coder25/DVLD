namespace Driving_License_Issuanse_Project
{
    partial class DetailsPerson
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
            this.ctrPersonDetials1 = new Driving_License_Issuanse_Project.ctrPersonDetials();
            this.SuspendLayout();
            // 
            // ctrPersonDetials1
            // 
            this.ctrPersonDetials1.BackColor = System.Drawing.Color.White;
            this.ctrPersonDetials1.DetailID = 0;
            this.ctrPersonDetials1.Location = new System.Drawing.Point(0, 3);
            this.ctrPersonDetials1.Name = "ctrPersonDetials1";
            this.ctrPersonDetials1.Size = new System.Drawing.Size(678, 374);
            this.ctrPersonDetials1.TabIndex = 0;
            // 
            // DetailsPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 376);
            this.Controls.Add(this.ctrPersonDetials1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "DetailsPerson";
            this.Text = "DetailsPerson";
            this.Load += new System.EventHandler(this.DetailsPerson_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrPersonDetials ctrPersonDetials1;
    }
}