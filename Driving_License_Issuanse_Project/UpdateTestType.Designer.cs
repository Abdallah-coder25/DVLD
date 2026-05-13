namespace Driving_License_Issuanse_Project
{
    partial class UpdateTestType
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
            this.ctrTestType1 = new Driving_License_Issuanse_Project.ctrTestType();
            this.SuspendLayout();
            // 
            // ctrTestType1
            // 
            this.ctrTestType1.Location = new System.Drawing.Point(12, 12);
            this.ctrTestType1.Name = "ctrTestType1";
            this.ctrTestType1.Size = new System.Drawing.Size(491, 417);
            this.ctrTestType1.TabIndex = 0;
            this.ctrTestType1.TypeID = 0;
            // 
            // UpdateTestType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 432);
            this.Controls.Add(this.ctrTestType1);
            this.Name = "UpdateTestType";
            this.Text = "UpdateTestType";
            this.Load += new System.EventHandler(this.UpdateTestType_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrTestType ctrTestType1;
    }
}