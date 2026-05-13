namespace Driving_License_Issuanse_Project
{
    partial class UpdateApplication
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
            this.ctrEditApplicationType1 = new Driving_License_Issuanse_Project.ctrEditApplicationType();
            this.SuspendLayout();
            // 
            // ctrEditApplicationType1
            // 
            this.ctrEditApplicationType1.BackColor = System.Drawing.Color.White;
            this.ctrEditApplicationType1.Location = new System.Drawing.Point(3, 0);
            this.ctrEditApplicationType1.Name = "ctrEditApplicationType1";
            this.ctrEditApplicationType1.Size = new System.Drawing.Size(521, 321);
            this.ctrEditApplicationType1.TabIndex = 0;
            this.ctrEditApplicationType1.TypeID = 0;
            // 
            // UpdateApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 328);
            this.Controls.Add(this.ctrEditApplicationType1);
            this.Name = "UpdateApplication";
            this.Text = "UpdateApplication";
            this.Load += new System.EventHandler(this.UpdateApplication_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrEditApplicationType ctrEditApplicationType1;
    }
}