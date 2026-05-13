namespace Driving_License_Issuanse_Project
{
    partial class IssuingALicnese
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrApplicationDetails1
            // 
            this.ctrApplicationDetails1.BackColor = System.Drawing.Color.White;
            this.ctrApplicationDetails1.DetailsID = 0;
            this.ctrApplicationDetails1.Location = new System.Drawing.Point(2, 1);
            this.ctrApplicationDetails1.Name = "ctrApplicationDetails1";
            this.ctrApplicationDetails1.Size = new System.Drawing.Size(605, 413);
            this.ctrApplicationDetails1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(77, 438);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(530, 161);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 441);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Note";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAdd.Location = new System.Drawing.Point(511, 605);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(96, 39);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Issue";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.Location = new System.Drawing.Point(394, 605);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 39);
            this.button2.TabIndex = 4;
            this.button2.Text = "close";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // IssuingALicnese
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(617, 650);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ctrApplicationDetails1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "IssuingALicnese";
            this.Text = "IssuingALicnese";
            this.Load += new System.EventHandler(this.IssuingALicnese_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrApplicationDetails ctrApplicationDetails1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button button2;
    }
}