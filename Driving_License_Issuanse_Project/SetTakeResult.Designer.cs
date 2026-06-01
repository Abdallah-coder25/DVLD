namespace Driving_License_Issuanse_Project
{
    partial class SetTakeResult
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
            this.ctrConductTheTest1 = new Driving_License_Issuanse_Project.ctrConductTheTest();
            this.SuspendLayout();
            // 
            // ctrConductTheTest1
            // 
            this.ctrConductTheTest1.Location = new System.Drawing.Point(-1, 6);
            this.ctrConductTheTest1.Name = "ctrConductTheTest1";
            this.ctrConductTheTest1.Size = new System.Drawing.Size(466, 651);
            this.ctrConductTheTest1.TabIndex = 0;
            // 
            // SetTakeResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 669);
            this.Controls.Add(this.ctrConductTheTest1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "SetTakeResult";
            this.Text = "SetTakeResult";
            this.Load += new System.EventHandler(this.SetTakeResult_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrConductTheTest ctrConductTheTest1;
    }
}